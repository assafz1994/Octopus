using System;
using System.Collections.Generic;
using System.Linq;
using Neo4jClient.Extensions;
using Newtonsoft.Json;

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
            var thisFields = Fields.OrderBy(kvp => kvp.Key).ToList();
            var objFields = entityResult.Fields.OrderBy(kvp => kvp.Key).ToList();
            var thisFieldsJson = JsonConvert.SerializeObject(thisFields);
            var objFieldsJson = JsonConvert.SerializeObject(objFields);
            return thisFieldsJson.Equals(objFieldsJson);
        }

    }
}
