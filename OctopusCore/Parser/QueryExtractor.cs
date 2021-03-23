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
            if (context.@insert() != null)
            {
                return HandleInsert(context.@insert());
            }
            return new SelectQueryInfo();
            // return base.VisitR(context);
        }

        private InsertQueryInfo HandleInsert(OctopusQLParser.InsertContext insert)
        {
            var parserEntities = new List<ParserEntity>();
            
            foreach (var insertClauseContext in insert.insertClause())
            {
                if (insertClauseContext.assignments() == null)
                {
                    throw new Exception("insert with selection is not supported");
                }

                var entityType = insertClauseContext.entity().GetText().ToLower();
                var entityName = insertClauseContext.entityRep().GetText();
                var fields = new Dictionary<string, dynamic>();
                foreach (var assignmentContext in insertClauseContext.assignments()._assignmentList)
                {
                    dynamic value;
                    if (assignmentContext.value().NUMBER() != null)
                    {
                        value = int.Parse(assignmentContext.value().GetText());
                    }
                    else
                    {
                        value = assignmentContext.value().GetText();
                    }

                    fields[assignmentContext.field().GetText().ToLower()] = value;
                }
                parserEntities.Add(new ParserEntity(entityType, entityName, fields));
            }

            var entityReps = insert.entityReps()._entityRepList.Select(x => x.GetText()).ToList();
            var entityNames = parserEntities.Select(x => x.EntityName).ToList();
            var set1 = new HashSet<string>(entityReps);
            var set2 = new HashSet<string>(entityNames);
            if (!set1.SetEquals(set2))
            {
                throw new Exception("length must be the same");
            }
            return new InsertQueryInfo(parserEntities, entityReps);
        }

        private SelectQueryInfo HandleSelect([NotNull] OctopusQLParser.SelectContext selectContext)
        {
            var selectQueryInfo = new SelectQueryInfo();
            var comparatorToFilter = new Dictionary<string, Func<List<string>, string, bool, Filter>>()
            {
                {"==", (list, s, b) => new EqFilter(list, s, b)},
            };
            selectQueryInfo.Entity = selectContext.entity().GetText().ToLower();
            var filters = new List<Filter>();
            foreach (var whereClause in selectContext.whereClause())
            {
                var fieldNames = new List<string>();
                fieldNames.AddRange(whereClause.fieldsWithDot()._el.Select(field => field.GetText().ToLower()));
                string value;
                var isQueried = false;
                if (whereClause.value().select() != null)
                {
                    var guid = System.Guid.NewGuid().ToString();
                    selectQueryInfo.SubQueries.Add(guid, HandleSelect(whereClause.value().select()));
                    value = guid;
                    isQueried = true;
                }
                else
                {
                    value = whereClause.value().GetText();
                }
                var comparator = whereClause.COMPARATOR().GetText(); 
                var filter = comparatorToFilter[comparator](fieldNames, value, isQueried);
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
