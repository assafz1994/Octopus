using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    public class ParserEntity
    {
        public string EntityType;
        public string EntityName;
        public Dictionary<string, dynamic> Fields { get; set; }

        public ParserEntity(string entityType, string entityName, Dictionary<string, dynamic> fields)
        {
            EntityType = entityType;
            EntityName = entityName;
            Fields = fields;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is ParserEntity)) return false;
            var parserEntity = (ParserEntity)obj;
            if (!EntityType.Equals(parserEntity.EntityType) || !EntityName.Equals(parserEntity.EntityName))
                return false;
            if (Fields.Count != parserEntity.Fields.Count) return false;
            foreach (var field in Fields)
            {
                if (!parserEntity.Fields.TryGetValue(field.Key, out var value) || !field.Value.Equals(value)) return false;
            }

            return true;
        }
    }
}
