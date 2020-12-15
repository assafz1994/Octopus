using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer.Jobs
{
    internal class QueryJob : Job
    {
        private readonly IDbHandler _dbHandler;

        public QueryJob(IDbHandler dbHandler, IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType)
        {
            _dbHandler = dbHandler;
            FieldsToSelect = fieldsToSelect;
            Filters = filters;
            EntityType = entityType;
        }

        public IReadOnlyCollection<string> FieldsToSelect { get; }
        public IReadOnlyCollection<Filter> Filters { get; }
        public string EntityType { get; }


        protected override Task<object> ExecuteInternalAsync()
        {
            return _dbHandler.ExecuteQueryWithFiltersAsync(FieldsToSelect, Filters, EntityType);
        }
    }
}