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

        private string _init =
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

        public CassandraDbConfigurator()
        {
            _cluster = Cluster.Builder()
                .AddContactPoint(_connectionString)
                .Build();
            _session = _cluster.Connect(_keySpace);
        }

        public void SetUpDb()
        {
            var queries = _init.Split(';').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            foreach (var query in queries)
            {
                _session.Execute(query);
            }
        }

        public void TearDownDb()
        {
            _session.Execute("DROP animal_table");
            _session.Execute("DROP animal_table_by_height");
            _session.Execute("DROP animal_table_by_food_height");
        }
    }
}
