namespace OctopusCore.Contract
{
    public class ExecutionResult{

        public List<Dictionary<string, object>> ListOfFieldsToValueMap { get; set; }
        public ExecutionResult(List<Dictionary<string,object>> listOfFieldsToValueMap)
        {
            ListOfFieldsToValueMap = listOfFieldsToValueMap;
        }

        public ExecutionResult()
        {
            
        }
    }
}