using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OctopusCore.Analyzer;
using OctopusCore.Contract;
using OctopusCore.Executor;
using OctopusCore.Parser;

namespace OctopusCore
{
    public class OctopusService : IOctopusService
    {
        private readonly IAnalyzer _analyzer;
        private readonly IExecutor _executor;
        private readonly IParser _parser;

        public OctopusService(IParser parser, IAnalyzer analyzer, IExecutor executor)
        {
            _parser = parser;
            _analyzer = analyzer;
            _executor = executor;
        }

        public async Task<string> ExecuteQueryAsync(string query)
        {
            try
            {
                var queryInfo = await _parser.ParseQuery(query);
                var workPlan = _analyzer.AnalyzeQuery(queryInfo);

                var executionResult = await _executor.ExecuteWorkPlanAsync(workPlan);
                return JsonConvert.SerializeObject(new {isSuccessful = true, result = executionResult.GetFields()});
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new {isSuccessful = false, message = ex.Message});
            }

          
        }
    }
}