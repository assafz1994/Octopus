using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using OctopusCore.Common;
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
            List<(string entityType, string fieldEntityType, string fieldName, List<string> fieldsToSelect)>
                joinsTuples)
        {
            using var connection = new SqliteConnection(_configurationProvider.ConnectionString);
            connection.Open();
            var fieldsToSelectWithGuid = new List<string>(fieldsToSelect) {StringConstants.Guid};
            var fields = string.Join(",", fieldsToSelectWithGuid);
            var table = _configurationProvider.GetTableName(entityType);
            var conditions = ConvertFiltersToWhereStatement(filters);

            var command = connection.CreateCommand();
            command.CommandText = SetCommandText(fields, table, conditions);

            //fieldsToSelect are the fields that will be shown to the user.
            //Guid field is inside the command that will be executed, but it won't be shown to the user
            var result = await ExecuteCommand(fieldsToSelect, command);

            return new ExecutionResult(entityType, result);
        }

        private static string SetCommandText(string fields, string table, string conditions)
        {
            return conditions == null
                ? $"SELECT {fields} FROM {table}"
                : $"SELECT {fields} FROM {table} WHERE {conditions}";
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
                var fieldToValueMap =
                    new EntityResult(fieldsToSelect.ToDictionary(field => field, field => reader[field.ToLower()]));

                output.Add(reader[StringConstants.Guid].ToString(), fieldToValueMap);
            }

            return output;
        }


        private string ConvertFiltersToWhereStatement(IReadOnlyCollection<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            var filtersAsString = new List<string>();
            foreach (var filter in filters)
            {
                if (filter.FieldNames.Count > 1) throw new ArgumentException("Fields with Include are not supported");

                var filterAsString = new StringBuilder().Append(filter.FieldNames[0]).Append(GetFilterOperator(filter))
                    .Append(filter.Expression).ToString();
                filtersAsString.Add(filterAsString);
            }

            var conditions = string.Join(" and ", filtersAsString);
            return conditions;
        }
    }
}