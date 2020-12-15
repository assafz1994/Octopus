using System;
using System.Threading.Tasks;
using OctopusCore.Configuration;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    public class Analyzer : IAnalyzer
    {
        private readonly IDatabaseConfigurationManager _databaseConfigurationManager;

        public Analyzer(IDatabaseConfigurationManager databaseConfigurationManager)
        {
            _databaseConfigurationManager = databaseConfigurationManager;
        }

        public WorkPlan AnalyzeQuery(QueryInfo queryInfo)
        {
            if (!(queryInfo is SelectQueryInfo selectQueryInfo))
            {
                throw new Exception("Unsupported query type");
            }

            var workPlanBuilder = new WorkPlanBuilder(_databaseConfigurationManager, selectQueryInfo.Entity);

            foreach (var queryFilter in selectQueryInfo.Filters)
            {
                workPlanBuilder.AddFilter(queryFilter);
            }

            foreach (var field in selectQueryInfo.Fields)
            {
                workPlanBuilder.AddProjectionField(field);
            }

            return workPlanBuilder.Build();
        }
    }
}