using System;
using System.Collections.Generic;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer.Jobs
{
    internal class QueryJob : Job
    {
        private readonly IDbHandler _dbHandler;
        private IReadOnlyCollection<string> _fieldsToSelect;
        private IReadOnlyCollection<Filter> filters;


        public QueryJob(IDbHandler dbHandler, IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters)
        {
            _dbHandler = dbHandler;
            _fieldsToSelect = fieldsToSelect;
            this.filters = filters;
        }


        protected override object ExecuteInternal()
        {
            return _dbHandler.ExecuteQueryWithFilters(_fieldsToSelect, filters);
        }
    }
}