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
            var fields = fieldsNames.Select(x => $"e.{x}");
            var query = client.Cypher.Match($"(e:{entityType})");
            if (filters.Any())
            {
                var wheres = filters.Select(x => $"e.{x.FieldNames.First()} = {x.Expression}");
                query = query.Where(string.Join(" and ", wheres));
            }
            //.Where("person.email='a@gmail.com'")

            var result = await query.Return<List<string>>($"[{string.Join(",", fields)}]").ResultsAsync;

            var entityResults = new Dictionary<string, EntityResult>();
            foreach (var nodeFields in result)
            {
                var dict = new Dictionary<string, dynamic>();
                for (int i = 0; i < fieldsNames.Count; i++)
                {
                    dict.Add(fieldsNames[i], nodeFields[i]);
                }

                var guid = dict["guid"];
                dict.Remove("guid");
                var entityResult = new EntityResult(dict);
                entityResults.Add(guid, entityResult);

            }

            return new ExecutionResult(entityType, entityResults);
        }
    }
}