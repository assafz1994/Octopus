using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public interface IDbHandler
    {
        Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType);
    }
}