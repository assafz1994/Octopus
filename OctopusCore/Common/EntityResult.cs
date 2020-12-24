using System.Collections.Generic;

namespace OctopusCore.Contract
{
    public class EntityResult
    {

        public Dictionary<string, dynamic> Fields { get; set; }

        public EntityResult(Dictionary<string, dynamic> fields)
        {
            Fields = fields;
        }

    }
}
