// Generated from OctopusQL.g4 by ANTLR 4.9
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class OctopusQLLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", 
			"ENTITY", "INSERT", "DELETE", "UPDATE", "ASSIGN", "PIPELINE", "COLON", 
			"ISEQUALS", "EQUALS", "GT", "GTE", "LT", "LTE", "ADD", "REMOVE", "A", 
			"C", "S", "Y", "H", "O", "U", "T", "F", "R", "M", "W", "E", "LOWERCASE", 
			"UPPERCASE", "WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
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


	public OctopusQLLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "OctopusQL.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\'\u0193\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b"+
		"\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\f\3\f\3"+
		"\r\3\r\3\r\3\r\3\r\5\r\u008f\n\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3"+
		"\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00a3\n\16"+
		"\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\5\17\u00b1"+
		"\n\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\5\20\u00c2\n\20\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00d9"+
		"\n\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\5\22\u00ed\n\22\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u0101"+
		"\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\5\24\u0115\n\24\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u0129"+
		"\n\25\3\26\3\26\3\26\5\26\u012e\n\26\3\27\3\27\3\30\3\30\3\31\3\31\3\31"+
		"\3\32\3\32\3\33\3\33\3\34\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37"+
		"\3\37\3 \3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)"+
		"\3)\3*\3*\3+\3+\3,\3,\3-\3-\3.\3.\3/\3/\3\60\3\60\6\60\u0169\n\60\r\60"+
		"\16\60\u016a\3\61\6\61\u016e\n\61\r\61\16\61\u016f\3\62\3\62\7\62\u0174"+
		"\n\62\f\62\16\62\u0177\13\62\3\63\6\63\u017a\n\63\r\63\16\63\u017b\3\63"+
		"\7\63\u017f\n\63\f\63\16\63\u0182\13\63\3\64\3\64\7\64\u0186\n\64\f\64"+
		"\16\64\u0189\13\64\3\64\3\64\3\65\6\65\u018e\n\65\r\65\16\65\u018f\3\65"+
		"\3\65\3\u0187\2\66\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r"+
		"\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33"+
		"\65\34\67\359\36;\37= ?!A\2C\2E\2G\2I\2K\2M\2O\2Q\2S\2U\2W\2Y\2[\2]\2"+
		"_\"a#c$e%g&i\'\3\2\23\4\2CCcc\4\2EEee\4\2UUuu\4\2[[{{\4\2JJjj\4\2QQqq"+
		"\4\2WWww\4\2VVvv\4\2HHhh\4\2TTtt\4\2OOoo\4\2YYyy\4\2GGgg\3\2c|\3\2C\\"+
		"\3\2\62;\5\2\13\f\17\17\"\"\2\u01a1\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2"+
		"\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23"+
		"\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2"+
		"\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2"+
		"\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3"+
		"\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2_\3\2"+
		"\2\2\2a\3\2\2\2\2c\3\2\2\2\2e\3\2\2\2\2g\3\2\2\2\2i\3\2\2\2\3k\3\2\2\2"+
		"\5m\3\2\2\2\7o\3\2\2\2\tq\3\2\2\2\13s\3\2\2\2\ru\3\2\2\2\17w\3\2\2\2\21"+
		"{\3\2\2\2\23\177\3\2\2\2\25\u0083\3\2\2\2\27\u0087\3\2\2\2\31\u008e\3"+
		"\2\2\2\33\u00a2\3\2\2\2\35\u00b0\3\2\2\2\37\u00c1\3\2\2\2!\u00d8\3\2\2"+
		"\2#\u00ec\3\2\2\2%\u0100\3\2\2\2\'\u0114\3\2\2\2)\u0128\3\2\2\2+\u012d"+
		"\3\2\2\2-\u012f\3\2\2\2/\u0131\3\2\2\2\61\u0133\3\2\2\2\63\u0136\3\2\2"+
		"\2\65\u0138\3\2\2\2\67\u013a\3\2\2\29\u013d\3\2\2\2;\u013f\3\2\2\2=\u0142"+
		"\3\2\2\2?\u0145\3\2\2\2A\u0148\3\2\2\2C\u014a\3\2\2\2E\u014c\3\2\2\2G"+
		"\u014e\3\2\2\2I\u0150\3\2\2\2K\u0152\3\2\2\2M\u0154\3\2\2\2O\u0156\3\2"+
		"\2\2Q\u0158\3\2\2\2S\u015a\3\2\2\2U\u015c\3\2\2\2W\u015e\3\2\2\2Y\u0160"+
		"\3\2\2\2[\u0162\3\2\2\2]\u0164\3\2\2\2_\u0168\3\2\2\2a\u016d\3\2\2\2c"+
		"\u0171\3\2\2\2e\u0179\3\2\2\2g\u0183\3\2\2\2i\u018d\3\2\2\2kl\7*\2\2l"+
		"\4\3\2\2\2mn\7+\2\2n\6\3\2\2\2op\7.\2\2p\b\3\2\2\2qr\7\60\2\2r\n\3\2\2"+
		"\2st\7]\2\2t\f\3\2\2\2uv\7_\2\2v\16\3\2\2\2wx\7C\2\2xy\7X\2\2yz\7I\2\2"+
		"z\20\3\2\2\2{|\7U\2\2|}\7W\2\2}~\7O\2\2~\22\3\2\2\2\177\u0080\7O\2\2\u0080"+
		"\u0081\7K\2\2\u0081\u0082\7P\2\2\u0082\24\3\2\2\2\u0083\u0084\7O\2\2\u0084"+
		"\u0085\7C\2\2\u0085\u0086\7Z\2\2\u0086\26\3\2\2\2\u0087\u0088\7,\2\2\u0088"+
		"\30\3\2\2\2\u0089\u008f\5\61\31\2\u008a\u008f\5\65\33\2\u008b\u008f\5"+
		"\67\34\2\u008c\u008f\59\35\2\u008d\u008f\5;\36\2\u008e\u0089\3\2\2\2\u008e"+
		"\u008a\3\2\2\2\u008e\u008b\3\2\2\2\u008e\u008c\3\2\2\2\u008e\u008d\3\2"+
		"\2\2\u008f\32\3\2\2\2\u0090\u0091\7u\2\2\u0091\u0092\7g\2\2\u0092\u0093"+
		"\7n\2\2\u0093\u0094\7g\2\2\u0094\u0095\7e\2\2\u0095\u00a3\7v\2\2\u0096"+
		"\u0097\7U\2\2\u0097\u0098\7G\2\2\u0098\u0099\7N\2\2\u0099\u009a\7G\2\2"+
		"\u009a\u009b\7E\2\2\u009b\u00a3\7V\2\2\u009c\u009d\7U\2\2\u009d\u009e"+
		"\7g\2\2\u009e\u009f\7n\2\2\u009f\u00a0\7g\2\2\u00a0\u00a1\7e\2\2\u00a1"+
		"\u00a3\7v\2\2\u00a2\u0090\3\2\2\2\u00a2\u0096\3\2\2\2\u00a2\u009c\3\2"+
		"\2\2\u00a3\34\3\2\2\2\u00a4\u00a5\7h\2\2\u00a5\u00a6\7t\2\2\u00a6\u00a7"+
		"\7q\2\2\u00a7\u00b1\7o\2\2\u00a8\u00a9\7H\2\2\u00a9\u00aa\7T\2\2\u00aa"+
		"\u00ab\7Q\2\2\u00ab\u00b1\7O\2\2\u00ac\u00ad\7H\2\2\u00ad\u00ae\7t\2\2"+
		"\u00ae\u00af\7q\2\2\u00af\u00b1\7o\2\2\u00b0\u00a4\3\2\2\2\u00b0\u00a8"+
		"\3\2\2\2\u00b0\u00ac\3\2\2\2\u00b1\36\3\2\2\2\u00b2\u00b3\7y\2\2\u00b3"+
		"\u00b4\7j\2\2\u00b4\u00b5\7g\2\2\u00b5\u00b6\7t\2\2\u00b6\u00c2\7g\2\2"+
		"\u00b7\u00b8\7Y\2\2\u00b8\u00b9\7J\2\2\u00b9\u00ba\7G\2\2\u00ba\u00bb"+
		"\7T\2\2\u00bb\u00c2\7G\2\2\u00bc\u00bd\7Y\2\2\u00bd\u00be\7j\2\2\u00be"+
		"\u00bf\7g\2\2\u00bf\u00c0\7t\2\2\u00c0\u00c2\7g\2\2\u00c1\u00b2\3\2\2"+
		"\2\u00c1\u00b7\3\2\2\2\u00c1\u00bc\3\2\2\2\u00c2 \3\2\2\2\u00c3\u00c4"+
		"\7k\2\2\u00c4\u00c5\7p\2\2\u00c5\u00c6\7e\2\2\u00c6\u00c7\7n\2\2\u00c7"+
		"\u00c8\7w\2\2\u00c8\u00c9\7f\2\2\u00c9\u00d9\7g\2\2\u00ca\u00cb\7K\2\2"+
		"\u00cb\u00cc\7P\2\2\u00cc\u00cd\7E\2\2\u00cd\u00ce\7N\2\2\u00ce\u00cf"+
		"\7W\2\2\u00cf\u00d0\7F\2\2\u00d0\u00d9\7G\2\2\u00d1\u00d2\7K\2\2\u00d2"+
		"\u00d3\7p\2\2\u00d3\u00d4\7e\2\2\u00d4\u00d5\7n\2\2\u00d5\u00d6\7w\2\2"+
		"\u00d6\u00d7\7f\2\2\u00d7\u00d9\7g\2\2\u00d8\u00c3\3\2\2\2\u00d8\u00ca"+
		"\3\2\2\2\u00d8\u00d1\3\2\2\2\u00d9\"\3\2\2\2\u00da\u00db\7g\2\2\u00db"+
		"\u00dc\7p\2\2\u00dc\u00dd\7v\2\2\u00dd\u00de\7k\2\2\u00de\u00df\7v\2\2"+
		"\u00df\u00ed\7{\2\2\u00e0\u00e1\7G\2\2\u00e1\u00e2\7P\2\2\u00e2\u00e3"+
		"\7V\2\2\u00e3\u00e4\7K\2\2\u00e4\u00e5\7V\2\2\u00e5\u00ed\7[\2\2\u00e6"+
		"\u00e7\7G\2\2\u00e7\u00e8\7p\2\2\u00e8\u00e9\7v\2\2\u00e9\u00ea\7k\2\2"+
		"\u00ea\u00eb\7v\2\2\u00eb\u00ed\7{\2\2\u00ec\u00da\3\2\2\2\u00ec\u00e0"+
		"\3\2\2\2\u00ec\u00e6\3\2\2\2\u00ed$\3\2\2\2\u00ee\u00ef\7k\2\2\u00ef\u00f0"+
		"\7p\2\2\u00f0\u00f1\7u\2\2\u00f1\u00f2\7g\2\2\u00f2\u00f3\7t\2\2\u00f3"+
		"\u0101\7v\2\2\u00f4\u00f5\7K\2\2\u00f5\u00f6\7P\2\2\u00f6\u00f7\7U\2\2"+
		"\u00f7\u00f8\7G\2\2\u00f8\u00f9\7T\2\2\u00f9\u0101\7V\2\2\u00fa\u00fb"+
		"\7K\2\2\u00fb\u00fc\7p\2\2\u00fc\u00fd\7u\2\2\u00fd\u00fe\7g\2\2\u00fe"+
		"\u00ff\7t\2\2\u00ff\u0101\7v\2\2\u0100\u00ee\3\2\2\2\u0100\u00f4\3\2\2"+
		"\2\u0100\u00fa\3\2\2\2\u0101&\3\2\2\2\u0102\u0103\7f\2\2\u0103\u0104\7"+
		"g\2\2\u0104\u0105\7n\2\2\u0105\u0106\7g\2\2\u0106\u0107\7v\2\2\u0107\u0115"+
		"\7g\2\2\u0108\u0109\7F\2\2\u0109\u010a\7G\2\2\u010a\u010b\7N\2\2\u010b"+
		"\u010c\7G\2\2\u010c\u010d\7V\2\2\u010d\u0115\7G\2\2\u010e\u010f\7F\2\2"+
		"\u010f\u0110\7g\2\2\u0110\u0111\7n\2\2\u0111\u0112\7g\2\2\u0112\u0113"+
		"\7v\2\2\u0113\u0115\7g\2\2\u0114\u0102\3\2\2\2\u0114\u0108\3\2\2\2\u0114"+
		"\u010e\3\2\2\2\u0115(\3\2\2\2\u0116\u0117\7w\2\2\u0117\u0118\7r\2\2\u0118"+
		"\u0119\7f\2\2\u0119\u011a\7c\2\2\u011a\u011b\7v\2\2\u011b\u0129\7g\2\2"+
		"\u011c\u011d\7W\2\2\u011d\u011e\7R\2\2\u011e\u011f\7F\2\2\u011f\u0120"+
		"\7C\2\2\u0120\u0121\7V\2\2\u0121\u0129\7G\2\2\u0122\u0123\7W\2\2\u0123"+
		"\u0124\7r\2\2\u0124\u0125\7f\2\2\u0125\u0126\7c\2\2\u0126\u0127\7v\2\2"+
		"\u0127\u0129\7g\2\2\u0128\u0116\3\2\2\2\u0128\u011c\3\2\2\2\u0128\u0122"+
		"\3\2\2\2\u0129*\3\2\2\2\u012a\u012e\5\63\32\2\u012b\u012e\5=\37\2\u012c"+
		"\u012e\5? \2\u012d\u012a\3\2\2\2\u012d\u012b\3\2\2\2\u012d\u012c\3\2\2"+
		"\2\u012e,\3\2\2\2\u012f\u0130\7~\2\2\u0130.\3\2\2\2\u0131\u0132\7<\2\2"+
		"\u0132\60\3\2\2\2\u0133\u0134\7?\2\2\u0134\u0135\7?\2\2\u0135\62\3\2\2"+
		"\2\u0136\u0137\7?\2\2\u0137\64\3\2\2\2\u0138\u0139\7@\2\2\u0139\66\3\2"+
		"\2\2\u013a\u013b\7@\2\2\u013b\u013c\7?\2\2\u013c8\3\2\2\2\u013d\u013e"+
		"\7>\2\2\u013e:\3\2\2\2\u013f\u0140\7>\2\2\u0140\u0141\7?\2\2\u0141<\3"+
		"\2\2\2\u0142\u0143\7-\2\2\u0143\u0144\7?\2\2\u0144>\3\2\2\2\u0145\u0146"+
		"\7/\2\2\u0146\u0147\7?\2\2\u0147@\3\2\2\2\u0148\u0149\t\2\2\2\u0149B\3"+
		"\2\2\2\u014a\u014b\t\3\2\2\u014bD\3\2\2\2\u014c\u014d\t\4\2\2\u014dF\3"+
		"\2\2\2\u014e\u014f\t\5\2\2\u014fH\3\2\2\2\u0150\u0151\t\6\2\2\u0151J\3"+
		"\2\2\2\u0152\u0153\t\7\2\2\u0153L\3\2\2\2\u0154\u0155\t\b\2\2\u0155N\3"+
		"\2\2\2\u0156\u0157\t\t\2\2\u0157P\3\2\2\2\u0158\u0159\t\n\2\2\u0159R\3"+
		"\2\2\2\u015a\u015b\t\13\2\2\u015bT\3\2\2\2\u015c\u015d\t\f\2\2\u015dV"+
		"\3\2\2\2\u015e\u015f\t\r\2\2\u015fX\3\2\2\2\u0160\u0161\t\16\2\2\u0161"+
		"Z\3\2\2\2\u0162\u0163\t\17\2\2\u0163\\\3\2\2\2\u0164\u0165\t\20\2\2\u0165"+
		"^\3\2\2\2\u0166\u0169\5[.\2\u0167\u0169\5]/\2\u0168\u0166\3\2\2\2\u0168"+
		"\u0167\3\2\2\2\u0169\u016a\3\2\2\2\u016a\u0168\3\2\2\2\u016a\u016b\3\2"+
		"\2\2\u016b`\3\2\2\2\u016c\u016e\t\21\2\2\u016d\u016c\3\2\2\2\u016e\u016f"+
		"\3\2\2\2\u016f\u016d\3\2\2\2\u016f\u0170\3\2\2\2\u0170b\3\2\2\2\u0171"+
		"\u0175\t\20\2\2\u0172\u0174\t\17\2\2\u0173\u0172\3\2\2\2\u0174\u0177\3"+
		"\2\2\2\u0175\u0173\3\2\2\2\u0175\u0176\3\2\2\2\u0176d\3\2\2\2\u0177\u0175"+
		"\3\2\2\2\u0178\u017a\t\17\2\2\u0179\u0178\3\2\2\2\u017a\u017b\3\2\2\2"+
		"\u017b\u0179\3\2\2\2\u017b\u017c\3\2\2\2\u017c\u0180\3\2\2\2\u017d\u017f"+
		"\t\21\2\2\u017e\u017d\3\2\2\2\u017f\u0182\3\2\2\2\u0180\u017e\3\2\2\2"+
		"\u0180\u0181\3\2\2\2\u0181f\3\2\2\2\u0182\u0180\3\2\2\2\u0183\u0187\7"+
		"$\2\2\u0184\u0186\13\2\2\2\u0185\u0184\3\2\2\2\u0186\u0189\3\2\2\2\u0187"+
		"\u0188\3\2\2\2\u0187\u0185\3\2\2\2\u0188\u018a\3\2\2\2\u0189\u0187\3\2"+
		"\2\2\u018a\u018b\7$\2\2\u018bh\3\2\2\2\u018c\u018e\t\22\2\2\u018d\u018c"+
		"\3\2\2\2\u018e\u018f\3\2\2\2\u018f\u018d\3\2\2\2\u018f\u0190\3\2\2\2\u0190"+
		"\u0191\3\2\2\2\u0191\u0192\b\65\2\2\u0192j\3\2\2\2\25\2\u008e\u00a2\u00b0"+
		"\u00c1\u00d8\u00ec\u0100\u0114\u0128\u012d\u0168\u016a\u016f\u0175\u017b"+
		"\u0180\u0187\u018f\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}