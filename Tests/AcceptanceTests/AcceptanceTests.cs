using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Octopus.Client;
using Tests.DbsConfiguration;

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
        public void TestSelect1()
        {
            // SetUpTestSelect1();
            // var query = "from animal a | Select a(*)";
            // var entities = _client.ExecuteQuery(query).Result;
            // foreach (var entity in entities)
            // {
            //     Console.WriteLine(entity.name);
            // }
        }

        [Test]
        public void TestSelect2()
        {
            // SetUpTestSelect1();
            // var query = "from animal a | Select(name)";
            // var entities = _client.ExecuteQuery(query).Result;
            // foreach (var entity in entities)
            // {
            //     Console.WriteLine(entity.name);
            // }
        }
        // private void SetUpTestSelect1()
        // {
        //     throw new NotImplementedException();
        // }
    }
}
