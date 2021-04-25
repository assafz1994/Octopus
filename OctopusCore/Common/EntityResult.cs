using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Contract
{
    public class EntityResult
    {

        public Dictionary<string, dynamic> Fields { get; set; }

        public EntityResult(Dictionary<string, dynamic> fields)
        {
            Fields = fields.ToDictionary(x=>x.Key,x=>x.Value,StringComparer.OrdinalIgnoreCase);
        }

    }
}
