using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Common;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;

namespace OctopusCore.Analyzer.Jobs
{
    class DeleteQueryJob : Job
    {
        private readonly IDbHandler _dbHandler;

        public DeleteQueryJob(IDbHandler dbHandler, string entityType, Dictionary<string, WorkPlan> subQueryWorkPlans)
        {
            _dbHandler = dbHandler;
            EntityType = entityType;
            SubQueryWorkPlans = subQueryWorkPlans;
        }

        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }
        public string EntityType { get; }

        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            var result = SubQueryWorkPlans.Values.First().Jobs.Last().Result;
            var guids = result.EntityResults.Values.Select(x => (string)x.Fields[StringConstants.Guid].ToString()).ToList();
            return _dbHandler.ExecuteDeleteQuery(EntityType, guids);
        }
    }
}
