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
            TearDownDb();
        }

        private readonly string[] _buyersEntities =
        {
            "buyerneoneo",
        };

        private readonly string[] _sellersEntities =
        {
            "sellerneosql",
            "sellerneomongo",
            "sellerneoneo"
        };

        private readonly string[] _buyersEntitiesWithJustGuids =
        {
            "buyersqlneo",
            "buyermongoneo"
        };

        private readonly (string Entity1, string Entity2, string Field1, string Field2)[] _relationsTestRelationsTuples
            =
            {
                ("buyerneoneo", "sellerneoneo", "buyFrom", "sellTo"),
                ("buyerneoneo", "sellerneoneo", "buyFromMany", "sellToMany"),
                ("buyerneoneo", "sellerneoneo", "favoriteSeller", ""),
                ("buyerneoneo", "sellerneoneo", "favoriteSellerMany", ""),
                ("buyerneoneo", "sellerneoneo", "", "favoriteBuyer"),
                ("buyerneoneo", "sellerneoneo", "", "favoriteBuyerMany"),
                ("buyersqlneo", "sellerneosql", "", "favoriteBuyer"),
                ("buyersqlneo", "sellerneosql", "", "favoriteBuyerMany"),
                ("buyermongoneo", "sellerneomongo", "", "favoriteBuyer"),
                ("buyermongoneo", "sellerneomongo", "", "favoriteBuyerMany")
            };

        private const string CreateNodeTemplate =
            @"CREATE (n:{0} {{name: '{1}', guid: '{2}'}})";
        private const string CreateNodeJustGuidTemplate =
            @"CREATE (n:{0} {{guid: '{1}'}})";

        private const string CreateEdgeTemplate =
            @"MATCH  (a:{0}),  (b:{1}) WHERE a.guid = '{2}' AND b.guid = '{3}' CREATE (a)-[r:{4}]->(b)";


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

        public void SetUpRelations()
        {
            var commands = new List<string>();


            foreach (var entity in _buyersEntitiesWithJustGuids)
            {
                foreach (var (guid, _) in RelationsConsts.Buyers)
                {
                    commands.Add(string.Format(CreateNodeJustGuidTemplate, entity, guid));
                }
            }

            foreach (var entity in _buyersEntities)
            {
                foreach (var (guid, name) in RelationsConsts.Buyers)
                {
                    commands.Add(string.Format(CreateNodeTemplate, entity, name, guid));
                }
            }

            foreach (var entity in _sellersEntities)
            {
                foreach (var (guid, name) in RelationsConsts.Sellers)
                {
                    commands.Add(string.Format(CreateNodeTemplate, entity, name, guid));
                }
            }

            foreach (var (entity1, entity2, field1, field2) in _relationsTestRelationsTuples)
            {
                foreach (var (guid1, guid2) in RelationsConsts.FieldsValuesMappings[(field1, field2)])
                {
                    if (string.IsNullOrEmpty(field1) == false)
                    {
                        commands.Add(string.Format(CreateEdgeTemplate, entity1, entity2, guid1, guid2, field1));
                    }
                    if (string.IsNullOrEmpty(field2) == false)
                    {
                        commands.Add(string.Format(CreateEdgeTemplate, entity2, entity1, guid2, guid1, field2));
                    }

                }
            }



            foreach (var command in commands)
            {
                Execute(command);
            }
        }

        private IAsyncSession OpenSession()
        {
            var driver = GraphDatabase.Driver(_connectionString, AuthTokens.Basic(_username, _password));
            var session = driver.AsyncSession();
            return session;
        }

        public void SetUpTestComplexSelect()
        {
            SetUpAddresses();
        }

        public void InitPerformanceTests()
        {
            var commands = new List<string>();

            const int numOfRows = DbsConfigurator.NumOfRows;

            foreach (var entity in _buyersEntitiesWithJustGuids)
            {
                for (var i = 0; i < numOfRows; i++)
                {
                    var guid = $"00000000-0000-0000-0000-000000{i:D6}";
                    commands.Add(string.Format(CreateNodeJustGuidTemplate, entity, guid));
                }
            }

            foreach (var entity in _buyersEntities)
            {
                for (var i = 0; i < numOfRows; i++)
                {
                    var guid = $"0000000-0000-0000-0000-000000{i:D6}";
                    var name = $"buyer{i}";
                    commands.Add(string.Format(CreateNodeTemplate, entity, name, guid));
                }
            }

            foreach (var entity in _sellersEntities)
            {
                for (var i = 0; i < numOfRows; i++)
                {
                    var guid = $"1000000-0000-0000-0000-000000{i:D6}";
                    var name = $"seller{i}";
                    commands.Add(string.Format(CreateNodeTemplate, entity, name, guid));
                }
            }

            for (var i = 0; i < numOfRows; i++)
            {
                var guidBuyer = $"0000000-0000-0000-0000-000000{i:D6}";
                var guidSeller = $"1000000-0000-0000-0000-000000{i:D6}";
                commands.Add(string.Format(CreateEdgeTemplate, "buyerneoneo", "sellerneoneo", guidBuyer, guidSeller, "buyFrom"));
                commands.Add(string.Format(CreateEdgeTemplate, "sellerneoneo", "buyerneoneo", guidSeller, guidBuyer, "sellTo"));

            }

            foreach (var command in commands)
            {
                Execute(command);
            }
        }
    }
}
