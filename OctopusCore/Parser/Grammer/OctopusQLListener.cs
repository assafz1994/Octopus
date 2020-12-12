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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="OctopusQLParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9")]
[System.CLSCompliant(false)]
public interface IOctopusQLListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.r"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterR([NotNull] OctopusQLParser.RContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.r"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitR([NotNull] OctopusQLParser.RContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.select"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelect([NotNull] OctopusQLParser.SelectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.select"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelect([NotNull] OctopusQLParser.SelectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.whereClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhereClause([NotNull] OctopusQLParser.WhereClauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.whereClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhereClause([NotNull] OctopusQLParser.WhereClauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.fieldsWithDot"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldsWithDot([NotNull] OctopusQLParser.FieldsWithDotContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.fieldsWithDot"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldsWithDot([NotNull] OctopusQLParser.FieldsWithDotContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.fields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFields([NotNull] OctopusQLParser.FieldsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.fields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFields([NotNull] OctopusQLParser.FieldsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.selectClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelectClause([NotNull] OctopusQLParser.SelectClauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.selectClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelectClause([NotNull] OctopusQLParser.SelectClauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.include"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInclude([NotNull] OctopusQLParser.IncludeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.include"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInclude([NotNull] OctopusQLParser.IncludeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.aggregateClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAggregateClause([NotNull] OctopusQLParser.AggregateClauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.aggregateClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAggregateClause([NotNull] OctopusQLParser.AggregateClauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunc([NotNull] OctopusQLParser.FuncContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunc([NotNull] OctopusQLParser.FuncContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterField([NotNull] OctopusQLParser.FieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitField([NotNull] OctopusQLParser.FieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] OctopusQLParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] OctopusQLParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntity([NotNull] OctopusQLParser.EntityContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.entity"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntity([NotNull] OctopusQLParser.EntityContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.entityRep"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntityRep([NotNull] OctopusQLParser.EntityRepContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.entityRep"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntityRep([NotNull] OctopusQLParser.EntityRepContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="OctopusQLParser.all"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAll([NotNull] OctopusQLParser.AllContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="OctopusQLParser.all"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAll([NotNull] OctopusQLParser.AllContext context);
}
