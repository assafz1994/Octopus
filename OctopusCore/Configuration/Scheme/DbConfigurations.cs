using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OctopusCore.Configuration
{
    public class DbConfigurations
    {
        public List<DbConfiguration> Configurations { get; set; }
    }

    public class DbConfiguration
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]

        public DbType DbType { get; set; }

        public string ConnectionString { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Entity> Entities { get; set; }
    }
}