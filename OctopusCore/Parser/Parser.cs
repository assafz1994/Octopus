using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace OctopusCore.Parser
{
    class Parser : IParser
    {
        public async Task<QueryInfo> ParseQuery(string query)
        {
            var target = new AntlrInputStream(query);
            var lexer = new OctopusQLLexer(target);
            var tokens = new CommonTokenStream(lexer);
            var parser = new OctopusQLParser(tokens)
            {
                BuildParseTree = true
            };

            var tree = parser.r();
            var queryExtractor = new QueryExtractor();
            var output = queryExtractor.Visit(tree);
            return output;
        }
    }
}
