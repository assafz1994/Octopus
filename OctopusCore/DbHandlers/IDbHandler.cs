using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Configuration;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public interface IDbHandler
    {
        Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType, List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples);
        Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields);
        Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection);
        Task<ExecutionResult> ExecuteUpdateQuery(string entityType, string guid, dynamic value);
    }
}