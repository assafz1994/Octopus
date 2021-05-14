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
using OctopusCore.Contract;
using OctopusCore.Parser;
using OctopusCore.Parser.Filters;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
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
                }
            };

            var schema = new Scheme()
            {
                Entities = entities,
            };

            DbConfiguration configuration = new DbConfiguration()
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
            this._sqliteDBHandler = new SqliteDbHandler(provider, analyzerConfigurationProvider);

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
        public void TestSelectMultipleFieldsWithFilterOfStudentUT()
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
            List<(string entityType, OctopusCore.Configuration.Field field, List<string> fieldsToSelect)> joinsTuples =
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
        public void TestSelectMultipleFieldsWithFilterAndWithComplexFieldOfStudentUT()
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
            List<(string entityType, Field field, List<string> fieldsToSelect)> joinsTuples =
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
            var expectedResult = new List<Dictionary<string, dynamic>>()
            {
                new Dictionary<string, dynamic>()
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
                    },
                }
            };

            // var entityResults = actualExecutionResult.EntityResults.Values.ToList();
            // List<Dictionary<string, dynamic>> fields = entityResults.Select(x => x.Fields).ToList();
            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        // [Test]
        // public void TestUpdate1()
        // {
        //     _sqliteDbConfigurator.SetUpTestComplexSelect();
        //     var actualUpdateExecutionResult = _sqliteDBHandler
        //         .ExecuteUpdateQuery("student", "ba78c4f3-deb0-4d51-8604-ae95c16cb147", "age", 20).Result;
        //     var expectedUpdateExecutionResult = new ExecutionResult("animal", new Dictionary<string, EntityResult>());
        //
        //     Assert.AreEqual(expectedUpdateExecutionResult, actualUpdateExecutionResult);
        //
        //     var executionResult = _sqliteDBHandler.ExecuteQueryWithFiltersAsync()
        //     var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
        //     {
        //         {"sid", "1"},
        //         {"name", "sn1" },
        //         {"age", 20 }
        //     });
        //
        // }
    }
}
