using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;

namespace OctopusCore.Analyzer.Jobs
{
    class UpdateQueryJob : Job
    {
        private readonly IDbHandler _dbHandler;
        public Dictionary<string, WorkPlan> SubQueryWorkPlans { get; set; }
        public string EntityType;
        public string EntityRep;
        public string Field { get; set; }
        public dynamic Value { get; set; }

        public Dictionary<string, string> EntityToSubQuery;
        public Dictionary<string, string> EntityRepToEntityType;

        public UpdateQueryJob(IDbHandler dbHandler, string entityType, string entityRep, Dictionary<string, string> entityToSubQuery, Dictionary<string, string> entityRepToEntityType, Dictionary<string, WorkPlan> subQueryWorkPlans, string field, dynamic value)
        {
            _dbHandler = dbHandler;
            EntityType = entityType;
            EntityRep = entityRep;
            EntityToSubQuery = entityToSubQuery;
            EntityRepToEntityType = entityRepToEntityType;
            SubQueryWorkPlans = subQueryWorkPlans;
            Field = field;
            Value = value;
        }

        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            var entityKey = EntityToSubQuery[EntityRep];
            var result = SubQueryWorkPlans[entityKey].Jobs.Last().Result;
            var guid = result.EntityResults.First().Key;
            return _dbHandler.ExecuteUpdateQuery(EntityType, guid, Field, Value);
        }
    }
}
