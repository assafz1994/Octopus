using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using OctopusCore.Common;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    public class CassandraDbHandler : IDbHandler
    {
        private readonly CassandraConfigurationProvider _configurationProvider;
        public CassandraDbHandler(CassandraConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters, string entityType)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(_configurationProvider.ConnectionString)
                .Build();
            var fieldsToSelectWithGuid = fieldsToSelect.ToList().Append(StringConstants.Guid).ToList();
            var fields = string.Join(",", fieldsToSelectWithGuid);
            // var table = _configurationProvider.GetTableName(entityType, filters);
            var conditions = ConvertFiltersToWhereStatement(filters);
            var session = cluster.Connect(_configurationProvider.KeySpace);
            var query = _configurationProvider.AssembleSelectQuery(entityType, fields, filters, conditions);
            var rs = session.Execute(query);
            var result = ExecuteCommand(fieldsToSelect, rs);
            return Task.FromResult(new ExecutionResult(entityType, result));
        }

        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(_configurationProvider.ConnectionString)
                .Build();
            var session = cluster.Connect(_configurationProvider.KeySpace);
            var tables = _configurationProvider.GetTableNames(entityType);
            var queries = AssembleInsertQueries(tables, fields);
            foreach (var query in queries)
            {
                session.Execute(query);
            }
            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        public Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(_configurationProvider.ConnectionString)
                .Build();
            var session = cluster.Connect(_configurationProvider.KeySpace);
            var tableNamesToTables = _configurationProvider.TableNamesToTables(entityType);
            var tableNames = _configurationProvider.GetTableNames(entityType);
            var mainTable = tableNames.First();
            var tables = _configurationProvider.GetTables(entityType);
            var byFields = GetByFields(tables);
            byFields.Add(StringConstants.Guid);
            var guidList = $"({string.Join(",", guidCollection)})";
            var selectQuery = $"SELECT {string.Join(",", byFields)} FROM {mainTable} WHERE GUID IN {guidList}";
            var rs = session.Execute(selectQuery);
            var entities = new List<Dictionary<string, dynamic>>();
            
            foreach (var row in rs)
            {
                var fieldToValueMap = byFields.ToDictionary(field => field, field => row.GetValue(typeof(object), field));
                entities.Add(fieldToValueMap);
            }

            foreach (var tableElement in tableNamesToTables)
            foreach (var entity in entities)
            {
                var deleteQuery = $"DELETE FROM {tableElement.Key} WHERE guid={entity[StringConstants.Guid]}";
                foreach (var field in tableElement.Value)
                {
                    deleteQuery += $" AND {field}={FieldToString(entity[field])}";
                }
                session.Execute(deleteQuery);
            }
            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        private string FieldToString(object o)
        {
            if (o is string s) return $"'{s}'";
            return $"{o}";
        }
        private List<string> GetByFields(List<List<string>> tables)
        {
            var set = new HashSet<string>();
            
            foreach (var table in tables)
            foreach (var field in table)
            {
                set.Add(field);
            }

            return set.ToList();
        }

        private List<string> AssembleInsertQueries(List<string> tables, IReadOnlyDictionary<string, dynamic> fields)
        {
            var queries = new List<string>();
            var fieldsList = fields.ToList();
            
            foreach (var table in tables)
            {
                var query = $"INSERT INTO {table} " +
                            $"({string.Join(",", fieldsList.Select(x => x.Key))}) " +
                            $"values " +
                            $"({string.Join(",", fieldsList.Select(x => ValueToString(x.Value)))});";
                queries.Add(query);
            }
            return queries;
        }

        private static string ValueToString(object argValue)
        {
            switch (argValue)
            {
                case string s:
                    return GetExpression(s);
                case int _:
                    return $"{argValue}";
                case Guid _:
                    return $"{argValue}";
                default:
                    return null;
            }
        }

        private string ConvertFiltersToWhereStatement(IReadOnlyCollection<Filter> filters)
        {
            if (filters.Count == 0) return "";

            var filtersAsString = new List<string>();
            foreach (var filter in filters)
            {
                if (filter.FieldNames.Count > 1) throw new ArgumentException("Fields with Include are not supported");

                var filterAsString = new StringBuilder().Append(filter.FieldNames[0]).Append(GetFilterOperator(filter))
                    .Append(GetExpression(filter.Expression)).ToString();
                filtersAsString.Add(filterAsString);
            }

            var conditions = string.Join(" and ", filtersAsString);
            return $"WHERE {conditions}";
        }

        private static string GetExpression(string expression)
        {
            if (!expression.StartsWith("\"") || !expression.EndsWith("\"")) return expression;
            var res = expression.Trim('"');
            return $"'{res}'";
        }

        private static string GetFilterOperator(Filter filter)
        {
            if (filter is EqFilter) return "=";

            throw new ArgumentException("Filter type is not supported");
        }

        private static Dictionary<string, EntityResult> ExecuteCommand(IReadOnlyCollection<string> fieldsToSelect, RowSet rs)
        {
            var output = new Dictionary<string, EntityResult>();

            foreach (var row in rs)
            {
                var fieldToValueMap = new EntityResult(fieldsToSelect.ToDictionary(field => field, field => row.GetValue(typeof(object), field)));
                output.Add(row.GetValue(typeof(object), StringConstants.Guid).ToString(), fieldToValueMap);
            }
            return output;
        }
    }
}