using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public class CassandraDbHandler : IDbHandler
    {
        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters, string entityType)
        {
            throw new System.NotImplementedException();
        }
    }
}