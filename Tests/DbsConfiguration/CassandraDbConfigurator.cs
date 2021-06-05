using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cassandra;

namespace Tests.DbsConfiguration
{
    class CassandraDbConfigurator
    {
        private Cluster _cluster;
        private ISession _session;
        private string _connectionString = "127.0.0.1";
        private string _keySpace = "octopustests";
        private string _cassandraCreateTableFile = "CreateTableCassandra.txt";
        private List<string> _tables;
        private string _init;

        public CassandraDbConfigurator()
        {
            _cluster = Cluster.Builder()
                .AddContactPoint(_connectionString)
                .Build();
            _session = _cluster.Connect(_keySpace);
            _tables = new List<string>()
            {
                "animal_table",
                "animal_table_by_height",
                "animal_table_by_food_height"
            };
            _init =
                @"CREATE KEYSPACE IF NOT EXISTS OctopusTests WITH replication = {'class': 'SimpleStrategy', 'replication_factor': '1'}  AND durable_writes = true;

                Create table IF NOT EXISTS Animal_table
                (
                    guid UUID,
                    aid text,
                    food text,
                    height int,
                PRIMARY KEY(guid)
                    );

                Create table IF NOT EXISTS Animal_table_by_height
                (
                    guid UUID,
                    aid text,
                    food text,
                    height int,
                PRIMARY KEY(height, guid)
                
                    );

                Create table IF NOT EXISTS Animal_table_by_food_height
                (
                    guid UUID,
                    aid text,
                    food text,
                    height int,
                PRIMARY KEY(food, height, guid)
                );";
        }

        public void SetUpDb()
        {
            TearDownDb();
            var queries = GetQueriesFromString(_init);
            foreach (var query in queries)
            {
                _session.Execute(query);
            }
        }

        private IEnumerable<string> GetQueriesFromString(string queriesString)
        {
            return queriesString.Split(';').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public void TearDownDb()
        {
            foreach (var table in _tables)
            {
                _session.Execute($"DROP table IF EXISTS {table}");
            }
        }

        public void SetUpTestSelectNamesOfAnimals()
        {
            var animals = new List<Dictionary<string, string>>() { 
                new Dictionary<string, string>
                {
                    {"guid", "9264f435-d1c7-4f1c-8b84-cf4bdb935641"},
                    {"aid", "'1'"},
                    {"food", "'f1'" },
                    {"height", "23" }
                },
                new Dictionary<string, string>
                {
                    {"guid", "e8d706f8-92be-429c-89cc-91973fca7a95"},
                    {"aid", "'2'"},
                    {"food", "'f23'" },
                    {"height", "23" }
                },
                new Dictionary<string, string>
                {
                    {"guid", "f443f95a-3d8f-4786-b3e6-0db8b790f7e6"},
                    {"aid", "'3'"},
                    {"food", "'f23'" },
                    {"height", "45" }
                }
            };

            foreach (var table in _tables)
            foreach (var animal in animals)
            {
                var animalToList = animal.ToList();
                var query = $"INSERT INTO {table} " +
                            $"({string.Join(",", animalToList.Select(x => x.Key))}) " +
                            $"values " +
                            $"({string.Join(",", animalToList.Select(x => x.Value))});";
                _session.Execute(query);
            }
        }

        public RowSet Execute(string query)
        {
            return _session.Execute(query);
        }

        public List<string> GetTables()
        {
            return _tables;
        }

        public void InitPerformanceTests()
        {
            
        }
    }
}
