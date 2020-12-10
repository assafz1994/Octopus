using OctopusCore.Analyzer;
using OctopusCore.Contract;

namespace OctopusCore.Executor
{
    public interface IExecutor
    {
        ExecutionResult ExecuteWorkPlan(WorkPlan workPlan);
    }
}