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
        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }

        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            throw new NotImplementedException();
        }
    }
}
