using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
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
            var fieldsToSelectWithGuid = fieldsToSelect.ToList().Append("guid").ToList();
            var fields = string.Join(",", fieldsToSelectWithGuid);
            // var table = _configurationProvider.GetTableName(entityType, filters);
            var conditions = ConvertFiltersToWhereStatement(filters);
            var session = cluster.Connect(_configurationProvider.KeySpace);
            var query = _configurationProvider.AssembleQuery(entityType, fields, filters, conditions);
            var rs = session.Execute(query);
            var result = ExecuteCommand(fieldsToSelect, rs);
            return Task.FromResult(new ExecutionResult(entityType, result));
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
                output.Add(row.GetValue(typeof(object), "guid").ToString(), fieldToValueMap);
            }
            return output;
        }
    }
}