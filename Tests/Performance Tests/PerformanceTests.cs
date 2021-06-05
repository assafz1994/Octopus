using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Octopus.Client;
using Tests.DbsConfiguration;

namespace Tests.Performance_Tests
{
    class PerformanceTests
    {
        private OctopusClient _client;
        private DbsConfigurator _dbsConfigurator;
        private const int NumOfEntries = 100000;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _client = new OctopusClient("http://localhost:5000");
            _dbsConfigurator = new DbsConfigurator();
            _dbsConfigurator.SetUpDbs();
            _dbsConfigurator.InitPerformanceTests();
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersBuyFromRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,buyFrom) include(buyFrom(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersBuyFromManyRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,buyFromMany) include(buyFromMany(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            var diff = endTime - startTime;
            System.Diagnostics.Trace.WriteLine(diff);
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersFavoriteSellerRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,favoriteSeller) include(favoriteSeller(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("buyersqlsql")]
        [TestCase("buyersqlmongo")]
        [TestCase("buyersqlneo")]
        [TestCase("buyermongoneo")]
        [TestCase("buyerneoneo")]
        [TestCase("buyermongomongo")]
        public void TestBuyersFavoriteSellerManyRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,favoriteSellerMany) include(favoriteSellerMany(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }


        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersSellToRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,sellTo) include(sellTo(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersSellToManyRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,sellToMany) include(sellToMany(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersFavoriteBuyerRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,favoriteBuyer) include(favoriteBuyer(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }

        [TestCase("sellersqlsql")]
        [TestCase("sellermongosql")]
        [TestCase("sellerneosql")]
        [TestCase("sellerneomongo")]
        [TestCase("sellerneoneo")]
        [TestCase("sellermongomongo")]
        public void TestSellersFavoriteBuyerManyRelations(string entityName)
        {
            var query = $"from {entityName} s | select s(name,favoriteBuyerMany) include(favoriteBuyerMany(name))";
            var startTime = DateTime.Now;
            var entities = _client.ExecuteQuery(query).Result;
            var endTime = DateTime.Now;
            Assert.AreEqual(entities.Length, NumOfEntries);
        }
    }
}
