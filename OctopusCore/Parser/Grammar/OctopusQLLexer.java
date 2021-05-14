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
		T__9=10, T__10=11, EQUALS=12, ASSIGN=13, COMPARATOR=14, SELECT=15, FROM=16, 
		WHERE=17, INCLUDE=18, ENTITY=19, INSERT=20, DELETE=21, UPDATE=22, PIPELINE=23, 
		COLON=24, ISEQUALS=25, GT=26, GTE=27, LT=28, LTE=29, ADD=30, REMOVE=31, 
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
			"T__9", "T__10", "EQUALS", "ASSIGN", "COMPARATOR", "SELECT", "FROM", 
			"WHERE", "INCLUDE", "ENTITY", "INSERT", "DELETE", "UPDATE", "PIPELINE", 
			"COLON", "ISEQUALS", "GT", "GTE", "LT", "LTE", "ADD", "REMOVE", "LOWERCASE", 
			"UPPERCASE", "WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", "'='", null, null, null, null, null, null, null, null, 
			null, null, "'|'", "':'", "'=='", "'>'", "'>='", "'<'", "'<='", "'+='", 
			"'-='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"EQUALS", "ASSIGN", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\'\u015f\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\3\2\3\2\3\3\3\3\3\4"+
		"\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3"+
		"\n\3\n\3\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\16\5\16u\n\16\3"+
		"\17\3\17\3\17\3\17\3\17\5\17|\n\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u0090\n\20"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u009e"+
		"\n\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\5\22\u00af\n\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00c6"+
		"\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\5\24\u00da\n\24\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u00ee"+
		"\n\25\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\5\26\u0102\n\26\3\27\3\27\3\27\3\27\3\27\3\27"+
		"\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\5\27\u0116"+
		"\n\27\3\30\3\30\3\31\3\31\3\32\3\32\3\32\3\33\3\33\3\34\3\34\3\34\3\35"+
		"\3\35\3\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3 \3!\3!\3\"\3\"\3#\3#\6#\u0135"+
		"\n#\r#\16#\u0136\3$\6$\u013a\n$\r$\16$\u013b\3%\3%\7%\u0140\n%\f%\16%"+
		"\u0143\13%\3&\6&\u0146\n&\r&\16&\u0147\3&\7&\u014b\n&\f&\16&\u014e\13"+
		"&\3\'\3\'\7\'\u0152\n\'\f\'\16\'\u0155\13\'\3\'\3\'\3(\6(\u015a\n(\r("+
		"\16(\u015b\3(\3(\3\u0153\2)\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25"+
		"\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32"+
		"\63\33\65\34\67\359\36;\37= ?!A\2C\2E\"G#I$K%M&O\'\3\2\6\3\2c|\3\2C\\"+
		"\3\2\62;\5\2\13\f\17\17\"\"\2\u017a\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2"+
		"\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23"+
		"\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2"+
		"\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2"+
		"\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3"+
		"\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2E\3\2"+
		"\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\3Q\3\2\2\2"+
		"\5S\3\2\2\2\7U\3\2\2\2\tW\3\2\2\2\13Y\3\2\2\2\r[\3\2\2\2\17]\3\2\2\2\21"+
		"a\3\2\2\2\23e\3\2\2\2\25i\3\2\2\2\27m\3\2\2\2\31o\3\2\2\2\33t\3\2\2\2"+
		"\35{\3\2\2\2\37\u008f\3\2\2\2!\u009d\3\2\2\2#\u00ae\3\2\2\2%\u00c5\3\2"+
		"\2\2\'\u00d9\3\2\2\2)\u00ed\3\2\2\2+\u0101\3\2\2\2-\u0115\3\2\2\2/\u0117"+
		"\3\2\2\2\61\u0119\3\2\2\2\63\u011b\3\2\2\2\65\u011e\3\2\2\2\67\u0120\3"+
		"\2\2\29\u0123\3\2\2\2;\u0125\3\2\2\2=\u0128\3\2\2\2?\u012b\3\2\2\2A\u012e"+
		"\3\2\2\2C\u0130\3\2\2\2E\u0134\3\2\2\2G\u0139\3\2\2\2I\u013d\3\2\2\2K"+
		"\u0145\3\2\2\2M\u014f\3\2\2\2O\u0159\3\2\2\2QR\7*\2\2R\4\3\2\2\2ST\7+"+
		"\2\2T\6\3\2\2\2UV\7.\2\2V\b\3\2\2\2WX\7\60\2\2X\n\3\2\2\2YZ\7]\2\2Z\f"+
		"\3\2\2\2[\\\7_\2\2\\\16\3\2\2\2]^\7C\2\2^_\7X\2\2_`\7I\2\2`\20\3\2\2\2"+
		"ab\7U\2\2bc\7W\2\2cd\7O\2\2d\22\3\2\2\2ef\7O\2\2fg\7K\2\2gh\7P\2\2h\24"+
		"\3\2\2\2ij\7O\2\2jk\7C\2\2kl\7Z\2\2l\26\3\2\2\2mn\7,\2\2n\30\3\2\2\2o"+
		"p\7?\2\2p\32\3\2\2\2qu\5\31\r\2ru\5=\37\2su\5? \2tq\3\2\2\2tr\3\2\2\2"+
		"ts\3\2\2\2u\34\3\2\2\2v|\5\63\32\2w|\5\65\33\2x|\5\67\34\2y|\59\35\2z"+
		"|\5;\36\2{v\3\2\2\2{w\3\2\2\2{x\3\2\2\2{y\3\2\2\2{z\3\2\2\2|\36\3\2\2"+
		"\2}~\7u\2\2~\177\7g\2\2\177\u0080\7n\2\2\u0080\u0081\7g\2\2\u0081\u0082"+
		"\7e\2\2\u0082\u0090\7v\2\2\u0083\u0084\7U\2\2\u0084\u0085\7G\2\2\u0085"+
		"\u0086\7N\2\2\u0086\u0087\7G\2\2\u0087\u0088\7E\2\2\u0088\u0090\7V\2\2"+
		"\u0089\u008a\7U\2\2\u008a\u008b\7g\2\2\u008b\u008c\7n\2\2\u008c\u008d"+
		"\7g\2\2\u008d\u008e\7e\2\2\u008e\u0090\7v\2\2\u008f}\3\2\2\2\u008f\u0083"+
		"\3\2\2\2\u008f\u0089\3\2\2\2\u0090 \3\2\2\2\u0091\u0092\7h\2\2\u0092\u0093"+
		"\7t\2\2\u0093\u0094\7q\2\2\u0094\u009e\7o\2\2\u0095\u0096\7H\2\2\u0096"+
		"\u0097\7T\2\2\u0097\u0098\7Q\2\2\u0098\u009e\7O\2\2\u0099\u009a\7H\2\2"+
		"\u009a\u009b\7t\2\2\u009b\u009c\7q\2\2\u009c\u009e\7o\2\2\u009d\u0091"+
		"\3\2\2\2\u009d\u0095\3\2\2\2\u009d\u0099\3\2\2\2\u009e\"\3\2\2\2\u009f"+
		"\u00a0\7y\2\2\u00a0\u00a1\7j\2\2\u00a1\u00a2\7g\2\2\u00a2\u00a3\7t\2\2"+
		"\u00a3\u00af\7g\2\2\u00a4\u00a5\7Y\2\2\u00a5\u00a6\7J\2\2\u00a6\u00a7"+
		"\7G\2\2\u00a7\u00a8\7T\2\2\u00a8\u00af\7G\2\2\u00a9\u00aa\7Y\2\2\u00aa"+
		"\u00ab\7j\2\2\u00ab\u00ac\7g\2\2\u00ac\u00ad\7t\2\2\u00ad\u00af\7g\2\2"+
		"\u00ae\u009f\3\2\2\2\u00ae\u00a4\3\2\2\2\u00ae\u00a9\3\2\2\2\u00af$\3"+
		"\2\2\2\u00b0\u00b1\7k\2\2\u00b1\u00b2\7p\2\2\u00b2\u00b3\7e\2\2\u00b3"+
		"\u00b4\7n\2\2\u00b4\u00b5\7w\2\2\u00b5\u00b6\7f\2\2\u00b6\u00c6\7g\2\2"+
		"\u00b7\u00b8\7K\2\2\u00b8\u00b9\7P\2\2\u00b9\u00ba\7E\2\2\u00ba\u00bb"+
		"\7N\2\2\u00bb\u00bc\7W\2\2\u00bc\u00bd\7F\2\2\u00bd\u00c6\7G\2\2\u00be"+
		"\u00bf\7K\2\2\u00bf\u00c0\7p\2\2\u00c0\u00c1\7e\2\2\u00c1\u00c2\7n\2\2"+
		"\u00c2\u00c3\7w\2\2\u00c3\u00c4\7f\2\2\u00c4\u00c6\7g\2\2\u00c5\u00b0"+
		"\3\2\2\2\u00c5\u00b7\3\2\2\2\u00c5\u00be\3\2\2\2\u00c6&\3\2\2\2\u00c7"+
		"\u00c8\7g\2\2\u00c8\u00c9\7p\2\2\u00c9\u00ca\7v\2\2\u00ca\u00cb\7k\2\2"+
		"\u00cb\u00cc\7v\2\2\u00cc\u00da\7{\2\2\u00cd\u00ce\7G\2\2\u00ce\u00cf"+
		"\7P\2\2\u00cf\u00d0\7V\2\2\u00d0\u00d1\7K\2\2\u00d1\u00d2\7V\2\2\u00d2"+
		"\u00da\7[\2\2\u00d3\u00d4\7G\2\2\u00d4\u00d5\7p\2\2\u00d5\u00d6\7v\2\2"+
		"\u00d6\u00d7\7k\2\2\u00d7\u00d8\7v\2\2\u00d8\u00da\7{\2\2\u00d9\u00c7"+
		"\3\2\2\2\u00d9\u00cd\3\2\2\2\u00d9\u00d3\3\2\2\2\u00da(\3\2\2\2\u00db"+
		"\u00dc\7k\2\2\u00dc\u00dd\7p\2\2\u00dd\u00de\7u\2\2\u00de\u00df\7g\2\2"+
		"\u00df\u00e0\7t\2\2\u00e0\u00ee\7v\2\2\u00e1\u00e2\7K\2\2\u00e2\u00e3"+
		"\7P\2\2\u00e3\u00e4\7U\2\2\u00e4\u00e5\7G\2\2\u00e5\u00e6\7T\2\2\u00e6"+
		"\u00ee\7V\2\2\u00e7\u00e8\7K\2\2\u00e8\u00e9\7p\2\2\u00e9\u00ea\7u\2\2"+
		"\u00ea\u00eb\7g\2\2\u00eb\u00ec\7t\2\2\u00ec\u00ee\7v\2\2\u00ed\u00db"+
		"\3\2\2\2\u00ed\u00e1\3\2\2\2\u00ed\u00e7\3\2\2\2\u00ee*\3\2\2\2\u00ef"+
		"\u00f0\7f\2\2\u00f0\u00f1\7g\2\2\u00f1\u00f2\7n\2\2\u00f2\u00f3\7g\2\2"+
		"\u00f3\u00f4\7v\2\2\u00f4\u0102\7g\2\2\u00f5\u00f6\7F\2\2\u00f6\u00f7"+
		"\7G\2\2\u00f7\u00f8\7N\2\2\u00f8\u00f9\7G\2\2\u00f9\u00fa\7V\2\2\u00fa"+
		"\u0102\7G\2\2\u00fb\u00fc\7F\2\2\u00fc\u00fd\7g\2\2\u00fd\u00fe\7n\2\2"+
		"\u00fe\u00ff\7g\2\2\u00ff\u0100\7v\2\2\u0100\u0102\7g\2\2\u0101\u00ef"+
		"\3\2\2\2\u0101\u00f5\3\2\2\2\u0101\u00fb\3\2\2\2\u0102,\3\2\2\2\u0103"+
		"\u0104\7w\2\2\u0104\u0105\7r\2\2\u0105\u0106\7f\2\2\u0106\u0107\7c\2\2"+
		"\u0107\u0108\7v\2\2\u0108\u0116\7g\2\2\u0109\u010a\7W\2\2\u010a\u010b"+
		"\7R\2\2\u010b\u010c\7F\2\2\u010c\u010d\7C\2\2\u010d\u010e\7V\2\2\u010e"+
		"\u0116\7G\2\2\u010f\u0110\7W\2\2\u0110\u0111\7r\2\2\u0111\u0112\7f\2\2"+
		"\u0112\u0113\7c\2\2\u0113\u0114\7v\2\2\u0114\u0116\7g\2\2\u0115\u0103"+
		"\3\2\2\2\u0115\u0109\3\2\2\2\u0115\u010f\3\2\2\2\u0116.\3\2\2\2\u0117"+
		"\u0118\7~\2\2\u0118\60\3\2\2\2\u0119\u011a\7<\2\2\u011a\62\3\2\2\2\u011b"+
		"\u011c\7?\2\2\u011c\u011d\7?\2\2\u011d\64\3\2\2\2\u011e\u011f\7@\2\2\u011f"+
		"\66\3\2\2\2\u0120\u0121\7@\2\2\u0121\u0122\7?\2\2\u01228\3\2\2\2\u0123"+
		"\u0124\7>\2\2\u0124:\3\2\2\2\u0125\u0126\7>\2\2\u0126\u0127\7?\2\2\u0127"+
		"<\3\2\2\2\u0128\u0129\7-\2\2\u0129\u012a\7?\2\2\u012a>\3\2\2\2\u012b\u012c"+
		"\7/\2\2\u012c\u012d\7?\2\2\u012d@\3\2\2\2\u012e\u012f\t\2\2\2\u012fB\3"+
		"\2\2\2\u0130\u0131\t\3\2\2\u0131D\3\2\2\2\u0132\u0135\5A!\2\u0133\u0135"+
		"\5C\"\2\u0134\u0132\3\2\2\2\u0134\u0133\3\2\2\2\u0135\u0136\3\2\2\2\u0136"+
		"\u0134\3\2\2\2\u0136\u0137\3\2\2\2\u0137F\3\2\2\2\u0138\u013a\t\4\2\2"+
		"\u0139\u0138\3\2\2\2\u013a\u013b\3\2\2\2\u013b\u0139\3\2\2\2\u013b\u013c"+
		"\3\2\2\2\u013cH\3\2\2\2\u013d\u0141\t\3\2\2\u013e\u0140\t\2\2\2\u013f"+
		"\u013e\3\2\2\2\u0140\u0143\3\2\2\2\u0141\u013f\3\2\2\2\u0141\u0142\3\2"+
		"\2\2\u0142J\3\2\2\2\u0143\u0141\3\2\2\2\u0144\u0146\t\2\2\2\u0145\u0144"+
		"\3\2\2\2\u0146\u0147\3\2\2\2\u0147\u0145\3\2\2\2\u0147\u0148\3\2\2\2\u0148"+
		"\u014c\3\2\2\2\u0149\u014b\t\4\2\2\u014a\u0149\3\2\2\2\u014b\u014e\3\2"+
		"\2\2\u014c\u014a\3\2\2\2\u014c\u014d\3\2\2\2\u014dL\3\2\2\2\u014e\u014c"+
		"\3\2\2\2\u014f\u0153\7$\2\2\u0150\u0152\13\2\2\2\u0151\u0150\3\2\2\2\u0152"+
		"\u0155\3\2\2\2\u0153\u0154\3\2\2\2\u0153\u0151\3\2\2\2\u0154\u0156\3\2"+
		"\2\2\u0155\u0153\3\2\2\2\u0156\u0157\7$\2\2\u0157N\3\2\2\2\u0158\u015a"+
		"\t\5\2\2\u0159\u0158\3\2\2\2\u015a\u015b\3\2\2\2\u015b\u0159\3\2\2\2\u015b"+
		"\u015c\3\2\2\2\u015c\u015d\3\2\2\2\u015d\u015e\b(\2\2\u015eP\3\2\2\2\25"+
		"\2t{\u008f\u009d\u00ae\u00c5\u00d9\u00ed\u0101\u0115\u0134\u0136\u013b"+
		"\u0141\u0147\u014c\u0153\u015b\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}