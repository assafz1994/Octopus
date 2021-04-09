using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using static System.Guid;

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
            return queryInfo switch
            {
                SelectQueryInfo selectQueryInfo => AnalyzeSelectQuery(selectQueryInfo),
                InsertQueryInfo insertQueryInfo => AnalyzeInsertQuery(insertQueryInfo),
                DeleteQueryInfo deleteQueryInfo => AnalyzeDeleteQuery(deleteQueryInfo),
                _ => throw new Exception("Unsupported query type")
            };
        }

        private WorkPlan AnalyzeDeleteQuery(DeleteQueryInfo deleteQueryInfo)
        {
            var jobs = new List<Job>();
            var queryInfo = deleteQueryInfo.SubQueries.Values.ToList().First();
            
            if (!(queryInfo is SelectQueryInfo selectQueryInfo))
            {
                throw new Exception("No select");
            }

            var subQueryWorkPlans = new Dictionary<string, WorkPlan>()
            {
                {NewGuid().ToString(), AnalyzeQuery(selectQueryInfo)}
            };
            var dbs = _analyzerConfigurationProvider.GetDbsToFields(deleteQueryInfo.Entity).Keys.ToList();
            foreach (var db in dbs)
            {
                var dbHandler = _dbHandlersResolver.ResolveDbHandler(db);
                jobs.Add(new DeleteQueryJob(dbHandler, deleteQueryInfo.Entity, subQueryWorkPlans));
            }
            return new WorkPlan(jobs, subQueryWorkPlans);
        }

        private WorkPlan AnalyzeSelectQuery(SelectQueryInfo selectQueryInfo)
        {
            var workPlanBuilder = new WorkPlanBuilder(_dbHandlersResolver, _analyzerConfigurationProvider, selectQueryInfo.Entity);

            var subQueryWorkPlans = selectQueryInfo.SubQueries.ToDictionary(v => v.Key, v => AnalyzeQuery(v.Value));
            foreach (var queryFilter in selectQueryInfo.Filters ?? Enumerable.Empty<Filter>())
            {
                workPlanBuilder.AddFilter(queryFilter);
                if (queryFilter.IsSubQueried)
                {
                    workPlanBuilder.AddSubQueriedWorkPlan(queryFilter, queryFilter.Expression, subQueryWorkPlans[queryFilter.Expression]);
                }
            }

            // For now this will get all fields, primitives and complex
            if (selectQueryInfo.Fields.Count == 1 && selectQueryInfo.Fields.First().Equals(StringConstants.All))
            {
                selectQueryInfo.Fields = _analyzerConfigurationProvider.GetEntityFields(selectQueryInfo.Entity);
            }

            foreach (var field in selectQueryInfo.Fields ?? Enumerable.Empty<string>())
                workPlanBuilder.AddProjectionField(field);

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
                var guid = NewGuid();
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