using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using OctopusCore.Parser;

namespace Tests.DbsConfiguration
{
    class SqliteDbConfigurator
    {
        // private string _initFilePath = "somepath";
        private string _sql1ConnectionString = "Data Source=DataBases\\sqlite1_test_db.db";
        private string _sql2ConnectionString = "Data Source=DataBases\\sqlite2_test_db.db";
        private string _sql1CreateTableFile = "CreateTableSqlite1.txt";
        private string _sql2CreateTableFile = "CreateTableSqlite2.txt";
        private string _sql1DropTables = "DROP TABLE student_table;" +
                                         "DROP TABLE teacher_table;" +
                                         "DROP TABLE student_teacher_taughtBy_teach;";

        private string _sql2DropTables = "DROP TABLE student_table;" +
                                         "DROP TABLE address_student__address;";

        private string _init1 =
            @"CREATE TABLE IF NOT EXISTS student_table (
	            guid TEXT PRIMARY KEY,
	            sid TEXT NOT NULL,
   	            age INT NOT NULL,
	            name TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS teacher_table (
	            guid TEXT PRIMARY KEY,
	            tid TEXT NOT NULL,
   	            age INT NOT NULL,
	            name TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS student_teacher_taughtBy_teach (
	            student	TEXT,
	            teacher	TEXT,
	            PRIMARY KEY(student,teacher)
            );";
        private string _init2 =
            @"CREATE TABLE IF NOT EXISTS student_table (
	            guid TEXT PRIMARY KEY,
	            sid TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS address_student__address (
	            address TEXT,
	            student TEXT,
	            PRIMARY KEY(address,student)
            );";
        public void SetUpDb()
        {
            CreateTables(_sql1ConnectionString, _init1);
            CreateTables(_sql2ConnectionString, _init2);
        }

        private void CreateTables(string connectionString, string createTableFile)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = createTableFile;
            command.ExecuteNonQuery();
        }

        public void TearDownDb()
        {
            DropTables(_sql1ConnectionString, _sql1DropTables);
            DropTables(_sql2ConnectionString, _sql2DropTables);
        }

        private void DropTables(string connectionString, string dropQuery)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = dropQuery;
            command.ExecuteNonQueryAsync();
        }
    }
}
