using System;
using System.Collections.Generic;
using System.Text;
using OctopusCore.Parser;
namespace Tests
{
    class Class1
    {
        public static void Main(string[] args)
        {
            var parser = new Parser();
            var s = "From Person p | Where p.id.tyu == \"ghjghj\" | Where p.name == \"Ohad\" | Select p(a, b, c)";
            var task= parser.ParseQuery(s);
            var res = task.Result;
            Console.WriteLine();
        }
    }
}
