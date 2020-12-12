using System.Collections.Generic;

namespace OctopusCore.Parser
{
    public class Field
    {
        public string Name { get; set; }

        public List<Field> Include { get; set; }

    }
}