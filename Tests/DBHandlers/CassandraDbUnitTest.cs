using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    class CassandraDbUnitTest
    {
        private CassandraDbConfigurator _cassandraDbConfigurator;

        private CassandraDbHandler _cassandraDbHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cassandraDbConfigurator = new CassandraDbConfigurator();
            var configString = @"{
                ""Id"": ""cassTests"",
                ""DbType"": ""Cassandra"",
                ""ConnectionString"": ""127.0.0.1"",
                ""KeySpace"": ""octopustests"",
                ""Entities"": [
                    {
                        ""Name"": ""animal"",
                        ""Fields"": [
                            {
                                ""Name"": ""aid"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""String""
                            },
                            {
                                ""Name"": ""food"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""String""
                            },
                            {
                                ""Name"": ""height"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""Int""
                            }
                        ],
                        ""TablesByFields"": [
                            [],
                            [ ""height"" ],
                            [ ""food"", ""height"" ]
                        ]
                    }
                ]
            }";
            var schema = new Scheme()
            {
                Entities = new List<Entity>()
                {
                    new Entity()
                    {
                        Name = "animal",
                        Fields = new List<Field>()
                        {
                            new Field()
                            {
                                Name = "aid",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.String
                            },
                            new Field
                            {
                                Name = "food",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.String
                            },
                            new Field
                            {
                                Name = "height",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.Int
                            },
                        }
                    }
                }
            };

            var configuration = JsonConvert.DeserializeObject<DbConfiguration>(configString);
            var provider = new CassandraConfigurationProvider(schema, configuration);
            _cassandraDbHandler = new CassandraDbHandler(provider);
        }

        [SetUp]
        public void SetUp()
        {
            _cassandraDbConfigurator.SetUpDb();
        }

        [TearDown]
        public void TearDown()
        {
            _cassandraDbConfigurator.TearDownDb();
        }

        [Test]
        public void TestSelect1()
        {
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var actualExecutionResult = _cassandraDbHandler
                .ExecuteQueryWithFiltersAsync(new List<string>() { "food", "height" }, 
                    new List<Filter>(), 
                    "animal",
                    new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var expectedExecutionResult = new ExecutionResult(
                "animal",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "9264f435-d1c7-4f1c-8b84-cf4bdb935641", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f1"},
                            {"height", 23}
                        })
                    },
                    {
                        "e8d706f8-92be-429c-89cc-91973fca7a95", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 23}
                        })
                    },
                    {
                        "f443f95a-3d8f-4786-b3e6-0db8b790f7e6", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 45}
                        })
                    }
                });
            
            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestSelect2()
        {
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var actualExecutionResult = _cassandraDbHandler
                .ExecuteQueryWithFiltersAsync(new List<string>() { "food", "height" },
                    new List<Filter>() {new EqFilter(new List<string>() {"height"}, "23")}, 
                    "animal",
                    new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var expectedExecutionResult = new ExecutionResult(
                "animal",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "9264f435-d1c7-4f1c-8b84-cf4bdb935641", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f1"},
                            {"height", 23}
                        })
                    },
                    {
                        "e8d706f8-92be-429c-89cc-91973fca7a95", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 23}
                        })
                    }
                });

            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestSelect3()
        {
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var actualExecutionResult = _cassandraDbHandler
                .ExecuteQueryWithFiltersAsync(new List<string>() { "food", "height" },
                    new List<Filter>()
                    {
                        new EqFilter(new List<string>() { "food" }, "\"f23\""),
                        new EqFilter(new List<string>() { "height" }, "23")
                    }, 
                    "animal",
                    new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var expectedExecutionResult = new ExecutionResult(
                "animal",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "e8d706f8-92be-429c-89cc-91973fca7a95", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 23}
                        })
                    }
                });

            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestSelect4()
        {
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var actualExecutionResult = _cassandraDbHandler
                .ExecuteQueryWithFiltersAsync(new List<string>() { "food", "height" },
                    new List<Filter>(){new EqFilter(new List<string>() { "food" }, "\"f23\""),}, 
                    "animal",
                    new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var expectedExecutionResult = new ExecutionResult(
                "animal",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "e8d706f8-92be-429c-89cc-91973fca7a95", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 23}
                        })
                    },
                    {
                        "f443f95a-3d8f-4786-b3e6-0db8b790f7e6", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"food", "f23"},
                            {"height", 45}
                        })
                    }
                });

            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestDelete1()
        {
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var actualInsertExecutionResult = _cassandraDbHandler
                .ExecuteDeleteQuery(
                    "animal", 
                    new List<string>()
                    {
                        "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
                        "e8d706f8-92be-429c-89cc-91973fca7a95"
                    }).Result;
            var expectedInsertExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedInsertExecutionResult, actualInsertExecutionResult);

            var rowSets = _cassandraDbConfigurator.GetTables()
                .Select(table => _cassandraDbConfigurator.Execute($"select * from {table}")).ToList();
            var fieldsToSelect = new List<string>() {"aid", "food", "height"};
            var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"aid", "3"},
                {"food", "f23" },
                {"height", 45 }
            });
            foreach (var rowSet in rowSets)
            foreach (var row in rowSet)
            {
                var actualEntityResult = new EntityResult(fieldsToSelect.ToDictionary(field => field, field => row.GetValue(typeof(object), field)));
                Assert.AreEqual(expectedEntityResult, actualEntityResult);
            }
            
        }

        [Test]
        public void TestInsert1()
        {
            var actualInsertExecutionResult = _cassandraDbHandler
                .ExecuteInsertQuery(
                    "animal",
                    new Dictionary<string, dynamic>()
                    {
                        {"guid", Guid.NewGuid()},
                        {"aid", "\"1\""},
                        {"food", "\"f1\"" },
                        {"height", 23 }
                    }).Result;
            var expectedInsertExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedInsertExecutionResult, actualInsertExecutionResult);

            var rowSets = _cassandraDbConfigurator.GetTables()
                .Select(table => _cassandraDbConfigurator.Execute($"select * from {table}")).ToList();
            var fieldsToSelect = new List<string>() { "aid", "food", "height" };
            var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"aid", "1"},
                {"food", "f1" },
                {"height", 23 }
            });
            foreach (var rowSet in rowSets)
            foreach (var row in rowSet)
            {
                var actualEntityResult = new EntityResult(fieldsToSelect.ToDictionary(field => field, field => row.GetValue(typeof(object), field)));
                Assert.AreEqual(expectedEntityResult, actualEntityResult);
            }

        }

        [Test]
        public void TestUpdate1()
        {
            // update age of animal to be 23
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var entityType = "animal";
            var guid = "9264f435-d1c7-4f1c-8b84-cf4bdb935641";
            var fieldToUpdate = "height";
            var newValue = 345;
            var resUpdate = _cassandraDbHandler.ExecuteUpdateQuery(entityType, guid, fieldToUpdate, newValue).Result;

            var expectedUpdateExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedUpdateExecutionResult, resUpdate);
            // execute select query of the updated entity to validate that the age changed as expected
            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "height",
                "aid"
            }.AsReadOnly();
            IReadOnlyCollection<Filter> filters = new List<OctopusCore.Parser.Filter>
            {
                new EqFilter(new List<string>() {"aid"}, "\"1\"")
            };
            var joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectQueryToValidateUpdate = _cassandraDbHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            var entityResults = resSelectQueryToValidateUpdate.EntityResults.Values.ToList();
            var fields = entityResults.Select(x => x.Fields).ToList();
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "height", newValue },
                    { "aid", "1"},
                }
            };
            CollectionAssert.AreEqual(fields, expectedResult);
        }

        [Test]
        public void TestUpdate2()
        {
            // update age of animal to be 23
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
            var entityType = "animal";
            var guid = "9264f435-d1c7-4f1c-8b84-cf4bdb935641";
            var fieldToUpdate = "food";
            var newValue = "\"345newFood\"";
            var resUpdate = _cassandraDbHandler.ExecuteUpdateQuery(entityType, guid, fieldToUpdate, newValue).Result;

            var expectedUpdateExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedUpdateExecutionResult, resUpdate);
            // execute select query of the updated entity to validate that the age changed as expected
            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "food",
                "aid"
            }.AsReadOnly();
            IReadOnlyCollection<Filter> filters = new List<OctopusCore.Parser.Filter>
            {
                new EqFilter(new List<string>() {"aid"}, "\"1\"")
            };
            var joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectQueryToValidateUpdate = _cassandraDbHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            var entityResults = resSelectQueryToValidateUpdate.EntityResults.Values.ToList();
            var fields = entityResults.Select(x => x.Fields).ToList();
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
                {
                    { "food", "345newFood" },
                    { "aid", "1"},
                }
            };
            CollectionAssert.AreEqual(fields, expectedResult);
        }
    }
}
