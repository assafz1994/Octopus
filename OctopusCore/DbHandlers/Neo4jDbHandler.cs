using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.DbHandlers
{
    public class Neo4jDbHandler: IDbHandler
    {
        private readonly Neo4jConfigurationProvider _configurationProvider;

        public Neo4jDbHandler(Neo4jConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect, IReadOnlyCollection<Filter> filters, string entityType)
        {
            return null;
        }
    }
}