using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    class UpdateQueryInfo : QueryInfo
    {
        public string Entity { get; set; }
        public List<ParserEntity> ParserEntities { get; set; }
        public UpdateQueryInfo()
        {
            SubQueries = new Dictionary<string, QueryInfo>();
            ParserEntities = new List<ParserEntity>();
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
