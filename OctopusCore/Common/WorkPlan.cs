using System.Collections.Concurrent;
using System.Collections.Generic;
using OctopusCore.Analyzer.Jobs;

namespace OctopusCore.Contract
{
    public class WorkPlan
    {
        public IReadOnlyDictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }
        public IReadOnlyCollection<Job> Jobs { get; }

        public WorkPlan(IReadOnlyCollection<Job> jobs, IReadOnlyDictionary<string, WorkPlan> subQueryWorkPlans)
        {
            Jobs = jobs;
            SubQueryWorkPlans = subQueryWorkPlans;
        }
    }
}