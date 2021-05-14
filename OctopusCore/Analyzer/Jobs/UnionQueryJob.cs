using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;

namespace OctopusCore.Analyzer.Jobs
{
    internal class UnionQueryJob : Job
    {
        private readonly List<Job> _primitiveFieldsJobs;
        private readonly Dictionary<string, WorkPlan> _complexFieldsToWorkPlan;
        private readonly IAnalyzerConfigurationProvider _configurationProvider;
        private readonly string _entityType;

        public UnionQueryJob(IAnalyzerConfigurationProvider configurationProvider, string entityType, List<Job> primitiveFieldsJobs, Dictionary<string, WorkPlan> complexFieldsToWorkPlan)
        {
            _configurationProvider = configurationProvider;
            _primitiveFieldsJobs = primitiveFieldsJobs;
            _complexFieldsToWorkPlan = complexFieldsToWorkPlan;
            _entityType = entityType;
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
                var currentWorkPlan = _complexFieldsToWorkPlan[complexFieldName];
                var complexFieldResult = currentWorkPlan.Jobs.Last().Result.EntityResults;
                var entitiesToRemove = new List<string>();
                var complexField = _configurationProvider.GetField(_entityType, complexFieldName);
                foreach (var outputEntityGuid in outputEntityResult.Keys)
                {
                    var entityFields = outputEntityResult[outputEntityGuid].Fields;
                    if (entityFields.ContainsKey(complexFieldName) == false)
                    {
                        if (complexFieldResult.ContainsKey(outputEntityGuid))
                        {
                            if (complexField.Type == DbFieldType.Array)
                            {
                                entityFields[complexFieldName] = ((Dictionary<string, EntityResult>)complexFieldResult[outputEntityGuid].Fields[complexFieldName]).Select(x=>x.Value.Fields);
                            }
                            else
                            {
                                entityFields[complexFieldName] = ((Dictionary<string, EntityResult>)complexFieldResult[outputEntityGuid].Fields[complexFieldName]).First().Value.Fields;
                            }
                        }
                        else
                        {
                            entitiesToRemove.Add(outputEntityGuid);
                        }
                    }
                    else
                    {
                        var complexFieldEntities = ((Dictionary<string, EntityResult>)entityFields[complexFieldName]);
                        var entitiesList = new List<dynamic>();//the entity list that will be returned as the value of the complex field
                        foreach (var complexEntityGuid in complexFieldEntities.Keys)
                        {
                            if (complexFieldResult.ContainsKey(complexEntityGuid))
                            {
                                entitiesList.Add(complexFieldResult[complexEntityGuid].Fields);
                            }
                            else
                            {
                                //if the guid is not present in the complex field results, we should remove the entire entity from the outputEntityResult.
                                //it can happens when an entity is filtered in the complex field query
                                entitiesToRemove.Add(outputEntityGuid);
                            }
                        }
                        if (complexField.Type == DbFieldType.Array)
                        {
                            entityFields[complexFieldName] = entitiesList;
                        }
                        else
                        {
                            entityFields[complexFieldName] = entitiesList.FirstOrDefault();
                        }
                    }


                }

                foreach (var entityToRemove in entitiesToRemove)
                {
                    outputEntityResult.Remove(entityToRemove);
                }
            }

            var executionResult = new ExecutionResult(_primitiveFieldsJobs.First().Result.Type, outputEntityResult);
            return Task.FromResult(executionResult);
        }
    }
}
