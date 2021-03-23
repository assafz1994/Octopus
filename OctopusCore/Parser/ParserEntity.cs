using System;
using System.Collections.Generic;
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
    }
}
