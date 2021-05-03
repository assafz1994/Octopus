using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using Octopus.Client;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
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
                        ""Name"": ""Animal"",
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
                        Name = "Animal",
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
            var executionResult1 = new ExecutionResult(
                "person",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "1", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"name", "ohad"},
                            {"age", 26}
                        })
                    },
                    {
                        "2", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"name", "Noa"},
                            {"age", 24}
                        })
                    }
                });
            var executionResult2 = new ExecutionResult(
                "person",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "2", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"name", "Noa"},
                            {"age", 24}
                        })
                    },
                    {
                        "1", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"name", "ohad"},
                            {"age", 26}
                        })
                    }
                    
                });
            Assert.AreEqual(executionResult1, executionResult2);
        }
    }
}
