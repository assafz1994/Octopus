using System;
using System.Collections.Generic;
using System.Text;
using OctopusCore.Analyzer;
using OctopusCore.Executor;
using OctopusCore.Parser;

namespace OctopusCore
{
    public class OctopusService : IOctopusService
    {
        private readonly IParser _parser;
        private readonly IAnalyzer _analyzer;
        private readonly IExecutor _executor;

        public OctopusService(IParser parser, IAnalyzer analyzer, IExecutor executor)
        {
            _parser = parser;
            _analyzer = analyzer;
            _executor = executor;
        }

        public void ExecuteQuery(string query)
        {
            //todo 
            var queryInfo = _parser.ParseQuery(query);
            var workPlan = _analyzer.AnalyzeQuery(queryInfo);
            var result = _executor.ExecuteWorkPlan(workPlan);

            //todo return execution result 
            throw new NotImplementedException();
        }
    }
}
