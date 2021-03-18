using System;
using System.Collections.Generic;
using OctopusCore.Parser.Filters;

namespace OctopusCore.Parser
{
    public abstract class Filter
    {
        public List<string> FieldNames { get; set; }

        public string Expression { get; set; }
        
        public bool IsSubQueried { get; set; }

        public abstract FilterType Type { get; }
    }
}