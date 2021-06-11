using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DbsConfiguration
{
    class DbsConfigurator
    {
        private CassandraDbConfigurator _cassandraDbConfigurator;
        private MongoDbConfigurator _mongoDbConfigurator;
        private Neo4jDbConfigurator _neo4JDbConfigurator;
        private SqliteDbConfigurator _sqliteDbConfigurator;
        public const int NumOfRows = 10_000;

        public DbsConfigurator()
        {
           // _cassandraDbConfigurator = new CassandraDbConfigurator();
           _mongoDbConfigurator = new MongoDbConfigurator();
           _neo4JDbConfigurator = new Neo4jDbConfigurator();
           _sqliteDbConfigurator = new SqliteDbConfigurator();
        }

        public void SetUpDbs()
        {
           // _cassandraDbConfigurator.SetUpDb();
           // _mongoDbConfigurator.SetUpDb();
           _neo4JDbConfigurator.SetUpDb();
           // _sqliteDbConfigurator.SetUpDb();
        }

        public void TearDownDbs()
        {
           // _cassandraDbConfigurator.TearDownDb();
            // _mongoDbConfigurator.TearDownDb();
           _neo4JDbConfigurator.TearDownDb();
           // _sqliteDbConfigurator.TearDownDb();
        }
       
        public void SetUpTestOfAnimals()
        {
            _mongoDbConfigurator.SetUpTestOfAnimals();
            _cassandraDbConfigurator.SetUpTestSelectNamesOfAnimals();
        }
        public void SetUpTestComplexSelect()
        {
            _sqliteDbConfigurator.SetUpTestComplexSelect();
            _neo4JDbConfigurator.SetUpTestComplexSelect();
        }

        public void SetUpTestRelations()
        {
            _sqliteDbConfigurator.SetUpTestRelations();
            _neo4JDbConfigurator.SetUpRelations();
            _mongoDbConfigurator.SetUpTestOfRelations();
        }

        public void InitPerformanceTests()
        {
            // _cassandraDbConfigurator.InitPerformanceTests();
            // _mongoDbConfigurator.InitPerformanceTests();
            _neo4JDbConfigurator.InitPerformanceTests();
            // _sqliteDbConfigurator.InitPerformanceTests();
        }
    }
}
