using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _filterTypeToOperatorRepresentation = new Dictionary<FilterType, string> { { FilterType.Eq, "=" } };
        }

        public async Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            var client = new GraphClient(new Uri(_configurationProvider.ConnectionString),
                _configurationProvider.Username, _configurationProvider.Password);

            await client.ConnectAsync(); //todo check if it should happen only once
            var fieldsNames = fieldsToSelect.ToList();
            if (!fieldsNames.Contains(StringConstants.Guid))
            {
                fieldsNames.Append(StringConstants.Guid).ToList();
            }

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

        public async Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var client = new GraphClient(new Uri(_configurationProvider.ConnectionString),
                _configurationProvider.Username, _configurationProvider.Password);

            await client.ConnectAsync();
            //todo check if indeed necessary to surround fields with ''. (probably not, it should return from the parser as string)
            //todo check what type should be guid(String?)
            var query = BuildInsertQuery(entityType, fields);
            //"(n:neoperson {email: 'ba@mail', hobby: 'mba'})"
            await client.Cypher.Create(query).ExecuteWithoutResultsAsync();
            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        public async Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection)
        {
            var client = new GraphClient(new Uri(_configurationProvider.ConnectionString),
                _configurationProvider.Username, _configurationProvider.Password);

            await client.ConnectAsync();
            var guidsAsString = $"['{string.Join(",", guidCollection)}']";
            var withStatement = $"{guidsAsString} as guids";
            // var query = $"{withStatement} match (e:{entityType}) where e.{StringConstants.Guid} in guids detach delete e";
            await client.Cypher.With(withStatement).Match($"(e:{entityType})").Where($"e.{StringConstants.Guid} in guids").DetachDelete("e").ExecuteWithoutResultsAsync();
            // await client.Cypher
            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());

        }

        private string BuildInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var query = new StringBuilder($"(e:{entityType} ").Append("{");
            //in case the key is Guid, need to wrap it with '', so it will be stored in db as string
            var keyValueFormatted = fields.Select(field => string.Format(field.Key.Equals(StringConstants.Guid) ? "{0}: '{1}'" : "{0}: {1}", field.Key, field.Value));
            query.Append(string.Join(",", keyValueFormatted));
            query.Append("})");
            return query.ToString();
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