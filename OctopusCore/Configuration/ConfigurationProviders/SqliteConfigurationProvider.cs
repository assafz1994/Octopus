using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Configuration.ConfigurationProviders
{
    public class SqliteConfigurationProvider
    {
        
        public string ConnectionString { get;}
        public SqliteConfigurationProvider(Scheme scheme, DbConfiguration dbConfiguration) 
        {
            ConnectionString = dbConfiguration.ConnectionString;
        }

        public string GetTableName(string entityType)
        {
            return entityType + "_table";
        }
    }
}
