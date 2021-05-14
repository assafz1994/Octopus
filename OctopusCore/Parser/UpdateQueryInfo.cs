using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    class UpdateQueryInfo : QueryInfo
    {
        public string Entity { get; set; }
        public Dictionary<string, string> EntityToSubQuery;
        public Dictionary<string, string> EntityRepToEntityType;
        public List<string> Fields;
        public dynamic Value;
        public UpdateQueryInfo()
        {
            SubQueries = new Dictionary<string, QueryInfo>();
            EntityToSubQuery = new Dictionary<string, string>();
        }

        public UpdateQueryInfo(string entity, 
            Dictionary<string, string> entityToSubQuery, 
            Dictionary<string, string> entityRepToEntityType,
            List<string> fields,
            dynamic value,
            Dictionary<string, QueryInfo> subQueries)
        {
            SubQueries = subQueries;
            Entity = entity;
            EntityRepToEntityType = entityRepToEntityType;
            EntityToSubQuery = entityToSubQuery;
            Fields = fields;
            Value = value;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is UpdateQueryInfo updateQueryInfo)) return false;
            return SubQueries.Values.SequenceEqual(updateQueryInfo.SubQueries.Values);

        }
    }
}
