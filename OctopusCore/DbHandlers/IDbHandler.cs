using System.Collections.Generic;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public interface IDbHandler
    {
        object ExecuteQueryWithFilters(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters); // todo return real object
    }
}