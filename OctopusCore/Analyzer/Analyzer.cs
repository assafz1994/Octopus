using System;
using System.Linq;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    public class Analyzer : IAnalyzer
    {

        private IDbHandlersResolver _dbHandlersResolver;
        private IAnalyzerConfigurationProvider _analyzerConfigurationProvider;

        public Analyzer(IDbHandlersResolver dbHandlersResolver ,IAnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
        }

        public WorkPlan AnalyzeQuery(QueryInfo queryInfo)
        {
            if (!(queryInfo is SelectQueryInfo selectQueryInfo)) throw new Exception("Unsupported query type");

            var workPlanBuilder = new WorkPlanBuilder(_dbHandlersResolver,_analyzerConfigurationProvider, selectQueryInfo.Entity);

            foreach (var queryFilter in selectQueryInfo.Filters ?? Enumerable.Empty<Filter>())
                workPlanBuilder.AddFilter(queryFilter);

            foreach (var field in selectQueryInfo.Fields ?? Enumerable.Empty<string>())
                workPlanBuilder.AddProjectionField(field);

            return workPlanBuilder.Build();
        }
    }
}