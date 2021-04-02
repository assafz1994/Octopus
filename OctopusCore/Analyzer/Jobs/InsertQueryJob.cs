using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;

namespace OctopusCore.Analyzer.Jobs
{
    internal class InsertQueryJob : Job
    {
        private readonly IDbHandler _dbHandler;
        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }
        public string EntityType;
        public Dictionary<string, dynamic> Fields { get; set; }
        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            throw new NotImplementedException();
        }

    }
}
