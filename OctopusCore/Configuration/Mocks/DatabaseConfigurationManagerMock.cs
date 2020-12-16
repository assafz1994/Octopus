using System.Collections.Generic;
using OctopusCore.DbHandlers;

namespace OctopusCore.Configuration.Mocks
{
    public class DatabaseConfigurationManagerMock : IDatabaseConfigurationManager
    {
        private readonly Dictionary<string, IDbHandler> _databaseKeyToDbHandlerMappings;
        private readonly Dictionary<string, Dictionary<string, string>> _entityTypeToFieldNameToDataBaseKeyMappings;

        public DatabaseConfigurationManagerMock(
            Dictionary<string, Dictionary<string, string>> entityTypeToFieldNameToDataBaseKeyMappings,
            Dictionary<string, IDbHandler> databaseKeyToDbHandlerMappings)
        {
            _entityTypeToFieldNameToDataBaseKeyMappings = entityTypeToFieldNameToDataBaseKeyMappings;
            _databaseKeyToDbHandlerMappings = databaseKeyToDbHandlerMappings;
        }

        public string GetFieldDatabaseKey(string entityType, string fieldName)
        {
            return _entityTypeToFieldNameToDataBaseKeyMappings[entityType][fieldName];
        }

        public IDbHandler ResolveDatabaseHandler(string databaseKey)
        {
            return _databaseKeyToDbHandlerMappings[databaseKey];
        }
    }
}