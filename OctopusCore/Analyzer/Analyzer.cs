using System;
using System.Collections.Generic;
using System.Linq;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    public class Analyzer : IAnalyzer
    {

        private readonly IDbHandlersResolver _dbHandlersResolver;
        private readonly IAnalyzerConfigurationProvider _analyzerConfigurationProvider;

        public Analyzer(IDbHandlersResolver dbHandlersResolver, IAnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
        }

        public WorkPlan AnalyzeQuery(QueryInfo queryInfo)
        {
            return queryInfo switch
            {
                SelectQueryInfo selectQueryInfo => AnalyzeSelectQuery(selectQueryInfo),
                InsertQueryInfo insertQueryInfo => AnalyzeInsertQuery(insertQueryInfo),
                _ => throw new Exception("Unsupported query type")
            };
        }

        private WorkPlan AnalyzeSelectQuery(SelectQueryInfo selectQueryInfo)
        {
            var workPlanBuilder = new WorkPlanBuilder(_dbHandlersResolver, _analyzerConfigurationProvider);
            var subQueryWorkPlans = selectQueryInfo.SubQueries.ToDictionary(v => v.Key, v => AnalyzeQuery(v.Value));
            foreach (var queryFilter in selectQueryInfo.Filters ?? Enumerable.Empty<Filter>())
            {
                workPlanBuilder.AddFilter(selectQueryInfo.Entity, queryFilter);
                if (queryFilter.IsSubQueried)
                {
                    workPlanBuilder.AddSubQueriedWorkPlan(queryFilter, queryFilter.Expression, subQueryWorkPlans[queryFilter.Expression], selectQueryInfo.Entity);
                }
            }

            foreach (var fieldName in selectQueryInfo.Fields ?? Enumerable.Empty<string>())
            {
                if (_analyzerConfigurationProvider.IsComplexField(selectQueryInfo.Entity, fieldName))
                {
                    //todo yonatan will validate that query includes fields!
                    var field = _analyzerConfigurationProvider.GetField(selectQueryInfo.Entity, fieldName);
                    workPlanBuilder.AddProjectionComplexField(selectQueryInfo.Entity, field, selectQueryInfo.Includes.Single(x => x.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)));
                }
                else
                {
                    workPlanBuilder.AddSimpleProjectionField(selectQueryInfo.Entity, fieldName);
                }
            }

            var workPlan = workPlanBuilder.Build(subQueryWorkPlans);
            return workPlan;
        }

        private WorkPlan AnalyzeInsertQuery(InsertQueryInfo insertQueryInfo)
        {
            var parserEntities = insertQueryInfo.ParserEntities.Where(x => insertQueryInfo.EntityReps.Contains(x.EntityName)).ToList();
            var jobs = new List<Job>();
            var subQueryWorkPlans = new Dictionary<string, WorkPlan>();
            foreach (var parserEntity in parserEntities)
            {
                var dbsToFields = _analyzerConfigurationProvider.GetDbsToFields(parserEntity.EntityType);
                var guid = Guid.NewGuid();
                foreach (var dbToFields in dbsToFields)
                {
                    var dbHandler = _dbHandlersResolver.ResolveDbHandler(dbToFields.Key);
                    var fields = parserEntity.Fields.Where(x => dbToFields.Value.Contains(x.Key)).ToList().ToDictionary(i => i.Key, i => i.Value);
                    fields[StringConstants.Guid] = guid;
                    var insertQueryJob = new InsertQueryJob(dbHandler, fields, parserEntity.EntityType, new Dictionary<string, WorkPlan>());
                    jobs.Add(insertQueryJob);
                }
            }
            return new WorkPlan(jobs, subQueryWorkPlans);
        }
    }
}