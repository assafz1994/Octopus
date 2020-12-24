namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class Neo4jConfigurationProvider
    {
        public string ConnectionString { get; }

        public Neo4jConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
        }
    }
}