using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.DbHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OctopusCore.Common;
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    [TestFixture, Apartment(ApartmentState.STA)]
    class SQLiteUnitTest
    {
        private OctopusClient _client;
        private SqliteDbConfigurator _sqliteDbConfigurator;
        private SqliteDbHandler _sqliteDBHandler;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _sqliteDbConfigurator = new SqliteDbConfigurator();
            var entities = new List<Entity>()
            {
                new Entity()
                {
                    Name = "Student",
                    Fields = new List<Field>()
                    {
                        new Field
                        {
                            Name = "sid",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "age",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.Int
                        },
                        new Field
                        {
                            Name = "name",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "address",
                            Type = DbFieldType.Object,
                            EntityName = "address",
                            ConnectedToField = null
                        },
                        new Field
                        {
                            Name = "taughtBy",
                            Type = DbFieldType.Object,
                            EntityName = "teacher",
                            ConnectedToField = "teach"
                        }
                    }
                },
                new Entity
                {
                    Name = "Student",
                    Fields = new List<Field>()
                    {
                        new Field
                        {
                            Name = "tid",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "age",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.Int
                        },
                        new Field
                        {
                            Name = "name",
                            Type = DbFieldType.Primitive,
                            PrimitiveType = PrimitiveType.String
                        },
                        new Field
                        {
                            Name = "teach",
                            Type = DbFieldType.Object,
                            EntityName = "student",
                            ConnectedToField = "taughtBy"
                        }
                    }
                },
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
            };

            var schema = new Scheme()
            {
                Entities = entities,
            };

            var configuration = new DbConfiguration()
                {Entities = entities, Id = "sql1", ConnectionString = "Data Source=DataBases\\sqlite1_test_db.db"};
            var provider = new SqliteConfigurationProvider(schema, configuration);
            var configurations = new DbConfigurations()
            {
                Configurations = new List<DbConfiguration>()
                {
                    configuration,
                }
            };
            var analyzerConfigurationProvider = new AnalyzerConfigurationProvider(schema, configurations);
            _sqliteDBHandler = new SqliteDbHandler(provider, analyzerConfigurationProvider);

        }

        [SetUp]
        public void SetUp()
        {
            _sqliteDbConfigurator.SetUpDb();
        }

        [TearDown]
        public void TearDown()
        {
            _sqliteDbConfigurator.TearDownDb();
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterOfStudent()
        {
            _sqliteDbConfigurator.SetUpTestComplexSelect();

            IReadOnlyCollection<string> fieldsToSelect = new List<string>
            {
                "sid",
                "age",
                "name",
            }.AsReadOnly();

            IReadOnlyCollection<Filter> filters = new List<Filter>
            {
                new EqFilter(new List<string>() {"age"}, 10)
            };

            var entityType = "student";
            var joinsTuples =
                new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var actualExecutionResult = _sqliteDBHandler
                .ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;

            var expectedExecutionResult = new ExecutionResult(
                entityType,
                new Dictionary<string, EntityResult>()
                {
                    {
                        "ba78c4f3-deb0-4d51-8604-ae95c16cb147",
                        new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"sid", "1"},
                            {"age", 10},
                            {"name", "sn1"}
                        })
                    },
                    {
                        "0433b07f-1d77-4f58-a58d-91daae887502",
                        new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"sid", "2"},
                            {"age", 10},
                            {"name", "sn2"}
                        })
                    },
                });
            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestSelectMultipleFieldsWithFilterAndWithComplexFieldOfStudent()
        {
            _sqliteDbConfigurator.SetUpTestComplexSelect();

            IReadOnlyCollection<string> fieldsToSelect = new List<string>
            {
                "sid",
                "age",
                "name",
            }.AsReadOnly();

            IReadOnlyCollection<Filter> filters = new List<Filter>
            {
                new EqFilter(new List<string>() {"age"}, 30)
            };

            var entityType = "student";
            var joinsTuples =
                new List<(string entityType, Field field, List<string> fieldsToSelect)>()
                {
                    (
                        entityType,
                        new Field()
                        {
                            ConnectedToField = "teach",
                            EntityName = "teacher",
                            Name = "taughtBy",
                            PrimitiveType = null,
                            Type = DbFieldType.Object
                        },
                        new List<string>() {"name"}
                    )
                };
            var entityRes = new EntityResult(
                new Dictionary<string, dynamic>()
                {
                    {"name", "tn3"}
                }
            );

            var actualExecutionResult = _sqliteDBHandler
                .ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
            var expectedExecutionResult = new ExecutionResult(
                entityType,
                new Dictionary<string, EntityResult>()
                {
                    {
                        "8f147986-8658-4561-860c-d1b23a134660",
                        new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"sid", "3"},
                            {"age", 30},
                            {"name", "sn3"},
                            {
                                "taughtBy",
                                new Dictionary<string, EntityResult>()
                                {
                                    {"f7b97e2a-e885-49e3-811d-201e72b27406", entityRes}
                                }
                            }
                        })
                    }
                });
            
            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestDeleteAnimals()
        {
            _sqliteDbConfigurator.SetUpTestAnimals();
            var actualInsertExecutionResult = _sqliteDBHandler
                .ExecuteDeleteQuery(
                    "animal",
                    new List<string>()
                    {
                        "9264f435-d1c7-4f1c-8b84-cf4bdb935641",
                        "e8d706f8-92be-429c-89cc-91973fca7a95"
                    }).Result;
            var expectedInsertExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedInsertExecutionResult, actualInsertExecutionResult);

            var actualSelectExecutionResult = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(
                new List<string>()
                {
                    "aid", "food", "height"
                },
                new List<Filter>(),
                "animal",
                new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            Assert.AreEqual(1, actualSelectExecutionResult.EntityResults.Count);
            var actualSelectEntityResult = actualSelectExecutionResult.EntityResults.Values.First();
            var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"aid", "3"},
                {"food", "f23" },
                {"height", 45 }
            });
            Assert.AreEqual(expectedEntityResult, actualSelectEntityResult);
        }

        [Test]
        public void TestInsertAnimal()
        {
            var actualInsertExecutionResult = _sqliteDBHandler
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

            var actualSelectExecutionResult = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(
                new List<string>()
                {
                    "aid", "food", "height"
                },
                new List<Filter>
                {
                    new EqFilter(new List<string>() {"aid"}, "\"1\"")
                },
                "animal",
                new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            Assert.AreEqual(1, actualSelectExecutionResult.EntityResults.Count);
            var actualSelectEntityResult = actualSelectExecutionResult.EntityResults.Values.First();
            var expectedSelectEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"aid", "1"},
                {"food", "f1"},
                {"height", 23}
            });
            Assert.AreEqual(expectedSelectEntityResult, actualSelectEntityResult);
        }

        [Test]
        public void TestUpdateAnimalHeight()
        {
            _sqliteDbConfigurator.SetUpTestAnimals();
            var entityType = "animal";
            var guid = "9264f435-d1c7-4f1c-8b84-cf4bdb935641";
            var fieldToUpdate = "height";
            var newValue = 345;
            var resUpdate = _sqliteDBHandler.ExecuteUpdateQuery(entityType, guid, fieldToUpdate, newValue).Result;

            var expectedUpdateExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedUpdateExecutionResult, resUpdate);
            // execute select query of the updated entity to validate that the age changed as expected
            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "height",
                "aid"
            }.AsReadOnly();
            IReadOnlyCollection<Filter> filters = new List<Filter>
            {
                new EqFilter(new List<string>() {"height"}, newValue)
            };
            var joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectQueryToValidateUpdate = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
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
        public void TestUpdateAnimalFood()
        {
            _sqliteDbConfigurator.SetUpTestAnimals();
            var entityType = "animal";
            var guid = "9264f435-d1c7-4f1c-8b84-cf4bdb935641";
            var fieldToUpdate = "food";
            var newValue = "\"345newFood\"";
            var resUpdate = _sqliteDBHandler.ExecuteUpdateQuery(entityType, guid, fieldToUpdate, newValue).Result;

            var expectedUpdateExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());

            Assert.AreEqual(expectedUpdateExecutionResult, resUpdate);
            // execute select query of the updated entity to validate that the age changed as expected
            IReadOnlyCollection<string> fieldsToSelect = new List<string> {
                "food",
                "aid"
            }.AsReadOnly();
            IReadOnlyCollection<Filter> filters = new List<OctopusCore.Parser.Filter>
            {
                new EqFilter(new List<string>() {"food"}, "\"345newFood\"")
            };
            var joinsTuples = new List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)>();
            var resSelectQueryToValidateUpdate = _sqliteDBHandler.ExecuteQueryWithFiltersAsync(fieldsToSelect, filters, entityType, joinsTuples).Result;
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
