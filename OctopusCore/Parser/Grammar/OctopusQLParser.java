// Generated from OctopusQL.g4 by ANTLR 4.9
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class OctopusQLParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, COMPARATOR=12, SELECT=13, FROM=14, WHERE=15, INCLUDE=16, 
		ENTITY=17, INSERT=18, DELETE=19, PIPELINE=20, COLON=21, ISEQUALS=22, EQUALS=23, 
		GT=24, GTE=25, LT=26, LTE=27, WORD=28, NUMBER=29, ENT=30, ENTREP=31, TEXT=32, 
		WHITESPACE=33;
	public static final int
		RULE_r = 0, RULE_select = 1, RULE_insert = 2, RULE_delete = 3, RULE_insertClause = 4, 
		RULE_deleteClause = 5, RULE_assignments = 6, RULE_assignment = 7, RULE_whereClause = 8, 
		RULE_fieldsWithDot = 9, RULE_fields = 10, RULE_entityReps = 11, RULE_selectClause = 12, 
		RULE_include = 13, RULE_aggregateClause = 14, RULE_values = 15, RULE_array = 16, 
		RULE_func = 17, RULE_field = 18, RULE_value = 19, RULE_entity = 20, RULE_entityRep = 21, 
		RULE_all = 22;
	private static String[] makeRuleNames() {
		return new String[] {
			"r", "select", "insert", "delete", "insertClause", "deleteClause", "assignments", 
			"assignment", "whereClause", "fieldsWithDot", "fields", "entityReps", 
			"selectClause", "include", "aggregateClause", "values", "array", "func", 
			"field", "value", "entity", "entityRep", "all"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", null, null, null, null, null, null, null, null, "'|'", 
			"':'", "'=='", "'='", "'>'", "'>='", "'<'", "'<='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", "ENTITY", "INSERT", 
			"DELETE", "PIPELINE", "COLON", "ISEQUALS", "EQUALS", "GT", "GTE", "LT", 
			"LTE", "WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "OctopusQL.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public OctopusQLParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class RContext extends ParserRuleContext {
		public SelectContext select() {
			return getRuleContext(SelectContext.class,0);
		}
		public InsertContext insert() {
			return getRuleContext(InsertContext.class,0);
		}
		public DeleteContext delete() {
			return getRuleContext(DeleteContext.class,0);
		}
		public RContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_r; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterR(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitR(this);
		}
	}

	public final RContext r() throws RecognitionException {
		RContext _localctx = new RContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_r);
		try {
			setState(49);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(46);
				select();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(47);
				insert();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(48);
				delete();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SelectContext extends ParserRuleContext {
		public TerminalNode FROM() { return getToken(OctopusQLParser.FROM, 0); }
		public EntityContext entity() {
			return getRuleContext(EntityContext.class,0);
		}
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public SelectClauseContext selectClause() {
			return getRuleContext(SelectClauseContext.class,0);
		}
		public AggregateClauseContext aggregateClause() {
			return getRuleContext(AggregateClauseContext.class,0);
		}
		public List<WhereClauseContext> whereClause() {
			return getRuleContexts(WhereClauseContext.class);
		}
		public WhereClauseContext whereClause(int i) {
			return getRuleContext(WhereClauseContext.class,i);
		}
		public SelectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterSelect(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitSelect(this);
		}
	}

	public final SelectContext select() throws RecognitionException {
		SelectContext _localctx = new SelectContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_select);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(51);
			match(FROM);
			setState(52);
			entity();
			setState(53);
			entityRep();
			setState(57);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(54);
					whereClause();
					}
					} 
				}
				setState(59);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			}
			setState(62);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(60);
				selectClause();
				}
				break;
			case 2:
				{
				setState(61);
				aggregateClause();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InsertContext extends ParserRuleContext {
		public TerminalNode INSERT() { return getToken(OctopusQLParser.INSERT, 0); }
		public EntityRepsContext entityReps() {
			return getRuleContext(EntityRepsContext.class,0);
		}
		public List<InsertClauseContext> insertClause() {
			return getRuleContexts(InsertClauseContext.class);
		}
		public InsertClauseContext insertClause(int i) {
			return getRuleContext(InsertClauseContext.class,i);
		}
		public InsertContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_insert; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterInsert(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitInsert(this);
		}
	}

	public final InsertContext insert() throws RecognitionException {
		InsertContext _localctx = new InsertContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_insert);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(64);
				insertClause();
				}
				}
				setState(67); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(69);
			match(INSERT);
			setState(70);
			entityReps();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeleteContext extends ParserRuleContext {
		public TerminalNode DELETE() { return getToken(OctopusQLParser.DELETE, 0); }
		public EntityRepsContext entityReps() {
			return getRuleContext(EntityRepsContext.class,0);
		}
		public List<DeleteClauseContext> deleteClause() {
			return getRuleContexts(DeleteClauseContext.class);
		}
		public DeleteClauseContext deleteClause(int i) {
			return getRuleContext(DeleteClauseContext.class,i);
		}
		public DeleteContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delete; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterDelete(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitDelete(this);
		}
	}

	public final DeleteContext delete() throws RecognitionException {
		DeleteContext _localctx = new DeleteContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_delete);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(73); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(72);
				deleteClause();
				}
				}
				setState(75); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(77);
			match(DELETE);
			setState(78);
			entityReps();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class InsertClauseContext extends ParserRuleContext {
		public TerminalNode ENTITY() { return getToken(OctopusQLParser.ENTITY, 0); }
		public EntityContext entity() {
			return getRuleContext(EntityContext.class,0);
		}
		public TerminalNode COLON() { return getToken(OctopusQLParser.COLON, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public AssignmentsContext assignments() {
			return getRuleContext(AssignmentsContext.class,0);
		}
		public SelectContext select() {
			return getRuleContext(SelectContext.class,0);
		}
		public InsertClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_insertClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterInsertClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitInsertClause(this);
		}
	}

	public final InsertClauseContext insertClause() throws RecognitionException {
		InsertClauseContext _localctx = new InsertClauseContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_insertClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(80);
			match(ENTITY);
			setState(81);
			entity();
			setState(82);
			match(COLON);
			setState(83);
			entityRep();
			setState(84);
			match(T__0);
			setState(87);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(85);
				assignments();
				}
				break;
			case FROM:
				{
				setState(86);
				select();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(89);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeleteClauseContext extends ParserRuleContext {
		public TerminalNode ENTITY() { return getToken(OctopusQLParser.ENTITY, 0); }
		public EntityContext entity() {
			return getRuleContext(EntityContext.class,0);
		}
		public TerminalNode COLON() { return getToken(OctopusQLParser.COLON, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public SelectContext select() {
			return getRuleContext(SelectContext.class,0);
		}
		public DeleteClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_deleteClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterDeleteClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitDeleteClause(this);
		}
	}

	public final DeleteClauseContext deleteClause() throws RecognitionException {
		DeleteClauseContext _localctx = new DeleteClauseContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_deleteClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(91);
			match(ENTITY);
			setState(92);
			entity();
			setState(93);
			match(COLON);
			setState(94);
			entityRep();
			setState(95);
			match(T__0);
			setState(96);
			select();
			setState(97);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentsContext extends ParserRuleContext {
		public AssignmentContext assignment;
		public List<AssignmentContext> assignmentList = new ArrayList<AssignmentContext>();
		public List<AssignmentContext> assignment() {
			return getRuleContexts(AssignmentContext.class);
		}
		public AssignmentContext assignment(int i) {
			return getRuleContext(AssignmentContext.class,i);
		}
		public AssignmentsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignments; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAssignments(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAssignments(this);
		}
	}

	public final AssignmentsContext assignments() throws RecognitionException {
		AssignmentsContext _localctx = new AssignmentsContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_assignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			((AssignmentsContext)_localctx).assignment = assignment();
			((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
			setState(104);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(100);
				match(T__2);
				setState(101);
				((AssignmentsContext)_localctx).assignment = assignment();
				((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
				}
				}
				setState(106);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AssignmentContext extends ParserRuleContext {
		public FieldContext field() {
			return getRuleContext(FieldContext.class,0);
		}
		public TerminalNode EQUALS() { return getToken(OctopusQLParser.EQUALS, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAssignment(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAssignment(this);
		}
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			field();
			setState(108);
			match(EQUALS);
			setState(109);
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhereClauseContext extends ParserRuleContext {
		public TerminalNode PIPELINE() { return getToken(OctopusQLParser.PIPELINE, 0); }
		public TerminalNode WHERE() { return getToken(OctopusQLParser.WHERE, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public FieldsWithDotContext fieldsWithDot() {
			return getRuleContext(FieldsWithDotContext.class,0);
		}
		public TerminalNode COMPARATOR() { return getToken(OctopusQLParser.COMPARATOR, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public WhereClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whereClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterWhereClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitWhereClause(this);
		}
	}

	public final WhereClauseContext whereClause() throws RecognitionException {
		WhereClauseContext _localctx = new WhereClauseContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_whereClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
			match(PIPELINE);
			setState(112);
			match(WHERE);
			setState(113);
			entityRep();
			setState(114);
			fieldsWithDot();
			setState(115);
			match(COMPARATOR);
			setState(116);
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FieldsWithDotContext extends ParserRuleContext {
		public FieldContext field;
		public List<FieldContext> el = new ArrayList<FieldContext>();
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public FieldsWithDotContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fieldsWithDot; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterFieldsWithDot(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitFieldsWithDot(this);
		}
	}

	public final FieldsWithDotContext fieldsWithDot() throws RecognitionException {
		FieldsWithDotContext _localctx = new FieldsWithDotContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_fieldsWithDot);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(120); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(118);
				match(T__3);
				setState(119);
				((FieldsWithDotContext)_localctx).field = field();
				((FieldsWithDotContext)_localctx).el.add(((FieldsWithDotContext)_localctx).field);
				}
				}
				setState(122); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==T__3 );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FieldsContext extends ParserRuleContext {
		public FieldContext field;
		public List<FieldContext> fieldList = new ArrayList<FieldContext>();
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public FieldsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fields; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterFields(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitFields(this);
		}
	}

	public final FieldsContext fields() throws RecognitionException {
		FieldsContext _localctx = new FieldsContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_fields);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124);
			((FieldsContext)_localctx).field = field();
			((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
			setState(129);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(125);
				match(T__2);
				setState(126);
				((FieldsContext)_localctx).field = field();
				((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
				}
				}
				setState(131);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EntityRepsContext extends ParserRuleContext {
		public EntityRepContext entityRep;
		public List<EntityRepContext> entityRepList = new ArrayList<EntityRepContext>();
		public List<EntityRepContext> entityRep() {
			return getRuleContexts(EntityRepContext.class);
		}
		public EntityRepContext entityRep(int i) {
			return getRuleContext(EntityRepContext.class,i);
		}
		public EntityRepsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_entityReps; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterEntityReps(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitEntityReps(this);
		}
	}

	public final EntityRepsContext entityReps() throws RecognitionException {
		EntityRepsContext _localctx = new EntityRepsContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_entityReps);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			((EntityRepsContext)_localctx).entityRep = entityRep();
			((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
			setState(137);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(133);
				match(T__2);
				setState(134);
				((EntityRepsContext)_localctx).entityRep = entityRep();
				((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
				}
				}
				setState(139);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SelectClauseContext extends ParserRuleContext {
		public TerminalNode PIPELINE() { return getToken(OctopusQLParser.PIPELINE, 0); }
		public TerminalNode SELECT() { return getToken(OctopusQLParser.SELECT, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public FieldsWithDotContext fieldsWithDot() {
			return getRuleContext(FieldsWithDotContext.class,0);
		}
		public FieldsContext fields() {
			return getRuleContext(FieldsContext.class,0);
		}
		public AllContext all() {
			return getRuleContext(AllContext.class,0);
		}
		public List<IncludeContext> include() {
			return getRuleContexts(IncludeContext.class);
		}
		public IncludeContext include(int i) {
			return getRuleContext(IncludeContext.class,i);
		}
		public SelectClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_selectClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterSelectClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitSelectClause(this);
		}
	}

	public final SelectClauseContext selectClause() throws RecognitionException {
		SelectClauseContext _localctx = new SelectClauseContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_selectClause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140);
			match(PIPELINE);
			setState(141);
			match(SELECT);
			setState(142);
			entityRep();
			setState(144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(143);
				fieldsWithDot();
				}
			}

			setState(146);
			match(T__0);
			setState(149);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(147);
				fields();
				}
				break;
			case T__10:
				{
				setState(148);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(151);
			match(T__1);
			setState(155);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(152);
				include();
				}
				}
				setState(157);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IncludeContext extends ParserRuleContext {
		public TerminalNode INCLUDE() { return getToken(OctopusQLParser.INCLUDE, 0); }
		public FieldContext field() {
			return getRuleContext(FieldContext.class,0);
		}
		public FieldsContext fields() {
			return getRuleContext(FieldsContext.class,0);
		}
		public AllContext all() {
			return getRuleContext(AllContext.class,0);
		}
		public List<IncludeContext> include() {
			return getRuleContexts(IncludeContext.class);
		}
		public IncludeContext include(int i) {
			return getRuleContext(IncludeContext.class,i);
		}
		public IncludeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_include; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterInclude(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitInclude(this);
		}
	}

	public final IncludeContext include() throws RecognitionException {
		IncludeContext _localctx = new IncludeContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_include);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(158);
			match(INCLUDE);
			setState(159);
			match(T__0);
			setState(160);
			field();
			setState(161);
			match(T__0);
			setState(164);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(162);
				fields();
				}
				break;
			case T__10:
				{
				setState(163);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(166);
			match(T__1);
			setState(170);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(167);
				include();
				}
				}
				setState(172);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(173);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AggregateClauseContext extends ParserRuleContext {
		public TerminalNode PIPELINE() { return getToken(OctopusQLParser.PIPELINE, 0); }
		public FuncContext func() {
			return getRuleContext(FuncContext.class,0);
		}
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public FieldContext field() {
			return getRuleContext(FieldContext.class,0);
		}
		public AggregateClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregateClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAggregateClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAggregateClause(this);
		}
	}

	public final AggregateClauseContext aggregateClause() throws RecognitionException {
		AggregateClauseContext _localctx = new AggregateClauseContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_aggregateClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(175);
			match(PIPELINE);
			setState(176);
			func();
			setState(177);
			match(T__0);
			setState(178);
			entityRep();
			setState(179);
			match(T__0);
			setState(180);
			field();
			setState(181);
			match(T__1);
			setState(182);
			match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValuesContext extends ParserRuleContext {
		public ValueContext value;
		public List<ValueContext> valueList = new ArrayList<ValueContext>();
		public List<ValueContext> value() {
			return getRuleContexts(ValueContext.class);
		}
		public ValueContext value(int i) {
			return getRuleContext(ValueContext.class,i);
		}
		public ValuesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_values; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterValues(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitValues(this);
		}
	}

	public final ValuesContext values() throws RecognitionException {
		ValuesContext _localctx = new ValuesContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_values);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(184);
			((ValuesContext)_localctx).value = value();
			((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
			setState(189);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(185);
				match(T__2);
				setState(186);
				((ValuesContext)_localctx).value = value();
				((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
				}
				}
				setState(191);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayContext extends ParserRuleContext {
		public ValuesContext values() {
			return getRuleContext(ValuesContext.class,0);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterArray(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitArray(this);
		}
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(T__4);
			setState(194);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << FROM) | (1L << WORD) | (1L << NUMBER) | (1L << ENTREP) | (1L << TEXT))) != 0)) {
				{
				setState(193);
				values();
				}
			}

			setState(196);
			match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuncContext extends ParserRuleContext {
		public FuncContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_func; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterFunc(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitFunc(this);
		}
	}

	public final FuncContext func() throws RecognitionException {
		FuncContext _localctx = new FuncContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_func);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(198);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__6) | (1L << T__7) | (1L << T__8) | (1L << T__9))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FieldContext extends ParserRuleContext {
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public FieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterField(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitField(this);
		}
	}

	public final FieldContext field() throws RecognitionException {
		FieldContext _localctx = new FieldContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_field);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(200);
			match(WORD);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValueContext extends ParserRuleContext {
		public SelectContext select() {
			return getRuleContext(SelectContext.class,0);
		}
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public TerminalNode TEXT() { return getToken(OctopusQLParser.TEXT, 0); }
		public TerminalNode NUMBER() { return getToken(OctopusQLParser.NUMBER, 0); }
		public TerminalNode ENTREP() { return getToken(OctopusQLParser.ENTREP, 0); }
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterValue(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitValue(this);
		}
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_value);
		try {
			setState(208);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FROM:
				enterOuterAlt(_localctx, 1);
				{
				setState(202);
				select();
				}
				break;
			case WORD:
				enterOuterAlt(_localctx, 2);
				{
				setState(203);
				match(WORD);
				}
				break;
			case TEXT:
				enterOuterAlt(_localctx, 3);
				{
				setState(204);
				match(TEXT);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 4);
				{
				setState(205);
				match(NUMBER);
				}
				break;
			case ENTREP:
				enterOuterAlt(_localctx, 5);
				{
				setState(206);
				match(ENTREP);
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 6);
				{
				setState(207);
				array();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EntityContext extends ParserRuleContext {
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public EntityContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_entity; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterEntity(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitEntity(this);
		}
	}

	public final EntityContext entity() throws RecognitionException {
		EntityContext _localctx = new EntityContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_entity);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(210);
			match(WORD);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class EntityRepContext extends ParserRuleContext {
		public TerminalNode ENTREP() { return getToken(OctopusQLParser.ENTREP, 0); }
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public EntityRepContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_entityRep; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterEntityRep(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitEntityRep(this);
		}
	}

	public final EntityRepContext entityRep() throws RecognitionException {
		EntityRepContext _localctx = new EntityRepContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_entityRep);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(212);
			_la = _input.LA(1);
			if ( !(_la==WORD || _la==ENTREP) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AllContext extends ParserRuleContext {
		public AllContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_all; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAll(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAll(this);
		}
	}

	public final AllContext all() throws RecognitionException {
		AllContext _localctx = new AllContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_all);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(214);
			match(T__10);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3#\u00db\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\3\2\3\2\3"+
		"\2\5\2\64\n\2\3\3\3\3\3\3\3\3\7\3:\n\3\f\3\16\3=\13\3\3\3\3\3\5\3A\n\3"+
		"\3\4\6\4D\n\4\r\4\16\4E\3\4\3\4\3\4\3\5\6\5L\n\5\r\5\16\5M\3\5\3\5\3\5"+
		"\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6Z\n\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7"+
		"\3\7\3\7\3\b\3\b\3\b\7\bi\n\b\f\b\16\bl\13\b\3\t\3\t\3\t\3\t\3\n\3\n\3"+
		"\n\3\n\3\n\3\n\3\n\3\13\3\13\6\13{\n\13\r\13\16\13|\3\f\3\f\3\f\7\f\u0082"+
		"\n\f\f\f\16\f\u0085\13\f\3\r\3\r\3\r\7\r\u008a\n\r\f\r\16\r\u008d\13\r"+
		"\3\16\3\16\3\16\3\16\5\16\u0093\n\16\3\16\3\16\3\16\5\16\u0098\n\16\3"+
		"\16\3\16\7\16\u009c\n\16\f\16\16\16\u009f\13\16\3\17\3\17\3\17\3\17\3"+
		"\17\3\17\5\17\u00a7\n\17\3\17\3\17\7\17\u00ab\n\17\f\17\16\17\u00ae\13"+
		"\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3"+
		"\21\7\21\u00be\n\21\f\21\16\21\u00c1\13\21\3\22\3\22\5\22\u00c5\n\22\3"+
		"\22\3\22\3\23\3\23\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u00d3"+
		"\n\25\3\26\3\26\3\27\3\27\3\30\3\30\3\30\2\2\31\2\4\6\b\n\f\16\20\22\24"+
		"\26\30\32\34\36 \"$&(*,.\2\4\3\2\t\f\4\2\36\36!!\2\u00dc\2\63\3\2\2\2"+
		"\4\65\3\2\2\2\6C\3\2\2\2\bK\3\2\2\2\nR\3\2\2\2\f]\3\2\2\2\16e\3\2\2\2"+
		"\20m\3\2\2\2\22q\3\2\2\2\24z\3\2\2\2\26~\3\2\2\2\30\u0086\3\2\2\2\32\u008e"+
		"\3\2\2\2\34\u00a0\3\2\2\2\36\u00b1\3\2\2\2 \u00ba\3\2\2\2\"\u00c2\3\2"+
		"\2\2$\u00c8\3\2\2\2&\u00ca\3\2\2\2(\u00d2\3\2\2\2*\u00d4\3\2\2\2,\u00d6"+
		"\3\2\2\2.\u00d8\3\2\2\2\60\64\5\4\3\2\61\64\5\6\4\2\62\64\5\b\5\2\63\60"+
		"\3\2\2\2\63\61\3\2\2\2\63\62\3\2\2\2\64\3\3\2\2\2\65\66\7\20\2\2\66\67"+
		"\5*\26\2\67;\5,\27\28:\5\22\n\298\3\2\2\2:=\3\2\2\2;9\3\2\2\2;<\3\2\2"+
		"\2<@\3\2\2\2=;\3\2\2\2>A\5\32\16\2?A\5\36\20\2@>\3\2\2\2@?\3\2\2\2A\5"+
		"\3\2\2\2BD\5\n\6\2CB\3\2\2\2DE\3\2\2\2EC\3\2\2\2EF\3\2\2\2FG\3\2\2\2G"+
		"H\7\24\2\2HI\5\30\r\2I\7\3\2\2\2JL\5\f\7\2KJ\3\2\2\2LM\3\2\2\2MK\3\2\2"+
		"\2MN\3\2\2\2NO\3\2\2\2OP\7\25\2\2PQ\5\30\r\2Q\t\3\2\2\2RS\7\23\2\2ST\5"+
		"*\26\2TU\7\27\2\2UV\5,\27\2VY\7\3\2\2WZ\5\16\b\2XZ\5\4\3\2YW\3\2\2\2Y"+
		"X\3\2\2\2Z[\3\2\2\2[\\\7\4\2\2\\\13\3\2\2\2]^\7\23\2\2^_\5*\26\2_`\7\27"+
		"\2\2`a\5,\27\2ab\7\3\2\2bc\5\4\3\2cd\7\4\2\2d\r\3\2\2\2ej\5\20\t\2fg\7"+
		"\5\2\2gi\5\20\t\2hf\3\2\2\2il\3\2\2\2jh\3\2\2\2jk\3\2\2\2k\17\3\2\2\2"+
		"lj\3\2\2\2mn\5&\24\2no\7\31\2\2op\5(\25\2p\21\3\2\2\2qr\7\26\2\2rs\7\21"+
		"\2\2st\5,\27\2tu\5\24\13\2uv\7\16\2\2vw\5(\25\2w\23\3\2\2\2xy\7\6\2\2"+
		"y{\5&\24\2zx\3\2\2\2{|\3\2\2\2|z\3\2\2\2|}\3\2\2\2}\25\3\2\2\2~\u0083"+
		"\5&\24\2\177\u0080\7\5\2\2\u0080\u0082\5&\24\2\u0081\177\3\2\2\2\u0082"+
		"\u0085\3\2\2\2\u0083\u0081\3\2\2\2\u0083\u0084\3\2\2\2\u0084\27\3\2\2"+
		"\2\u0085\u0083\3\2\2\2\u0086\u008b\5,\27\2\u0087\u0088\7\5\2\2\u0088\u008a"+
		"\5,\27\2\u0089\u0087\3\2\2\2\u008a\u008d\3\2\2\2\u008b\u0089\3\2\2\2\u008b"+
		"\u008c\3\2\2\2\u008c\31\3\2\2\2\u008d\u008b\3\2\2\2\u008e\u008f\7\26\2"+
		"\2\u008f\u0090\7\17\2\2\u0090\u0092\5,\27\2\u0091\u0093\5\24\13\2\u0092"+
		"\u0091\3\2\2\2\u0092\u0093\3\2\2\2\u0093\u0094\3\2\2\2\u0094\u0097\7\3"+
		"\2\2\u0095\u0098\5\26\f\2\u0096\u0098\5.\30\2\u0097\u0095\3\2\2\2\u0097"+
		"\u0096\3\2\2\2\u0097\u0098\3\2\2\2\u0098\u0099\3\2\2\2\u0099\u009d\7\4"+
		"\2\2\u009a\u009c\5\34\17\2\u009b\u009a\3\2\2\2\u009c\u009f\3\2\2\2\u009d"+
		"\u009b\3\2\2\2\u009d\u009e\3\2\2\2\u009e\33\3\2\2\2\u009f\u009d\3\2\2"+
		"\2\u00a0\u00a1\7\22\2\2\u00a1\u00a2\7\3\2\2\u00a2\u00a3\5&\24\2\u00a3"+
		"\u00a6\7\3\2\2\u00a4\u00a7\5\26\f\2\u00a5\u00a7\5.\30\2\u00a6\u00a4\3"+
		"\2\2\2\u00a6\u00a5\3\2\2\2\u00a6\u00a7\3\2\2\2\u00a7\u00a8\3\2\2\2\u00a8"+
		"\u00ac\7\4\2\2\u00a9\u00ab\5\34\17\2\u00aa\u00a9\3\2\2\2\u00ab\u00ae\3"+
		"\2\2\2\u00ac\u00aa\3\2\2\2\u00ac\u00ad\3\2\2\2\u00ad\u00af\3\2\2\2\u00ae"+
		"\u00ac\3\2\2\2\u00af\u00b0\7\4\2\2\u00b0\35\3\2\2\2\u00b1\u00b2\7\26\2"+
		"\2\u00b2\u00b3\5$\23\2\u00b3\u00b4\7\3\2\2\u00b4\u00b5\5,\27\2\u00b5\u00b6"+
		"\7\3\2\2\u00b6\u00b7\5&\24\2\u00b7\u00b8\7\4\2\2\u00b8\u00b9\7\4\2\2\u00b9"+
		"\37\3\2\2\2\u00ba\u00bf\5(\25\2\u00bb\u00bc\7\5\2\2\u00bc\u00be\5(\25"+
		"\2\u00bd\u00bb\3\2\2\2\u00be\u00c1\3\2\2\2\u00bf\u00bd\3\2\2\2\u00bf\u00c0"+
		"\3\2\2\2\u00c0!\3\2\2\2\u00c1\u00bf\3\2\2\2\u00c2\u00c4\7\7\2\2\u00c3"+
		"\u00c5\5 \21\2\u00c4\u00c3\3\2\2\2\u00c4\u00c5\3\2\2\2\u00c5\u00c6\3\2"+
		"\2\2\u00c6\u00c7\7\b\2\2\u00c7#\3\2\2\2\u00c8\u00c9\t\2\2\2\u00c9%\3\2"+
		"\2\2\u00ca\u00cb\7\36\2\2\u00cb\'\3\2\2\2\u00cc\u00d3\5\4\3\2\u00cd\u00d3"+
		"\7\36\2\2\u00ce\u00d3\7\"\2\2\u00cf\u00d3\7\37\2\2\u00d0\u00d3\7!\2\2"+
		"\u00d1\u00d3\5\"\22\2\u00d2\u00cc\3\2\2\2\u00d2\u00cd\3\2\2\2\u00d2\u00ce"+
		"\3\2\2\2\u00d2\u00cf\3\2\2\2\u00d2\u00d0\3\2\2\2\u00d2\u00d1\3\2\2\2\u00d3"+
		")\3\2\2\2\u00d4\u00d5\7\36\2\2\u00d5+\3\2\2\2\u00d6\u00d7\t\3\2\2\u00d7"+
		"-\3\2\2\2\u00d8\u00d9\7\r\2\2\u00d9/\3\2\2\2\24\63;@EMYj|\u0083\u008b"+
		"\u0092\u0097\u009d\u00a6\u00ac\u00bf\u00c4\u00d2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}