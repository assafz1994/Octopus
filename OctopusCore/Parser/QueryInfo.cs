using System.Collections.Generic;

namespace OctopusCore.Parser
{
    public abstract class QueryInfo
    {
        public Dictionary<string, QueryInfo> SubQueries { get; set; }
    }
}