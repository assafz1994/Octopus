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
        public const string All = "$ALL$";
        public override QueryInfo VisitR([NotNull] OctopusQLParser.RContext context)
        {
            if (context.@select() != null)
            {
                return HandleSelect(context.@select());
            }
            return new SelectQueryInfo();
            // return base.VisitR(context);
        }

        private SelectQueryInfo HandleSelect([NotNull] OctopusQLParser.SelectContext selectContext)
        {
            var selectQueryInfo = new SelectQueryInfo();
            var comparatorToFilter = new Dictionary<string, Func<List<string>, string, Filter>>()
            {
                {"==", (list, s) => new EqFilter(list, s)},
            };
            selectQueryInfo.Entity = selectContext.entity().GetText().ToLower();
            var filters = new List<Filter>();
            foreach (var whereClause in selectContext.whereClause())
            {
                var fieldNames = new List<string>();
                fieldNames.AddRange(whereClause.fieldsWithDot()._el.Select(field => field.GetText().ToLower()));
                var value = whereClause.value().GetText();
                var comparator = whereClause.COMPARATOR().GetText(); 
                var filter = comparatorToFilter[comparator](fieldNames, value);
                filters.Add(filter);
            }
            selectQueryInfo.Filters = filters;
            
            if (selectContext.selectClause() != null)
            {
                var fields = new List<string>();
                var nestedProperty = new ArrayList<string>();
                if (selectContext.selectClause().all() != null)
                {
                    fields.Add(All);
                }
                else if (selectContext.selectClause().fields() != null)
                {
                    fields.AddRange(selectContext.selectClause().fields()._fieldList.Select(fieldContext => fieldContext.GetText().ToLower()));
                }

                if (selectContext.selectClause().fieldsWithDot() != null)
                {
                    nestedProperty.AddRange(selectContext.selectClause().fieldsWithDot()._el.Select(field => field.GetText().ToLower()));
                }

                var includes = selectContext.selectClause().include().Select(includeContext => new Include(includeContext)).ToList();
                selectQueryInfo.Fields = fields;
                selectQueryInfo.Includes = includes;
                selectQueryInfo.NestedProperty = nestedProperty;
            }
            return selectQueryInfo;
        }
    }
}
