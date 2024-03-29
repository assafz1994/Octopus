﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Neo4jClient.Cypher;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    public class CassandraDbHandler : IDbHandler
    {
        private readonly CassandraConfigurationProvider _configurationProvider;
        private Cluster _cluster;
        private ISession _session;

        public CassandraDbHandler(CassandraConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _cluster = Cluster.Builder()
                .AddContactPoint(_configurationProvider.ConnectionString)
                .Build();
            _session = _cluster.Connect(_configurationProvider.KeySpace);
        }
        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters, string entityType,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples)
        {
            var fieldsToSelectWithGuid = fieldsToSelect.ToList().Append(StringConstants.Guid).ToList();
            var fields = (fieldsToSelectWithGuid.Count == 1) ? 
                fieldsToSelectWithGuid.First() : 
                string.Join(",", fieldsToSelectWithGuid);
            // var table = _configurationProvider.GetTableName(entityType, filters);
            var conditions = ConvertFiltersToWhereStatement(filters);
            var query = _configurationProvider.AssembleSelectQuery(entityType, fields, filters, conditions);
            var rs = _session.Execute(query);
            var result = ExecuteCommand(fieldsToSelect, rs);
            return Task.FromResult(new ExecutionResult(entityType, result));
        }

        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var tables = _configurationProvider.GetTableNames(entityType);
            var queries = AssembleInsertQueries(tables, fields);
            foreach (var query in queries)
            {
                _session.Execute(query);
            }
            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        public Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection)
        {
            var tableNamesToTables = _configurationProvider.TableNamesToTables(entityType);
            var tables = _configurationProvider.GetTables(entityType);
            var byFields = GetByFields(tables);
            byFields.Add(StringConstants.Guid);
            var entities = GetEntities(entityType, guidCollection, byFields);
            foreach (var tableElement in tableNamesToTables)
            foreach (var entity in entities)
            {
                var deleteQuery = $"DELETE FROM {tableElement.Key} WHERE guid={entity[StringConstants.Guid]}";
                foreach (var field in tableElement.Value)
                {
                    deleteQuery += $" AND {field}={FieldToString(entity[field])}";
                }
                _session.Execute(deleteQuery);
            }
            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        private List<Dictionary<string, dynamic>> GetEntities(string entityType, IReadOnlyCollection<string> guidCollection, List<string> fields)
        {
            var tableNames = _configurationProvider.GetTableNames(entityType);
            var mainTable = tableNames.First();
            var guidList = $"({string.Join(",", guidCollection)})";
            var selectQuery = $"SELECT {string.Join(",", fields)} FROM {mainTable} WHERE GUID IN {guidList}";
            var rs = _session.Execute(selectQuery);
            var entities = new List<Dictionary<string, dynamic>>();

            foreach (var row in rs)
            {
                var fieldToValueMap = fields.ToDictionary(field => field, field => row.GetValue(typeof(object), field));
                entities.Add(fieldToValueMap);
            }

            return entities;
        }

        public Task<ExecutionResult> ExecuteUpdateQuery(string entityType, string guid, string updateField, dynamic value)
        {
            var fields = _configurationProvider.GetFields(entityType);
            var guidList = new List<string>() {guid};
            var executionResult = ExecuteQueryWithFiltersAsync(fields,
                new List<Filter>()
                {
                    new EqFilter(new List<string>() {StringConstants.Guid}, guid)
                },
                entityType,
                new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var entity = executionResult.EntityResults.Values.First().Fields;
            entity = entity.ToDictionary(x => x.Key, x => UntrimExpression(x.Value));
            ExecuteDeleteQuery(entityType, guidList);
            entity[updateField] = value;
            entity[StringConstants.Guid] = Guid.Parse(guid);
            ExecuteInsertQuery(entityType, entity);
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

        private static dynamic UntrimExpression(dynamic expression)
        {
            if (expression is string s)
            {
                return $"\"{s}\"";
            }

            return expression;
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