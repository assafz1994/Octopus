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
		ENTITY=17, INSERT=18, DELETE=19, UPDATE=20, ASSIGN=21, PIPELINE=22, COLON=23, 
		ISEQUALS=24, EQUALS=25, GT=26, GTE=27, LT=28, LTE=29, ADD=30, REMOVE=31, 
		WORD=32, NUMBER=33, ENT=34, ENTREP=35, TEXT=36, WHITESPACE=37;
	public static final int
		RULE_r = 0, RULE_select = 1, RULE_insert = 2, RULE_delete = 3, RULE_update = 4, 
		RULE_insertClause = 5, RULE_getClause = 6, RULE_assignments = 7, RULE_assignment = 8, 
		RULE_whereClause = 9, RULE_fieldsWithDot = 10, RULE_fields = 11, RULE_entityReps = 12, 
		RULE_selectClause = 13, RULE_include = 14, RULE_aggregateClause = 15, 
		RULE_values = 16, RULE_array = 17, RULE_func = 18, RULE_field = 19, RULE_value = 20, 
		RULE_entity = 21, RULE_entityRep = 22, RULE_all = 23;
	private static String[] makeRuleNames() {
		return new String[] {
			"r", "select", "insert", "delete", "update", "insertClause", "getClause", 
			"assignments", "assignment", "whereClause", "fieldsWithDot", "fields", 
			"entityReps", "selectClause", "include", "aggregateClause", "values", 
			"array", "func", "field", "value", "entity", "entityRep", "all"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", null, null, null, null, null, null, null, null, null, 
			null, "'|'", "':'", "'=='", "'='", "'>'", "'>='", "'<'", "'<='", "'+='", 
			"'-='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", "ENTITY", "INSERT", 
			"DELETE", "UPDATE", "ASSIGN", "PIPELINE", "COLON", "ISEQUALS", "EQUALS", 
			"GT", "GTE", "LT", "LTE", "ADD", "REMOVE", "WORD", "NUMBER", "ENT", "ENTREP", 
			"TEXT", "WHITESPACE"
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
		public UpdateContext update() {
			return getRuleContext(UpdateContext.class,0);
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
			setState(52);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(48);
				select();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(49);
				insert();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(50);
				delete();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(51);
				update();
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
			setState(54);
			match(FROM);
			setState(55);
			entity();
			setState(56);
			entityRep();
			setState(60);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(57);
					whereClause();
					}
					} 
				}
				setState(62);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			}
			setState(65);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(63);
				selectClause();
				}
				break;
			case 2:
				{
				setState(64);
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
			setState(68); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(67);
				insertClause();
				}
				}
				setState(70); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(72);
			match(INSERT);
			setState(73);
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
		public List<GetClauseContext> getClause() {
			return getRuleContexts(GetClauseContext.class);
		}
		public GetClauseContext getClause(int i) {
			return getRuleContext(GetClauseContext.class,i);
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
			setState(76); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(75);
				getClause();
				}
				}
				setState(78); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(80);
			match(DELETE);
			setState(81);
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

	public static class UpdateContext extends ParserRuleContext {
		public TerminalNode UPDATE() { return getToken(OctopusQLParser.UPDATE, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(OctopusQLParser.ASSIGN, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public List<GetClauseContext> getClause() {
			return getRuleContexts(GetClauseContext.class);
		}
		public GetClauseContext getClause(int i) {
			return getRuleContext(GetClauseContext.class,i);
		}
		public FieldsWithDotContext fieldsWithDot() {
			return getRuleContext(FieldsWithDotContext.class,0);
		}
		public UpdateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_update; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterUpdate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitUpdate(this);
		}
	}

	public final UpdateContext update() throws RecognitionException {
		UpdateContext _localctx = new UpdateContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_update);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(83);
				getClause();
				}
				}
				setState(86); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(88);
			match(UPDATE);
			setState(89);
			entityRep();
			setState(91);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(90);
				fieldsWithDot();
				}
			}

			setState(93);
			match(ASSIGN);
			setState(94);
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
		enterRule(_localctx, 10, RULE_insertClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			match(ENTITY);
			setState(97);
			entity();
			setState(98);
			match(COLON);
			setState(99);
			entityRep();
			setState(100);
			match(T__0);
			setState(103);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(101);
				assignments();
				}
				break;
			case FROM:
				{
				setState(102);
				select();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(105);
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

	public static class GetClauseContext extends ParserRuleContext {
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
		public GetClauseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_getClause; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterGetClause(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitGetClause(this);
		}
	}

	public final GetClauseContext getClause() throws RecognitionException {
		GetClauseContext _localctx = new GetClauseContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_getClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			match(ENTITY);
			setState(108);
			entity();
			setState(109);
			match(COLON);
			setState(110);
			entityRep();
			setState(111);
			match(T__0);
			setState(112);
			select();
			setState(113);
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
		enterRule(_localctx, 14, RULE_assignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115);
			((AssignmentsContext)_localctx).assignment = assignment();
			((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
			setState(120);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(116);
				match(T__2);
				setState(117);
				((AssignmentsContext)_localctx).assignment = assignment();
				((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
				}
				}
				setState(122);
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
		enterRule(_localctx, 16, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			field();
			setState(124);
			match(EQUALS);
			setState(125);
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
		enterRule(_localctx, 18, RULE_whereClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127);
			match(PIPELINE);
			setState(128);
			match(WHERE);
			setState(129);
			entityRep();
			setState(130);
			fieldsWithDot();
			setState(131);
			match(COMPARATOR);
			setState(132);
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
		enterRule(_localctx, 20, RULE_fieldsWithDot);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(136); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(134);
				match(T__3);
				setState(135);
				((FieldsWithDotContext)_localctx).field = field();
				((FieldsWithDotContext)_localctx).el.add(((FieldsWithDotContext)_localctx).field);
				}
				}
				setState(138); 
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
		enterRule(_localctx, 22, RULE_fields);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(140);
			((FieldsContext)_localctx).field = field();
			((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
			setState(145);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(141);
				match(T__2);
				setState(142);
				((FieldsContext)_localctx).field = field();
				((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
				}
				}
				setState(147);
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
		enterRule(_localctx, 24, RULE_entityReps);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			((EntityRepsContext)_localctx).entityRep = entityRep();
			((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
			setState(153);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(149);
				match(T__2);
				setState(150);
				((EntityRepsContext)_localctx).entityRep = entityRep();
				((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
				}
				}
				setState(155);
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
		enterRule(_localctx, 26, RULE_selectClause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(156);
			match(PIPELINE);
			setState(157);
			match(SELECT);
			setState(158);
			entityRep();
			setState(160);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(159);
				fieldsWithDot();
				}
			}

			setState(162);
			match(T__0);
			setState(165);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(163);
				fields();
				}
				break;
			case T__10:
				{
				setState(164);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(167);
			match(T__1);
			setState(171);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(168);
				include();
				}
				}
				setState(173);
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
		enterRule(_localctx, 28, RULE_include);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174);
			match(INCLUDE);
			setState(175);
			match(T__0);
			setState(176);
			field();
			setState(177);
			match(T__0);
			setState(180);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(178);
				fields();
				}
				break;
			case T__10:
				{
				setState(179);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(182);
			match(T__1);
			setState(186);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(183);
				include();
				}
				}
				setState(188);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(189);
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
		enterRule(_localctx, 30, RULE_aggregateClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			match(PIPELINE);
			setState(192);
			func();
			setState(193);
			match(T__0);
			setState(194);
			entityRep();
			setState(195);
			match(T__0);
			setState(196);
			field();
			setState(197);
			match(T__1);
			setState(198);
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
		enterRule(_localctx, 32, RULE_values);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(200);
			((ValuesContext)_localctx).value = value();
			((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
			setState(205);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(201);
				match(T__2);
				setState(202);
				((ValuesContext)_localctx).value = value();
				((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
				}
				}
				setState(207);
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
		enterRule(_localctx, 34, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(208);
			match(T__4);
			setState(210);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__4) | (1L << WORD) | (1L << NUMBER) | (1L << ENTREP) | (1L << TEXT))) != 0)) {
				{
				setState(209);
				values();
				}
			}

			setState(212);
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
		enterRule(_localctx, 36, RULE_func);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(214);
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
		enterRule(_localctx, 38, RULE_field);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(216);
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
		enterRule(_localctx, 40, RULE_value);
		try {
			setState(227);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				enterOuterAlt(_localctx, 1);
				{
				setState(218);
				match(T__0);
				setState(219);
				select();
				setState(220);
				match(T__1);
				}
				break;
			case WORD:
				enterOuterAlt(_localctx, 2);
				{
				setState(222);
				match(WORD);
				}
				break;
			case TEXT:
				enterOuterAlt(_localctx, 3);
				{
				setState(223);
				match(TEXT);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 4);
				{
				setState(224);
				match(NUMBER);
				}
				break;
			case ENTREP:
				enterOuterAlt(_localctx, 5);
				{
				setState(225);
				match(ENTREP);
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 6);
				{
				setState(226);
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
		enterRule(_localctx, 42, RULE_entity);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(229);
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
		enterRule(_localctx, 44, RULE_entityRep);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(231);
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
		enterRule(_localctx, 46, RULE_all);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\'\u00ee\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\3\2\3\2\3\2\3\2\5\2\67\n\2\3\3\3\3\3\3\3\3\7\3=\n\3\f\3\16\3@\13\3\3"+
		"\3\3\3\5\3D\n\3\3\4\6\4G\n\4\r\4\16\4H\3\4\3\4\3\4\3\5\6\5O\n\5\r\5\16"+
		"\5P\3\5\3\5\3\5\3\6\6\6W\n\6\r\6\16\6X\3\6\3\6\3\6\5\6^\n\6\3\6\3\6\3"+
		"\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7\5\7j\n\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3"+
		"\b\3\b\3\b\3\t\3\t\3\t\7\ty\n\t\f\t\16\t|\13\t\3\n\3\n\3\n\3\n\3\13\3"+
		"\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\6\f\u008b\n\f\r\f\16\f\u008c\3\r"+
		"\3\r\3\r\7\r\u0092\n\r\f\r\16\r\u0095\13\r\3\16\3\16\3\16\7\16\u009a\n"+
		"\16\f\16\16\16\u009d\13\16\3\17\3\17\3\17\3\17\5\17\u00a3\n\17\3\17\3"+
		"\17\3\17\5\17\u00a8\n\17\3\17\3\17\7\17\u00ac\n\17\f\17\16\17\u00af\13"+
		"\17\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u00b7\n\20\3\20\3\20\7\20\u00bb"+
		"\n\20\f\20\16\20\u00be\13\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\21\3"+
		"\21\3\21\3\21\3\22\3\22\3\22\7\22\u00ce\n\22\f\22\16\22\u00d1\13\22\3"+
		"\23\3\23\5\23\u00d5\n\23\3\23\3\23\3\24\3\24\3\25\3\25\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u00e6\n\26\3\27\3\27\3\30\3\30\3\31"+
		"\3\31\3\31\2\2\32\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\2"+
		"\4\3\2\t\f\4\2\"\"%%\2\u00f1\2\66\3\2\2\2\48\3\2\2\2\6F\3\2\2\2\bN\3\2"+
		"\2\2\nV\3\2\2\2\fb\3\2\2\2\16m\3\2\2\2\20u\3\2\2\2\22}\3\2\2\2\24\u0081"+
		"\3\2\2\2\26\u008a\3\2\2\2\30\u008e\3\2\2\2\32\u0096\3\2\2\2\34\u009e\3"+
		"\2\2\2\36\u00b0\3\2\2\2 \u00c1\3\2\2\2\"\u00ca\3\2\2\2$\u00d2\3\2\2\2"+
		"&\u00d8\3\2\2\2(\u00da\3\2\2\2*\u00e5\3\2\2\2,\u00e7\3\2\2\2.\u00e9\3"+
		"\2\2\2\60\u00eb\3\2\2\2\62\67\5\4\3\2\63\67\5\6\4\2\64\67\5\b\5\2\65\67"+
		"\5\n\6\2\66\62\3\2\2\2\66\63\3\2\2\2\66\64\3\2\2\2\66\65\3\2\2\2\67\3"+
		"\3\2\2\289\7\20\2\29:\5,\27\2:>\5.\30\2;=\5\24\13\2<;\3\2\2\2=@\3\2\2"+
		"\2><\3\2\2\2>?\3\2\2\2?C\3\2\2\2@>\3\2\2\2AD\5\34\17\2BD\5 \21\2CA\3\2"+
		"\2\2CB\3\2\2\2D\5\3\2\2\2EG\5\f\7\2FE\3\2\2\2GH\3\2\2\2HF\3\2\2\2HI\3"+
		"\2\2\2IJ\3\2\2\2JK\7\24\2\2KL\5\32\16\2L\7\3\2\2\2MO\5\16\b\2NM\3\2\2"+
		"\2OP\3\2\2\2PN\3\2\2\2PQ\3\2\2\2QR\3\2\2\2RS\7\25\2\2ST\5\32\16\2T\t\3"+
		"\2\2\2UW\5\16\b\2VU\3\2\2\2WX\3\2\2\2XV\3\2\2\2XY\3\2\2\2YZ\3\2\2\2Z["+
		"\7\26\2\2[]\5.\30\2\\^\5\26\f\2]\\\3\2\2\2]^\3\2\2\2^_\3\2\2\2_`\7\27"+
		"\2\2`a\5*\26\2a\13\3\2\2\2bc\7\23\2\2cd\5,\27\2de\7\31\2\2ef\5.\30\2f"+
		"i\7\3\2\2gj\5\20\t\2hj\5\4\3\2ig\3\2\2\2ih\3\2\2\2jk\3\2\2\2kl\7\4\2\2"+
		"l\r\3\2\2\2mn\7\23\2\2no\5,\27\2op\7\31\2\2pq\5.\30\2qr\7\3\2\2rs\5\4"+
		"\3\2st\7\4\2\2t\17\3\2\2\2uz\5\22\n\2vw\7\5\2\2wy\5\22\n\2xv\3\2\2\2y"+
		"|\3\2\2\2zx\3\2\2\2z{\3\2\2\2{\21\3\2\2\2|z\3\2\2\2}~\5(\25\2~\177\7\33"+
		"\2\2\177\u0080\5*\26\2\u0080\23\3\2\2\2\u0081\u0082\7\30\2\2\u0082\u0083"+
		"\7\21\2\2\u0083\u0084\5.\30\2\u0084\u0085\5\26\f\2\u0085\u0086\7\16\2"+
		"\2\u0086\u0087\5*\26\2\u0087\25\3\2\2\2\u0088\u0089\7\6\2\2\u0089\u008b"+
		"\5(\25\2\u008a\u0088\3\2\2\2\u008b\u008c\3\2\2\2\u008c\u008a\3\2\2\2\u008c"+
		"\u008d\3\2\2\2\u008d\27\3\2\2\2\u008e\u0093\5(\25\2\u008f\u0090\7\5\2"+
		"\2\u0090\u0092\5(\25\2\u0091\u008f\3\2\2\2\u0092\u0095\3\2\2\2\u0093\u0091"+
		"\3\2\2\2\u0093\u0094\3\2\2\2\u0094\31\3\2\2\2\u0095\u0093\3\2\2\2\u0096"+
		"\u009b\5.\30\2\u0097\u0098\7\5\2\2\u0098\u009a\5.\30\2\u0099\u0097\3\2"+
		"\2\2\u009a\u009d\3\2\2\2\u009b\u0099\3\2\2\2\u009b\u009c\3\2\2\2\u009c"+
		"\33\3\2\2\2\u009d\u009b\3\2\2\2\u009e\u009f\7\30\2\2\u009f\u00a0\7\17"+
		"\2\2\u00a0\u00a2\5.\30\2\u00a1\u00a3\5\26\f\2\u00a2\u00a1\3\2\2\2\u00a2"+
		"\u00a3\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\u00a7\7\3\2\2\u00a5\u00a8\5\30"+
		"\r\2\u00a6\u00a8\5\60\31\2\u00a7\u00a5\3\2\2\2\u00a7\u00a6\3\2\2\2\u00a7"+
		"\u00a8\3\2\2\2\u00a8\u00a9\3\2\2\2\u00a9\u00ad\7\4\2\2\u00aa\u00ac\5\36"+
		"\20\2\u00ab\u00aa\3\2\2\2\u00ac\u00af\3\2\2\2\u00ad\u00ab\3\2\2\2\u00ad"+
		"\u00ae\3\2\2\2\u00ae\35\3\2\2\2\u00af\u00ad\3\2\2\2\u00b0\u00b1\7\22\2"+
		"\2\u00b1\u00b2\7\3\2\2\u00b2\u00b3\5(\25\2\u00b3\u00b6\7\3\2\2\u00b4\u00b7"+
		"\5\30\r\2\u00b5\u00b7\5\60\31\2\u00b6\u00b4\3\2\2\2\u00b6\u00b5\3\2\2"+
		"\2\u00b6\u00b7\3\2\2\2\u00b7\u00b8\3\2\2\2\u00b8\u00bc\7\4\2\2\u00b9\u00bb"+
		"\5\36\20\2\u00ba\u00b9\3\2\2\2\u00bb\u00be\3\2\2\2\u00bc\u00ba\3\2\2\2"+
		"\u00bc\u00bd\3\2\2\2\u00bd\u00bf\3\2\2\2\u00be\u00bc\3\2\2\2\u00bf\u00c0"+
		"\7\4\2\2\u00c0\37\3\2\2\2\u00c1\u00c2\7\30\2\2\u00c2\u00c3\5&\24\2\u00c3"+
		"\u00c4\7\3\2\2\u00c4\u00c5\5.\30\2\u00c5\u00c6\7\3\2\2\u00c6\u00c7\5("+
		"\25\2\u00c7\u00c8\7\4\2\2\u00c8\u00c9\7\4\2\2\u00c9!\3\2\2\2\u00ca\u00cf"+
		"\5*\26\2\u00cb\u00cc\7\5\2\2\u00cc\u00ce\5*\26\2\u00cd\u00cb\3\2\2\2\u00ce"+
		"\u00d1\3\2\2\2\u00cf\u00cd\3\2\2\2\u00cf\u00d0\3\2\2\2\u00d0#\3\2\2\2"+
		"\u00d1\u00cf\3\2\2\2\u00d2\u00d4\7\7\2\2\u00d3\u00d5\5\"\22\2\u00d4\u00d3"+
		"\3\2\2\2\u00d4\u00d5\3\2\2\2\u00d5\u00d6\3\2\2\2\u00d6\u00d7\7\b\2\2\u00d7"+
		"%\3\2\2\2\u00d8\u00d9\t\2\2\2\u00d9\'\3\2\2\2\u00da\u00db\7\"\2\2\u00db"+
		")\3\2\2\2\u00dc\u00dd\7\3\2\2\u00dd\u00de\5\4\3\2\u00de\u00df\7\4\2\2"+
		"\u00df\u00e6\3\2\2\2\u00e0\u00e6\7\"\2\2\u00e1\u00e6\7&\2\2\u00e2\u00e6"+
		"\7#\2\2\u00e3\u00e6\7%\2\2\u00e4\u00e6\5$\23\2\u00e5\u00dc\3\2\2\2\u00e5"+
		"\u00e0\3\2\2\2\u00e5\u00e1\3\2\2\2\u00e5\u00e2\3\2\2\2\u00e5\u00e3\3\2"+
		"\2\2\u00e5\u00e4\3\2\2\2\u00e6+\3\2\2\2\u00e7\u00e8\7\"\2\2\u00e8-\3\2"+
		"\2\2\u00e9\u00ea\t\3\2\2\u00ea/\3\2\2\2\u00eb\u00ec\7\r\2\2\u00ec\61\3"+
		"\2\2\2\26\66>CHPX]iz\u008c\u0093\u009b\u00a2\u00a7\u00ad\u00b6\u00bc\u00cf"+
		"\u00d4\u00e5";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}