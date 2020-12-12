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
		COMPARISON=10, SELECT=11, FROM=12, WHERE=13, INCLUDE=14, PIPELINE=15, 
		EQUALS=16, GT=17, GTE=18, LT=19, LTE=20, WORD=21, NUMBER=22, ENT=23, ENTREP=24, 
		TEXT=25, WHITESPACE=26;
	public static final int
		RULE_r = 0, RULE_select = 1, RULE_whereClause = 2, RULE_attributesWithDot = 3, 
		RULE_attributes = 4, RULE_selectClause = 5, RULE_include = 6, RULE_aggregateClause = 7, 
		RULE_func = 8, RULE_attribute = 9, RULE_value = 10, RULE_entity = 11, 
		RULE_entityRep = 12, RULE_all = 13;
	private static String[] makeRuleNames() {
		return new String[] {
			"r", "select", "whereClause", "attributesWithDot", "attributes", "selectClause", 
			"include", "aggregateClause", "func", "attribute", "value", "entity", 
			"entityRep", "all"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'.'", "','", "'('", "')'", "'AVG'", "'SUM'", "'MIN'", "'MAX'", 
			"'*'", null, null, null, null, null, "'|'", "'=='", "'>'", "'>='", "'<'", 
			"'<='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, "COMPARISON", 
			"SELECT", "FROM", "WHERE", "INCLUDE", "PIPELINE", "EQUALS", "GT", "GTE", 
			"LT", "LTE", "WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
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
			enterOuterAlt(_localctx, 1);
			{
			setState(28);
			select();
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
			setState(30);
			match(FROM);
			setState(31);
			entity();
			setState(32);
			entityRep();
			setState(36);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(33);
					whereClause();
					}
					} 
				}
				setState(38);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,0,_ctx);
			}
			setState(41);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				{
				setState(39);
				selectClause();
				}
				break;
			case 2:
				{
				setState(40);
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

	public static class WhereClauseContext extends ParserRuleContext {
		public TerminalNode PIPELINE() { return getToken(OctopusQLParser.PIPELINE, 0); }
		public TerminalNode WHERE() { return getToken(OctopusQLParser.WHERE, 0); }
		public EntityRepContext entityRep() {
			return getRuleContext(EntityRepContext.class,0);
		}
		public AttributesWithDotContext attributesWithDot() {
			return getRuleContext(AttributesWithDotContext.class,0);
		}
		public TerminalNode COMPARISON() { return getToken(OctopusQLParser.COMPARISON, 0); }
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
		enterRule(_localctx, 4, RULE_whereClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(43);
			match(PIPELINE);
			setState(44);
			match(WHERE);
			setState(45);
			entityRep();
			setState(46);
			attributesWithDot();
			setState(47);
			match(COMPARISON);
			setState(48);
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

	public static class AttributesWithDotContext extends ParserRuleContext {
		public AttributeContext attribute;
		public List<AttributeContext> el = new ArrayList<AttributeContext>();
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public AttributesWithDotContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attributesWithDot; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAttributesWithDot(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAttributesWithDot(this);
		}
	}

	public final AttributesWithDotContext attributesWithDot() throws RecognitionException {
		AttributesWithDotContext _localctx = new AttributesWithDotContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_attributesWithDot);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(52); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(50);
				match(T__0);
				setState(51);
				((AttributesWithDotContext)_localctx).attribute = attribute();
				((AttributesWithDotContext)_localctx).el.add(((AttributesWithDotContext)_localctx).attribute);
				}
				}
				setState(54); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==T__0 );
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

	public static class AttributesContext extends ParserRuleContext {
		public AttributeContext attribute;
		public List<AttributeContext> attrList = new ArrayList<AttributeContext>();
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public AttributesContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attributes; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAttributes(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAttributes(this);
		}
	}

	public final AttributesContext attributes() throws RecognitionException {
		AttributesContext _localctx = new AttributesContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_attributes);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(56);
			((AttributesContext)_localctx).attribute = attribute();
			((AttributesContext)_localctx).attrList.add(((AttributesContext)_localctx).attribute);
			setState(61);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__1) {
				{
				{
				setState(57);
				match(T__1);
				setState(58);
				((AttributesContext)_localctx).attribute = attribute();
				((AttributesContext)_localctx).attrList.add(((AttributesContext)_localctx).attribute);
				}
				}
				setState(63);
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
		public AttributesWithDotContext attributesWithDot() {
			return getRuleContext(AttributesWithDotContext.class,0);
		}
		public AttributesContext attributes() {
			return getRuleContext(AttributesContext.class,0);
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
		enterRule(_localctx, 10, RULE_selectClause);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(64);
			match(PIPELINE);
			setState(65);
			match(SELECT);
			setState(66);
			entityRep();
			setState(68);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__0) {
				{
				setState(67);
				attributesWithDot();
				}
			}

			setState(70);
			match(T__2);
			setState(73);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(71);
				attributes();
				}
				break;
			case T__8:
				{
				setState(72);
				all();
				}
				break;
			case T__3:
				break;
			default:
				break;
			}
			setState(75);
			match(T__3);
			setState(79);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(76);
				include();
				}
				}
				setState(81);
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
		public AttributeContext attribute() {
			return getRuleContext(AttributeContext.class,0);
		}
		public AttributesContext attributes() {
			return getRuleContext(AttributesContext.class,0);
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
		enterRule(_localctx, 12, RULE_include);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(82);
			match(INCLUDE);
			setState(83);
			match(T__2);
			setState(84);
			attribute();
			setState(85);
			match(T__2);
			setState(88);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case WORD:
				{
				setState(86);
				attributes();
				}
				break;
			case T__8:
				{
				setState(87);
				all();
				}
				break;
			case T__3:
				break;
			default:
				break;
			}
			setState(90);
			match(T__3);
			setState(94);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(91);
				include();
				}
				}
				setState(96);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(97);
			match(T__3);
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
		public AttributeContext attribute() {
			return getRuleContext(AttributeContext.class,0);
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
		enterRule(_localctx, 14, RULE_aggregateClause);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			match(PIPELINE);
			setState(100);
			func();
			setState(101);
			match(T__2);
			setState(102);
			entityRep();
			setState(103);
			match(T__2);
			setState(104);
			attribute();
			setState(105);
			match(T__3);
			setState(106);
			match(T__3);
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
		enterRule(_localctx, 16, RULE_func);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(108);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__5) | (1L << T__6) | (1L << T__7))) != 0)) ) {
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

	public static class AttributeContext extends ParserRuleContext {
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof OctopusQLListener ) ((OctopusQLListener)listener).exitAttribute(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_attribute);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(110);
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
		public TerminalNode WORD() { return getToken(OctopusQLParser.WORD, 0); }
		public TerminalNode TEXT() { return getToken(OctopusQLParser.TEXT, 0); }
		public TerminalNode NUMBER() { return getToken(OctopusQLParser.NUMBER, 0); }
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
		enterRule(_localctx, 20, RULE_value);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(112);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << WORD) | (1L << NUMBER) | (1L << TEXT))) != 0)) ) {
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
		enterRule(_localctx, 22, RULE_entity);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(114);
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
		enterRule(_localctx, 24, RULE_entityRep);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(116);
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
		enterRule(_localctx, 26, RULE_all);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(118);
			match(T__8);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\34{\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t\13\4"+
		"\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\3\2\3\2\3\3\3\3\3\3\3\3\7\3%\n\3\f"+
		"\3\16\3(\13\3\3\3\3\3\5\3,\n\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\6\5"+
		"\67\n\5\r\5\16\58\3\6\3\6\3\6\7\6>\n\6\f\6\16\6A\13\6\3\7\3\7\3\7\3\7"+
		"\5\7G\n\7\3\7\3\7\3\7\5\7L\n\7\3\7\3\7\7\7P\n\7\f\7\16\7S\13\7\3\b\3\b"+
		"\3\b\3\b\3\b\3\b\5\b[\n\b\3\b\3\b\7\b_\n\b\f\b\16\bb\13\b\3\b\3\b\3\t"+
		"\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16"+
		"\3\16\3\17\3\17\3\17\2\2\20\2\4\6\b\n\f\16\20\22\24\26\30\32\34\2\5\3"+
		"\2\7\n\4\2\27\30\33\33\4\2\27\27\32\32\2w\2\36\3\2\2\2\4 \3\2\2\2\6-\3"+
		"\2\2\2\b\66\3\2\2\2\n:\3\2\2\2\fB\3\2\2\2\16T\3\2\2\2\20e\3\2\2\2\22n"+
		"\3\2\2\2\24p\3\2\2\2\26r\3\2\2\2\30t\3\2\2\2\32v\3\2\2\2\34x\3\2\2\2\36"+
		"\37\5\4\3\2\37\3\3\2\2\2 !\7\16\2\2!\"\5\30\r\2\"&\5\32\16\2#%\5\6\4\2"+
		"$#\3\2\2\2%(\3\2\2\2&$\3\2\2\2&\'\3\2\2\2\'+\3\2\2\2(&\3\2\2\2),\5\f\7"+
		"\2*,\5\20\t\2+)\3\2\2\2+*\3\2\2\2,\5\3\2\2\2-.\7\21\2\2./\7\17\2\2/\60"+
		"\5\32\16\2\60\61\5\b\5\2\61\62\7\f\2\2\62\63\5\26\f\2\63\7\3\2\2\2\64"+
		"\65\7\3\2\2\65\67\5\24\13\2\66\64\3\2\2\2\678\3\2\2\28\66\3\2\2\289\3"+
		"\2\2\29\t\3\2\2\2:?\5\24\13\2;<\7\4\2\2<>\5\24\13\2=;\3\2\2\2>A\3\2\2"+
		"\2?=\3\2\2\2?@\3\2\2\2@\13\3\2\2\2A?\3\2\2\2BC\7\21\2\2CD\7\r\2\2DF\5"+
		"\32\16\2EG\5\b\5\2FE\3\2\2\2FG\3\2\2\2GH\3\2\2\2HK\7\5\2\2IL\5\n\6\2J"+
		"L\5\34\17\2KI\3\2\2\2KJ\3\2\2\2KL\3\2\2\2LM\3\2\2\2MQ\7\6\2\2NP\5\16\b"+
		"\2ON\3\2\2\2PS\3\2\2\2QO\3\2\2\2QR\3\2\2\2R\r\3\2\2\2SQ\3\2\2\2TU\7\20"+
		"\2\2UV\7\5\2\2VW\5\24\13\2WZ\7\5\2\2X[\5\n\6\2Y[\5\34\17\2ZX\3\2\2\2Z"+
		"Y\3\2\2\2Z[\3\2\2\2[\\\3\2\2\2\\`\7\6\2\2]_\5\16\b\2^]\3\2\2\2_b\3\2\2"+
		"\2`^\3\2\2\2`a\3\2\2\2ac\3\2\2\2b`\3\2\2\2cd\7\6\2\2d\17\3\2\2\2ef\7\21"+
		"\2\2fg\5\22\n\2gh\7\5\2\2hi\5\32\16\2ij\7\5\2\2jk\5\24\13\2kl\7\6\2\2"+
		"lm\7\6\2\2m\21\3\2\2\2no\t\2\2\2o\23\3\2\2\2pq\7\27\2\2q\25\3\2\2\2rs"+
		"\t\3\2\2s\27\3\2\2\2tu\7\27\2\2u\31\3\2\2\2vw\t\4\2\2w\33\3\2\2\2xy\7"+
		"\13\2\2y\35\3\2\2\2\13&+8?FKQZ`";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}