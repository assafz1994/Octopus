using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OctopusCore.Parser
{
    class DeleteQueryInfo : QueryInfo
    {
        public DeleteQueryInfo()
        {
            SubQueries = new Dictionary<string, QueryInfo>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is DeleteQueryInfo deleteQueryInfo)) return false;
            return SubQueries.Values.SequenceEqual(deleteQueryInfo.SubQueries.Values);

        }
    }
}
