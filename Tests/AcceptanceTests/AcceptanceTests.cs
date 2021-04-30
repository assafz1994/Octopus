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
            
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
