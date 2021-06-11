using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Octopus.Client;
using Tests.DbsConfiguration;

namespace OctopusDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpoint = GetEndpointDialog();

            InitDbDialog();

            await RunQueryDialog(endpoint);
        }

        static string GetEndpointDialog()
        {
            const string defaultEndpoint = "http://localhost:5000";
            Console.WriteLine($"Enter the Octopus Server Endpoint(Default is {defaultEndpoint}. leave empty to use the default value):");
            var endpoint = Console.ReadLine();
            return string.IsNullOrWhiteSpace(endpoint) ? defaultEndpoint : endpoint;
        }

        static void InitDbDialog()
        {
            Console.WriteLine("Do you want to Init the Databases? Choose the desired option:");
            Console.WriteLine("1) Complex Select Init");
            Console.WriteLine("2) Animals Init");
            Console.WriteLine("3) Relations Init");
            Console.WriteLine("4) Continue Without Init");
            var answer = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(answer) == false && int.TryParse(answer, out var selectedOption))
            {
                if (selectedOption > 0 && selectedOption < 4)
                {
                    try
                    {
                        var configurator = new DbsConfigurator();
                        configurator.SetUpDbs();
                        switch (selectedOption)
                        {
                            case 1:
                                configurator.SetUpTestComplexSelect();
                                break;
                            case 2:
                                configurator.SetUpTestOfAnimals();
                                break;
                            case 3:
                                configurator.SetUpTestRelations();
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed To Init DB. Exception={e}");
                    }
                }
                else
                {
                    Console.WriteLine("Skipping Db Init");

                }
            }
            else
                Console.WriteLine("Skipping Db Init");
        }

        static async Task RunQueryDialog(string endpoint)
        {
            var input = "";
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Query or Write Exit:");
                    input = Console.ReadLine();

                    if (input?.Equals("exit", StringComparison.InvariantCultureIgnoreCase) == true)
                    {
                        Console.WriteLine("Thank you for using OctopusDB! See you next time");
                        break;
                    }
                    using (var client = new OctopusClient(endpoint))
                    {
                        var entities = await client.ExecuteQuery(input);
                        int entityCount = 1;

                        foreach (var entity in entities)
                        {
                            Console.WriteLine($"Entity {entityCount}:");
                            foreach (KeyValuePair<string, object> kvp in entity)
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
