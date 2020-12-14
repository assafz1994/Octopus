using System;
using System.Threading.Tasks;
using OctopusCore.Analyzer;
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

        public async Task ExecuteQuery(string query)
        {
            
            var queryInfo = await _parser.ParseQuery(query);
            var workPlan = _analyzer.AnalyzeQuery(queryInfo);
            var result = await _executor.ExecuteWorkPlanAsync(workPlan);

            //todo return execution result 
            throw new NotImplementedException();
        }
    }
}