using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OctopusCore.Configuration;
using OctopusCore.Parser;
namespace Tests
{
    class Class1
    {
        public static void Main(string[] args)
        {
            // var parser = new OctopusCore.Parser.Parser();
            // var a1 = new List<string>()
            // {
            //     "From Person p | Where p.id.tyu == \"ghjghj\" | Where p.name == \"Ohad\" | Select p(a, b, c)", 
            //     "From Person p\r\n| where p.FirstName == \"Noa\"\r\n| Select p(id, FirstName, friend,enemy)  Include (friend(FirstName)) \r\nInclude (enemy(FirstName))\r\n",
            //     "From Person p\r\n| Where p.FirstName ==\"Noa\"\r\n\t| Select p(id, FirstName, friend) Include (friend(FirstName, enemy) \r\nInclude (enemy(FirstName)))",
            //     "From Person p\r\n| Where p.FirstName ==| Select p(id, FirstName, friend)"
            // };
            // var a2 = a1.Select(x => (SelectQueryInfo) parser.ParseQuery(x).Result).ToList();
            // Console.WriteLine();

            var s = new Scheme()
            {
                Entities = new List<Entity>()
                {
                    new Entity()
                    {
                        Name = "Person", Fields = new List<Field>
                        {
                            new Field
                            {
                                Name = "id",
                                ConnectedTo = null,
                                Type = "string"
                            },
                            new Field
                            {
                                Name = "age",
                                ConnectedTo = null,
                                Type = "string"
                            }
                        }
                    }
                }
            };
            var configuration = new DbConfigurations()
            {
                Configurations = new List<DbConfiguration>()
                {
                    new DbConfiguration()
                    {
                        ConnectionString = "Data Source=DataBases\\sqlite_db.db",
                        DbType = DbType.Sqlite,
                        Entities = new List<Entity>()
                        {
                            new Entity()
                            {
                                Fields = new List<Field>()
                                {
                                    new Field()
                                    {
                                        ConnectedTo = null,
                                        Name = "Id",
                                        Type = "string"
                                    },
                                    new Field()
                                    {
                                        ConnectedTo = null,
                                        Name = "age",
                                        Type = "int"
                                    },
                                    new Field()
                                    {
                                        ConnectedTo = null,
                                        Name = "name",
                                        Type = "string"
                                    }
                                },
                                Name = "Person"
                            }
                        }
                    }
                }
            };
            var a = JsonConvert.SerializeObject(s);
            var b = JsonConvert.SerializeObject(configuration);
            Console.Out.WriteLine("");
        }
    }
}
