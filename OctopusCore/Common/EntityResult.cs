using System;
using System.Collections.Generic;
using System.Linq;
using Neo4jClient.Extensions;

namespace OctopusCore.Contract
{
    public class EntityResult
    {

        public Dictionary<string, dynamic> Fields { get; set; }

        public EntityResult(Dictionary<string, dynamic> fields)
        {
            Fields = fields.ToDictionary(x=>x.Key,x=>x.Value,StringComparer.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is EntityResult)) return false;
            var entityResult = (EntityResult)obj;
            var thisFields = Fields.ToList();
            var objFields = entityResult.Fields.ToList();
            return thisFields.ContentsEqual(objFields);
        }

    }
}
