using System.Collections.Generic;
using System.Text;

namespace OctopusCore.Contract
{
    public class ExecutionResult
    {

        public List<Dictionary<string, object>> ListOfFieldsToValueMap { get; set; }
        public ExecutionResult(List<Dictionary<string, object>> listOfFieldsToValueMap)
        {
            ListOfFieldsToValueMap = listOfFieldsToValueMap;
        }

        public override string ToString()//todo change the result format, this is just for a demo
        {
            if (ListOfFieldsToValueMap == null)
            {
                return "";
            }

            var stringBuilder = new StringBuilder();
            foreach (var entity in ListOfFieldsToValueMap)
            {
                stringBuilder.Append($"[{GetEntityString(entity)}]\n");
            }

            return stringBuilder.ToString();

        }

        private string GetEntityString(Dictionary<string, object> entity)
        {
            var entityStringBuilder = new StringBuilder();
            foreach (var keyValue in entity)
            {
                entityStringBuilder.Append($"{keyValue.Key}={keyValue.Value} ");
            }

            return entityStringBuilder.ToString();
        }
    }
}