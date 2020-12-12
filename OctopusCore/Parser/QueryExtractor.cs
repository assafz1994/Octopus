using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using OctopusCore.Parser.Filters;

namespace OctopusCore.Parser
{
    internal class QueryExtractor : OctopusQLBaseVisitor<QueryInfo>
    {
        public override QueryInfo VisitR([NotNull] OctopusQLParser.RContext context)
        {
            if (context.@select() != null)
            {
                return VisitSelect(context.@select());
            }
            return new QueryInfo();
            // return base.VisitR(context);
        }

        private QueryInfo VisitSelect([NotNull] OctopusQLParser.SelectContext selectContext)
        {
            var entity = selectContext.entity().GetText();
            var filters = new ArrayList<Filter>();
            foreach (var whereClause in selectContext.whereClause())
            {
                var fieldNames = new ArrayList<string>();
                fieldNames.AddRange(whereClause.attributesWithDot()._el.Select(attribute => attribute.GetText()));
                var value = whereClause.value().GetText();
                var filter = new EqFilter(fieldNames, value);
                filters.Add(filter);
            }

            if (selectContext.selectClause() != null)
            {
                var field = new Field();
                foreach (var includeContext in selectContext.selectClause().include())
                {
                    
                }
            }
            return null;
        }
    }
}
