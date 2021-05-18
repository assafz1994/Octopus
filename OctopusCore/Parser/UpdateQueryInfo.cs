using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    public class UpdateQueryInfo : QueryInfo
    {
        public string Entity { get; set; }
        public string EntityRep { get; set; }
        public Dictionary<string, string> EntityToSubQuery;
        public Dictionary<string, string> EntityRepToEntityType;
        public List<string> Fields;
        public dynamic Value;

        public UpdateQueryInfo(string entity,
            string entityRep,
            Dictionary<string, string> entityToSubQuery, 
            Dictionary<string, string> entityRepToEntityType,
            List<string> fields,
            dynamic value,
            Dictionary<string, QueryInfo> subQueries)
        {
            SubQueries = subQueries;
            Entity = entity;
            EntityRep = entityRep;
            EntityRepToEntityType = entityRepToEntityType;
            EntityToSubQuery = entityToSubQuery;
            Fields = fields;
            Value = value;
        }

        public UpdateQueryInfo()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is UpdateQueryInfo updateQueryInfo)) return false;
            return Entity.Equals(updateQueryInfo.Entity) &&
                   EntityRep.Equals(updateQueryInfo.EntityRep) &&
                   Fields.SequenceEqual(updateQueryInfo.Fields) &&
                   EntityToSubQuery.Keys.SequenceEqual(updateQueryInfo.EntityToSubQuery.Keys) &&
                   EntityRepToEntityType.OrderBy(kv => kv.Key).ToList()
                       .SequenceEqual(updateQueryInfo.EntityRepToEntityType.OrderBy(kv => kv.Key).ToList()) &&
                   SubQueries.Values.SequenceEqual(updateQueryInfo.SubQueries.Values);

        }
    }
}
