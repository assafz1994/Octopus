using System.Collections.Generic;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public interface IAnalyzerConfigurationProvider
    {
        public Dictionary<string, List<string>> GetDbsToFields(string entityType);
        string GetFieldDatabaseKey(string entityType, string fieldName);
        bool IsComplexField(string entityType, string fieldName);
        public string GetFieldEntityType(string entityType, string fieldName);

    }
}