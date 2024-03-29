//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from OctopusQL.g4 by ANTLR 4.9

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="OctopusQLParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9")]
[System.CLSCompliant(false)]
public interface IOctopusQLVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.r"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitR([NotNull] OctopusQLParser.RContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.select"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelect([NotNull] OctopusQLParser.SelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.deleteSelect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeleteSelect([NotNull] OctopusQLParser.DeleteSelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.insert"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInsert([NotNull] OctopusQLParser.InsertContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.delete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDelete([NotNull] OctopusQLParser.DeleteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.update"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUpdate([NotNull] OctopusQLParser.UpdateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.insertClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInsertClause([NotNull] OctopusQLParser.InsertClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.getClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGetClause([NotNull] OctopusQLParser.GetClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.assignments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignments([NotNull] OctopusQLParser.AssignmentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] OctopusQLParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.whereClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhereClause([NotNull] OctopusQLParser.WhereClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.fieldsWithDot"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFieldsWithDot([NotNull] OctopusQLParser.FieldsWithDotContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.fields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFields([NotNull] OctopusQLParser.FieldsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.entityReps"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntityReps([NotNull] OctopusQLParser.EntityRepsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.selectClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelectClause([NotNull] OctopusQLParser.SelectClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.include"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInclude([NotNull] OctopusQLParser.IncludeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.aggregateClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAggregateClause([NotNull] OctopusQLParser.AggregateClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.values"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValues([NotNull] OctopusQLParser.ValuesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray([NotNull] OctopusQLParser.ArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc([NotNull] OctopusQLParser.FuncContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitField([NotNull] OctopusQLParser.FieldContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] OctopusQLParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntity([NotNull] OctopusQLParser.EntityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.entityRep"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntityRep([NotNull] OctopusQLParser.EntityRepContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="OctopusQLParser.all"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAll([NotNull] OctopusQLParser.AllContext context);
}
