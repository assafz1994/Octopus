using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Parser
{
    public class ParserEntity
    {
        public string EntityType;
        public Dictionary<string, dynamic> Fields { get; set; }

        public ParserEntity(string entityType, Dictionary<string, dynamic> fields)
        {
            EntityType = entityType;
            Fields = fields;
        }
    }
}
