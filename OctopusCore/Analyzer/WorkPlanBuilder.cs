using System;
using System.Collections.Generic;
using System.Linq;
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
            var queryJobs = _databaseKeyToQueryJobBuilderMappings.Values.Select(builder => builder.Build()).ToList();
            if (queryJobs.Count > 1) throw new Exception("Query an entity from multiple DBs is not supported");

            return new WorkPlan(queryJobs);
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