using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jClient;
using OctopusCore.Common;
using OctopusCore.Configuration;
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
            _filterTypeToOperatorRepresentation = new Dictionary<FilterType, string>
            {
                {FilterType.Eq, "="},
                {FilterType.In, "in"}
            };
        }

        public async Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType,
            List<(string entityType, Field field, List<string> fieldsToSelect)>
                joinsTuples)
        {
            if (joinsTuples.Count > 0)
            {
                return await ExecuteQueryWithComplexFields(fieldsToSelect, filters, entityType, joinsTuples);
            }

            return await ExecuteQueryWithSimpleFields(fieldsToSelect, filters, entityType);
        }

        private async Task<ExecutionResult> ExecuteQueryWithSimpleFields(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters,
            string entityType)
        {
            var session = OpenSession();

            var fieldsNames = fieldsToSelect.ToList();
            if (!fieldsNames.Contains(StringConstants.Guid))
            {
                fieldsNames.Add(StringConstants.Guid);
            }

            var queryFields = fieldsNames.Select(GetQueryField);


            var query = new StringBuilder($"match {GetQueryEntity(entityType)} ");
            if (filters.Any())
            {
                var where = filters.Select(GetQueryCondition).ToList();
                query.Append($"where {string.Join(" and ", @where)}");
            }

            query.Append($" return {string.Join(",", queryFields)}");
            var cursor = await session.RunAsync(query.ToString());
            var result = await cursor.ToListAsync();
            var entityResults = BuildResultsDictionary(result, fieldsNames);

            return new ExecutionResult(entityType, entityResults);
        }

        private IAsyncSession OpenSession()
        {
            IDriver driver = GraphDatabase.Driver(_configurationProvider.ConnectionString,
                AuthTokens.Basic(_configurationProvider.Username, _configurationProvider.Password));
            var session = driver.AsyncSession();
            return session;
        }

        private async Task<ExecutionResult> ExecuteQueryWithComplexFields(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples)
        {
            var session =OpenSession();

            var fieldsNames = fieldsToSelect.ToList();
            if (!fieldsNames.Contains(StringConstants.Guid))
            {
                fieldsNames.Add(StringConstants.Guid);
            }
            var toEntitiesList = new List<string>();
            var complexFields = new HashSet<string>();
            var complexFieldsCount = 0;
            var matchQuery = new StringBuilder();
            foreach (var joinsTuple in joinsTuples)
            { 
                complexFields.Add(joinsTuple.field.Name);

                matchQuery.Append($"match (e:{entityType})");
                matchQuery.Append(
                    $"-[r{complexFieldsCount}:{joinsTuple.field.Name}]->(p{complexFieldsCount}:{joinsTuple.field.EntityName}) ");
                toEntitiesList.Add($"p{complexFieldsCount}");
                complexFieldsCount++;
            }

            if (filters.Any())
            {
                var where = filters.Select(GetQueryCondition).ToList();
                matchQuery.Append($"where {string.Join(" and ", where)} ");
            }

            var returnStatement = new StringBuilder("return ");

            foreach (var field in fieldsNames)
            {
                if (!complexFields.Contains(field))
                {
                    returnStatement.Append($"e.{field},");
                }
            }

            var toEntityGuids = toEntitiesList.Select(entity => $"{entity}.{StringConstants.Guid} ");
            returnStatement.Append(string.Join(",", toEntityGuids));



            var cursor = await session.RunAsync(matchQuery.Append(returnStatement).ToString());

            var res = await cursor.ToListAsync();
            await session.CloseAsync();

            var entitiesResult = BuildResultsDictionary(res, fieldsNames, complexFields);
            return new ExecutionResult(entityType,entitiesResult);
        }

        private Dictionary<string, EntityResult> BuildResultsDictionary(List<IRecord> recordsFromDb,
            List<string> fieldsNames, HashSet<string> complexFields)
        {
            var numOfComplexFields = complexFields.Count;
            var complexFieldsList = complexFields.ToList();
            var entityResults = new Dictionary<string, EntityResult>();
            for (int i = 0; i < recordsFromDb.Count; i++)
            {
                var dict = new Dictionary<string, dynamic>();

                foreach (var field in fieldsNames)
                    dict.Add(field, recordsFromDb[i][$"e.{field}"]);
                for (int j = 0; j < complexFields.Count; j++)
                {
                    var complexField = complexFieldsList[j];
                    dict[complexField] = new Dictionary<string, EntityResult>()
                    {
                        {
                            (string)recordsFromDb[i][$"p{j}.{StringConstants.Guid}"], new EntityResult(new Dictionary<string, dynamic>())
                        }
                    };
                }
            

                var guid = dict[StringConstants.Guid];
                dict.Remove(StringConstants.Guid);
                var entityResult = new EntityResult(dict);
                entityResults.Add(guid, entityResult);
            }

            return entityResults;

        }

        public async Task<ExecutionResult> ExecuteInsertQuery(string entityType,
            IReadOnlyDictionary<string, dynamic> fields)
        {
            var session = OpenSession();
            var query = BuildInsertQuery(entityType, fields);
            var cursor = await session.RunAsync(query);
            await session.CloseAsync();
            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        public async Task<ExecutionResult> ExecuteDeleteQuery(string entityType,
            IReadOnlyCollection<string> guidCollection)
        {
            var session = OpenSession();
            var guids = guidCollection.Select(guid => $"'{guid}'");
            var guidsAsString = $"[{string.Join(",", guids)}]";
            await session.RunAsync(
                $"match (e:{entityType}) where e.{StringConstants.Guid} in {guidsAsString} detach delete e");
            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        private string BuildInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var query = new StringBuilder($"create (e:{entityType} ").Append("{");
            //in case the key is Guid, need to wrap it with '', so it will be stored in db as string
            var keyValueFormatted = fields.Select(field =>
                string.Format(field.Key.Equals(StringConstants.Guid) ? "{0}: '{1}'" : "{0}: {1}", field.Key,
                    field.Value));
            query.Append(string.Join(",", keyValueFormatted));
            query.Append("})");
            return query.ToString();
        }

        private string GetFilterOperator(Filter filter)
        {
            return _filterTypeToOperatorRepresentation[filter.Type];
        }

        private static Dictionary<string, EntityResult> BuildResultsDictionary(List<IRecord> result,
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
            if (filter.Type == FilterType.In)
            {
                var guids = filter.CalcValue().Select(guid=>$"'{guid}'").ToList();
                return $"e.{filter.FieldNames.First()} {GetFilterOperator(filter)} [{string.Join(",",guids)}]";
            }

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