using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore.Executor
{
    public class Executor:IExecutor
    {
        public Task<ExecutionResult> ExecuteWorkPlanAsync(WorkPlan workPlan)
        {
            throw new NotImplementedException();
        }
    }
}
