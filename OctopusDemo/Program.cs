using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Octopus.Client;

namespace OctopusDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var query = @"from Person p | where p.name == ""Assaf"" | where p.age == 26 |select p(name,age)";

            using (var client = new OctopusClient("http://localhost:5000"))
            {
                var entities = await client.ExecuteQuery(query);
                foreach (var entity in entities)
                {
                    Console.WriteLine(entity.name);
                }
            }
        }
    }
}
