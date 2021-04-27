using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.Analyzer
{
    internal class WorkPlanBuilder
    {
        private readonly Dictionary<string, SelectQueryJobBuilder> _databaseKeyToQueryJobBuilderMappings;
        private readonly Dictionary<string, WorkPlanBuilder> _complexFieldNameToWorkPlanBuilderMappings;
        private readonly IAnalyzerConfigurationProvider _analyzerConfigurationProvider;
        private readonly IDbHandlersResolver _dbHandlersResolver;

        private (string fieldFrom, string fieldTo, string transformedEntityName)? _transformInfo;

        public WorkPlanBuilder(IDbHandlersResolver dbHandlersResolver,
            IAnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
            _databaseKeyToQueryJobBuilderMappings = new Dictionary<string, SelectQueryJobBuilder>();
            _complexFieldNameToWorkPlanBuilderMappings = new Dictionary<string, WorkPlanBuilder>(StringComparer.OrdinalIgnoreCase);
        }

        public void AddFilter(string entityType, Filter filter)
        {
            if (filter.FieldNames.Count > 1)
            {
                var currentFieldName = filter.FieldNames.First();

                if (_complexFieldNameToWorkPlanBuilderMappings.ContainsKey(currentFieldName) == false)
                {
                    _complexFieldNameToWorkPlanBuilderMappings[currentFieldName] = new WorkPlanBuilder(_dbHandlersResolver, _analyzerConfigurationProvider);
                }

                var workPlanBuilder = _complexFieldNameToWorkPlanBuilderMappings[currentFieldName];

                var currentFieldEntityType =
                    _analyzerConfigurationProvider.GetField(entityType, currentFieldName).EntityName;
                workPlanBuilder.AddFilter(currentFieldEntityType, filter.GetNextFilter());
                return;
            }

            //todo please delete me
            //we assume that the guid is entered last
            if (filter.FieldNames.First() == StringConstants.Guid)
            {
                foreach (var job in _databaseKeyToQueryJobBuilderMappings.Values)
                {
                    job.AddFilter(filter);
                }

                return;
            }

            //todo add to all fields
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, filter.FieldNames.Single());
            queryJobBuilder.AddFilter(filter);
        }

        public void AddTransform(string fieldFrom, string fieldTo, string transformedEntity)
        {
            _transformInfo = (fieldFrom, fieldTo, transformedEntity);
        }

        public void AddSimpleProjectionField(string entityType, string fieldName)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, fieldName);
            queryJobBuilder.AddProjectionSimpleField(fieldName);
        }

        public void AddSubQueriedWorkPlan(Filter filter, string guid, WorkPlan workPlan, string entityType)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, filter.FieldNames.Single());

            queryJobBuilder.AddWorkPlan(guid, workPlan);
        }

        public WorkPlan Build(Dictionary<string, WorkPlan> subQueryWorkPlans)
        {
            var primitiveFieldsJobs = new List<Job>(_databaseKeyToQueryJobBuilderMappings.Values.Select(builder => builder.Build()));
            var allJobs = new List<Job>(primitiveFieldsJobs);
            var complexFieldsToWorkPlan = new Dictionary<string, WorkPlan>();
            foreach (var complexFieldName in _complexFieldNameToWorkPlanBuilderMappings.Keys)
            {
                var workPlan = _complexFieldNameToWorkPlanBuilderMappings[complexFieldName].Build(subQueryWorkPlans);//todo check//todo solve problem with subqueries
                if (workPlan.Jobs.Any() == false)
                {
                    continue;
                }
                complexFieldsToWorkPlan[complexFieldName] = workPlan;
                allJobs.AddRange(workPlan.Jobs);
            }

            if (primitiveFieldsJobs.Count > 1 || complexFieldsToWorkPlan.Any())
            {
                var unionQueryJob = new UnionQueryJob(primitiveFieldsJobs, complexFieldsToWorkPlan);
                allJobs.Add(unionQueryJob);
            }

            if (_transformInfo != null)
            {
                var info = _transformInfo.Value;
                allJobs.Add(new TransformJob(info.fieldFrom, info.fieldTo, info.transformedEntityName, allJobs.Last()));
            }
            return new WorkPlan(allJobs, subQueryWorkPlans);
        }

        private SelectQueryJobBuilder GetOrCreateQueryJobBuilder(string entityType, string fieldName)
        {
            var fieldDatabaseKey = _analyzerConfigurationProvider.GetFieldDatabaseKey(entityType, fieldName);
            if (_databaseKeyToQueryJobBuilderMappings.ContainsKey(fieldDatabaseKey) == false)
            {
                var dbHandler = _dbHandlersResolver.ResolveDbHandler(fieldDatabaseKey);
                _databaseKeyToQueryJobBuilderMappings.Add(fieldDatabaseKey,
                    new SelectQueryJobBuilder(entityType, dbHandler));
            }

            return _databaseKeyToQueryJobBuilderMappings[fieldDatabaseKey];
        }

        public void AddProjectionComplexField(string entityType, Field field,
            Include includedFields)
        {
            if (_complexFieldNameToWorkPlanBuilderMappings.ContainsKey(field.Name) == false)
            {
                _complexFieldNameToWorkPlanBuilderMappings[field.Name] = new WorkPlanBuilder(_dbHandlersResolver, _analyzerConfigurationProvider);
            }

            var workPlanBuilder = _complexFieldNameToWorkPlanBuilderMappings[field.Name];


            //todo remove duplicate code pattern
            foreach (var includedFieldsField in includedFields.Fields ?? Enumerable.Empty<string>())
            {
                if (_analyzerConfigurationProvider.IsComplexField(field.EntityName, includedFieldsField))//todo please don't commit me please!!!!
                {
                    var fieldDetails = _analyzerConfigurationProvider.GetField(field.EntityName, includedFieldsField);
                    workPlanBuilder.AddProjectionComplexField(fieldDetails.EntityName, fieldDetails, includedFields.Includes.Single(x => x.Name.Equals(includedFieldsField, StringComparison.OrdinalIgnoreCase)));
                }
                else
                {
                    workPlanBuilder.AddSimpleProjectionField(field.EntityName, includedFieldsField);
                }
            }


            if (IsConnectionInEntityDb())
            {
                var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, field.Name);
                //fieldToSelect is empty because we want to query only the Guids
                queryJobBuilder.AddProjectionComplexField(entityType, field, new List<string>());//todo consider removing the list

                var futureJob = queryJobBuilder.GetFutureJob();

                //futureJob.Result.Result.EntityResults["friend"].Fields.Keys;
                var fieldNames = new List<string>
                {
                    StringConstants.Guid
                };
                var filter = new InFilter(fieldNames, null, false)
                {
                    CalcValue = CalcValueFunc
                };
                workPlanBuilder.AddFilter(entityType, filter);

                IEnumerable<string> CalcValueFunc()
                {
                    if (futureJob.IsCompleted == false)
                    {
                        throw new Exception("Job wasn't created yet!");
                    }

                    var queryJob = futureJob.Result;
                    if (queryJob.HasExecuted == false)
                    {
                        throw new Exception("Job Wasn't executed yet!");
                    }

                    var jobResult = queryJob.Result;

                    return jobResult.EntityResults.Values.Select(x => x.Fields[field.Name]).Cast<Dictionary<string, EntityResult>>().SelectMany(x => x.Keys);
                }
            }
            else
            {
                var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, field.Name);
                var futureJob = queryJobBuilder.GetFutureJob();

                //add projection
                var connectedToField = _analyzerConfigurationProvider.GetField(field.EntityName, field.ConnectedToField);
                workPlanBuilder.AddProjectionComplexField(field.EntityName, connectedToField, new Include());

                //add filter
                var fieldNames = new List<string>
                {
                    field.ConnectedToField
                };

                var filter = new InFilter(fieldNames, null, false)
                {
                    CalcValue = CalcValueFunc
                };
                workPlanBuilder.AddFilter(field.EntityName, filter);

                //add transform
                workPlanBuilder.AddTransform(connectedToField.Name, field.Name, field.EntityName);


                IEnumerable<string> CalcValueFunc()
                {
                    if (futureJob.IsCompleted == false)
                    {
                        throw new Exception("Job wasn't created yet!");
                    }

                    var queryJob = futureJob.Result;
                    if (queryJob.HasExecuted == false)
                    {
                        throw new Exception("Job Wasn't executed yet!");
                    }

                    var jobResult = queryJob.Result;

                    return jobResult.EntityResults.Keys;
                }
            }


            bool IsConnectionInEntityDb()
            {
                return entityType == "student";
            }




            //same DB optimization
            //var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, field.Name);
            //queryJobBuilder.AddProjectionComplexField(entityType, field,
            //    includedFields); //todo yonatan will make sure included fields are exists and simple
            ////todo yonatan will make sure entities are in the same db
        }
    }
}