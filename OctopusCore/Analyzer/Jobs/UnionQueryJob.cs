using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore.Analyzer.Jobs
{
    internal class UnionQueryJob : Job
    {
        public List<Job> Jobs { get; set; }

        public UnionQueryJob(List<Job> jobs)
        {
            Jobs = jobs;
        }
        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            var jobsEntityResults = Jobs.Select(x => x.Result.EntityResults);
            var hashSet = new HashSet<string>(jobsEntityResults.First().Keys);
            // get guids that are in all of the results
            foreach (var entityResult in jobsEntityResults)
            {
                hashSet.IntersectWith(entityResult.Keys);    
            }
            var intersection = hashSet.ToList();
            var outputEntityResult = intersection.ToDictionary(guid => guid, guid => new EntityResult(new Dictionary<string, object>()));
            // go through entities that are in all of the results
            foreach (var guidToEntityResult in jobsEntityResults.SelectMany(x => x))
            {
                if (!intersection.Contains(guidToEntityResult.Key)) continue;
                foreach (var field in guidToEntityResult.Value.Fields)
                {
                    outputEntityResult[guidToEntityResult.Key].Fields.Add(field.Key, field.Value);
                }
            }
            var executionResult = new ExecutionResult(Jobs.First().Result.Type, outputEntityResult);
            return Task.FromResult(executionResult);
        }
    }
}
