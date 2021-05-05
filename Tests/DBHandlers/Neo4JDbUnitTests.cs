using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4j.Driver;
using Newtonsoft.Json;
using NUnit.Framework;
using OctopusCore.Common;
using OctopusCore.Configuration;
using OctopusCore.Configuration.ConfigurationProviders;
using OctopusCore.Contract;
using OctopusCore.DbHandlers;
using OctopusCore.Parser;
using Tests.DbsConfiguration;

namespace Tests.DBHandlers
{
    class Neo4JDbUnitTests
    {
        private Neo4jDbConfigurator _neo4jDbConfigurator;

        private Neo4JDbHandler _neo4jDbHandler;

        private List<string> _tables;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _neo4jDbConfigurator = new Neo4jDbConfigurator();

            var configString = @"{
                ""Id"": ""neo4j"",
                ""DbType"": ""Neo4j"",
                ""ConnectionString"": ""bolt://localhost:7687/"",
                ""Username"": ""neo4j"",
                ""Password"": ""1234"",
                ""Entities"": [
                    {
                        ""Name"": ""address"",
                        ""Fields"": [
                            {
                                ""Name"": ""city"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""String""
                            },
                            {
                                ""Name"": ""street"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""String""
                            },
                            {
                                ""Name"": ""number"",
                                ""Type"": ""Primitive"",
                                ""PrimitiveType"": ""Int""
                            }
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
                        Name = "address",
                        Fields = new List<Field>()
                        {
                            new Field()
                            {
                                Name = "city",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.String
                            },
                            new Field
                            {
                                Name = "street",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.String
                            },
                            new Field
                            {
                                Name = "number",
                                Type = DbFieldType.Primitive,
                                PrimitiveType = PrimitiveType.Int
                            },
                        }
                    }
                }
            };

            var configuration = JsonConvert.DeserializeObject<DbConfiguration>(configString);
            var provider = new Neo4jConfigurationProvider(schema, configuration);
            _neo4jDbHandler = new Neo4JDbHandler(provider);
        }

        [SetUp]
        public void SetUp()
        {
            _neo4jDbConfigurator.SetUpDb();
        }

        [TearDown]
        public void TearDown()
        {
            _neo4jDbConfigurator.TearDownDb();
        }

        [Test]
        public void TestSelect1()
        {
            _neo4jDbConfigurator.SetUpAddresses();
            var actualExecutionResult = _neo4jDbHandler
                .ExecuteQueryWithFiltersAsync(new List<string>() {"city", "street", "number"},
                    new List<Filter>(),
                    "address",
                    new List<(string entityType, Field field, List<string> fieldsToSelect)>()).Result;
            var expectedExecutionResult = new ExecutionResult(
                "address",
                new Dictionary<string, EntityResult>()
                {
                    {
                        "6828e47d-fd3f-42d4-8e59-39621d09d373", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"city", "Tel-Aviv"},
                            {"street", "Kaplan"},
                            {"number", 1}
                        })
                    },
                    {
                        "024768e9-3956-4354-a968-e194c61893bf", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"city", "Beer Sheva"},
                            {"street", "Rager"},
                            {"number", 1}
                        })
                    },
                    {
                        "b82fcaff-45d2-4980-b315-dbdfe996f592", new EntityResult(new Dictionary<string, dynamic>()
                        {
                            {"city", "Beer Sheva"},
                            {"street", "Rager"},
                            {"number", 2}
                        })
                    }
                });

            Assert.AreEqual(expectedExecutionResult, actualExecutionResult);
        }

        [Test]
        public void TestInsert1()
        {
            var actualInsertExecutionResult = _neo4jDbHandler
                .ExecuteInsertQuery(
                    "address",
                    new Dictionary<string, dynamic>()
                    {
                        {"city", "\"Tel-Aviv\""},
                        {"street", "\"Kaplan\""},
                        {"number", 1},
                        {"guid", Guid.NewGuid()}
                    }).Result;

            var executionInsertResult = new ExecutionResult("address", new Dictionary<string, EntityResult>());
            Assert.AreEqual(executionInsertResult, actualInsertExecutionResult);

            
            var result = _neo4jDbConfigurator.Execute("match (e:address) return e.city,e.street,e.number,e.guid");
            Assert.AreEqual(1, result.Count);
            var buildResultsDictionary = BuildResultsDictionary(result, new List<string>(){ "city", "street", "number", "guid"});
            var actualEntityResult = buildResultsDictionary.Values.First();
            var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"city", "Tel-Aviv"},
                {"street", "Kaplan"},
                {"number", 1}
            });
            Assert.AreEqual(actualEntityResult, expectedEntityResult);
        }

        private static Dictionary<string, EntityResult> BuildResultsDictionary(List<IRecord> result,
            IReadOnlyList<string> fieldsNames)
        {
            var entityResults = new Dictionary<string, EntityResult>();
            foreach (var nodeFields in result)
            {
                var dict = new Dictionary<string, dynamic>();
                for (var i = 0; i < fieldsNames.Count; i++) dict.Add(fieldsNames[i], nodeFields[i]);
                var guid = dict[StringConstants.Guid];
                dict.Remove(StringConstants.Guid);
                var entityResult = new EntityResult(dict);
                entityResults.Add(guid, entityResult);
            }

            return entityResults;
        }

        [Test]
        public void TestDelete1()
        {
            _neo4jDbConfigurator.SetUpAddresses();
            var actualDeleteExecutionResult = _neo4jDbHandler
                .ExecuteDeleteQuery(
                    "address",
                    new List<string>()
                    {
                        "6828e47d-fd3f-42d4-8e59-39621d09d373",
                        "024768e9-3956-4354-a968-e194c61893bf"
                    }).Result;

            var expectedDeleteResult = new ExecutionResult("address", new Dictionary<string, EntityResult>());
            Assert.AreEqual(expectedDeleteResult, actualDeleteExecutionResult);


            var result = _neo4jDbConfigurator.Execute("match (e:address) return e.city,e.street,e.number,e.guid");
            Assert.AreEqual(1, result.Count);
            var buildResultsDictionary = BuildResultsDictionary(result, new List<string>() { "city", "street", "number", "guid" });
            var actualEntityResult = buildResultsDictionary.Values.First();
            var expectedEntityResult = new EntityResult(new Dictionary<string, dynamic>()
            {
                {"city", "Beer Sheva"},
                {"street", "Rager"},
                {"number", 2}
            });
            Assert.AreEqual(actualEntityResult, expectedEntityResult);
        }
    }
}
