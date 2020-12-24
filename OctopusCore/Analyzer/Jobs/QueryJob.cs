using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;
using System.Linq;

namespace OctopusCore.Analyzer.Jobs
{
    internal class QueryJob : Job
    {
        private readonly IDbHandler _dbHandler;

        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }

        public QueryJob(IDbHandler dbHandler, IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType, Dictionary<string, WorkPlan> subQueryWorkPlans)
        {
            _dbHandler = dbHandler;
            FieldsToSelect = fieldsToSelect;
            Filters = filters;
            EntityType = entityType;
            SubQueryWorkPlans = subQueryWorkPlans;
        }

        public IReadOnlyCollection<string> FieldsToSelect { get; }
        public IReadOnlyCollection<Filter> Filters { get; }
        public string EntityType { get; }


        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            foreach (var filter in Filters)
            {
                if (filter.IsSubQueried)
                {
                    filter.Expression = SubQueryWorkPlans[filter.Expression].Jobs.Last().Result.EntityResults.Values.First().Fields.Values.First().ToString();
                }
            }
            return _dbHandler.ExecuteQueryWithFiltersAsync(FieldsToSelect, Filters, EntityType);
        }
    }
}