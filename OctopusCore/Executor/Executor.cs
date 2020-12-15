using System.Linq;
using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore.Executor
{
    public class Executor : IExecutor
    {
        public async Task<ExecutionResult> ExecuteWorkPlanAsync(WorkPlan workPlan)
        {
            foreach (var job in workPlan.Jobs) await job.ExecuteAsync();

            return workPlan.Jobs.Last().Result as ExecutionResult;
        }
    }
}