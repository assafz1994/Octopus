using System.Collections.Generic;
using System.Linq;
using OctopusCore.Parser;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class CassandraConfigurationProvider
    {
        public string ConnectionString { get; }
        public string KeySpace { get; }
        public List<Entity> Entities { get; set; }
        public CassandraConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
            KeySpace = dbConfiguration.KeySpace;
            Entities = dbConfiguration.Entities;
        }

        public string GetTableName(string entityType, IReadOnlyCollection<Filter> filters)
        {
            if (filters.Count == 0) return $"{entityType}_table";
            var tableByField = Entities.First(x => x.Name.Equals(entityType)).Fields;
            return filters.Count > 0 
                ? $"{entityType}_by_{filters.First().FieldNames.First()}_table" 
                : $"{entityType}_table";
        }
    }
}