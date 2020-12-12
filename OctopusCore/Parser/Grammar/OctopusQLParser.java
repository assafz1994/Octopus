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
		ENTITY=17, INSERT=18, PIPELINE=19, COLON=20, ISEQUALS=21, EQUALS=22, GT=23, 
		GTE=24, LT=25, LTE=26, WORD=27, NUMBER=28, ENT=29, ENTREP=30, TEXT=31, 
		WHITESPACE=32;
	public static final int
		RULE_r = 0, RULE_select = 1, RULE_insert = 2, RULE_insertClause = 3, RULE_assignments = 4, 
		RULE_assignment = 5, RULE_whereClause = 6, RULE_fieldsWithDot = 7, RULE_fields = 8, 
		RULE_entityReps = 9, RULE_selectClause = 10, RULE_include = 11, RULE_aggregateClause = 12, 
		RULE_values = 13, RULE_array = 14, RULE_func = 15, RULE_field = 16, RULE_value = 17, 
		RULE_entity = 18, RULE_entityRep = 19, RULE_all = 20;
	private static String[] makeRuleNames() {
		return new String[] {
			"r", "select", "insert", "insertClause", "assignments", "assignment", 
			"whereClause", "fieldsWithDot", "fields", "entityReps", "selectClause", 
			"include", "aggregateClause", "values", "array", "func", "field", "value", 
			"entity", "entityRep", "all"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", null, null, null, null, null, null, null, "'|'", "':'", 
			"'=='", "'='", "'>'", "'>='", "'<'", "'<='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", "ENTITY", "INSERT", 
			"PIPELINE", "COLON", "ISEQUALS", "EQUALS", "GT", "GTE", "LT", "LTE", 
			"WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
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
			setState(44);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FROM:
				enterOuterAlt(_localctx, 1);
				{
				setState(42);
				select();
				}
				break;
			case ENTITY:
				enterOuterAlt(_localctx, 2);
				{
				setState(43);
				insert();
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
			setState(46);
			match(FROM);
			setState(47);
			entity();
			setState(48);
			entityRep();
			setState(52);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(49);
					whereClause();
					}
					} 
				}
				setState(54);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,1,_ctx);
			}
			setState(57);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				{
				setState(55);
				selectClause();
				}
				break;
			case 2:
				{
				setState(56);
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
			setState(60); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(59);
				insertClause();
				}
				}
				setState(62); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==ENTITY );
			setState(64);
			match(INSERT);
			setState(65);
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
		enterRule(_localctx, 6, RULE_insertClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(67);
			match(ENTITY);
			setState(68);
			entity();
			setState(69);
			match(COLON);
			setState(70);
			entityRep();
			setState(71);
			match(T__0);
			setState(74);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(72);
				assignments();
				}
				break;
			case FROM:
				{
				setState(73);
				select();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(76);
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
		enterRule(_localctx, 8, RULE_assignments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(78);
			((AssignmentsContext)_localctx).assignment = assignment();
			((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
			setState(83);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(79);
				match(T__2);
				setState(80);
				((AssignmentsContext)_localctx).assignment = assignment();
				((AssignmentsContext)_localctx).assignmentList.add(((AssignmentsContext)_localctx).assignment);
				}
				}
				setState(85);
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
		enterRule(_localctx, 10, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(86);
			field();
			setState(87);
			match(EQUALS);
			setState(88);
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
		enterRule(_localctx, 12, RULE_whereClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			match(PIPELINE);
			setState(91);
			match(WHERE);
			setState(92);
			entityRep();
			setState(93);
			fieldsWithDot();
			setState(94);
			match(COMPARATOR);
			setState(95);
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
		enterRule(_localctx, 14, RULE_fieldsWithDot);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(97);
				match(T__3);
				setState(98);
				((FieldsWithDotContext)_localctx).field = field();
				((FieldsWithDotContext)_localctx).el.add(((FieldsWithDotContext)_localctx).field);
				}
				}
				setState(101); 
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
		enterRule(_localctx, 16, RULE_fields);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			((FieldsContext)_localctx).field = field();
			((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
			setState(108);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(104);
				match(T__2);
				setState(105);
				((FieldsContext)_localctx).field = field();
				((FieldsContext)_localctx).fieldList.add(((FieldsContext)_localctx).field);
				}
				}
				setState(110);
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
		enterRule(_localctx, 18, RULE_entityReps);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
			((EntityRepsContext)_localctx).entityRep = entityRep();
			((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
			setState(116);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(112);
				match(T__2);
				setState(113);
				((EntityRepsContext)_localctx).entityRep = entityRep();
				((EntityRepsContext)_localctx).entityRepList.add(((EntityRepsContext)_localctx).entityRep);
				}
				}
				setState(118);
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
		enterRule(_localctx, 20, RULE_selectClause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(119);
			match(PIPELINE);
			setState(120);
			match(SELECT);
			setState(121);
			entityRep();
			setState(123);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__3) {
				{
				setState(122);
				fieldsWithDot();
				}
			}

			setState(125);
			match(T__0);
			setState(128);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(126);
				fields();
				}
				break;
			case T__10:
				{
				setState(127);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(130);
			match(T__1);
			setState(134);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(131);
				include();
				}
				}
				setState(136);
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
		enterRule(_localctx, 22, RULE_include);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			match(INCLUDE);
			setState(138);
			match(T__0);
			setState(139);
			field();
			setState(140);
			match(T__0);
			setState(143);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(141);
				fields();
				}
				break;
			case T__10:
				{
				setState(142);
				all();
				}
				break;
			case T__1:
				break;
			default:
				break;
			}
			setState(145);
			match(T__1);
			setState(149);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(146);
				include();
				}
				}
				setState(151);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(152);
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
		enterRule(_localctx, 24, RULE_aggregateClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(154);
			match(PIPELINE);
			setState(155);
			func();
			setState(156);
			match(T__0);
			setState(157);
			entityRep();
			setState(158);
			match(T__0);
			setState(159);
			field();
			setState(160);
			match(T__1);
			setState(161);
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
		enterRule(_localctx, 26, RULE_values);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(163);
			((ValuesContext)_localctx).value = value();
			((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
			setState(168);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__2) {
				{
				{
				setState(164);
				match(T__2);
				setState(165);
				((ValuesContext)_localctx).value = value();
				((ValuesContext)_localctx).valueList.add(((ValuesContext)_localctx).value);
				}
				}
				setState(170);
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
		enterRule(_localctx, 28, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
			match(T__4);
			setState(173);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << FROM) | (1L << WORD) | (1L << NUMBER) | (1L << ENTREP) | (1L << TEXT))) != 0)) {
				{
				setState(172);
				values();
				}
			}

			setState(175);
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
		enterRule(_localctx, 30, RULE_func);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
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
		enterRule(_localctx, 32, RULE_field);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(179);
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
		enterRule(_localctx, 34, RULE_value);
		try {
			setState(187);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FROM:
				enterOuterAlt(_localctx, 1);
				{
				setState(181);
				select();
				}
				break;
			case WORD:
				enterOuterAlt(_localctx, 2);
				{
				setState(182);
				match(WORD);
				}
				break;
			case TEXT:
				enterOuterAlt(_localctx, 3);
				{
				setState(183);
				match(TEXT);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 4);
				{
				setState(184);
				match(NUMBER);
				}
				break;
			case ENTREP:
				enterOuterAlt(_localctx, 5);
				{
				setState(185);
				match(ENTREP);
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 6);
				{
				setState(186);
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
		enterRule(_localctx, 36, RULE_entity);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
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
		enterRule(_localctx, 38, RULE_entityRep);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
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
		enterRule(_localctx, 40, RULE_all);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\"\u00c6\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\3\2\3\2\5\2/\n\2\3\3\3\3\3\3"+
		"\3\3\7\3\65\n\3\f\3\16\38\13\3\3\3\3\3\5\3<\n\3\3\4\6\4?\n\4\r\4\16\4"+
		"@\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5\5M\n\5\3\5\3\5\3\6\3\6\3\6"+
		"\7\6T\n\6\f\6\16\6W\13\6\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3"+
		"\t\3\t\6\tf\n\t\r\t\16\tg\3\n\3\n\3\n\7\nm\n\n\f\n\16\np\13\n\3\13\3\13"+
		"\3\13\7\13u\n\13\f\13\16\13x\13\13\3\f\3\f\3\f\3\f\5\f~\n\f\3\f\3\f\3"+
		"\f\5\f\u0083\n\f\3\f\3\f\7\f\u0087\n\f\f\f\16\f\u008a\13\f\3\r\3\r\3\r"+
		"\3\r\3\r\3\r\5\r\u0092\n\r\3\r\3\r\7\r\u0096\n\r\f\r\16\r\u0099\13\r\3"+
		"\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\7\17"+
		"\u00a9\n\17\f\17\16\17\u00ac\13\17\3\20\3\20\5\20\u00b0\n\20\3\20\3\20"+
		"\3\21\3\21\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00be\n\23\3\24"+
		"\3\24\3\25\3\25\3\26\3\26\3\26\2\2\27\2\4\6\b\n\f\16\20\22\24\26\30\32"+
		"\34\36 \"$&(*\2\4\3\2\t\f\4\2\35\35  \2\u00c7\2.\3\2\2\2\4\60\3\2\2\2"+
		"\6>\3\2\2\2\bE\3\2\2\2\nP\3\2\2\2\fX\3\2\2\2\16\\\3\2\2\2\20e\3\2\2\2"+
		"\22i\3\2\2\2\24q\3\2\2\2\26y\3\2\2\2\30\u008b\3\2\2\2\32\u009c\3\2\2\2"+
		"\34\u00a5\3\2\2\2\36\u00ad\3\2\2\2 \u00b3\3\2\2\2\"\u00b5\3\2\2\2$\u00bd"+
		"\3\2\2\2&\u00bf\3\2\2\2(\u00c1\3\2\2\2*\u00c3\3\2\2\2,/\5\4\3\2-/\5\6"+
		"\4\2.,\3\2\2\2.-\3\2\2\2/\3\3\2\2\2\60\61\7\20\2\2\61\62\5&\24\2\62\66"+
		"\5(\25\2\63\65\5\16\b\2\64\63\3\2\2\2\658\3\2\2\2\66\64\3\2\2\2\66\67"+
		"\3\2\2\2\67;\3\2\2\28\66\3\2\2\29<\5\26\f\2:<\5\32\16\2;9\3\2\2\2;:\3"+
		"\2\2\2<\5\3\2\2\2=?\5\b\5\2>=\3\2\2\2?@\3\2\2\2@>\3\2\2\2@A\3\2\2\2AB"+
		"\3\2\2\2BC\7\24\2\2CD\5\24\13\2D\7\3\2\2\2EF\7\23\2\2FG\5&\24\2GH\7\26"+
		"\2\2HI\5(\25\2IL\7\3\2\2JM\5\n\6\2KM\5\4\3\2LJ\3\2\2\2LK\3\2\2\2MN\3\2"+
		"\2\2NO\7\4\2\2O\t\3\2\2\2PU\5\f\7\2QR\7\5\2\2RT\5\f\7\2SQ\3\2\2\2TW\3"+
		"\2\2\2US\3\2\2\2UV\3\2\2\2V\13\3\2\2\2WU\3\2\2\2XY\5\"\22\2YZ\7\30\2\2"+
		"Z[\5$\23\2[\r\3\2\2\2\\]\7\25\2\2]^\7\21\2\2^_\5(\25\2_`\5\20\t\2`a\7"+
		"\16\2\2ab\5$\23\2b\17\3\2\2\2cd\7\6\2\2df\5\"\22\2ec\3\2\2\2fg\3\2\2\2"+
		"ge\3\2\2\2gh\3\2\2\2h\21\3\2\2\2in\5\"\22\2jk\7\5\2\2km\5\"\22\2lj\3\2"+
		"\2\2mp\3\2\2\2nl\3\2\2\2no\3\2\2\2o\23\3\2\2\2pn\3\2\2\2qv\5(\25\2rs\7"+
		"\5\2\2su\5(\25\2tr\3\2\2\2ux\3\2\2\2vt\3\2\2\2vw\3\2\2\2w\25\3\2\2\2x"+
		"v\3\2\2\2yz\7\25\2\2z{\7\17\2\2{}\5(\25\2|~\5\20\t\2}|\3\2\2\2}~\3\2\2"+
		"\2~\177\3\2\2\2\177\u0082\7\3\2\2\u0080\u0083\5\22\n\2\u0081\u0083\5*"+
		"\26\2\u0082\u0080\3\2\2\2\u0082\u0081\3\2\2\2\u0082\u0083\3\2\2\2\u0083"+
		"\u0084\3\2\2\2\u0084\u0088\7\4\2\2\u0085\u0087\5\30\r\2\u0086\u0085\3"+
		"\2\2\2\u0087\u008a\3\2\2\2\u0088\u0086\3\2\2\2\u0088\u0089\3\2\2\2\u0089"+
		"\27\3\2\2\2\u008a\u0088\3\2\2\2\u008b\u008c\7\22\2\2\u008c\u008d\7\3\2"+
		"\2\u008d\u008e\5\"\22\2\u008e\u0091\7\3\2\2\u008f\u0092\5\22\n\2\u0090"+
		"\u0092\5*\26\2\u0091\u008f\3\2\2\2\u0091\u0090\3\2\2\2\u0091\u0092\3\2"+
		"\2\2\u0092\u0093\3\2\2\2\u0093\u0097\7\4\2\2\u0094\u0096\5\30\r\2\u0095"+
		"\u0094\3\2\2\2\u0096\u0099\3\2\2\2\u0097\u0095\3\2\2\2\u0097\u0098\3\2"+
		"\2\2\u0098\u009a\3\2\2\2\u0099\u0097\3\2\2\2\u009a\u009b\7\4\2\2\u009b"+
		"\31\3\2\2\2\u009c\u009d\7\25\2\2\u009d\u009e\5 \21\2\u009e\u009f\7\3\2"+
		"\2\u009f\u00a0\5(\25\2\u00a0\u00a1\7\3\2\2\u00a1\u00a2\5\"\22\2\u00a2"+
		"\u00a3\7\4\2\2\u00a3\u00a4\7\4\2\2\u00a4\33\3\2\2\2\u00a5\u00aa\5$\23"+
		"\2\u00a6\u00a7\7\5\2\2\u00a7\u00a9\5$\23\2\u00a8\u00a6\3\2\2\2\u00a9\u00ac"+
		"\3\2\2\2\u00aa\u00a8\3\2\2\2\u00aa\u00ab\3\2\2\2\u00ab\35\3\2\2\2\u00ac"+
		"\u00aa\3\2\2\2\u00ad\u00af\7\7\2\2\u00ae\u00b0\5\34\17\2\u00af\u00ae\3"+
		"\2\2\2\u00af\u00b0\3\2\2\2\u00b0\u00b1\3\2\2\2\u00b1\u00b2\7\b\2\2\u00b2"+
		"\37\3\2\2\2\u00b3\u00b4\t\2\2\2\u00b4!\3\2\2\2\u00b5\u00b6\7\35\2\2\u00b6"+
		"#\3\2\2\2\u00b7\u00be\5\4\3\2\u00b8\u00be\7\35\2\2\u00b9\u00be\7!\2\2"+
		"\u00ba\u00be\7\36\2\2\u00bb\u00be\7 \2\2\u00bc\u00be\5\36\20\2\u00bd\u00b7"+
		"\3\2\2\2\u00bd\u00b8\3\2\2\2\u00bd\u00b9\3\2\2\2\u00bd\u00ba\3\2\2\2\u00bd"+
		"\u00bb\3\2\2\2\u00bd\u00bc\3\2\2\2\u00be%\3\2\2\2\u00bf\u00c0\7\35\2\2"+
		"\u00c0\'\3\2\2\2\u00c1\u00c2\t\3\2\2\u00c2)\3\2\2\2\u00c3\u00c4\7\r\2"+
		"\2\u00c4+\3\2\2\2\23.\66;@LUgnv}\u0082\u0088\u0091\u0097\u00aa\u00af\u00bd";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}