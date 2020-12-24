using System.Reflection;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class Neo4jConfigurationProvider
    {
        public string ConnectionString { get; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Neo4jConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
            Username = dbConfiguration.Username;
            Password = dbConfiguration.Password;
        }
    }
}