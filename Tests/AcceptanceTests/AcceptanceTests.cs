using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Octopus.Client;
using Tests.DbsConfiguration;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tests.AcceptanceTests
{
    class AcceptanceTests
    {
        private OctopusClient _client;
        private DbsConfigurator _dbsConfigurator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _dbsConfigurator = new DbsConfigurator();
        }

        [SetUp]
        public void SetUp()
        {
            _dbsConfigurator.SetUpDbs();
        }

        [TearDown]
        public void TearDown()
        {
            _dbsConfigurator.TearDownDbs();
        }

        [Test]
        public void TestSelectNamesOfAnimals()
        {
            SetUpTestSelectNamesOfAnimals();
            var query = "From Animal a | Select a(name)";
            var entities = _client.ExecuteQuery(query).Result;
            
            var listOfDictionaryEntities = entities.Select(x => new RouteValueDictionary(x));
            
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"name", "Maffin"},
                },
                new Dictionary<string, object>()
                {
                    {"name", "Woody"},
                },
                new Dictionary<string, object>()
                {
                    {"name", "Doggy"},
                },
            };
            
            CollectionAssert.AreEqual(listOfDictionaryEntities, expectedResult);
        }

        [Test]
        public void TestSelectNamesOfAnimalsFromEmptyTable()
        {
            var query = "From Animal a | Select a(name)";
            var entities = _client.ExecuteQuery(query).Result;
            
            var listOfDictionaryEntities = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>(){};
            CollectionAssert.AreEqual(listOfDictionaryEntities, expectedResult);
        }

        [Test]
        public void TestSelectMultipleFieldsOfAnimals()
        {
            SetUpTestSelectNamesOfAnimals();
            var query = "From Animal a | Select a(age, name)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"age", 5 },
                    {"name", "Maffin"},
                },
                new Dictionary<string, object>()
                {
                    { "age", 6 },
                    { "name", "Woody"},
                },
                new Dictionary<string, object>()
                {
                    {"age", 8 },
                    {"name", "Doggy"},
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestSelectMultipleFieldsOfAnimalsFromMultipleTablesCassandraAndMongo()
        {
            SetUpTestSelectNamesOfAnimals();
            var query = "From Animal a | Select a(aid, age, name)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"aid", "1"},
                    {"age", 5 },
                    {"name", "Maffin"},
                },
                new Dictionary<string, object>()
                {
                    {"aid", "2"},
                    { "age", 6 },
                    { "name", "Woody"},
                },
                new Dictionary<string, object>()
                {
                    {"aid", "3"},
                    {"age", 8 },
                    {"name", "Doggy"},
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestSelectAnimalWithFilter()
        {
            SetUpTestSelectNamesOfAnimals();
            var query = "From Animal a | where a.name == \"Maffin\" | Select a(age, name)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"age", 5 },
                    {"name", "Maffin"},
                },
            };

            CollectionAssert.AreEquivalent(result, expectedResult);
        }


        // [Test]
        public void TestDeleteOneAnimal()
        {
            SetUpTestSelectNamesOfAnimals();
            var query = "Delete From Animal a | Where a.name == \"Maffin\"";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"age", 5 },
                    {"name", "Maffin"},
                },
                new Dictionary<string, object>()
                {
                    { "age", 6 },
                    { "name", "Woody"},
                },
                new Dictionary<string, object>()
                {
                    {"age", 8 },
                    {"name", "Doggy"},
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelect1()
        {
            SetUpTestComplexSelect();
            var query = "from student s |select s(sid,age,name,taughtBy) include(taughtBy(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var t = entities.Select(x => JsonConvert.SerializeObject(x)).ToList();
            var t2 = t.Select(x => JObject.Parse(x)).ToList();
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<dynamic>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "1"},
                    {"age", 10},
                    {"name", "sn1"},
                    {"taughtBy", new JObject() {{"name", "tn1"}}}
                },
                new Dictionary<string, object>()
                {
                    {"sid", "2"},
                    {"age", 10},
                    {"name", "sn2"},
                    {"taughtBy", new JObject() {{"name", "tn2"}}}
                },
                new Dictionary<string, object>()
                {
                    {"sid", "3"},
                    {"age", 30},
                    {"name", "sn3"},
                     {"taughtBy", new JObject() {{"name", "tn3"}}}
                }
            };
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestComplexSelect2()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.taughtBy.name == \"tn1\" |select s(name,taughtBy) include(taughtBy(age, name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"name", "sn1"},
                    {"taughtBy", new JObject
                    {
                        {"age", 100},
                        {"name", "tn1"}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelect3()
        {
            SetUpTestComplexSelect();
            var query = "from teacher t | where t.teach.name == \"sn3\" |select t(name,teach) include(teach(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"name", "tn3"},
                    {"teach", new JObject
                    {
                        {"name", "sn3"}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelect4()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.age == 10 | select s(sid,age,name,taughtBy) include(taughtBy(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "1"},
                    {"age", 10},
                    {"name", "sn1"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn1"}
                    }}
                },
                new Dictionary<string, object>()
                {
                    {"sid", "2"},
                    {"age", 10},
                    {"name", "sn2"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn2"}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelect5()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.taughtBy.age == 100 | select s(sid,age,name,taughtBy) include(taughtBy(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "1"},
                    {"age", 10},
                    {"name", "sn1"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn1"}
                    }}
                },
                new Dictionary<string, object>()
                {
                    {"sid", "3"},
                    {"age", 30},
                    {"name", "sn3"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn3"}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        private void SetUpTestSelectNamesOfAnimals()
        {
            _dbsConfigurator.SetUpTestSelectNamesOfAnimals();
        }

        private void SetUpTestComplexSelect()
        {
            _dbsConfigurator.SetUpTestComplexSelect();
        }
    }
}
