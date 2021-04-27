using System.Collections.Generic;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public interface IAnalyzerConfigurationProvider
    {
        Dictionary<string, List<string>> GetDbsToFields(string entityType);
        string GetFieldDatabaseKey(string entityType, string fieldName);
        bool IsComplexField(string entityType, string fieldName);
        Field GetField(string entityType, string fieldName);

        string GetEntityPrimaryKey(string entityType);
        List<string> GetEntityFields(string entityType);
    }
}