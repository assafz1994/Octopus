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
        private readonly List<Job> _primitiveFieldsJobs;
        private readonly Dictionary<string, WorkPlan> _complexFieldsToWorkPlan;

        public UnionQueryJob(List<Job> primitiveFieldsJobs, Dictionary<string, WorkPlan> complexFieldsToWorkPlan)
        {
            _primitiveFieldsJobs = primitiveFieldsJobs;
            _complexFieldsToWorkPlan = complexFieldsToWorkPlan;
        }
        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            var jobsEntityResults = _primitiveFieldsJobs.Select(x => x.Result.EntityResults).ToList();
            var intersections = new HashSet<string>(jobsEntityResults.First().Keys);
            // get guids that are in all of the results
            foreach (var entityResult in jobsEntityResults)
            {
                intersections.IntersectWith(entityResult.Keys);
            }
            var outputEntityResult = intersections.ToDictionary(guid => guid, guid => new EntityResult(new Dictionary<string, object>()));
            // go through entities that are in all of the results
            foreach (var guidToEntityResult in jobsEntityResults.SelectMany(x => x))
            {
                if (!intersections.Contains(guidToEntityResult.Key)) continue;
                foreach (var field in guidToEntityResult.Value.Fields)
                {
                    outputEntityResult[guidToEntityResult.Key].Fields.Add(field.Key, field.Value);
                }
            }

            foreach (var complexFieldName in _complexFieldsToWorkPlan.Keys)
            {
                var complexFieldResult = _complexFieldsToWorkPlan[complexFieldName].Jobs.Last().Result.EntityResults;
                foreach (var entityFields in outputEntityResult.Values)
                {
                    var complexEntityGuid = ((Dictionary<string,EntityResult>)entityFields.Fields[complexFieldName]).First().Key;//todo we use first because we assume it is not an array
                    entityFields.Fields[complexFieldName] = complexFieldResult[complexEntityGuid].Fields;
                }
            }
            
            var executionResult = new ExecutionResult(_primitiveFieldsJobs.First().Result.Type, outputEntityResult);
            return Task.FromResult(executionResult);
        }
    }
}
