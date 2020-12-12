using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Parser
{
    public class SelectQueryInfo : QueryInfo
    {
        public string Entity { get; set; }
        public List<Filter> Filters { get; set; }
        public List<string> NestedProperty { get; set; }
        public List<string> Fields { get; set; }
        public List<Include> Includes { get; set; }
    }
}
