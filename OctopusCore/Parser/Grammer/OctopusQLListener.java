// Generated from OctopusQL.g4 by ANTLR 4.9
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link OctopusQLParser}.
 */
public interface OctopusQLListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#r}.
	 * @param ctx the parse tree
	 */
	void enterR(OctopusQLParser.RContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#r}.
	 * @param ctx the parse tree
	 */
	void exitR(OctopusQLParser.RContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#select}.
	 * @param ctx the parse tree
	 */
	void enterSelect(OctopusQLParser.SelectContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#select}.
	 * @param ctx the parse tree
	 */
	void exitSelect(OctopusQLParser.SelectContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#whereClause}.
	 * @param ctx the parse tree
	 */
	void enterWhereClause(OctopusQLParser.WhereClauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#whereClause}.
	 * @param ctx the parse tree
	 */
	void exitWhereClause(OctopusQLParser.WhereClauseContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#attributesWithDot}.
	 * @param ctx the parse tree
	 */
	void enterAttributesWithDot(OctopusQLParser.AttributesWithDotContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#attributesWithDot}.
	 * @param ctx the parse tree
	 */
	void exitAttributesWithDot(OctopusQLParser.AttributesWithDotContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#attributes}.
	 * @param ctx the parse tree
	 */
	void enterAttributes(OctopusQLParser.AttributesContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#attributes}.
	 * @param ctx the parse tree
	 */
	void exitAttributes(OctopusQLParser.AttributesContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#selectClause}.
	 * @param ctx the parse tree
	 */
	void enterSelectClause(OctopusQLParser.SelectClauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#selectClause}.
	 * @param ctx the parse tree
	 */
	void exitSelectClause(OctopusQLParser.SelectClauseContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#include}.
	 * @param ctx the parse tree
	 */
	void enterInclude(OctopusQLParser.IncludeContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#include}.
	 * @param ctx the parse tree
	 */
	void exitInclude(OctopusQLParser.IncludeContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#aggregateClause}.
	 * @param ctx the parse tree
	 */
	void enterAggregateClause(OctopusQLParser.AggregateClauseContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#aggregateClause}.
	 * @param ctx the parse tree
	 */
	void exitAggregateClause(OctopusQLParser.AggregateClauseContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#func}.
	 * @param ctx the parse tree
	 */
	void enterFunc(OctopusQLParser.FuncContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#func}.
	 * @param ctx the parse tree
	 */
	void exitFunc(OctopusQLParser.FuncContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(OctopusQLParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(OctopusQLParser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#value}.
	 * @param ctx the parse tree
	 */
	void enterValue(OctopusQLParser.ValueContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#value}.
	 * @param ctx the parse tree
	 */
	void exitValue(OctopusQLParser.ValueContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#entity}.
	 * @param ctx the parse tree
	 */
	void enterEntity(OctopusQLParser.EntityContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#entity}.
	 * @param ctx the parse tree
	 */
	void exitEntity(OctopusQLParser.EntityContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#entityRep}.
	 * @param ctx the parse tree
	 */
	void enterEntityRep(OctopusQLParser.EntityRepContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#entityRep}.
	 * @param ctx the parse tree
	 */
	void exitEntityRep(OctopusQLParser.EntityRepContext ctx);
	/**
	 * Enter a parse tree produced by {@link OctopusQLParser#all}.
	 * @param ctx the parse tree
	 */
	void enterAll(OctopusQLParser.AllContext ctx);
	/**
	 * Exit a parse tree produced by {@link OctopusQLParser#all}.
	 * @param ctx the parse tree
	 */
	void exitAll(OctopusQLParser.AllContext ctx);
}