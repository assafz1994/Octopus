using System.Collections.Generic;

namespace OctopusCore.Parser
{
    public abstract class Filter
    {
        public List<string> FieldNames { get; set; }

        public string Expression { get; set; }
    }
}