using System.Threading.Tasks;
using OctopusCore.Analyzer;
using OctopusCore.Contract;

namespace OctopusCore.Executor
{
    public interface IExecutor
    {
        Task<ExecutionResult> ExecuteWorkPlanAsync(WorkPlan workPlan);
    }
}