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
        private readonly Dictionary<string, QueryJobBuilder> _databaseKeyToQueryJobBuilderMappings;
        private readonly string _entityType;
        private readonly IAnalyzerConfigurationProvider _analyzerConfigurationProvider;
        private readonly IDbHandlersResolver _dbHandlersResolver;

        public WorkPlanBuilder(IDbHandlersResolver dbHandlersResolver,
            IAnalyzerConfigurationProvider analyzerConfigurationProvider, string entityType)
        {
            _entityType = entityType;
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;

            _databaseKeyToQueryJobBuilderMappings = new Dictionary<string, QueryJobBuilder>();
        }

        public void AddFilter(Filter filter)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(filter.FieldNames.Single());
            queryJobBuilder.AddFilter(filter);
        }

        public void AddProjectionField(string fieldName)
        {
            var queryJobBuilder = GetOrCreateQueryJobBuilder(fieldName);
            queryJobBuilder.AddProjectionField(fieldName);
        }

        public WorkPlan Build()
        {
            var jobs = new List<Job>(_databaseKeyToQueryJobBuilderMappings.Values.Select(builder => builder.Build()));
            if (jobs.Count > 1)
            {
                var unionQueryJob = new UnionQueryJob(jobs);
                jobs.Add(unionQueryJob);
            }

            return new WorkPlan(jobs);
        }

        private QueryJobBuilder GetOrCreateQueryJobBuilder(string fieldName)
        {
            var fieldDatabaseKey = _analyzerConfigurationProvider.GetFieldDatabaseKey(_entityType, fieldName);
            if (_databaseKeyToQueryJobBuilderMappings.ContainsKey(fieldDatabaseKey) == false)
            {
                var dbHandler = _dbHandlersResolver.ResolveDbHandler(fieldDatabaseKey);
                _databaseKeyToQueryJobBuilderMappings.Add(fieldDatabaseKey,
                    new QueryJobBuilder(dbHandler, _entityType));
            }

            return _databaseKeyToQueryJobBuilderMappings[fieldDatabaseKey];
        }
    }
}