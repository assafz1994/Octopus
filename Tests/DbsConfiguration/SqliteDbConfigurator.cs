using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace Tests.DbsConfiguration
{
    class SqliteDbConfigurator
    {
        // private string _initFilePath = "somepath";
        private string _sql1ConnectionString = "Data Source=DataBases\\sqlite1_test_db.db";
        private string _sql2ConnectionString = "Data Source=DataBases\\sqlite2_test_db.db";
        private string _sql1CreateTableFile = "CreateTableSqlite1.txt";
        private string _sql2CreateTableFile = "CreateTableSqlite2.txt";
        public void SetUpDb()
        {
            CreateTables(_sql1ConnectionString, _sql1CreateTableFile);
            CreateTables(_sql2ConnectionString, _sql2CreateTableFile);
        }

        private void CreateTables(string connectionString, string createTableFile)
        {
            using var connection = new SqliteConnection(connectionString);
            var command = connection.CreateCommand();
            command.CommandText = System.IO.File.ReadAllText(createTableFile);
            command.ExecuteNonQueryAsync();
        }
    }
}
