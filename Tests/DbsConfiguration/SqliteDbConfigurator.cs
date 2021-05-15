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
        public string Sql1ConnectionString = "Data Source=DataBases\\sqlite1_test_db.db";
        public string Sql2ConnectionString = "Data Source=DataBases\\sqlite2_test_db.db";
        private string _sql1CreateTableFile = "CreateTableSqlite1.txt";
        private string _sql2CreateTableFile = "CreateTableSqlite2.txt";
        private string _sql1DropTables;
        private string _sql2DropTables;
        private string _init1;
        private string _init2;
        private string _insert1;
        private string _insertAnimals;

        public SqliteDbConfigurator()
        {
            _sql1DropTables = @"DROP TABLE IF EXISTS ""student_table"";
                              DROP TABLE IF EXISTS ""teacher_table"";
                              DROP TABLE IF EXISTS ""student_teacher_taughtBy_teach""; ";
            _sql2DropTables = @"DROP TABLE IF EXISTS ""student_table"";
                              DROP TABLE IF EXISTS ""address_student__address"";";
            _init1 = _sql1DropTables +
                @"CREATE TABLE  IF NOT EXISTS ""student_table"" (
	                ""guid""	TEXT,
                    ""sid"" TEXT,
   	                ""age"" INT,
	                ""name""	TEXT,
	                PRIMARY KEY(""guid"")
                );

                CREATE TABLE IF NOT EXISTS ""teacher_table"" (
	                ""guid""	TEXT,
                    ""tid"" TEXT,
   	                ""age"" INT,
	                ""name""	TEXT,
	                PRIMARY KEY(""guid"")
                );

                CREATE TABLE ""student_teacher_taughtBy_teach"" (
	                ""student""	TEXT,
	                ""teacher""	TEXT,
	                PRIMARY KEY(""student"",""teacher"")
                );

                Create table IF NOT EXISTS ""Animal_table""
                (
                    ""guid""	TEXT,
                    ""aid""	TEXT,
                    ""food"" TEXT,
   	                ""height"" INT,
		            PRIMARY KEY(""guid"")
                );";
            _init2 = _sql2DropTables +
                @"CREATE TABLE IF NOT EXISTS ""student_table"" (
	                ""guid"" TEXT PRIMARY KEY,
	                ""sid"" TEXT
                );

                CREATE TABLE IF NOT EXISTS ""address_student__address"" (
	                ""address"" TEXT,
	                ""student"" TEXT,
	                PRIMARY KEY(""address"",""student"")
                );";
            _insert1 = @"INSERT INTO ""student_table"" (guid,sid,age,name) VALUES(""ba78c4f3-deb0-4d51-8604-ae95c16cb147"",""1"",10,""sn1"");
                INSERT INTO ""student_table"" (guid,sid,age,name) VALUES(""0433b07f-1d77-4f58-a58d-91daae887502"",""2"",10,""sn2"");
                INSERT INTO ""student_table"" (guid,sid,age,name) VALUES(""8f147986-8658-4561-860c-d1b23a134660"",""3"",30,""sn3"");

                INSERT INTO ""teacher_table"" (guid,tid,age,name) VALUES(""389a7f06-8ed0-4753-8ff5-1350652102f8"",""1"",100,""tn1"");
                INSERT INTO ""teacher_table"" (guid,tid,age,name) VALUES(""7bed1d94-41a2-4681-894c-6c6dcc41a45b"",""2"",200,""tn2"");
                INSERT INTO ""teacher_table"" (guid,tid,age,name) VALUES(""f7b97e2a-e885-49e3-811d-201e72b27406"",""3"",100,""tn3"");

                INSERT INTO student_teacher_taughtBy_teach (student,teacher) 
                VALUES(""ba78c4f3-deb0-4d51-8604-ae95c16cb147"",""389a7f06-8ed0-4753-8ff5-1350652102f8"");
                INSERT INTO student_teacher_taughtBy_teach (student,teacher) 
                VALUES(""0433b07f-1d77-4f58-a58d-91daae887502"",""7bed1d94-41a2-4681-894c-6c6dcc41a45b"");
                INSERT INTO student_teacher_taughtBy_teach (student,teacher) 
                VALUES(""8f147986-8658-4561-860c-d1b23a134660"",""f7b97e2a-e885-49e3-811d-201e72b27406"");";
            _insertAnimals = @"INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""9264f435-d1c7-4f1c-8b84-cf4bdb935641"",""1"",""f1"",23);
                INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""e8d706f8-92be-429c-89cc-91973fca7a95"",""2"",""f23"",23);
                INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""f443f95a-3d8f-4786-b3e6-0db8b790f7e6"",""3"",""f23"",45);";
        }
        public void SetUpDb()
        {
            SendCommand(Sql1ConnectionString, _init1);
            SendCommand(Sql2ConnectionString, _init2);
        }

        public void TearDownDb()
        {
            SendCommand(Sql1ConnectionString, _sql1DropTables);
            SendCommand(Sql2ConnectionString, _sql2DropTables);
        }

        public void SendCommand(string connectionString, string commandText)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQueryAsync();
        }

        public void SetUpTestComplexSelect()
        {
            SendCommand(Sql1ConnectionString, _insert1);
        }

        public void SetUpTestAnimals()
        {
            SendCommand(Sql1ConnectionString, _insertAnimals);
        }
    }
}
