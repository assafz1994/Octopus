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
            var workPlanBuilder = new WorkPlanBuilder(_databaseConfigurationManager, queryInfo.Entity);

            foreach (var queryFilter in queryInfo.Filters)
            {
                workPlanBuilder.AddFilter(queryFilter);
            }

            foreach (var field in queryInfo.Projection)
            {
                workPlanBuilder.AddProjectionField(field);
            }

            return workPlanBuilder.Build();
        }
    }
}