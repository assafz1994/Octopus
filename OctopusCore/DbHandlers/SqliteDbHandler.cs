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
        private readonly Dictionary<FilterType, string> _filterTypeToOperatorRepresentation;

        public SqliteDbHandler(SqliteConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _filterTypeToOperatorRepresentation = new Dictionary<FilterType, string> {{FilterType.Eq, "="}};
        }

        public async Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType,
            List<(string entityType, Field field, List<string> fieldsToSelect)>
                joinsTuples)
        {
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var fieldsToSelectWithGuid = new List<string>(fieldsToSelect) {StringConstants.Guid};
            var table = _configurationProvider.GetTableName(entityType);
            var fields = GetFields(fieldsToSelectWithGuid, table, joinsTuples);
            var conditions = ConvertFiltersToWhereStatement(filters, table);

            var command = connection.CreateCommand();
            command.CommandText = SetCommandText(fields, entityType, table, conditions,joinsTuples);

            //fieldsToSelect are the fields that will be shown to the user.
            //Guid field is inside the command that will be executed, but it won't be shown to the user
            var result = await ExecuteCommand(fieldsToSelect, command);

            return new ExecutionResult(entityType, result);
        }

        private string GetFields(List<string> rootFields,string rootTable, List<(string entityType, Field field, List<string> fieldsToSelect)> joinTuples)
        {
            var allFields = rootFields.Select(field => $"{rootTable}.{field}").ToList();
            foreach (var tuple in joinTuples)
            {
                var tableName = _configurationProvider.GetTableName(tuple.field.EntityName);
                allFields.AddRange(tuple.fieldsToSelect.Select((fieldName => $"{tableName}_{tuple.field.Name}.{fieldName} as {tableName}_{tuple.field.Name}_{fieldName}")));
            }

            return string.Join(",", allFields);
        }
        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            throw new NotImplementedException();
        }

        private  string SetCommandText(string fields, string rootEntity,string table,string conditions,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples)
        {
            var query = new StringBuilder($"SELECT {fields} FROM {table} ");

            var prevEntity = rootEntity;
            var prevTableAlias= table;
            foreach (var tuple in joinsTuples)
            {
                var joinConnectionTable = _configurationProvider.GetConnectionTable(tuple.entityType, tuple.field);
                var joinTable = _configurationProvider.GetTableName(tuple.field.EntityName);
                var tableAlias = $"{joinTable}_{tuple.field.Name}";
                query.Append($"INNER JOIN {joinConnectionTable} ON {joinConnectionTable}.{prevEntity} = {prevTableAlias}.guid ");
                query.Append($"INNER JOIN {joinTable} AS {tableAlias} ON {joinConnectionTable}.{tuple.field.EntityName} = {tableAlias}.guid ");

                prevEntity = tuple.field.EntityName;
                prevTableAlias= tableAlias;

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


        private static async Task<Dictionary<string, EntityResult>> ExecuteCommand(
            IReadOnlyCollection<string> fieldsToSelect,
            SqliteCommand command)
        {
            using var reader = await command.ExecuteReaderAsync();
            var output = new Dictionary<string, EntityResult>();

            while (await reader.ReadAsync())
            {
                var dictionary = new Dictionary<string, dynamic>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i) == StringConstants.Guid)
                    {
                        continue;
                    }
                    dictionary[reader.GetName(i)] = reader[i];
                }
                var fieldToValueMap = new EntityResult(dictionary);

                output.Add(reader[StringConstants.Guid].ToString(), fieldToValueMap);
            }

            return output;
        }


        private string ConvertFiltersToWhereStatement(IReadOnlyCollection<Filter> filters, string rootTableName)
        {
            if (filters.Count == 0)
                return null;

            var filtersAsString = new List<string>();
            foreach (var filter in filters)
            {
                if (filter.FieldNames.Count > 1) throw new ArgumentException("Fields with Include are not supported");

                var filterAsString = new StringBuilder().Append($"{rootTableName}.{filter.FieldNames[0]}").Append(GetFilterOperator(filter))
                    .Append(filter.Expression).ToString();
                filtersAsString.Add(filterAsString);
            }

            var conditions = string.Join(" and ", filtersAsString);
            return conditions;
        }
    }
}