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
		ENTITY=17, INSERT=18, PIPELINE=19, COLON=20, ISEQUALS=21, EQUALS=22, GT=23, 
		GTE=24, LT=25, LTE=26, WORD=27, NUMBER=28, ENT=29, ENTREP=30, TEXT=31, 
		WHITESPACE=32;
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
			"ENTITY", "INSERT", "PIPELINE", "COLON", "ISEQUALS", "EQUALS", "GT", 
			"GTE", "LT", "LTE", "A", "C", "S", "Y", "H", "O", "U", "T", "F", "R", 
			"M", "W", "E", "LOWERCASE", "UPPERCASE", "WORD", "NUMBER", "ENT", "ENTREP", 
			"TEXT", "WHITESPACE"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\"\u0156\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3"+
		"\6\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\13\3\13\3"+
		"\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\5\r\u0085\n\r\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\5\16\u0099\n\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\5\17\u00a7\n\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\5\20\u00b8\n\20\3\21\3\21\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21"+
		"\3\21\5\21\u00cf\n\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\5\22\u00e3\n\22\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\5\23\u00f7\n\23\3\24\3\24\3\25\3\25\3\26\3\26\3\26\3\27\3\27\3\30"+
		"\3\30\3\31\3\31\3\31\3\32\3\32\3\33\3\33\3\33\3\34\3\34\3\35\3\35\3\36"+
		"\3\36\3\37\3\37\3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3"+
		"(\3(\3)\3)\3*\3*\3+\3+\6+\u012c\n+\r+\16+\u012d\3,\6,\u0131\n,\r,\16,"+
		"\u0132\3-\3-\7-\u0137\n-\f-\16-\u013a\13-\3.\6.\u013d\n.\r.\16.\u013e"+
		"\3.\7.\u0142\n.\f.\16.\u0145\13.\3/\3/\7/\u0149\n/\f/\16/\u014c\13/\3"+
		"/\3/\3\60\6\60\u0151\n\60\r\60\16\60\u0152\3\60\3\60\3\u014a\2\61\3\3"+
		"\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21"+
		"!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\29\2;\2=\2?\2A"+
		"\2C\2E\2G\2I\2K\2M\2O\2Q\2S\2U\35W\36Y\37[ ]!_\"\3\2\23\4\2CCcc\4\2EE"+
		"ee\4\2UUuu\4\2[[{{\4\2JJjj\4\2QQqq\4\2WWww\4\2VVvv\4\2HHhh\4\2TTtt\4\2"+
		"OOoo\4\2YYyy\4\2GGgg\3\2c|\3\2C\\\3\2\62;\5\2\13\f\17\17\"\"\2\u015e\2"+
		"\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2"+
		"\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2"+
		"\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2"+
		"\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2"+
		"\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2"+
		"\2\2[\3\2\2\2\2]\3\2\2\2\2_\3\2\2\2\3a\3\2\2\2\5c\3\2\2\2\7e\3\2\2\2\t"+
		"g\3\2\2\2\13i\3\2\2\2\rk\3\2\2\2\17m\3\2\2\2\21q\3\2\2\2\23u\3\2\2\2\25"+
		"y\3\2\2\2\27}\3\2\2\2\31\u0084\3\2\2\2\33\u0098\3\2\2\2\35\u00a6\3\2\2"+
		"\2\37\u00b7\3\2\2\2!\u00ce\3\2\2\2#\u00e2\3\2\2\2%\u00f6\3\2\2\2\'\u00f8"+
		"\3\2\2\2)\u00fa\3\2\2\2+\u00fc\3\2\2\2-\u00ff\3\2\2\2/\u0101\3\2\2\2\61"+
		"\u0103\3\2\2\2\63\u0106\3\2\2\2\65\u0108\3\2\2\2\67\u010b\3\2\2\29\u010d"+
		"\3\2\2\2;\u010f\3\2\2\2=\u0111\3\2\2\2?\u0113\3\2\2\2A\u0115\3\2\2\2C"+
		"\u0117\3\2\2\2E\u0119\3\2\2\2G\u011b\3\2\2\2I\u011d\3\2\2\2K\u011f\3\2"+
		"\2\2M\u0121\3\2\2\2O\u0123\3\2\2\2Q\u0125\3\2\2\2S\u0127\3\2\2\2U\u012b"+
		"\3\2\2\2W\u0130\3\2\2\2Y\u0134\3\2\2\2[\u013c\3\2\2\2]\u0146\3\2\2\2_"+
		"\u0150\3\2\2\2ab\7*\2\2b\4\3\2\2\2cd\7+\2\2d\6\3\2\2\2ef\7.\2\2f\b\3\2"+
		"\2\2gh\7\60\2\2h\n\3\2\2\2ij\7]\2\2j\f\3\2\2\2kl\7_\2\2l\16\3\2\2\2mn"+
		"\7C\2\2no\7X\2\2op\7I\2\2p\20\3\2\2\2qr\7U\2\2rs\7W\2\2st\7O\2\2t\22\3"+
		"\2\2\2uv\7O\2\2vw\7K\2\2wx\7P\2\2x\24\3\2\2\2yz\7O\2\2z{\7C\2\2{|\7Z\2"+
		"\2|\26\3\2\2\2}~\7,\2\2~\30\3\2\2\2\177\u0085\5+\26\2\u0080\u0085\5/\30"+
		"\2\u0081\u0085\5\61\31\2\u0082\u0085\5\63\32\2\u0083\u0085\5\65\33\2\u0084"+
		"\177\3\2\2\2\u0084\u0080\3\2\2\2\u0084\u0081\3\2\2\2\u0084\u0082\3\2\2"+
		"\2\u0084\u0083\3\2\2\2\u0085\32\3\2\2\2\u0086\u0087\7u\2\2\u0087\u0088"+
		"\7g\2\2\u0088\u0089\7n\2\2\u0089\u008a\7g\2\2\u008a\u008b\7e\2\2\u008b"+
		"\u0099\7v\2\2\u008c\u008d\7U\2\2\u008d\u008e\7G\2\2\u008e\u008f\7N\2\2"+
		"\u008f\u0090\7G\2\2\u0090\u0091\7E\2\2\u0091\u0099\7V\2\2\u0092\u0093"+
		"\7U\2\2\u0093\u0094\7g\2\2\u0094\u0095\7n\2\2\u0095\u0096\7g\2\2\u0096"+
		"\u0097\7e\2\2\u0097\u0099\7v\2\2\u0098\u0086\3\2\2\2\u0098\u008c\3\2\2"+
		"\2\u0098\u0092\3\2\2\2\u0099\34\3\2\2\2\u009a\u009b\7h\2\2\u009b\u009c"+
		"\7t\2\2\u009c\u009d\7q\2\2\u009d\u00a7\7o\2\2\u009e\u009f\7H\2\2\u009f"+
		"\u00a0\7T\2\2\u00a0\u00a1\7Q\2\2\u00a1\u00a7\7O\2\2\u00a2\u00a3\7H\2\2"+
		"\u00a3\u00a4\7t\2\2\u00a4\u00a5\7q\2\2\u00a5\u00a7\7o\2\2\u00a6\u009a"+
		"\3\2\2\2\u00a6\u009e\3\2\2\2\u00a6\u00a2\3\2\2\2\u00a7\36\3\2\2\2\u00a8"+
		"\u00a9\7y\2\2\u00a9\u00aa\7j\2\2\u00aa\u00ab\7g\2\2\u00ab\u00ac\7t\2\2"+
		"\u00ac\u00b8\7g\2\2\u00ad\u00ae\7Y\2\2\u00ae\u00af\7J\2\2\u00af\u00b0"+
		"\7G\2\2\u00b0\u00b1\7T\2\2\u00b1\u00b8\7G\2\2\u00b2\u00b3\7Y\2\2\u00b3"+
		"\u00b4\7j\2\2\u00b4\u00b5\7g\2\2\u00b5\u00b6\7t\2\2\u00b6\u00b8\7g\2\2"+
		"\u00b7\u00a8\3\2\2\2\u00b7\u00ad\3\2\2\2\u00b7\u00b2\3\2\2\2\u00b8 \3"+
		"\2\2\2\u00b9\u00ba\7k\2\2\u00ba\u00bb\7p\2\2\u00bb\u00bc\7e\2\2\u00bc"+
		"\u00bd\7n\2\2\u00bd\u00be\7w\2\2\u00be\u00bf\7f\2\2\u00bf\u00cf\7g\2\2"+
		"\u00c0\u00c1\7K\2\2\u00c1\u00c2\7P\2\2\u00c2\u00c3\7E\2\2\u00c3\u00c4"+
		"\7N\2\2\u00c4\u00c5\7W\2\2\u00c5\u00c6\7F\2\2\u00c6\u00cf\7G\2\2\u00c7"+
		"\u00c8\7K\2\2\u00c8\u00c9\7p\2\2\u00c9\u00ca\7e\2\2\u00ca\u00cb\7n\2\2"+
		"\u00cb\u00cc\7w\2\2\u00cc\u00cd\7f\2\2\u00cd\u00cf\7g\2\2\u00ce\u00b9"+
		"\3\2\2\2\u00ce\u00c0\3\2\2\2\u00ce\u00c7\3\2\2\2\u00cf\"\3\2\2\2\u00d0"+
		"\u00d1\7g\2\2\u00d1\u00d2\7p\2\2\u00d2\u00d3\7v\2\2\u00d3\u00d4\7k\2\2"+
		"\u00d4\u00d5\7v\2\2\u00d5\u00e3\7{\2\2\u00d6\u00d7\7G\2\2\u00d7\u00d8"+
		"\7P\2\2\u00d8\u00d9\7V\2\2\u00d9\u00da\7K\2\2\u00da\u00db\7V\2\2\u00db"+
		"\u00e3\7[\2\2\u00dc\u00dd\7G\2\2\u00dd\u00de\7p\2\2\u00de\u00df\7v\2\2"+
		"\u00df\u00e0\7k\2\2\u00e0\u00e1\7v\2\2\u00e1\u00e3\7{\2\2\u00e2\u00d0"+
		"\3\2\2\2\u00e2\u00d6\3\2\2\2\u00e2\u00dc\3\2\2\2\u00e3$\3\2\2\2\u00e4"+
		"\u00e5\7k\2\2\u00e5\u00e6\7p\2\2\u00e6\u00e7\7u\2\2\u00e7\u00e8\7g\2\2"+
		"\u00e8\u00e9\7t\2\2\u00e9\u00f7\7v\2\2\u00ea\u00eb\7K\2\2\u00eb\u00ec"+
		"\7P\2\2\u00ec\u00ed\7U\2\2\u00ed\u00ee\7G\2\2\u00ee\u00ef\7T\2\2\u00ef"+
		"\u00f7\7V\2\2\u00f0\u00f1\7K\2\2\u00f1\u00f2\7p\2\2\u00f2\u00f3\7u\2\2"+
		"\u00f3\u00f4\7g\2\2\u00f4\u00f5\7t\2\2\u00f5\u00f7\7v\2\2\u00f6\u00e4"+
		"\3\2\2\2\u00f6\u00ea\3\2\2\2\u00f6\u00f0\3\2\2\2\u00f7&\3\2\2\2\u00f8"+
		"\u00f9\7~\2\2\u00f9(\3\2\2\2\u00fa\u00fb\7<\2\2\u00fb*\3\2\2\2\u00fc\u00fd"+
		"\7?\2\2\u00fd\u00fe\7?\2\2\u00fe,\3\2\2\2\u00ff\u0100\7?\2\2\u0100.\3"+
		"\2\2\2\u0101\u0102\7@\2\2\u0102\60\3\2\2\2\u0103\u0104\7@\2\2\u0104\u0105"+
		"\7?\2\2\u0105\62\3\2\2\2\u0106\u0107\7>\2\2\u0107\64\3\2\2\2\u0108\u0109"+
		"\7>\2\2\u0109\u010a\7?\2\2\u010a\66\3\2\2\2\u010b\u010c\t\2\2\2\u010c"+
		"8\3\2\2\2\u010d\u010e\t\3\2\2\u010e:\3\2\2\2\u010f\u0110\t\4\2\2\u0110"+
		"<\3\2\2\2\u0111\u0112\t\5\2\2\u0112>\3\2\2\2\u0113\u0114\t\6\2\2\u0114"+
		"@\3\2\2\2\u0115\u0116\t\7\2\2\u0116B\3\2\2\2\u0117\u0118\t\b\2\2\u0118"+
		"D\3\2\2\2\u0119\u011a\t\t\2\2\u011aF\3\2\2\2\u011b\u011c\t\n\2\2\u011c"+
		"H\3\2\2\2\u011d\u011e\t\13\2\2\u011eJ\3\2\2\2\u011f\u0120\t\f\2\2\u0120"+
		"L\3\2\2\2\u0121\u0122\t\r\2\2\u0122N\3\2\2\2\u0123\u0124\t\16\2\2\u0124"+
		"P\3\2\2\2\u0125\u0126\t\17\2\2\u0126R\3\2\2\2\u0127\u0128\t\20\2\2\u0128"+
		"T\3\2\2\2\u0129\u012c\5Q)\2\u012a\u012c\5S*\2\u012b\u0129\3\2\2\2\u012b"+
		"\u012a\3\2\2\2\u012c\u012d\3\2\2\2\u012d\u012b\3\2\2\2\u012d\u012e\3\2"+
		"\2\2\u012eV\3\2\2\2\u012f\u0131\t\21\2\2\u0130\u012f\3\2\2\2\u0131\u0132"+
		"\3\2\2\2\u0132\u0130\3\2\2\2\u0132\u0133\3\2\2\2\u0133X\3\2\2\2\u0134"+
		"\u0138\t\20\2\2\u0135\u0137\t\17\2\2\u0136\u0135\3\2\2\2\u0137\u013a\3"+
		"\2\2\2\u0138\u0136\3\2\2\2\u0138\u0139\3\2\2\2\u0139Z\3\2\2\2\u013a\u0138"+
		"\3\2\2\2\u013b\u013d\t\17\2\2\u013c\u013b\3\2\2\2\u013d\u013e\3\2\2\2"+
		"\u013e\u013c\3\2\2\2\u013e\u013f\3\2\2\2\u013f\u0143\3\2\2\2\u0140\u0142"+
		"\t\21\2\2\u0141\u0140\3\2\2\2\u0142\u0145\3\2\2\2\u0143\u0141\3\2\2\2"+
		"\u0143\u0144\3\2\2\2\u0144\\\3\2\2\2\u0145\u0143\3\2\2\2\u0146\u014a\7"+
		"$\2\2\u0147\u0149\13\2\2\2\u0148\u0147\3\2\2\2\u0149\u014c\3\2\2\2\u014a"+
		"\u014b\3\2\2\2\u014a\u0148\3\2\2\2\u014b\u014d\3\2\2\2\u014c\u014a\3\2"+
		"\2\2\u014d\u014e\7$\2\2\u014e^\3\2\2\2\u014f\u0151\t\22\2\2\u0150\u014f"+
		"\3\2\2\2\u0151\u0152\3\2\2\2\u0152\u0150\3\2\2\2\u0152\u0153\3\2\2\2\u0153"+
		"\u0154\3\2\2\2\u0154\u0155\b\60\2\2\u0155`\3\2\2\2\22\2\u0084\u0098\u00a6"+
		"\u00b7\u00ce\u00e2\u00f6\u012b\u012d\u0132\u0138\u013e\u0143\u014a\u0152"+
		"\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}