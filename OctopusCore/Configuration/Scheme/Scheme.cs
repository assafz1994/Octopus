using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OctopusCore.Configuration
{
    public class Scheme
    {
        public List<Entity> Entities { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
        public List<List<string>> TablesByFields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DbFieldType Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]

        public PrimitiveType PrimitiveType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EntityName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectedToField { get; set; }
    }
}