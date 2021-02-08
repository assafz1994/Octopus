using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Neo4jClient;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public class Neo4jDbHandler : IDbHandler
    {
        private readonly Neo4jConfigurationProvider _configurationProvider;

        public Neo4jDbHandler(Neo4jConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public async Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            var client = new GraphClient(new Uri(_configurationProvider.ConnectionString),
                _configurationProvider.Username, _configurationProvider.Password);

            await client.ConnectAsync(); //todo check if it should happen only once
            var fieldsNames = fieldsToSelect.ToList().Append("guid").ToList();
            var queryFields = fieldsNames.Select(GetQueryField);
            var query = client.Cypher.Match(GetQueryEntity(entityType));
            if (filters.Any())
            {
                var where = filters.Select(GetQueryCondition);
                query = query.Where(string.Join(" and ", where));
            }
            //.Where("person.email='a@gmail.com'")

            var result = await query.Return<List<string>>($"[{string.Join(",", queryFields)}]").ResultsAsync;

            var entityResults = BuildResultsDictionary(result, fieldsNames);

            return new ExecutionResult(entityType, entityResults);
        }

        private static Dictionary<string, EntityResult> BuildResultsDictionary(IEnumerable<List<string>> result, List<string> fieldsNames)
        {
            var entityResults = new Dictionary<string, EntityResult>();
            foreach (var nodeFields in result)
            {
                var dict = new Dictionary<string, dynamic>();
                for (var i = 0; i < fieldsNames.Count; i++)
                {
                    dict.Add(fieldsNames[i], nodeFields[i]);
                }

                var guid = dict["guid"];
                dict.Remove("guid");
                var entityResult = new EntityResult(dict);
                entityResults.Add(guid, entityResult);
            }

            return entityResults;
        }

        private static string GetQueryCondition(Filter filter)
        {
            return $"e.{filter.FieldNames.First()} = {filter.Expression}";
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