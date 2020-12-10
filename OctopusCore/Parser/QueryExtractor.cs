using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;

namespace OctopusCore.Parser
{
    class QueryExtractor : OctopusQLBaseVisitor<QueryInfo>
    {
        public override QueryInfo VisitR([NotNull] OctopusQLParser.RContext context)
        {
            Console.WriteLine();
            return base.VisitR(context);
        }
    }
}
