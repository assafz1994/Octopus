using System.Collections.Generic;
using System.Linq;
using OctopusCore.Parser;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class CassandraConfigurationProvider
    {
        public string ConnectionString { get; }
        public string KeySpace { get; }
        public CassandraConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
            KeySpace = dbConfiguration.KeySpace;
        }

        public string GetTableName(string entityType, IReadOnlyCollection<Filter> filters)
        {
            return filters.Count > 0 
                ? $"{entityType}_by_{filters.First().FieldNames.First()}_table" 
                : $"{entityType}_table";
        }
    }
}