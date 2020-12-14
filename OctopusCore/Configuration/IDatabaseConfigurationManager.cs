using OctopusCore.DbHandlers;

namespace OctopusCore.Configuration
{
    public interface IDatabaseConfigurationManager
    {
        string GetFieldDatabaseKey(string entityType, string fieldName);
        IDbHandler ResolveDatabaseHandler(string databaseKey);
    }
}