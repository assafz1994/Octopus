using System;
using System.Collections.Generic;
using System.Text;
using Cassandra;

namespace Tests.DbsConfiguration
{
    class CassandraDbConfigurator
    {
        private Cluster _cluster;
        private ISession _session;
        private string _connectionString = "127.0.0.1";
        private string _keySpace = "OctopusTests";
        private string _cassandraCreateTableFile = "CreateTableCassandra.txt";

        public CassandraDbConfigurator()
        {
            _cluster = Cluster.Builder()
                .AddContactPoint(_connectionString)
                .Build();
            _session = _cluster.Connect(_keySpace);
        }

        public void SetUpDb()
        {
            _session.Execute(System.IO.File.ReadAllText(_cassandraCreateTableFile));
        }

        public void TearDownDb()
        {
            _session.Execute(
                "TRUNCATE Animal_table;" +
                "TRUNCATE Animal_table_by_height;" +
                "TRUNCATE Animal_table_by_food_height;"
                );
        }
    }
}
