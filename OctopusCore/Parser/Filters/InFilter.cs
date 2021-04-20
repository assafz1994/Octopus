using System.Collections.Generic;

namespace OctopusCore.Parser.Filters
{
    public class InFilter:Filter
    {
        public override FilterType Type { get; } = FilterType.In;
    }
}