using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    internal class WorkPlanBuilder
    {
        private readonly Dictionary<string, SelectQueryJobBuilder> _databaseKeyToQueryJobBuilderMappings;
        private readonly IAnalyzerConfigurationProvider _analyzerConfigurationProvider;
        private readonly IDbHandlersResolver _dbHandlersResolver;

        public WorkPlanBuilder(IDbHandlersResolver dbHandlersResolver,
            IAnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
            _databaseKeyToQueryJobBuilderMappings = new Dictionary<string, SelectQueryJobBuilder>();
        }

        public void AddFilter(string entityType, Filter filter)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, filter.FieldNames.Single());
            queryJobBuilder.AddFilter(filter);
        }

        public void AddSimpleProjectionField(string entityType, string fieldName)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, fieldName);
            queryJobBuilder.AddProjectionSimpleField(entityType, fieldName);
        }

        public void AddSubQueriedWorkPlan(Filter filter, string guid, WorkPlan workPlan, string entityType)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, filter.FieldNames.Single());

            queryJobBuilder.AddWorkPlan(guid, workPlan);
        }

        public WorkPlan Build(Dictionary<string, WorkPlan> subQueryWorkPlans)
        {
            var jobs = new List<Job>(_databaseKeyToQueryJobBuilderMappings.Values.Select(builder => builder.Build()));
            if (jobs.Count > 1)
            {
                var unionQueryJob = new UnionQueryJob(new List<Job>(jobs));
                jobs.Add(unionQueryJob);
            }

            return new WorkPlan(jobs, subQueryWorkPlans);
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

        public void AddProjectionComplexField(string entityType, string field, string fieldEntityType,
            List<string> includedFields)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(entityType, field);
            queryJobBuilder.AddProjectionComplexField(entityType, fieldEntityType, field,
                includedFields); //todo assaf will make sure included fields are exists and simple
            //todo assaf will make sure entities are in the same db
        }
    }
}