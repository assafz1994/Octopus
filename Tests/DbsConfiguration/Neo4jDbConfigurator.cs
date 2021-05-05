using System;
using System.Collections.Generic;
using System.Text;
using Neo4j.Driver;
using Neo4jClient;

namespace Tests.DbsConfiguration
{
    class Neo4jDbConfigurator
    {
        private string _connectionString = "bolt://localhost:7687/";
        private string _username = "neo4j";
        private string _password = "1234";
        public void SetUpDb()
        {
            
        }

        public void TearDownDb()
        {
            var tearDownStrings = new List<string>()
            {
                "match (a) -[r] -> () delete a, r",
                "match (a) delete a"
            };
            foreach (var query in tearDownStrings)
            {
                Execute(query);
            }
        }

        public List<IRecord> Execute(string query)
        {
            var session = OpenSession();

            var cursor = session.RunAsync(query).Result;
            var result = cursor.ToListAsync().Result;
            session.CloseAsync();
            return result;
        }

        public void SetUpAddresses()
        {
            var insertStrings = new List<string>()
            {
                "CREATE (n:address {city: 'Tel-Aviv', street: 'Kaplan', number: 1, guid:'6828e47d-fd3f-42d4-8e59-39621d09d373'})",
                "CREATE (n:address {city: 'Beer Sheva', street: 'Rager', number: 1, guid:'024768e9-3956-4354-a968-e194c61893bf'})",
                "CREATE (n:address {city: 'Beer Sheva', street: 'Rager', number: 2, guid:'b82fcaff-45d2-4980-b315-dbdfe996f592'})"
            };
            foreach (var insertString in insertStrings)
            {
                Execute(insertString);
            }
        }

        private IAsyncSession OpenSession()
        {
            var driver = GraphDatabase.Driver(_connectionString, AuthTokens.Basic(_username, _password));
            var session = driver.AsyncSession();
            return session;
        }
    }
}
