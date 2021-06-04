using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra.Data.Linq;
using Microsoft.Data.Sqlite;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    public class SqliteDbHandler : IDbHandler
    {
        private readonly SqliteConfigurationProvider _configurationProvider;
        private readonly AnalyzerConfigurationProvider _analyzerConfigurationProvider;
        private readonly Dictionary<FilterType, string> _filterTypeToOperatorRepresentation;

        public SqliteDbHandler(SqliteConfigurationProvider configurationProvider, AnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _configurationProvider = configurationProvider;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
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
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var fieldsToSelectWithGuid = new List<string>(fieldsToSelect) { StringConstants.Guid };
            var table = _configurationProvider.GetTableName(entityType);
            var fields = GetFields(fieldsToSelectWithGuid, table, joinsTuples);
            var conditions = ConvertFiltersToWhereStatement(filters, table, entityType);

            var command = connection.CreateCommand();
            command.CommandText = SetCommandText(fields, entityType, table, conditions, joinsTuples);

            //fieldsToSelect are the fields that will be shown to the user.
            //Guid field is inside the command that will be executed, but it won't be shown to the user
            var result = await ExecuteCommand(table, fieldsToSelect, joinsTuples, command);

            return new ExecutionResult(entityType, result);
        }

        private string GetFields(List<string> rootFields, string rootTable,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinTuples)
        {
            var allFields = rootFields.Select(field => $"{rootTable}.{field}").ToList();
            foreach (var tuple in joinTuples)
            {
                var connectionTable = _configurationProvider.GetConnectionTable(tuple.entityType, tuple.field);
                var tableName = _configurationProvider.GetTableName(tuple.field.EntityName);
                allFields.AddRange(tuple.fieldsToSelect.Select(GetSelectedFields));
                allFields.Add($"{connectionTable}.{tuple.field.EntityName} as {rootTable}_{tuple.field.Name}");

                string GetSelectedFields(string fieldName)
                {
                    return $"{tableName}_{tuple.field.Name}.{fieldName} as {tableName}_{tuple.field.Name}_{fieldName}";
                }
            }
            return string.Join(",", allFields);
        }

        public async Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var table = _configurationProvider.GetTableName(entityType);

            var fieldsNames = fields.Keys.ToList();
            var fieldsValues = fieldsNames.Select(fieldName => ValueToString(fields[fieldName]));
            var query = $"INSERT INTO {table} ({string.Join(",", fields.Keys)}) Values ({string.Join(",", fieldsValues)})";

            var command = connection.CreateCommand();
            command.CommandText = query;

            var row = await command.ExecuteNonQueryAsync();

            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        public async Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection)
        {
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var table = _configurationProvider.GetTableName(entityType);
            var guidList = $"({string.Join(",", guidCollection.Select(x => $"'{x}'"))})";
            var query = $"DELETE FROM {table} WHERE GUID IN {guidList}";

            var command = connection.CreateCommand();
            command.CommandText = query;

            var row = await command.ExecuteNonQueryAsync();

            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        public async Task<ExecutionResult> ExecuteUpdateQuery(string entityType, string guid, string field, dynamic value)
        {
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var table = _configurationProvider.GetTableName(entityType);
            var query = $"UPDATE {table} SET {field} = {ValueToString(value)} WHERE GUID = '{guid}'";

            var command = connection.CreateCommand();
            command.CommandText = query;

            var row = await command.ExecuteNonQueryAsync();
            return new ExecutionResult(entityType, new Dictionary<string, EntityResult>());
        }

        //todo reuse this logic for all handlers
        private static string ValueToString(object argValue)
        {
            return argValue switch
            {
                string s => GetExpression(s),
                int _ => $"{argValue}",
                Guid _ => $"'{argValue}'",
                _ => null
            };
        }
        private static string GetExpression(string expression)
        {
            if (!expression.StartsWith("\"") || !expression.EndsWith("\"")) return expression;
            var res = expression.Trim('"');
            return $"'{res}'";
        }

        private string SetCommandText(string fields, string rootEntity, string table, string conditions,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples)
        {
            var query = new StringBuilder($"SELECT {fields} FROM {table} ");

            var prevEntity = rootEntity;
            var prevTableAlias = table;
            foreach (var tuple in joinsTuples)
            {
                var joinConnectionTable = _configurationProvider.GetConnectionTable(tuple.entityType, tuple.field);
                var joinTable = _configurationProvider.GetTableName(tuple.field.EntityName);
                var tableAlias = $"{joinTable}_{tuple.field.Name}";
                query.Append($"INNER JOIN {joinConnectionTable} ON {joinConnectionTable}.{prevEntity} = {prevTableAlias}.guid ");
                if (tuple.fieldsToSelect.Any())
                {
                    query.Append($"INNER JOIN {joinTable} AS {tableAlias} ON {joinConnectionTable}.{tuple.field.EntityName} = {tableAlias}.guid ");
                }

                prevEntity = tuple.field.EntityName;
                prevTableAlias = tableAlias;

            }

            if (string.IsNullOrEmpty(conditions) == false)
            {
                query.Append($"WHERE {conditions}");
            }

            return query.ToString();
        }

        private string GetFilterOperator(Filter filter)
        {
            return _filterTypeToOperatorRepresentation[filter.Type];
        }


        private async Task<Dictionary<string, EntityResult>> ExecuteCommand(
            string rootTable,
            IReadOnlyCollection<string> fieldsToSelect,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples,
            SqliteCommand command)
        {
            using var reader = await command.ExecuteReaderAsync();
            var output = new Dictionary<string, EntityResult>();

            while (await reader.ReadAsync())
            {
                var currentEntityGuid = reader[StringConstants.Guid].ToString();
                if (output.ContainsKey(currentEntityGuid) == false)
                {
                    var dictionary = new Dictionary<string, dynamic>();
                    //add all primitive fields
                    foreach (var fieldName in fieldsToSelect)
                    {
                        dictionary[fieldName] = reader[fieldName];
                    }
                    output.Add(currentEntityGuid, new EntityResult(dictionary));
                }

                var currentEntity = output[currentEntityGuid];

                foreach (var joinsTuple in joinsTuples)
                {
                    if (currentEntity.Fields.ContainsKey(joinsTuple.field.Name) == false)
                    {
                        currentEntity.Fields[joinsTuple.field.Name] = new Dictionary<string, EntityResult>();
                    }

                    var complexFieldEntities = (Dictionary<string, EntityResult>)currentEntity.Fields[joinsTuple.field.Name];

                    var complexFieldsToFields = new Dictionary<string, dynamic>();
                    //todo this code is for future optimization when we can select many fields that are stored in the same database
                    //var tableName = _configurationProvider.GetTableName(joinsTuple.field.EntityName);
                    //foreach (var fieldNameOfComplexField in joinsTuple.fieldsToSelect)
                    //{
                    //    complexFieldsToFields[fieldNameOfComplexField] =
                    //        reader[$"{tableName}_{joinsTuple.field.Name}_{fieldNameOfComplexField}"];
                    //}

                    var guidOfComplexField = reader[$"{rootTable}_{joinsTuple.field.Name}"].ToString();
                    if (complexFieldEntities.ContainsKey(guidOfComplexField) == false)
                    {
                        complexFieldEntities[guidOfComplexField] = new EntityResult(complexFieldsToFields);
                    }

                }
            }

            return output;
        }


        private string ConvertFiltersToWhereStatement(IReadOnlyCollection<Filter> filters, string rootTableName, string entityType)
        {
            if (filters.Count == 0)
                return null;

            var filtersAsString = new List<string>();
            foreach (var filter in filters)
            {
                if (filter.FieldNames.Count > 1) throw new ArgumentException("Fields with Include are not supported");

                var filteredFieldName = $"{rootTableName}.{filter.FieldNames[0]}";
                if (filter.FieldNames[0] != "guid" && _analyzerConfigurationProvider.IsComplexField(entityType, filter.FieldNames[0]))
                {
                    var field = _analyzerConfigurationProvider.GetField(entityType, filter.FieldNames[0]);
                    var connectionTableName = _configurationProvider.GetConnectionTable(entityType, field);
                    filteredFieldName = $"{connectionTableName}.{field.EntityName}";
                }

                if (filter.Type == FilterType.In)
                {
                    var values = filter.CalcValue().Select(x => $"\"{x}\"");//todo just do something
                    filtersAsString.Add($"{filteredFieldName} {GetFilterOperator(filter)} ({string.Join(",", values)})");
                }
                else
                {
                    var filterAsString =
                        $"{filteredFieldName} {GetFilterOperator(filter)} {filter.Expression}";
                    filtersAsString.Add(filterAsString);
                }
            }

            var conditions = string.Join(" and ", filtersAsString);
            return conditions;
        }
    }
}