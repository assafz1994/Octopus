using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Configuration.Scheme
{
    public class DbConfigurations
    {
        public List<DbConfiguration> Configurations { get; set; }
    }

    public class DbConfiguration
    {
        public string Id { get; set; }
        public string DbType { get; set; }
        public string ConnectionString { get; set; }
        public List<Entity> Entities { get; set; }
    }
}