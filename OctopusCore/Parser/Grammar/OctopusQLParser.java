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
		T__9=10, T__10=11, ASSIGN=12, EQUALS=13, COMPARATOR=14, SELECT=15, FROM=16, 
		WHERE=17, INCLUDE=18, ENTITY=19, INSERT=20, DELETE=21, UPDATE=22, PIPELINE=23, 
		COLON=24, ISEQUALS=25, GT=26, GTE=27, LT=28, LTE=29, ADD=30, REMOVE=31, 
		WORD=32, NUMBER=33, ENT=34, ENTREP=35, TEXT=36, WHITESPACE=37;
	public static final int
		RULE_r = 0, RULE_select = 1, RULE_deleteSelect = 2, RULE_insert = 3, RULE_delete = 4, 
		RULE_update = 5, RULE_insertClause = 6, RULE_getClause = 7, RULE_assignments = 8, 
		RULE_assignment = 9, RULE_whereClause = 10, RULE_fieldsWithDot = 11, RULE_fields = 12, 
		RULE_entityReps = 13, RULE_selectClause = 14, RULE_include = 15, RULE_aggregateClause = 16, 
		RULE_values = 17, RULE_array = 18, RULE_func = 19, RULE_field = 20, RULE_value = 21, 
		RULE_entity = 22, RULE_entityRep = 23, RULE_all = 24;
	private static String[] makeRuleNames() {
		return new String[] {
			"r", "select", "deleteSelect", "insert", "delete", "update", "insertClause", 
			"getClause", "assignments", "assignment", "whereClause", "fieldsWithDot", 
			"fields", "entityReps", "selectClause", "include", "aggregateClause", 
			"values", "array", "func", "field", "value", "entity", "entityRep", "all"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", null, "'='", null, null, null, null, null, null, null, 
			null, null, "'|'", "':'", "'=='", "'>'", "'>='", "'<'", "'<='", "'+='", 
			"'-='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"ASSIGN", "EQUALS", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", 
			"ENTITY", "INSERT", "DELETE", "UPDATE", "PIPELINE", "COLON", "ISEQUALS", 
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
			setState(54);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(50);
				select();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(51);
				insert();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(52);
				delete();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(53);
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
			setState(56);
			match(FROM);
			setState(57);
			entity();
			setState(58);
			entityRep();
			setState(62);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(59);
					whereClause();
					}
					} 
				}
				setState(64);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			}
			setState(67);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(65);
				selectClause();
				}
				break;
			case 2:
				{
				setState(66);
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

	public static class DeleteSelectContext extends ParserRuleContext {
		public TerminalNode FROM() { return getToken(OctopusQLParser.FROM, 0); }
		public EntityContext entity() {
			return getRuleContext(EntityContext.class,0);
		}
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public List<WhereClauseContext> whereClause() {
			return getRuleContexts(WhereClauseContext.class);
		}
		public WhereClauseContext whereClause(int i) {
			return getRuleContext(WhereClauseContext.class,i);
		}
		public DeleteSelectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_deleteSelect; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterDeleteSelect(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitDeleteSelect(this);
		}
	}

	public final DeleteSelectContext deleteSelect() throws RecognitionException {
		DeleteSelectContext _localctx = new DeleteSelectContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_deleteSelect);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(69);
			match(FROM);
			setState(70);
			entity();
			setState(71);
			entityRep();
			setState(75);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PIPELINE) {
				{
				{
				setState(72);
				whereClause();
				}
				}
				setState(77);
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
		enterRule(_localctx, 6, RULE_insert);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(79); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(78);
				insertClause();
				}
				}
				setState(81); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(83);
			match(INSERT);
			setState(84);
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
		public DeleteSelectContext deleteSelect() {
			return getRuleContext(DeleteSelectContext.class,0);
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
		enterRule(_localctx, 8, RULE_delete);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(86);
			match(DELETE);
			setState(87);
			deleteSelect();
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
		enterRule(_localctx, 10, RULE_update);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(89);
				getClause();
				}
				}
				setState(92); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(94);
			match(UPDATE);
			setState(95);
			entityRep();
			setState(97);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(96);
				fieldsWithDot();
				}
			}

			setState(99);
			match(ASSIGN);
			setState(100);
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
		enterRule(_localctx, 12, RULE_insertClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(ENTITY);
			setState(103);
			entity();
			setState(104);
			match(COLON);
			setState(105);
			entityRep();
			setState(106);
			match(T__0);
			setState(109);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(107);
				assignments();
				}
				break;
			case FROM:
				{
				setState(108);
				select();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(111);
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
		enterRule(_localctx, 14, RULE_getClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(113);
			match(ENTITY);
			setState(114);
			entity();
			setState(115);
			match(COLON);
			setState(116);
			entityRep();
			setState(117);
			match(T__0);
			setState(118);
			select();
			setState(119);
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
		enterRule(_localctx, 16, RULE_assignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			((AssignmentsContext)_localctx).assignment = assignment();
			((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
			setState(126);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(122);
				match(T__2);
				setState(123);
				((AssignmentsContext)_localctx).assignment = assignment();
				((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
				}
				}
				setState(128);
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
		enterRule(_localctx, 18, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(129);
			field();
			setState(130);
			match(EQUALS);
			setState(131);
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
		enterRule(_localctx, 20, RULE_whereClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(133);
			match(PIPELINE);
			setState(134);
			match(WHERE);
			setState(135);
			entityRep();
			setState(136);
			fieldsWithDot();
			setState(137);
			match(COMPARATOR);
			setState(138);
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
		enterRule(_localctx, 22, RULE_fieldsWithDot);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(142); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(140);
				match(T__3);
				setState(141);
				((FieldsWithDotContext)_localctx).field = field();
				((FieldsWithDotContext)_localctx).el.add(((FieldsWithDotContext)_localctx).field);
				}
				}
				setState(144); 
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
		enterRule(_localctx, 24, RULE_fields);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(146);
			((FieldsContext)_localctx).field = field();
			((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
			setState(151);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(147);
				match(T__2);
				setState(148);
				((FieldsContext)_localctx).field = field();
				((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
				}
				}
				setState(153);
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
		enterRule(_localctx, 26, RULE_entityReps);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(154);
			((EntityRepsContext)_localctx).entityRep = entityRep();
			((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
			setState(159);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(155);
				match(T__2);
				setState(156);
				((EntityRepsContext)_localctx).entityRep = entityRep();
				((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
				}
				}
				setState(161);
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
		enterRule(_localctx, 28, RULE_selectClause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(162);
			match(PIPELINE);
			setState(163);
			match(SELECT);
			setState(164);
			entityRep();
			setState(166);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(165);
				fieldsWithDot();
				}
			}

			setState(168);
			match(T__0);
			setState(171);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(169);
				fields();
				}
				break;
			case T__10:
				{
				setState(170);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(173);
			match(T__1);
			setState(177);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(174);
				include();
				}
				}
				setState(179);
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
		enterRule(_localctx, 30, RULE_include);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			match(INCLUDE);
			setState(181);
			match(T__0);
			setState(182);
			field();
			setState(183);
			match(T__0);
			setState(186);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(184);
				fields();
				}
				break;
			case T__10:
				{
				setState(185);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(188);
			match(T__1);
			setState(192);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(189);
				include();
				}
				}
				setState(194);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(195);
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
		enterRule(_localctx, 32, RULE_aggregateClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			match(PIPELINE);
			setState(198);
			func();
			setState(199);
			match(T__0);
			setState(200);
			entityRep();
			setState(201);
			match(T__0);
			setState(202);
			field();
			setState(203);
			match(T__1);
			setState(204);
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
		enterRule(_localctx, 34, RULE_values);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(206);
			((ValuesContext)_localctx).value = value();
			((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
			setState(211);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(207);
				match(T__2);
				setState(208);
				((ValuesContext)_localctx).value = value();
				((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
				}
				}
				setState(213);
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
		enterRule(_localctx, 36, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(214);
			match(T__4);
			setState(216);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << T__4) | (1L << WORD) | (1L << NUMBER) | (1L << ENTREP) | (1L << TEXT))) != 0)) {
				{
				setState(215);
				values();
				}
			}

			setState(218);
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
		enterRule(_localctx, 38, RULE_func);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(220);
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
		enterRule(_localctx, 40, RULE_field);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(222);
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
		enterRule(_localctx, 42, RULE_value);
		try {
			setState(233);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
				enterOuterAlt(_localctx, 1);
				{
				setState(224);
				match(T__0);
				setState(225);
				select();
				setState(226);
				match(T__1);
				}
				break;
			case WORD:
				enterOuterAlt(_localctx, 2);
				{
				setState(228);
				match(WORD);
				}
				break;
			case TEXT:
				enterOuterAlt(_localctx, 3);
				{
				setState(229);
				match(TEXT);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 4);
				{
				setState(230);
				match(NUMBER);
				}
				break;
			case ENTREP:
				enterOuterAlt(_localctx, 5);
				{
				setState(231);
				match(ENTREP);
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 6);
				{
				setState(232);
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
		enterRule(_localctx, 44, RULE_entity);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(235);
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
		enterRule(_localctx, 46, RULE_entityRep);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(237);
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
		enterRule(_localctx, 48, RULE_all);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(239);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\'\u00f4\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\3\2\3\2\3\2\3\2\5\29\n\2\3\3\3\3\3\3\3\3\7\3?\n\3\f\3\16\3"+
		"B\13\3\3\3\3\3\5\3F\n\3\3\4\3\4\3\4\3\4\7\4L\n\4\f\4\16\4O\13\4\3\5\6"+
		"\5R\n\5\r\5\16\5S\3\5\3\5\3\5\3\6\3\6\3\6\3\7\6\7]\n\7\r\7\16\7^\3\7\3"+
		"\7\3\7\5\7d\n\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\bp\n\b\3\b\3"+
		"\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\7\n\177\n\n\f\n\16\n\u0082"+
		"\13\n\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\6\r\u0091"+
		"\n\r\r\r\16\r\u0092\3\16\3\16\3\16\7\16\u0098\n\16\f\16\16\16\u009b\13"+
		"\16\3\17\3\17\3\17\7\17\u00a0\n\17\f\17\16\17\u00a3\13\17\3\20\3\20\3"+
		"\20\3\20\5\20\u00a9\n\20\3\20\3\20\3\20\5\20\u00ae\n\20\3\20\3\20\7\20"+
		"\u00b2\n\20\f\20\16\20\u00b5\13\20\3\21\3\21\3\21\3\21\3\21\3\21\5\21"+
		"\u00bd\n\21\3\21\3\21\7\21\u00c1\n\21\f\21\16\21\u00c4\13\21\3\21\3\21"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\23\3\23\3\23\7\23\u00d4"+
		"\n\23\f\23\16\23\u00d7\13\23\3\24\3\24\5\24\u00db\n\24\3\24\3\24\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\5\27\u00ec"+
		"\n\27\3\30\3\30\3\31\3\31\3\32\3\32\3\32\2\2\33\2\4\6\b\n\f\16\20\22\24"+
		"\26\30\32\34\36 \"$&(*,.\60\62\2\4\3\2\t\f\4\2\"\"%%\2\u00f6\28\3\2\2"+
		"\2\4:\3\2\2\2\6G\3\2\2\2\bQ\3\2\2\2\nX\3\2\2\2\f\\\3\2\2\2\16h\3\2\2\2"+
		"\20s\3\2\2\2\22{\3\2\2\2\24\u0083\3\2\2\2\26\u0087\3\2\2\2\30\u0090\3"+
		"\2\2\2\32\u0094\3\2\2\2\34\u009c\3\2\2\2\36\u00a4\3\2\2\2 \u00b6\3\2\2"+
		"\2\"\u00c7\3\2\2\2$\u00d0\3\2\2\2&\u00d8\3\2\2\2(\u00de\3\2\2\2*\u00e0"+
		"\3\2\2\2,\u00eb\3\2\2\2.\u00ed\3\2\2\2\60\u00ef\3\2\2\2\62\u00f1\3\2\2"+
		"\2\649\5\4\3\2\659\5\b\5\2\669\5\n\6\2\679\5\f\7\28\64\3\2\2\28\65\3\2"+
		"\2\28\66\3\2\2\28\67\3\2\2\29\3\3\2\2\2:;\7\22\2\2;<\5.\30\2<@\5\60\31"+
		"\2=?\5\26\f\2>=\3\2\2\2?B\3\2\2\2@>\3\2\2\2@A\3\2\2\2AE\3\2\2\2B@\3\2"+
		"\2\2CF\5\36\20\2DF\5\"\22\2EC\3\2\2\2ED\3\2\2\2F\5\3\2\2\2GH\7\22\2\2"+
		"HI\5.\30\2IM\5\60\31\2JL\5\26\f\2KJ\3\2\2\2LO\3\2\2\2MK\3\2\2\2MN\3\2"+
		"\2\2N\7\3\2\2\2OM\3\2\2\2PR\5\16\b\2QP\3\2\2\2RS\3\2\2\2SQ\3\2\2\2ST\3"+
		"\2\2\2TU\3\2\2\2UV\7\26\2\2VW\5\34\17\2W\t\3\2\2\2XY\7\27\2\2YZ\5\6\4"+
		"\2Z\13\3\2\2\2[]\5\20\t\2\\[\3\2\2\2]^\3\2\2\2^\\\3\2\2\2^_\3\2\2\2_`"+
		"\3\2\2\2`a\7\30\2\2ac\5\60\31\2bd\5\30\r\2cb\3\2\2\2cd\3\2\2\2de\3\2\2"+
		"\2ef\7\16\2\2fg\5,\27\2g\r\3\2\2\2hi\7\25\2\2ij\5.\30\2jk\7\32\2\2kl\5"+
		"\60\31\2lo\7\3\2\2mp\5\22\n\2np\5\4\3\2om\3\2\2\2on\3\2\2\2pq\3\2\2\2"+
		"qr\7\4\2\2r\17\3\2\2\2st\7\25\2\2tu\5.\30\2uv\7\32\2\2vw\5\60\31\2wx\7"+
		"\3\2\2xy\5\4\3\2yz\7\4\2\2z\21\3\2\2\2{\u0080\5\24\13\2|}\7\5\2\2}\177"+
		"\5\24\13\2~|\3\2\2\2\177\u0082\3\2\2\2\u0080~\3\2\2\2\u0080\u0081\3\2"+
		"\2\2\u0081\23\3\2\2\2\u0082\u0080\3\2\2\2\u0083\u0084\5*\26\2\u0084\u0085"+
		"\7\17\2\2\u0085\u0086\5,\27\2\u0086\25\3\2\2\2\u0087\u0088\7\31\2\2\u0088"+
		"\u0089\7\23\2\2\u0089\u008a\5\60\31\2\u008a\u008b\5\30\r\2\u008b\u008c"+
		"\7\20\2\2\u008c\u008d\5,\27\2\u008d\27\3\2\2\2\u008e\u008f\7\6\2\2\u008f"+
		"\u0091\5*\26\2\u0090\u008e\3\2\2\2\u0091\u0092\3\2\2\2\u0092\u0090\3\2"+
		"\2\2\u0092\u0093\3\2\2\2\u0093\31\3\2\2\2\u0094\u0099\5*\26\2\u0095\u0096"+
		"\7\5\2\2\u0096\u0098\5*\26\2\u0097\u0095\3\2\2\2\u0098\u009b\3\2\2\2\u0099"+
		"\u0097\3\2\2\2\u0099\u009a\3\2\2\2\u009a\33\3\2\2\2\u009b\u0099\3\2\2"+
		"\2\u009c\u00a1\5\60\31\2\u009d\u009e\7\5\2\2\u009e\u00a0\5\60\31\2\u009f"+
		"\u009d\3\2\2\2\u00a0\u00a3\3\2\2\2\u00a1\u009f\3\2\2\2\u00a1\u00a2\3\2"+
		"\2\2\u00a2\35\3\2\2\2\u00a3\u00a1\3\2\2\2\u00a4\u00a5\7\31\2\2\u00a5\u00a6"+
		"\7\21\2\2\u00a6\u00a8\5\60\31\2\u00a7\u00a9\5\30\r\2\u00a8\u00a7\3\2\2"+
		"\2\u00a8\u00a9\3\2\2\2\u00a9\u00aa\3\2\2\2\u00aa\u00ad\7\3\2\2\u00ab\u00ae"+
		"\5\32\16\2\u00ac\u00ae\5\62\32\2\u00ad\u00ab\3\2\2\2\u00ad\u00ac\3\2\2"+
		"\2\u00ad\u00ae\3\2\2\2\u00ae\u00af\3\2\2\2\u00af\u00b3\7\4\2\2\u00b0\u00b2"+
		"\5 \21\2\u00b1\u00b0\3\2\2\2\u00b2\u00b5\3\2\2\2\u00b3\u00b1\3\2\2\2\u00b3"+
		"\u00b4\3\2\2\2\u00b4\37\3\2\2\2\u00b5\u00b3\3\2\2\2\u00b6\u00b7\7\24\2"+
		"\2\u00b7\u00b8\7\3\2\2\u00b8\u00b9\5*\26\2\u00b9\u00bc\7\3\2\2\u00ba\u00bd"+
		"\5\32\16\2\u00bb\u00bd\5\62\32\2\u00bc\u00ba\3\2\2\2\u00bc\u00bb\3\2\2"+
		"\2\u00bc\u00bd\3\2\2\2\u00bd\u00be\3\2\2\2\u00be\u00c2\7\4\2\2\u00bf\u00c1"+
		"\5 \21\2\u00c0\u00bf\3\2\2\2\u00c1\u00c4\3\2\2\2\u00c2\u00c0\3\2\2\2\u00c2"+
		"\u00c3\3\2\2\2\u00c3\u00c5\3\2\2\2\u00c4\u00c2\3\2\2\2\u00c5\u00c6\7\4"+
		"\2\2\u00c6!\3\2\2\2\u00c7\u00c8\7\31\2\2\u00c8\u00c9\5(\25\2\u00c9\u00ca"+
		"\7\3\2\2\u00ca\u00cb\5\60\31\2\u00cb\u00cc\7\3\2\2\u00cc\u00cd\5*\26\2"+
		"\u00cd\u00ce\7\4\2\2\u00ce\u00cf\7\4\2\2\u00cf#\3\2\2\2\u00d0\u00d5\5"+
		",\27\2\u00d1\u00d2\7\5\2\2\u00d2\u00d4\5,\27\2\u00d3\u00d1\3\2\2\2\u00d4"+
		"\u00d7\3\2\2\2\u00d5\u00d3\3\2\2\2\u00d5\u00d6\3\2\2\2\u00d6%\3\2\2\2"+
		"\u00d7\u00d5\3\2\2\2\u00d8\u00da\7\7\2\2\u00d9\u00db\5$\23\2\u00da\u00d9"+
		"\3\2\2\2\u00da\u00db\3\2\2\2\u00db\u00dc\3\2\2\2\u00dc\u00dd\7\b\2\2\u00dd"+
		"\'\3\2\2\2\u00de\u00df\t\2\2\2\u00df)\3\2\2\2\u00e0\u00e1\7\"\2\2\u00e1"+
		"+\3\2\2\2\u00e2\u00e3\7\3\2\2\u00e3\u00e4\5\4\3\2\u00e4\u00e5\7\4\2\2"+
		"\u00e5\u00ec\3\2\2\2\u00e6\u00ec\7\"\2\2\u00e7\u00ec\7&\2\2\u00e8\u00ec"+
		"\7#\2\2\u00e9\u00ec\7%\2\2\u00ea\u00ec\5&\24\2\u00eb\u00e2\3\2\2\2\u00eb"+
		"\u00e6\3\2\2\2\u00eb\u00e7\3\2\2\2\u00eb\u00e8\3\2\2\2\u00eb\u00e9\3\2"+
		"\2\2\u00eb\u00ea\3\2\2\2\u00ec-\3\2\2\2\u00ed\u00ee\7\"\2\2\u00ee/\3\2"+
		"\2\2\u00ef\u00f0\t\3\2\2\u00f0\61\3\2\2\2\u00f1\u00f2\7\r\2\2\u00f2\63"+
		"\3\2\2\2\268@EMS^co\u0080\u0092\u0099\u00a1\u00a8\u00ad\u00b3\u00bc\u00c2"+
		"\u00d5\u00da\u00eb";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}