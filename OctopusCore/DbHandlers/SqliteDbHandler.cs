﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    public class SqliteDbHandler : IDbHandler
    {
        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            using var connection = new SqliteConnection(GetConnectionString());
            connection.Open();

            var table = entityType;
            var fields = string.Join(",", fieldsToSelect);
            var conditions = ConvertFiltersToWhereStatement(filters);

            var command = connection.CreateCommand();
            //todo prevent sql injection
            command.CommandText = "SELECT " + fields + " FROM " + table + " WHERE " + conditions;

            var result = ExecuteCommand(fieldsToSelect, command);

            return Task.FromResult(new ExecutionResult(result));
        }

        private string GetFilterOperator(Filter filter)
        {
            if (filter is EqFilter) return "=";

            throw new ArgumentException("Filter type is not supported");
        }

        private string GetConnectionString()
        {
            //todo should receive this from Configuration
            return "Data Source=DataBases\\demoDb.db";
        }

        private static List<Dictionary<string, object>> ExecuteCommand(IReadOnlyCollection<string> fieldsToSelect,
            SqliteCommand command)
        {
            using var reader = command.ExecuteReader();
            var output = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var fieldToValueMap = fieldsToSelect.ToDictionary(field => field, field => reader[field]);

                output.Add(fieldToValueMap);
            }

            return output;
        }

        private string ConvertFiltersToWhereStatement(IReadOnlyCollection<Filter> filters)
        {
            if (filters.Count == 0)
            {
                //todo check why 'true' not working. think about alternative
                return "1=1";
            }

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