using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer.Jobs
{
    internal class QueryJob : Job
    {
        private readonly IDbHandler _dbHandler;
        private readonly IReadOnlyCollection<string> _fieldsToSelect;
        private readonly IReadOnlyCollection<Filter> _filters;
        private readonly string _entityType;


        public QueryJob(IDbHandler dbHandler, IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            _dbHandler = dbHandler;
            _fieldsToSelect = fieldsToSelect;
            _filters = filters;
            _entityType = entityType;
        }


        protected override Task<object> ExecuteInternalAsync()
        {
            return _dbHandler.ExecuteQueryWithFiltersAsync(_fieldsToSelect, _filters,_entityType);
        }
    }
}