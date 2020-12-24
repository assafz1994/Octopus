using System.Collections.Generic;
using OctopusCore.DbHandlers;

namespace OctopusCore.Configuration.Mocks
{
    public class DbHandlerResolverMock : IDbHandlersResolver
    {
        private readonly Dictionary<string, IDbHandler> _databaseKeyToDbHandlerMappings;
        public DbHandlerResolverMock(Dictionary<string,IDbHandler> databaseKeyToDbHandlerMappings)
        {
            _databaseKeyToDbHandlerMappings = databaseKeyToDbHandlerMappings;
        }

        public IDbHandler ResolveDbHandler(string databaseKey)
        {
            return _databaseKeyToDbHandlerMappings[databaseKey];
        }
    }
}