using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using OctopusCore.Common;
using OctopusCore.Parser.Filters;
using static System.Guid;

namespace OctopusCore.Parser
{
    internal class QueryExtractor : OctopusQLBaseVisitor<QueryInfo>
    {
        public static Dictionary<string, Func<List<string>, string, bool, Filter>> ComparatorToFilter =
            new Dictionary<string, Func<List<string>, string, bool, Filter>>()
        {
            {"==", (list, s, b) => new EqFilter(list, s, b)},
        };
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

            if (context.@delete() != null)
            {
                return HandleDelete(context.@delete());
            }

            if (context.@update() != null)
            {
                return HandleUpdate(context.@update());
            }

            throw new Exception("Unsupported query");
        }

        private UpdateQueryInfo HandleUpdate(OctopusQLParser.UpdateContext update)
        {
            var entityToSubQuery = new Dictionary<string, string>();
            var entityRepToEntityType = new Dictionary<string, string>();
            var subQueries = new Dictionary<string, QueryInfo>();

            if (update.getClause().Length != 1)
            {
                throw new Exception("Only one entity is supported");
            }

            foreach (var getClauseContext in update.getClause())
            {
                var curEntityRep = getClauseContext.entityRep().GetText();
                var curEntityType = getClauseContext.entity().GetText().ToLower();
                var selectQueryInfo = HandleSelect(getClauseContext.@select());
                var subQueryGuid = NewGuid().ToString();
                entityToSubQuery.Add(curEntityRep, subQueryGuid);
                entityRepToEntityType.Add(curEntityRep, curEntityType);
                subQueries.Add(subQueryGuid, selectQueryInfo);
            }

            var entityRep = update.entityRep().GetText();
            var entityType = entityRepToEntityType[entityRep];
            var fields = update.fieldsWithDot()._el.Select(field => field.GetText().ToLower()).ToList();

            dynamic value;
            if (update.value().NUMBER() != null)
            {
                value = int.Parse(update.value().GetText());
            }
            else
            {
                value = update.value().GetText();
            }

            return new UpdateQueryInfo(entityType, entityRep, entityToSubQuery, entityRepToEntityType, fields, value, subQueries);
        }

        private DeleteQueryInfo HandleDelete(OctopusQLParser.DeleteContext delete)
        {
            var deleteQueryInfo = new DeleteQueryInfo();
            var deleteSelect = delete.@deleteSelect();
            
            if (deleteSelect == null)
            {
                throw new Exception("select can't be null");
            }

            var selectQueryInfo = HandleDeleteSelect(deleteSelect);
            selectQueryInfo.Fields.Add(selectQueryInfo.Filters.First().FieldNames.First());
            deleteQueryInfo.Entity = selectQueryInfo.Entity;
            deleteQueryInfo.SubQueries.Add(NewGuid().ToString(), selectQueryInfo);
            return deleteQueryInfo;
        }

        private SelectQueryInfo HandleDeleteSelect(OctopusQLParser.DeleteSelectContext deleteSelect)
        {
            var selectQueryInfo = new SelectQueryInfo();
            UpdateSelectQueryInfo(selectQueryInfo, deleteSelect.entity(), deleteSelect.whereClause());
            return selectQueryInfo;
        }

        private void UpdateSelectQueryInfo(SelectQueryInfo selectQueryInfo,
            OctopusQLParser.EntityContext entityContext, OctopusQLParser.WhereClauseContext[] whereClauseContexts)
        {
            selectQueryInfo.Entity = entityContext.GetText().ToLower();
            var filters = new List<Filter>();
            foreach (var whereClause in whereClauseContexts)
            {
                var fieldNames = new List<string>();
                fieldNames.AddRange(whereClause.fieldsWithDot()._el.Select(field => field.GetText().ToLower()));
                string value;
                var isQueried = false;
                if (whereClause.value().select() != null)
                {
                    var guid = NewGuid().ToString();
                    selectQueryInfo.SubQueries.Add(guid, HandleSelect(whereClause.value().select()));
                    value = guid;
                    isQueried = true;
                }
                else
                {
                    value = whereClause.value().GetText();
                }
                var comparator = whereClause.COMPARATOR().GetText();
                var filter = ComparatorToFilter[comparator](fieldNames, value, isQueried);
                filters.Add(filter);
            }

            selectQueryInfo.Filters = filters;
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
            UpdateSelectQueryInfo(selectQueryInfo, selectContext.entity(), selectContext.whereClause());
            
            if (selectContext.selectClause() == null)
            {
                throw new Exception("no select at the end of query");
            }

            var fields = new List<string>();
            var nestedProperty = new ArrayList<string>();
            if (selectContext.selectClause().all() != null)
            {
                fields.Add(StringConstants.All);
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
            
            return selectQueryInfo;
        }
    }
}
