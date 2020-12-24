using System.IO;
using Newtonsoft.Json;
using SchemeType = OctopusCore.Configuration.Scheme;
using DbConfigurationType = OctopusCore.Configuration.DbConfigurations;

namespace OctopusCore.Configuration
{
    public class ConfigurationAndSchemeReader
    {
        public ConfigurationAndSchemeReader(string configurationPath, string schemePath)
        {
            using var schemeFile = File.OpenText(schemePath);
            using var dbConfigurationsFile = File.OpenText(configurationPath);
            Scheme = JsonConvert.DeserializeObject<SchemeType>(schemeFile.ReadToEnd());
            DbConfigurations = JsonConvert.DeserializeObject<DbConfigurationType>(dbConfigurationsFile.ReadToEnd());
        }

        public SchemeType Scheme { get; }
        public DbConfigurationType DbConfigurations { get; }
    }
}