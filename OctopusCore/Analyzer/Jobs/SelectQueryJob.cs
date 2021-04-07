using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;
using System.Linq;
using OctopusCore.Configuration;

namespace OctopusCore.Analyzer.Jobs
{
    internal class SelectQueryJob : Job
    {
        private readonly IDbHandler _dbHandler;

        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }

        public SelectQueryJob(IDbHandler dbHandler, string entityType, IReadOnlyCollection<string> fieldsToSelect,
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples,
            IReadOnlyCollection<Filter> filters, Dictionary<string, WorkPlan> subQueryWorkPlans)
        {
            _dbHandler = dbHandler;
            FieldsToSelect = fieldsToSelect;
            JoinsTuples = joinsTuples;
            Filters = filters;
            SubQueryWorkPlans = subQueryWorkPlans;
            EntityType = entityType;
        }

        public IReadOnlyCollection<string> FieldsToSelect { get; }
        public List<(string entityType, Field field, List<string> fieldsToSelect)> JoinsTuples { get; }
        public IReadOnlyCollection<Filter> Filters { get; }
        public string EntityType { get; }



        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            foreach (var filter in Filters)
            {
                if (filter.IsSubQueried)
                {
                    var lastJob = SubQueryWorkPlans[(string) filter.Expression].Jobs.Last();
                    var expression = lastJob.Result.EntityResults.Values.First().Fields.Values.First();

                    if (expression is string)
                    {
                        expression = $"\"{expression}\"";
                    }

                    filter.Expression = expression;
                }
            }

            return _dbHandler.ExecuteQueryWithFiltersAsync(FieldsToSelect, Filters, EntityType,JoinsTuples);
        }
    }
}