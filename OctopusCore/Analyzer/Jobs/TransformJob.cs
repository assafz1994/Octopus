using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore.Analyzer.Jobs
{
    internal class TransformJob : Job
    {
        private readonly string _fieldFrom;
        private readonly string _fieldTo;
        private readonly Job _previousJob;
        private readonly string _transformedEntityType;

        public TransformJob(string fieldFrom, string fieldTo, string transformedEntityType, Job previousJob)
        {
            _fieldFrom = fieldFrom;
            _fieldTo = fieldTo;
            _transformedEntityType = transformedEntityType;
            _previousJob = previousJob;
        }

        //If 2 entities are connected by a single relation, for example a student is taught by a teacher & a teacher teach a student
        //we can represent the information by a collection of students each one points to a teacher OR a collection of teachers each one points to a student
        //This function change from this this two representations
        //e.g Student.taughtBy[teacher] -> Teacher.teach[student]
        //In this example, fieldTo is taught by and field from is teach, and transformedEntityType is teacher
        protected override Task<ExecutionResult> ExecuteInternalAsync()
        {
            var entities = _previousJob.Result.EntityResults;
            var transformedEntities = new Dictionary<string, EntityResult>();
            foreach (var entityGuid in entities.Keys)
            {
                var entity = entities[entityGuid];
                var transformedEntityGuid =
                    ((Dictionary<string, EntityResult>) entity.Fields[_fieldFrom]).Keys
                    .Single(); //not supporting arrays yet. oops

                transformedEntities[transformedEntityGuid] = TransformEntity(entityGuid, entity);
            }

            return Task.FromResult(new ExecutionResult(_transformedEntityType, transformedEntities));


            EntityResult TransformEntity(string entityGuid, EntityResult entity)
            {
                var clonedEntity = Clone(entity);
                clonedEntity.Fields
                    .Remove(_fieldFrom); // we don't need the fieldFrom because we add the entity by the fieldTo

                return new EntityResult(new Dictionary<string, dynamic>
                {
                    {
                        _fieldTo, new Dictionary<string, EntityResult>
                        {
                            {entityGuid, clonedEntity}
                        }
                    }
                });
            }

            static EntityResult Clone(EntityResult entity)
            {
                return new EntityResult(entity.Fields.ToDictionary(x => x.Key, y => y.Value));
            }
        }
    }
}