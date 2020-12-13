using System.Collections.Generic;
using OctopusCore.Analyzer.Jobs;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    internal class QueryJobBuilder
    {
        private readonly IDbHandler _dbHandler;
        private readonly List<string> _fieldsToSelect;
        private readonly List<Filter> _filters;

        public QueryJobBuilder(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;

            _fieldsToSelect = new List<string>();
            _filters = new List<Filter>();
        }

        public void AddProjectionField(string fieldName)
        {
            _fieldsToSelect.Add(fieldName);
        }

        public void AddFilter(Filter filter)
        {
            _filters.Add(filter);
        }

        public QueryJob Build()
        {
            return new QueryJob(_dbHandler, _fieldsToSelect, _filters);
        }
    }
}