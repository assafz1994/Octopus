namespace OctopusCore.Configuration.ConfigurationProviders
{
    public interface IAnalyzerConfigurationProvider
    {
        string GetFieldDatabaseKey(string entityType, string fieldName);
    }
}