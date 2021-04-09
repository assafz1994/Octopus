using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Parser
{
    class DeleteQueryInfo : QueryInfo
    {
        public DeleteQueryInfo()
        {
            SubQueries = new Dictionary<string, QueryInfo>();
        }
    }
}
