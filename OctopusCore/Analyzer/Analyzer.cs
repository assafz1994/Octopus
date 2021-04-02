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
    public class Analyzer : IAnalyzer
    {

        private IDbHandlersResolver _dbHandlersResolver;
        private IAnalyzerConfigurationProvider _analyzerConfigurationProvider;

        public Analyzer(IDbHandlersResolver dbHandlersResolver ,IAnalyzerConfigurationProvider analyzerConfigurationProvider)
        {
            _dbHandlersResolver = dbHandlersResolver;
            _analyzerConfigurationProvider = analyzerConfigurationProvider;
        }

        public WorkPlan AnalyzeQuery(QueryInfo queryInfo)
        {
            // if (!(queryInfo is SelectQueryInfo selectQueryInfo)) throw new Exception("Unsupported query type");
            if (queryInfo is InsertQueryInfo insertQueryInfo) return AnalyzeInsertQuery(insertQueryInfo);
            var selectQueryInfo = (SelectQueryInfo) queryInfo;
            
            var workPlanBuilder = new WorkPlanBuilder(_dbHandlersResolver,_analyzerConfigurationProvider, selectQueryInfo.Entity);

            var subQueryWorkPlans = selectQueryInfo.SubQueries.ToDictionary(v => v.Key, v => AnalyzeQuery(v.Value));
            foreach (var queryFilter in selectQueryInfo.Filters ?? Enumerable.Empty<Filter>())
            {
                workPlanBuilder.AddFilter(queryFilter);
                if (queryFilter.IsSubQueried)
                {
                    workPlanBuilder.AddSubQueriedWorkPlan(queryFilter, queryFilter.Expression, subQueryWorkPlans[queryFilter.Expression]);
                }
            }
            
            foreach (var field in selectQueryInfo.Fields ?? Enumerable.Empty<string>())
                workPlanBuilder.AddProjectionField(field);

            var workPlan = workPlanBuilder.Build();
            workPlan.SubQueryWorkPlans = subQueryWorkPlans;
            return workPlan;
        }

        private WorkPlan AnalyzeInsertQuery(InsertQueryInfo insertQueryInfo)
        {
            var parserEntities = insertQueryInfo.ParserEntities.Where(x => insertQueryInfo.EntityReps.Contains(x.EntityName)).ToList();
            var jobs = new List<Job>();
            foreach (var parserEntity in parserEntities)
            {
                var dbsDict = _analyzerConfigurationProvider.GetDbAndFields(parserEntity.EntityType);
                foreach (var dbToFields in dbsDict)
                {
                    var dbHandler = _dbHandlersResolver.ResolveDbHandler(dbToFields.Key);
                    var fields = parserEntity.Fields.Where(x => dbToFields.Value.Contains(x.Key)).ToList().ToDictionary(i => i.Key, i => i.Value);
                    var insertQueryJob = new InsertQueryJob(dbHandler, fields, parserEntity.EntityType, new Dictionary<string, WorkPlan>());
                    jobs.Add(insertQueryJob);
                }
            }

            return new WorkPlan(jobs);
        }
    }
}