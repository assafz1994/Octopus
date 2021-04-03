using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4jClient;
using OctopusCore.Common;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    public class Neo4JDbHandler : IDbHandler
    {
        private readonly Neo4jConfigurationProvider _configurationProvider;
        private readonly Dictionary<FilterType, string> _filterTypeToOperatorRepresentation;

        public Neo4JDbHandler(Neo4jConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _filterTypeToOperatorRepresentation = new Dictionary<FilterType, string> {{FilterType.Eq, "="}};
        }

        public async Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            var client = new GraphClient(new Uri(_configurationProvider.ConnectionString),
                _configurationProvider.Username, _configurationProvider.Password);

            await client.ConnectAsync(); //todo check if it should happen only once
            var fieldsNames = fieldsToSelect.ToList().Append(StringConstants.Guid).ToList();
            var queryFields = fieldsNames.Select(GetQueryField);
            var query = client.Cypher.Match(GetQueryEntity(entityType));
            if (filters.Any())
            {
                var where = filters.Select(GetQueryCondition);
                query = query.Where(string.Join(" and ", where));
            }

            var result = await query.Return<List<string>>($"[{string.Join(",", queryFields)}]").ResultsAsync;

            var entityResults = BuildResultsDictionary(result, fieldsNames);

            return new ExecutionResult(entityType, entityResults);
        }

        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            throw new NotImplementedException();
        }

        private string GetFilterOperator(Filter filter)
        {
            return _filterTypeToOperatorRepresentation[filter.Type];
        }

        private static Dictionary<string, EntityResult> BuildResultsDictionary(IEnumerable<List<string>> result,
            IReadOnlyList<string> fieldsNames)
        {
            var entityResults = new Dictionary<string, EntityResult>();
            foreach (var nodeFields in result)
            {
                var dict = new Dictionary<string, dynamic>();
                for (var i = 0; i < fieldsNames.Count; i++) dict.Add(fieldsNames[i], nodeFields[i]);

                var guid = dict[StringConstants.Guid];
                dict.Remove(StringConstants.Guid);
                var entityResult = new EntityResult(dict);
                entityResults.Add(guid, entityResult);
            }

            return entityResults;
        }

        private string GetQueryCondition(Filter filter)
        {
            return $"e.{filter.FieldNames.First()} {GetFilterOperator(filter)} {filter.Expression}";
        }

        private static string GetQueryEntity(string entityType)
        {
            return $"(e:{entityType})";
        }

        private static string GetQueryField(string x)
        {
            return $"e.{x}";
        }
    }
}