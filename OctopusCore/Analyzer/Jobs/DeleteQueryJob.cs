using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;

namespace OctopusCore.Analyzer.Jobs
{
    class DeleteQueryJob : Job
    {
        private readonly IDbHandler _dbHandler;

        public DeleteQueryJob(IDbHandler dbHandler, string entity, WorkPlan subQueryWorkPlan)
        {
            _dbHandler = dbHandler;
            Entity = entity;
            SubQueryWorkPlan = subQueryWorkPlan;
        }

        public WorkPlan SubQueryWorkPlan { get; set; }
        public string Entity { get; }

        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
