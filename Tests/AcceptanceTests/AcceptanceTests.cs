﻿using System;
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
            SetUpTestOfAnimals();
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
            var expectedResult = new List<Dictionary<string, object>>() { };
            CollectionAssert.AreEqual(listOfDictionaryEntities, expectedResult);
        }

        [Test]
        public void TestSelectMultipleFieldsOfAnimals()
        {
            SetUpTestOfAnimals();
            var query = "From Animal a | Select a(name, age)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"name", "Maffin"},
                    {"age", 5 },
                },
                new Dictionary<string, object>()
                {
                    { "name", "Woody"},
                    { "age", 6 },
                },
                new Dictionary<string, object>()
                {
                    {"name", "Doggy"},
                    {"age", 8 },
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestSelectMultipleFieldsOfAnimalsFromMultipleTablesCassandraAndMongo()
        {
            SetUpTestOfAnimals();
            var query = "From Animal a | Select a(aid, age, name, food, height)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"aid", "1"},
                    {"food", "f1" },
                    {"height", 23 },
                    {"age", 5 },
                    {"name", "Maffin"},


                },
                new Dictionary<string, object>()
                {
                    {"aid", "2"},
                    {"food", "f23" },
                    {"height", 23 },
                    { "age", 6 },
                    { "name", "Woody"},
                },
                new Dictionary<string, object>()
                {
                    {"aid", "3"},
                    {"food", "f23" },
                    {"height", 45 },
                    {"age", 8 },
                    {"name", "Doggy"},
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestSelectAllFieldsOfAnimalsFromMultipleTablesCassandraAndMongo()
        {
            SetUpTestOfAnimals();
            var query = "From Animal a | Select a(*)";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"aid", "1"},
                    {"food", "f1" },
                    {"height", 23 },
                    {"name", "Maffin"},
                    {"age", 5 },



                },
                new Dictionary<string, object>()
                {
                    {"aid", "2"},
                    {"food", "f23" },
                    {"height", 23 },
                    { "name", "Woody"},
                    { "age", 6 },
                },
                new Dictionary<string, object>()
                {
                    {"aid", "3"},
                    {"food", "f23" },
                    {"height", 45 },
                    {"name", "Doggy"},
                    {"age", 8 },
                },
            };

            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestSelectAnimalWithFilter()
        {
            SetUpTestOfAnimals();
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

        [Test]
        public void TestUpdateAnimalAge()
        {
            SetUpTestOfAnimals();
            var query = @"Entity Animal : an1(From Animal a | where a.aid == ""1"" | select a(aid, age))
                          Update an1.age = 23";
            var executeUpdateQuery = _client.ExecuteQuery(query).Result;

            // execute select query of the updated entity to validate that the age changed as expected
            var selectQueryToValidateUpdate = "From Animal a | where a.aid == \"1\" | Select a(aid, age)";
            var resSelectQueryToValidateUpdate = _client.ExecuteQuery(selectQueryToValidateUpdate).Result;
            var updatedEntity = resSelectQueryToValidateUpdate.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"aid", "1"},
                    {"age", 23 },
                },
            };
            CollectionAssert.AreEquivalent(updatedEntity, expectedResult);
        }

        [Test]
        public void TestUpdateAnimalHeight()
        {
            SetUpTestOfAnimals();
            var query = @"Entity Animal : an1(From Animal a | where a.aid == ""1"" | select a(aid, height))
                          Update an1.height = 345";
            var executeUpdateQuery = _client.ExecuteQuery(query).Result;
            // execute select query of the updated entity to validate that the age changed as expected
            var selectQueryToValidateUpdate = "From Animal a | where a.aid == \"1\" | Select a(height, aid)";
            var resSelectQueryToValidateUpdate = _client.ExecuteQuery(selectQueryToValidateUpdate).Result;
            var updatedEntity = resSelectQueryToValidateUpdate.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"height", 345 },
                    {"aid", "1"},
                },
            };
            CollectionAssert.AreEquivalent(updatedEntity, expectedResult);
        }

        [Test]
        public void TestUpdateAnimalFood()
        {
            SetUpTestOfAnimals();
            var query = @"Entity Animal : an1(From Animal a | where a.aid == ""1"" | select a(aid, food))
                          Update an1.food = ""newfood""";
            var executeUpdateQuery = _client.ExecuteQuery(query).Result;

            // execute select query of the updated entity to validate that the age changed as expected
            var selectQueryToValidateUpdate = "From Animal a | where a.aid == \"1\" | Select a(food, aid)";
            var resSelectQueryToValidateUpdate = _client.ExecuteQuery(selectQueryToValidateUpdate).Result;
            var updatedEntity = resSelectQueryToValidateUpdate.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"food", "newfood" },
                    {"aid", "1"},
                },
            };
            CollectionAssert.AreEquivalent(updatedEntity, expectedResult);
        }

        [Test]
        public void TestDeleteAnimal()
        {
            SetUpTestOfAnimals();
            var insertQuery = "Delete From Animal a | Where a.name == \"Maffin\"";
            var insertEntities = _client.ExecuteQuery(insertQuery).Result;
            Assert.AreEqual(0, insertEntities.Length);

            var selectQuery = "From Animal a | Where a.name == \"Maffin\" | select(name)";
            var selectEntities = _client.ExecuteQuery(insertQuery).Result;
            Assert.AreEqual(0, selectEntities.Length);
        }

        [Test]
        public void TestInsertManyEntitiesOfDifferentTypesSimultaneous()
        {
            var insertQuery =
                @"Entity Animal : an1 (aid = ""1"", name = ""Maffin"", Age = 5, food = ""f1"", height = 23)
                Entity Animal : an2 (aid = ""2"", name = ""Woody"", Age = 6, food = ""f23"", height = 23)
                Entity Address : ad1 (city = ""Tel-Aviv"", street = ""Kaplan"", number = 1)
                Entity Address : ad2 (city = ""Beer Sheva"", street = ""Rager"", number = 1)
                insert an1, an2, ad1, ad2";
            var insertEntities = _client.ExecuteQuery(insertQuery).Result;
            Assert.AreEqual(0, insertEntities.Length);

            var selectQuery1 = "From Animal a | select a(name)";
            var selectEntities1 = _client.ExecuteQuery(selectQuery1).Result;
            var result1 = selectEntities1.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult1 = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"name", "Maffin"},
                },
                new Dictionary<string, object>()
                {
                    {"name", "Woody"},
                },
            };

            CollectionAssert.AreEquivalent(expectedResult1, result1);

            var selectQuery2 = "From Address a | select a(city)";
            var selectEntities2 = _client.ExecuteQuery(selectQuery2).Result;
            var result2 = selectEntities2.Select(x => new RouteValueDictionary(x)).ToList();

            var expectedResult2 = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"city", "Tel-Aviv"},
                },
                new Dictionary<string, object>()
                {
                    {"city", "Beer Sheva"},
                },
            };

            CollectionAssert.AreEquivalent(expectedResult2, result2);
        }

        [Test]
        public void TestComplexSelectFromManyTablesWithRelationOfOneToOneWithoutFilter()
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
        public void TestComplexSelectFromManyTablesWithRelationOfOneToOneWithSimpleFilter()
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
        public void TestComplexSelectWithAllFromManyTablesWithRelationOfOneToOneWithSimpleFilter()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.age == 10 | select s(*) include(taughtBy(name))";
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
        public void TestComplexSelectOfStudentFromManyTablesWithRelationOfOneToOneWithFilterOnTeacherName()
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
        public void TestComplexSelectOfTeacherFromManyTablesWithRelationOfOneToOneWithFilter()
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
        public void TestComplexSelectOfStudentFromManyTablesWithRelationOfOneToOneWithFilterOnTeacherAge()
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

        [Test]
        public void TestComplexSelectOfStudentFromManyTablesAndDbsWithRelationOfOneToOneWithFilter()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.age == 10 | select s(sid,age,name,address) include(address(city, street,number))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x));
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "1"},
                    {"age", 10},
                    {"name", "sn1"},
                    {"address", new JObject
                    {
                        {"city", "Tel-Aviv"},
                        {"street", "Kaplan"},
                        {"number", 1}
                    }}
                },
                new Dictionary<string, object>()
                {
                    {"sid", "2"},
                    {"age", 10},
                    {"name", "sn2"},
                    {"address", new JObject
                    {
                        {"city", "Beer Sheva"},
                        {"street", "Rager"},
                        {"number", 1}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelectOfStudentFromManyTablesAndDbsWithRelationOfOneToOneWithFilterOnAddress()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.address.city == \"Beer Sheva\" | select s(sid,age,name,address, taughtBy) include(address(city, street,number)) include(taughtBy(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "2"},
                    {"age", 10},
                    {"name", "sn2"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn2"}
                    }},
                    {"address", new JObject
                    {
                        {"city", "Beer Sheva"},
                        {"street", "Rager"},
                        {"number", 1}
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
                    }},
                    {"address", new JObject
                    {
                        {"city", "Beer Sheva"},
                        {"street", "Rager"},
                        {"number", 2}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [Test]
        public void TestComplexSelectWithAllOfStudentFromManyTablesAndDbsWithRelationOfOneToOneWithFilterOnAddress()
        {
            SetUpTestComplexSelect();
            var query = "from student s | where s.address.city == \"Beer Sheva\" | select s(*) include(address(city, street,number)) include(taughtBy(name))";
            var entities = _client.ExecuteQuery(query).Result;
            var result = entities.Select(x => new RouteValueDictionary(x)).ToList();
            var expectedResult = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    {"sid", "2"},
                    {"age", 10},
                    {"name", "sn2"},
                    {"taughtBy", new JObject
                    {
                        {"name", "tn2"}
                    }},
                    {"address", new JObject
                    {
                        {"city", "Beer Sheva"},
                        {"street", "Rager"},
                        {"number", 1}
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
                    }},
                    {"address", new JObject
                    {
                        {"city", "Beer Sheva"},
                        {"street", "Rager"},
                        {"number", 2}
                    }}
                }
            };
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersBuyFromRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,buyFrom) include(buyFrom(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("buyer1", entities[0].name);
            Assert.AreEqual("seller1", entities[0].buyFrom.name.ToString());
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersBuyFromManyRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,buyFromMany) include(buyFromMany(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("buyer1", entities[0].name);
            var seller1 = (entities[0].buyFromMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "seller1");
            var seller2 = (entities[0].buyFromMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "seller2");
            Assert.AreEqual("seller1", seller1?.name.ToString());
            Assert.AreEqual("seller2", seller2?.name.ToString());
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersFavoriteSellerRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,favoriteSeller) include(favoriteSeller(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("buyer3", entities[0].name);
            Assert.AreEqual("seller3", entities[0].favoriteSeller.name.ToString());
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersFavoriteSellerManyRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,favoriteSellerMany) include(favoriteSellerMany(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("buyer3", entities[0].name);
            var seller2 = (entities[0].favoriteSellerMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "seller2");
            var seller3 = (entities[0].favoriteSellerMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "seller3");
            Assert.AreEqual("seller2", seller2?.name.ToString());
            Assert.AreEqual("seller3", seller3?.name.ToString());
        }


        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersSellToRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,sellTo) include(sellTo(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("seller1", entities[0].name);
            Assert.AreEqual("buyer1", entities[0].sellTo.name.ToString());
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersSellToManyRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,sellToMany) include(sellToMany(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 2);
            var seller1 = entities.FirstOrDefault(x => x.name == "seller1");
            var seller2 = entities.FirstOrDefault(x => x.name == "seller2");
            Assert.AreEqual("buyer1", seller1?.sellToMany[0].name.ToString());
            Assert.AreEqual("buyer1", seller2?.sellToMany[0].name.ToString());
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersFavoriteBuyerRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,favoriteBuyer) include(favoriteBuyer(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("seller1", entities[0].name);
            Assert.AreEqual("buyer1", entities[0].favoriteBuyer.name.ToString());
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersFavoriteBuyerManyRelations(string entityName)
        {
            _dbsConfigurator.SetUpTestRelations();
            var query = $"from {entityName} s | select s(name,favoriteBuyerMany) include(favoriteBuyerMany(name))";
            var entities = _client.ExecuteQuery(query).Result;
            Assert.AreEqual(entities.Length, 1);
            Assert.AreEqual("seller3", entities[0].name);
            var buyer1 = (entities[0].favoriteBuyerMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "buyer1");
            var buyer3 = (entities[0].favoriteBuyerMany as IEnumerable<dynamic>)?.FirstOrDefault(x => x.name == "buyer3");
            Assert.AreEqual("buyer1", buyer1?.name.ToString());
            Assert.AreEqual("buyer3", buyer3?.name.ToString());
        }


        private void SetUpTestOfAnimals()
        {
            _dbsConfigurator.SetUpTestOfAnimals();
        }

        private void SetUpTestComplexSelect()
        {
            _dbsConfigurator.SetUpTestComplexSelect();
        }
    }
}
