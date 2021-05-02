using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;

namespace OctopusCore.DbHandlers
{
    internal class MongoDBHandler : IDbHandler
    {
        private readonly MongoDBConfigurationProvider _configurationProvider;

        public MongoDBHandler(MongoDBConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public Task<ExecutionResult> ExecuteQueryWithFiltersAsync(IReadOnlyCollection<string> fieldsToSelect,
            IReadOnlyCollection<Filter> filters, string entityType,
            List<(string entityType, Field field, List<string> fieldsToSelect)>
                joinsTuples)
        {
            MongoClient dbClient = new MongoClient(_configurationProvider.ConnectionString); // no need to insert connection string -> local db is the default
            
            var databaseName = MongoUrl.Create(_configurationProvider.ConnectionString).DatabaseName;

            var db = dbClient.GetDatabase(databaseName);
            var collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);

            var fieldsToSelectWithGuid = new List<string>(fieldsToSelect);
            fieldsToSelectWithGuid.AddRange(joinsTuples.Select(x =>
                x.field.Name)); //todo we assume for now all fields in join tuple are complex fields of the same entity
            var guidIsRequested = false;

            if (!fieldsToSelect.Contains("guid"))
                fieldsToSelectWithGuid.Add("guid");
            else
                guidIsRequested = true;
            var project = BuildProjection(fieldsToSelectWithGuid);

            var conditions = BuildFilters(filters);

            var mongoDocuments =
                GetRelevantDocuments(collection, project, conditions, guidIsRequested); // todo make this method async!!
            return Task.FromResult(ConvertDocumentsToExecutionResult(mongoDocuments, entityType, fieldsToSelect, joinsTuples, guidIsRequested));
        }

        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            var dbClient = new MongoClient(); // no need to insert connection string -> local db is the default
            var databaseName = MongoUrl.Create(_configurationProvider.ConnectionString).DatabaseName;
            var db = dbClient.GetDatabase(databaseName);
            var collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);

            var entityToInsert = new BsonDocument();
            foreach (var key in fields.Keys)
            {
                var val = fields[key] is string ? GetExpression(fields[key]) : fields[key];
                entityToInsert.Add(key, val);
            }

            collection.InsertOne(entityToInsert);

            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        public Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection)
        {
            var guidsToDelete = new List<Guid>();
            foreach (var guid in guidCollection) guidsToDelete.Add(Guid.Parse(guid));

            var dbClient = new MongoClient(); // no need to insert connection string -> local db is the default
            var databaseName = MongoUrl.Create(_configurationProvider.ConnectionString).DatabaseName;
            var db = dbClient.GetDatabase(databaseName);
            var collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);

            var deleteFilter = Builders<BsonDocument>.Filter.In("guid", guidsToDelete);
            collection.DeleteMany(deleteFilter);

            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        private IEnumerable<BsonDocument> GetRelevantDocuments(IMongoCollection<BsonDocument> collection,
            ProjectionDefinition<BsonDocument> project, FilterDefinition<BsonDocument> conditions, bool guidIsRequested)
        {
            return conditions == null
                ? collection.Find(_ => true).Project(project).ToList()
                : collection.Find(conditions).Project(project).ToList();
            //Dictionary<string, EntityResult> entityResults = new Dictionary<string, EntityResult>();
            //foreach (var entity in result)
            //{

            //    var entityWithOutGuid = entity.ToDictionary();
            //    if (!guidIsRequested)
            //    {
            //        entityWithOutGuid.Remove("guid");
            //    }
            //    entityResults.Add(entity["guid"].ToString(), new EntityResult(entityWithOutGuid));
            //}

            //return entityResults;
        }

        private ExecutionResult ConvertDocumentsToExecutionResult(IEnumerable<BsonDocument> mongoDocuments, string entityType,
            IReadOnlyCollection<string> fieldsToSelect,
            List<(string entityType, Field field, List<string> fieldsToSelect)>
                joinsTuples, bool guidIsRequested)
        {

            var entityResults = new Dictionary<string, EntityResult>();
            foreach (var document in mongoDocuments)
            {
                var currentEntity = new Dictionary<string, dynamic>();
                foreach (var fieldName in fieldsToSelect)
                {
                    currentEntity[fieldName] = document[fieldName]; // todo check about type
                }
                foreach (var joinTuple in joinsTuples)
                {
                    var complexFieldsToFields = new Dictionary<string, dynamic>(); // todo add support in fields to select of a join tuple (right now we only get the guid)
                    var guidOfComplexField = document[joinTuple.field.Name].ToString();
                    currentEntity[joinTuple.field.Name] = new Dictionary<string, EntityResult>
                    {
                        {
                            guidOfComplexField,new EntityResult(complexFieldsToFields)
                        }
                    };
                }

                if (guidIsRequested)
                {
                    currentEntity.Add("guid", document["guid"].AsGuid.ToString());
                }
                entityResults.Add(document["guid"].AsGuid.ToString(), new EntityResult(currentEntity));
            }

            return new ExecutionResult(entityType, entityResults);
        }

        private ProjectionDefinition<BsonDocument> BuildProjection(IReadOnlyCollection<string> fieldsToSelect)
        {
            ProjectionDefinition<BsonDocument> project = null;

            foreach (var columnName in fieldsToSelect)
                if (project == null)
                    project = Builders<BsonDocument>.Projection.Include(columnName).Exclude("_id");
                else
                    project = project.Include(columnName);

            return project;
        }

        private string GetFilterOperator(Filter filter)
        {
            if (filter is EqFilter) return "=";

            throw new ArgumentException("Filter type is not supported");
        }

        private FilterDefinition<BsonDocument> BuildFilters(IReadOnlyCollection<Filter> filters_input)
        {
            FilterDefinition<BsonDocument> filterOutput = null;
            var builder = Builders<BsonDocument>.Filter;

            if (filters_input.Count == 0)
                return filterOutput;

            foreach (var filter in filters_input)
            {
                if (filter.FieldNames.Count > 1)
                    throw new ArgumentException("Fields with Include are not supported");

                FilterDefinition<BsonDocument> filterOp;
                var exp = filter.Expression is string ? GetExpression(filter.Expression) : filter.Expression;

                switch (filter.Type)
                {
                    case FilterType.Eq:
                        {
                            filterOp = builder.Eq(filter.FieldNames[0], exp);
                            break;
                        }
                    //todo not supported yet
                    //case ">":
                    //    {
                    //        filterOp = builder.Gt(filter.FieldNames[0], exp);
                    //        break;
                    //    }
                    //case "<":
                    //    {
                    //        filterOp = builder.Lt(filter.FieldNames[0], exp);
                    //        break;
                    //    }
                    case FilterType.In:
                        {
                            filterOp = builder.In(filter.FieldNames[0], filter.CalcValue());
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException("This type of field is not supported");
                        }
                }

                filterOutput = filterOutput == null ? filterOp : filterOutput & filterOp;
            }

            return filterOutput;
        }

        private static string GetExpression(string expression)
        {
            if (!expression.StartsWith("\"") || !expression.EndsWith("\"")) return expression;
            var res = expression.Trim('"');
            return $"{res}";
        }
    }
}