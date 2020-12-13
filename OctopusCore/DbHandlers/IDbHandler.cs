using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public interface IDbHandler
    {
        Task<object> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters,string entityType); // todo return real object
    }
}