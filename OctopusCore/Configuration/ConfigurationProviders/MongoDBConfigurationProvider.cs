using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    class MongoDBConfigurationProvider
    {
        public string ConnectionString { get; }
        public MongoDBConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration)
        {
            ConnectionString = dbConfiguration.ConnectionString;
        }

        public string GetTableName(string entityType)
        {
            return entityType + "_table";
        }
    }
}
