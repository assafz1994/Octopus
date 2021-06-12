using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Tests.DbsConfiguration
{
    internal class SqliteDbConfigurator
    {
        private const string DropTableTemplate = @"DROP TABLE IF EXISTS ""{0}"";
";

        private const string InsertTemplate = @"INSERT INTO ""{0}"" ({1},{2}) VALUES(""{3}"",""{4}"");
";

        private const string CreateRelationsEntityTableTemplate = @"CREATE TABLE  IF NOT EXISTS ""{0}"" (
	                ""guid"" TEXT,
                    ""name"" TEXT,
	                PRIMARY KEY(""guid"")
                );
";

        private const string RelationTableTemplate = "{0}_{1}_{2}_{3}";

        private const string CreateRelationsTestsRelationsTableTemplate = @"CREATE TABLE  IF NOT EXISTS ""{0}"" (
	                ""{1}""	TEXT,
                    ""{2}"" TEXT,
	                PRIMARY KEY(""{3}"",""{4}""));
";

        private readonly string _init1;
        private readonly string _init2;
        private readonly string _insert1;
        private readonly string _insertAnimals;

        private readonly string[] _relationsTestBuyersEntitiesTablesNames =
        {
            "buyersqlsql_table",
            "buyersqlmongo_table",
            "buyersqlneo_table"
        };

        private readonly (string Entity1, string Entity2, string Field1, string Field2)[] _relationsTestRelationsTuples
            =
            {
                ("buyersqlsql", "sellersqlsql", "buyFrom", "sellTo"),
                ("buyersqlsql", "sellersqlsql", "buyFromMany", "sellToMany"),
                ("buyersqlsql", "sellersqlsql", "favoriteSeller", ""),
                ("buyersqlsql", "sellersqlsql", "favoriteSellerMany", ""),
                ("buyersqlsql", "sellersqlsql", "", "favoriteBuyer"),
                ("buyersqlsql", "sellersqlsql", "", "favoriteBuyerMany"),
                ("buyersqlmongo", "sellermongosql", "buyFrom", "sellTo"),
                ("buyersqlmongo", "sellermongosql", "buyFromMany", "sellToMany"),
                ("buyersqlmongo", "sellermongosql", "favoriteSeller", ""),
                ("buyersqlmongo", "sellermongosql", "favoriteSellerMany", ""),
                ("buyersqlneo", "sellerneosql", "buyFrom", "sellTo"),
                ("buyersqlneo", "sellerneosql", "buyFromMany", "sellToMany"),
                ("buyersqlneo", "sellerneosql", "favoriteSeller", ""),
                ("buyersqlneo", "sellerneosql", "favoriteSellerMany", "")
            };

        private readonly string[] _relationsTestSellersEntitiesTablesNames =
        {
            "sellersqlsql_table"
        };


        private readonly string _sql1DropTables;
        private readonly string _sql2DropTables;
        public readonly string Sql1ConnectionString;
        public readonly string Sql2ConnectionString = "Data Source=DataBases\\sqlite2_test_db.db";

        public SqliteDbConfigurator(string sql1ConnectionString)
        {
            Sql1ConnectionString = sql1ConnectionString;
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

                Create table IF NOT EXISTS ""animal_table""
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
            _insert1 =
                @"INSERT INTO ""student_table"" (guid,sid,age,name) VALUES(""ba78c4f3-deb0-4d51-8604-ae95c16cb147"",""1"",10,""sn1"");
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
            _insertAnimals =
                @"INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""9264f435-d1c7-4f1c-8b84-cf4bdb935641"",""1"",""f1"",23);
                INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""e8d706f8-92be-429c-89cc-91973fca7a95"",""2"",""f23"",23);
                INSERT INTO ""animal_table"" (guid,aid,food,height) VALUES(""f443f95a-3d8f-4786-b3e6-0db8b790f7e6"",""3"",""f23"",45);";
        }

        public void SetUpDb()
        {
            SendCommand(Sql1ConnectionString, _init1);
            SendCommand(Sql2ConnectionString, _init2);
            SendCommand(Sql1ConnectionString, GetInitRelationsQuery());
        }

        public void TearDownDb()
        {
            SendCommand(Sql1ConnectionString, _sql1DropTables);
            SendCommand(Sql2ConnectionString, _sql2DropTables);
            SendCommand(Sql1ConnectionString, GetDropRelationsQuery());
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

        public void SetUpTestRelations()
        {
            SendCommand(Sql1ConnectionString, GetInsertRelationsQuery());
        }


        private string GetInitRelationsQuery()
        {
            var sb = new StringBuilder();
            sb.Append(GetDropRelationsQuery());
            //entities tables
            foreach (var entityTableName in
                _relationsTestBuyersEntitiesTablesNames.Concat(_relationsTestSellersEntitiesTablesNames))
                sb.AppendFormat(CreateRelationsEntityTableTemplate, entityTableName);
            //relations tables
            foreach (var (entity1, entity2, field1, field2) in _relationsTestRelationsTuples)
            {
                var tableName = string.Format(RelationTableTemplate, entity1, entity2, field1, field2);
                sb.AppendFormat(CreateRelationsTestsRelationsTableTemplate, tableName, entity1, entity2, entity1,
                    entity2);
            }

            return sb.ToString();
        }

        private string GetDropRelationsQuery()
        {
            var sb = new StringBuilder();

            //entities tables
            foreach (var entityTableName in _relationsTestBuyersEntitiesTablesNames.Concat(
                _relationsTestSellersEntitiesTablesNames)) sb.AppendFormat(DropTableTemplate, entityTableName);
            //relations tables
            foreach (var (entity1, entity2, field1, field2) in _relationsTestRelationsTuples)
            {
                var tableName = string.Format(RelationTableTemplate, entity1, entity2, field1, field2);
                sb.AppendFormat(DropTableTemplate, tableName);
            }

            return sb.ToString();
        }

        private string GetInsertRelationsQuery()
        {
            var sb = new StringBuilder();

            //entities tables 
            foreach (var entityTableName in _relationsTestBuyersEntitiesTablesNames)
            foreach (var (guid, name) in RelationsConsts.Buyers)
                sb.AppendFormat(InsertTemplate, entityTableName, "guid", "name", guid, name);

            foreach (var entityTableName in _relationsTestSellersEntitiesTablesNames)
            foreach (var (guid, name) in RelationsConsts.Sellers)
                sb.AppendFormat(InsertTemplate, entityTableName, "guid", "name", guid, name);

            //relations tables
            foreach (var (entity1, entity2, field1, field2) in _relationsTestRelationsTuples)
            {
                var tableName = string.Format(RelationTableTemplate, entity1, entity2, field1, field2);
                foreach (var (guid1, guid2) in RelationsConsts.FieldsValuesMappings[(field1, field2)])
                    sb.AppendFormat(InsertTemplate, tableName, entity1, entity2, guid1, guid2);
            }

            return sb.ToString();
        }
    }
}