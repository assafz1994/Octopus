using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient.Extensions;

namespace OctopusCore.Contract
{
    public class ExecutionResult
    {
        public string Type { get; set; }
        public Dictionary<string, EntityResult> EntityResults { get; set; } // guid -> entity 
        public ExecutionResult(string type, Dictionary<string, EntityResult> entityResults)
        {
            Type = type;
            EntityResults = entityResults;
        }

        public List<Dictionary<string, dynamic>> GetFields()
        {
            return EntityResults.Values.Select(x => x.Fields).ToList();
        }

        private string GetEntityString(EntityResult entityResult)
        {
            var entityStringBuilder = new StringBuilder();
            foreach (var keyValue in entityResult.Fields)
            {
                entityStringBuilder.Append($"{keyValue.Key}={keyValue.Value} ");
            }

            return entityStringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is ExecutionResult)) return false;
            var executionResult = (ExecutionResult)obj;
            var thisEntityResults = EntityResults.ToList();
            var objEntityResults = executionResult.EntityResults.ToList();
            return executionResult.Type.Equals(Type) && thisEntityResults.ContentsEqual(objEntityResults);
        }
    }
}