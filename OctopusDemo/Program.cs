using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            const string defaultEndpoint = "http://localhost:5000";
            Console.WriteLine($"Enter the Octopus Server Endpoint(Default is {defaultEndpoint}. leave empty to use the defalut value):");
            var endpoint = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                endpoint = defaultEndpoint;
            }
            var input = "";
            while (input?.Equals("exit",StringComparison.InvariantCultureIgnoreCase) == false)
            {
                try
                {
                    Console.WriteLine("Enter Query or Write Exit:");
                    input = Console.ReadLine();
                   // input = @"from Person p | where p.name == ""Assaf"" | where p.age == 26 |select p(name,age)";
                    using (var client = new OctopusClient(endpoint))
                    {
                        var entities = await client.ExecuteQuery(input);
                        int entityCount = 1;

                        foreach (var entity in entities)
                        {
                            Console.WriteLine($"Entity {entityCount}:");
                            foreach (KeyValuePair<string,object> kvp in entity)
                            {
                                string name = kvp.Key;
                                object value = kvp.Value;
                                Console.WriteLine("{0}={1}", name, value);
                            }

                            entityCount++;
                        }
                    }
                }
                catch (Exception e)
                {
                    input = "";
                    Console.WriteLine("Error:\n\n");
                    Console.WriteLine(e);
                }
            }

        }
    }
}
