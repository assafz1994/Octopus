using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;
using OctopusCore.Configuration.ConfigurationProviders;
using MongoDB.Driver;
using MongoDB.Bson;
using OctopusCore.Configuration;

namespace OctopusCore.DbHandlers
{
    class MongoDBHandler : IDbHandler
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
            string collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);
            
            var fieldsToSelectWithGuid = new List<string>(fieldsToSelect);
            var guidIsRequested = false;

            if (!fieldsToSelect.Contains("guid"))
            {
                fieldsToSelectWithGuid.Add("guid");
            }
            else
            {
                guidIsRequested = true;
            }
            ProjectionDefinition<BsonDocument> project = BuildProjection(fieldsToSelectWithGuid);

            FilterDefinition<BsonDocument> conditions = BuildFilters(filters);
           
            var result = ExecuteCommand(collection, project, conditions, guidIsRequested);

            return Task.FromResult(new ExecutionResult(entityType, result));
        }

        public Task<ExecutionResult> ExecuteInsertQuery(string entityType, IReadOnlyDictionary<string, dynamic> fields)
        {
            MongoClient dbClient = new MongoClient(); // no need to insert connection string -> local db is the default
            var databaseName = MongoUrl.Create(_configurationProvider.ConnectionString).DatabaseName;
            var db = dbClient.GetDatabase(databaseName);
            string collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);

            BsonDocument entityToInsert = new BsonDocument();
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
            foreach (var guid in guidCollection)
            {
                guidsToDelete.Add(Guid.Parse(guid));
            }

            MongoClient dbClient = new MongoClient(); // no need to insert connection string -> local db is the default
            var databaseName = MongoUrl.Create(_configurationProvider.ConnectionString).DatabaseName;
            var db = dbClient.GetDatabase(databaseName);
            string collectionName = _configurationProvider.GetTableName(entityType);
            var collection = db.GetCollection<BsonDocument>(collectionName);
           
            var deleteFilter = Builders<BsonDocument>.Filter.In("guid", guidsToDelete);
            collection.DeleteMany(deleteFilter);
           
            return Task.FromResult(new ExecutionResult(entityType, new Dictionary<string, EntityResult>()));
        }

        private Dictionary<string, EntityResult> ExecuteCommand(IMongoCollection<BsonDocument> collection, ProjectionDefinition<BsonDocument> project, FilterDefinition<BsonDocument> conditions, bool guidIsRequested)
        {
            List<BsonDocument> result = (conditions == null)
                ? collection.Find(_ => true).Project(project).ToList()
                : collection.Find(conditions).Project(project).ToList();
            Dictionary<string, EntityResult> entityResults = new Dictionary<string, EntityResult>();
            foreach (var entity in result)
            {
                var entityWithOutGuid = entity.ToDictionary();
                if (!guidIsRequested)
                {
                    entityWithOutGuid.Remove("guid");
                }
                entityResults.Add(entity["guid"].ToString(), new EntityResult(entityWithOutGuid));
            }

            return entityResults;
        }

        private ProjectionDefinition<BsonDocument> BuildProjection(IReadOnlyCollection<string> fieldsToSelect)
        {
            ProjectionDefinition<BsonDocument> project = null;

            foreach (string columnName in fieldsToSelect)
            {
                if (project == null)
                {
                    project = Builders<BsonDocument>.Projection.Include(columnName).Exclude("_id");
                }
                else
                {
                    project = project.Include(columnName);
                }
            }

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
            FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;

            if (filters_input.Count == 0)
                return filterOutput;

            foreach (var filter in filters_input)
            {
                if (filter.FieldNames.Count > 1)
                    throw new ArgumentException("Fields with Include are not supported");

                FilterDefinition<BsonDocument> filterOp;
                dynamic exp = filter.Expression is string ? GetExpression(filter.Expression) : filter.Expression;
                
                switch (GetFilterOperator(filter))
                {
                    case "=":
                        {
                            filterOp = builder.Eq(filter.FieldNames[0], exp);
                            break;
                        }
                    case ">":
                        {
                            filterOp = builder.Gt(filter.FieldNames[0], exp);
                            break;
                        }
                    case "<":
                        {
                            filterOp = builder.Lt(filter.FieldNames[0], exp);
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException("This type of field is not supported");
                        }
                }
                filterOutput = (filterOutput == null) ? filterOp : filterOutput & filterOp;
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