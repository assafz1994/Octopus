using Autofac;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    [TestFixture]
    class MongoDBUnitTest
    {
        private OctopusClient _client;
        private MongoDbConfigurator _mongoDbConfigurator;
        private MongoDBHandler _mongoDBHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _mongoDbConfigurator = new MongoDbConfigurator();

            var schema = new Scheme()
            {
                Entities = new List<Entity>(){
                new Entity()
                {
                    Name="Animal",
                    Fields= new List<Field>()
                    {
                        new Field()
                        {
                             Name= "aid",
                            Type =  DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field {
                             Name = "name",
                             Type = DbFieldType.Primitive,
                             PrimitiveType = PrimitiveType.String
                        },
                        new Field{
                             Name = "age",
                              Type = DbFieldType.Primitive,
                             PrimitiveType = PrimitiveType.Int
                        },
                    }

                }}
            };

            var configuration = new DbConfiguration() { Entities = null, ConnectionString = "mongodb://localhost:27017/mongodbtests_1" };
            var provider = new MongoDBConfigurationProvider(schema, configuration);
            _mongoDBHandler = new MongoDBHandler(provider); 

        }

        [SetUp]
        public void SetUp()
        {
            _mongoDbConfigurator.SetUpDb();
        }

        [TearDown]
        public void TearDown()
        {
            _mongoDbConfigurator.TearDownDb();
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterOfAnimalsUT()
        {
            SetUpTestOfAnimals();

            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "name",
                "age",
            }.AsReadOnly();
            
            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>
            { 
                new OctopusCore.Parser.Filters.EqFilter(new List<string>() {"name"}, "Maffin")
            };

            var entityType = "animal";
            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var res = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples ).Result;
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    {"name", "Maffin"},
                    { "age", 5 },
                },
            };

            var entityResults = res.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();

           CollectionAssert.AreEqual(fields, expectedResult);            
        }

    [Test]
        public void TestSelectMultipleFieldsWithoutFilterOfAnimalsUT()
        {
            SetUpTestOfAnimals();

            IReadOnlyCollection<string> fieldsToSelect = new List<String> {
                "name",
                "age",
                "aid"
            }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>{};

            var entityType = "animal"; 

            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();

            var res = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;

            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "name", "Maffin"},
                    { "age", 5 },
                    { "aid", "1"},
                },
                new Dictionary<string, object>()
                {
                    { "name", "Woody"},
                    { "age", 6 },
                    { "aid", "2"},

                },
                new Dictionary<string, object>()
                {
                    { "name", "Doggy"},
                    { "age", 8 },
                    { "aid", "3"},
                },
            };

            var entityResults = res.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();

            CollectionAssert.AreEqual(fields, expectedResult);
        }

        [Test]
        public void TestUpdateAgeAnimalUT()
        {
            // update age of animal to be 23
            SetUpTestOfAnimals();
            var entityType = "animal";
            var guid = "9264f435-d1c7-4f1c-8b84-cf4bdb935641";
            var fieldToUpdate = "age";
            var newValue = 23;
            var resUpdate = _mongoDBHandler.ExecuteUpdateQuery(entityType, guid, fieldToUpdate, newValue).Result;

            // execute select query of the updated entity to validate that the age changed as expected
            IReadOnlyCollection<string> fieldsToSelect = new List<String> {
                "age",
                "aid"
            }.AsReadOnly();
            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter> 
            {
                new OctopusCore.Parser.Filters.EqFilter(new List<string>() {"aid"}, "1")
            };
            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectQueryToValidateUpdate = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            var entityResults = resSelectQueryToValidateUpdate.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "age", 23 },
                    { "aid", "1"},
                }
            };
            CollectionAssert.AreEqual(fields, expectedResult);
        }

        [Test]
        public void TestInsertOneAnimalUT()
        {
            SetUpTestOfAnimals();

            IReadOnlyDictionary<string, dynamic> fields = new Dictionary<string, dynamic> {
             {"name", "Roxi"},
             {"age", 16 },
             {"aid","4"},
             {"guid", new Guid("9264f435-a1c7-4f1c-8b84-cf4bdb935641")},
            };

            var entityType = "animal"; 

            _mongoDBHandler.ExecuteInsertQuery(entityType, fields);

            IReadOnlyCollection<string> fieldsToSelect = new List<string> {"name","age","aid"}.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>{};

            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectAfterInsert = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;

            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "name", "Maffin"},
                    { "age", 5 },
                    { "aid", "1"},
                },
                new Dictionary<string, object>()
                {
                    { "name", "Woody"},
                    { "age", 6 },
                    { "aid", "2"},

                },
                new Dictionary<string, object>()
                {
                    { "name", "Doggy"},
                    { "age", 8 },
                    { "aid", "3"},
                },
                new Dictionary<string, dynamic>()
                {
                    {"name", "Roxi"},
                    {"age", 16 },
                    {"aid","4"},
                }
            };

            var entityResults = resSelectAfterInsert.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fieldsAndValues = entityResults.Select(x => x.Fields).ToList();

            CollectionAssert.AreEqual(fieldsAndValues, expectedResult);

        }

        [Test]
        public void TestDeleteOneAnimalUT()
        {
            SetUpTestOfAnimals();

            IReadOnlyCollection<string> guidCollection = new List<string> {
             "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
            };

            var entityType = "animal";

            _mongoDBHandler.ExecuteDeleteQuery(entityType, guidCollection);
            
            IReadOnlyCollection<string> fieldsToSelect = new List<string> { "name", "age", "aid" }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>{};

            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectAfterDelete = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;

            // select all the entities in the table and ensure no one with this guid exists. 
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, object>()
                {
                    { "name", "Woody"},
                    { "age", 6 },
                    { "aid", "2"},

                },
                new Dictionary<string, object>()
                {
                    { "name", "Doggy"},
                    { "age", 8 },
                    { "aid", "3"},
                },
            };

            var entityResults = resSelectAfterDelete.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fieldsAndValues = entityResults.Select(x => x.Fields).ToList();

            CollectionAssert.AreEqual(fieldsAndValues, expectedResult);
        }

        [Test]
        public void TestDeleteManyAnimalsUT()
        {
            SetUpTestOfAnimals();

            IReadOnlyCollection<string> guidCollection = new List<string> {
             "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
             "e8d706f8-92be-429c-89cc-91973fca7a95",
            };

            var entityType = "animal";

            _mongoDBHandler.ExecuteDeleteQuery(entityType, guidCollection);
            
            IReadOnlyCollection<string> fieldsToSelect = new List<string> { "name", "age", "aid" }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter> { };

            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectAfterDelete = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            // only doggy needs to be in the table after the deletion {"guid", "f443f95a-3d8f-4786-b3e6-0db8b790f7e6"}, so select all the entities from the table and check that only doggy exists.
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, object>()
                {
                    { "name", "Doggy"},
                    { "age", 8 },
                    { "aid", "3"},
                },
            };

            var entityResults = resSelectAfterDelete.EntityResults.Values.ToList();
            List<Dictionary<string, dynamic>> fieldsAndValues = entityResults.Select(x => x.Fields).ToList();

            CollectionAssert.AreEqual(fieldsAndValues, expectedResult);
        }

        private void SetUpTestOfAnimals()
        {
            _mongoDbConfigurator.SetUpTestOfAnimals();
        }
    }
}
