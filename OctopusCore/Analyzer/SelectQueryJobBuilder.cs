using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.Configuration;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    internal class SelectQueryJobBuilder
    {
        private readonly IDbHandler _dbHandler;
        private readonly List<string> _fieldsToSelect;
        private readonly List<Filter> _filters;
        private readonly string _entityType;
        private Dictionary<string, WorkPlan> _subQueriesWorkPlans;
        private List<(string entityType, Field field, List<string> fieldsToSelect)> _joinsTuples;
        private TaskCompletionSource<SelectQueryJob> _tcs;

        public SelectQueryJobBuilder(string entityType,IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
            _entityType = entityType;

            _fieldsToSelect = new List<string>();
            _filters = new List<Filter>();
            _subQueriesWorkPlans = new Dictionary<string, WorkPlan>();
            _joinsTuples = new List<(string entityType, Field field, List<string> fieldsToSelect)>();
            _tcs = new TaskCompletionSource<SelectQueryJob>();
        }

        public void AddProjectionSimpleField(string fieldName)
        {
            _fieldsToSelect.Add(fieldName);
        }
        public void AddProjectionComplexField(string entityType, Field field,List<string> fieldsToSelect)
        {
            _joinsTuples.Add((entityType,field,fieldsToSelect));
        }

        public void AddFilter(Filter filter)
        {
            _filters.Add(filter);
        }
        public void AddWorkPlan(string guid, WorkPlan workPlan)
        {
            _subQueriesWorkPlans.Add(guid, workPlan);
        }

        public SelectQueryJob Build()
        {
            if (_tcs.Task.IsCompleted)
            {
                return _tcs.Task.Result;
            }
            var job = new SelectQueryJob(_dbHandler, _entityType, _fieldsToSelect, _joinsTuples, _filters, _subQueriesWorkPlans);
            _tcs.SetResult(job);
            return job;
        }

        public Task<SelectQueryJob> GetFutureJob()
        {
            return _tcs.Task;
        }
    }
}