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
            var jobsEntityResults = Jobs.SelectMany(x => x.Result.EntityResults);
            var outputEntityResult = new Dictionary<string, EntityResult>();
            
            // go through all the guids and entityResults that are in all the jobs received
            foreach (var guidToEntityResult in jobsEntityResults)
            {
                // if it's the first time to encounter this object, add it to the dictionary
                if (!outputEntityResult.ContainsKey(guidToEntityResult.Key))
                {
                    outputEntityResult[guidToEntityResult.Key] = new EntityResult(new Dictionary<string, dynamic>());
                }
                // add all the fields to the output object
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
