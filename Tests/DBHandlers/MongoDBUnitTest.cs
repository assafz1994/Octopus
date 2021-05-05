using Autofac;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    [TestFixture]
    class MongoDBUnitTest
    {

        private OctopusClient _client;
        private DbsConfigurator _dbsConfigurator;
        private MongoDBHandler _mongoDBHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _dbsConfigurator = new DbsConfigurator();

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
            this._mongoDBHandler = new MongoDBHandler(provider); 

        }

        [SetUp]
        public void SetUp()
        {
            _dbsConfigurator.SetUpMongoDB();
        }

        [TearDown]
        public void TearDown()
        {
            _dbsConfigurator.TearDownMongoDB();
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterOfAnimalsUT()
        {
            SetUpTestSelectNamesOfAnimals();

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

            var query = "From Animal a | Select a(name)";
            //var entities = _client.ExecuteQuery(query).Result;

            //var listOfDictionaryEntities = entities.Select(x => new RouteValueDictionary(x));

            //var expectedResult = new List<Dictionary<string, object>>()
            //{
            //    new Dictionary<string, object>()
            //    {
                      //{ "age", 5 },
            //        {"name", "Maffin"},
            //    },
            //};

            //CollectionAssert.AreEqual(listOfDictionaryEntities, expectedResult);
        }

        [Test]
        public void TestSelectMultipleFieldsWithoutFilterOfAnimalsUT()
        {
            SetUpTestSelectNamesOfAnimals();

            IReadOnlyCollection<string> fieldsToSelect = new List<String> {
                "name",
                "age",
                "aid"
            }.AsReadOnly();

            IReadOnlyCollection<OctopusCore.Parser.Filter> filters = new List<OctopusCore.Parser.Filter>{};

            var entityType = "animal"; 

            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();

            var res = _mongoDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;

            //var query = "From Animal a | Select a(name)";
            //var entities = _client.ExecuteQuery(query).Result;

            //var listOfDictionaryEntities = entities.Select(x => new RouteValueDictionary(x));

            //var expectedResult = new List<Dictionary<string, object>>()
            //{
            //  new Dictionary<string, object>()
            //        {
            //            {"aid", "1"},
            //            {"age", 5 },
            //            {"name", "Maffin"},
            //        },
            //        new Dictionary<string, object>()
            //        {
            //            {"aid", "2"},
            //            { "age", 6 },
            //            { "name", "Woody"},
            //        },
            //        new Dictionary<string, object>()
            //        {
            //            {"aid", "3"},
            //            {"age", 8 },
            //            {"name", "Doggy"},
            //        },
            //};

            //CollectionAssert.AreEqual(listOfDictionaryEntities, expectedResult);
        }



        [Test]
        public void TestInsertOneAnimalUT()
        {
            SetUpTestSelectNamesOfAnimals();

            IReadOnlyDictionary<string, dynamic> fields = new Dictionary<string, dynamic> {
             {"name", "Roxi"},
             {"guid", new Guid("9264f435-a1c7-4f1c-8b84-cf4bdb935641")},
             {"aid","4"},
             {"age", 16 }
            };

            var entityType = "animal"; 

            var res = _mongoDBHandler.ExecuteInsertQuery(entityType, fields);
        }

        //        Task<ExecutionResult> ExecuteDeleteQuery(string entityType, IReadOnlyCollection<string> guidCollection);

        [Test]
        public void TestDeleteOneAnimalUT()
        {
            SetUpTestSelectNamesOfAnimals();

            IReadOnlyCollection<string> guidCollection = new List<string> {
             "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
            };

            var entityType = "animal";

            var res = _mongoDBHandler.ExecuteDeleteQuery(entityType, guidCollection);
        }

        [Test]
        public void TestDeleteManyAnimalsUT()
        {
            SetUpTestSelectNamesOfAnimals();

            IReadOnlyCollection<string> guidCollection = new List<string> {
             "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
             "e8d706f8-92be-429c-89cc-91973fca7a95",
            };

            var entityType = "animal";

            var res = _mongoDBHandler.ExecuteDeleteQuery(entityType, guidCollection);

            // only doggy needs to be in the table after the deletion {"guid", "f443f95a-3d8f-4786-b3e6-0db8b790f7e6"},
            // { "aid", "3"},
            // { "age", 8 },
            // { "name", "Doggy" }
        }

        private void SetUpTestSelectNamesOfAnimals()
        {
            _dbsConfigurator.SetUpTestSelectNamesOfAnimals();
        }

    }
}
