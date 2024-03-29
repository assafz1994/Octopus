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
		T__9=10, T__10=11, EQUALS=12, COMPARATOR=13, SELECT=14, FROM=15, WHERE=16, 
		INCLUDE=17, ENTITY=18, INSERT=19, DELETE=20, UPDATE=21, PIPELINE=22, COLON=23, 
		ISEQUALS=24, GT=25, GTE=26, LT=27, LTE=28, ADD=29, REMOVE=30, WORD=31, 
		NUMBER=32, ENT=33, ENTREP=34, TEXT=35, WHITESPACE=36;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "EQUALS", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", 
			"ENTITY", "INSERT", "DELETE", "UPDATE", "PIPELINE", "COLON", "ISEQUALS", 
			"GT", "GTE", "LT", "LTE", "ADD", "REMOVE", "LOWERCASE", "UPPERCASE", 
			"WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'('", "')'", "','", "'.'", "'['", "']'", "'AVG'", "'SUM'", "'MIN'", 
			"'MAX'", "'*'", "'='", null, null, null, null, null, null, null, null, 
			null, "'|'", "':'", "'=='", "'>'", "'>='", "'<'", "'<='", "'+='", "'-='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"EQUALS", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", "ENTITY", 
			"INSERT", "DELETE", "UPDATE", "PIPELINE", "COLON", "ISEQUALS", "GT", 
			"GTE", "LT", "LTE", "ADD", "REMOVE", "WORD", "NUMBER", "ENT", "ENTREP", 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2&\u0158\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\3\2\3\2\3\3\3\3\3\4\3\4\3"+
		"\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n"+
		"\3\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\16\3\16\3\16\5\16u\n"+
		"\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3"+
		"\17\3\17\3\17\3\17\3\17\5\17\u0089\n\17\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u0097\n\20\3\21\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00a8\n\21\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\5\22\u00bf\n\22\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23"+
		"\u00d3\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u00e7\n\24\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25"+
		"\u00fb\n\25\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\5\26\u010f\n\26\3\27\3\27\3\30\3\30\3\31"+
		"\3\31\3\31\3\32\3\32\3\33\3\33\3\33\3\34\3\34\3\35\3\35\3\35\3\36\3\36"+
		"\3\36\3\37\3\37\3\37\3 \3 \3!\3!\3\"\3\"\6\"\u012e\n\"\r\"\16\"\u012f"+
		"\3#\6#\u0133\n#\r#\16#\u0134\3$\3$\7$\u0139\n$\f$\16$\u013c\13$\3%\6%"+
		"\u013f\n%\r%\16%\u0140\3%\7%\u0144\n%\f%\16%\u0147\13%\3&\3&\7&\u014b"+
		"\n&\f&\16&\u014e\13&\3&\3&\3\'\6\'\u0153\n\'\r\'\16\'\u0154\3\'\3\'\3"+
		"\u014c\2(\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33"+
		"\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67"+
		"\359\36;\37= ?\2A\2C!E\"G#I$K%M&\3\2\6\3\2c|\3\2C\\\3\2\62;\5\2\13\f\17"+
		"\17\"\"\2\u0171\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3"+
		"\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2"+
		"\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3"+
		"\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2"+
		"\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\2"+
		"9\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3"+
		"\2\2\2\2K\3\2\2\2\2M\3\2\2\2\3O\3\2\2\2\5Q\3\2\2\2\7S\3\2\2\2\tU\3\2\2"+
		"\2\13W\3\2\2\2\rY\3\2\2\2\17[\3\2\2\2\21_\3\2\2\2\23c\3\2\2\2\25g\3\2"+
		"\2\2\27k\3\2\2\2\31m\3\2\2\2\33t\3\2\2\2\35\u0088\3\2\2\2\37\u0096\3\2"+
		"\2\2!\u00a7\3\2\2\2#\u00be\3\2\2\2%\u00d2\3\2\2\2\'\u00e6\3\2\2\2)\u00fa"+
		"\3\2\2\2+\u010e\3\2\2\2-\u0110\3\2\2\2/\u0112\3\2\2\2\61\u0114\3\2\2\2"+
		"\63\u0117\3\2\2\2\65\u0119\3\2\2\2\67\u011c\3\2\2\29\u011e\3\2\2\2;\u0121"+
		"\3\2\2\2=\u0124\3\2\2\2?\u0127\3\2\2\2A\u0129\3\2\2\2C\u012d\3\2\2\2E"+
		"\u0132\3\2\2\2G\u0136\3\2\2\2I\u013e\3\2\2\2K\u0148\3\2\2\2M\u0152\3\2"+
		"\2\2OP\7*\2\2P\4\3\2\2\2QR\7+\2\2R\6\3\2\2\2ST\7.\2\2T\b\3\2\2\2UV\7\60"+
		"\2\2V\n\3\2\2\2WX\7]\2\2X\f\3\2\2\2YZ\7_\2\2Z\16\3\2\2\2[\\\7C\2\2\\]"+
		"\7X\2\2]^\7I\2\2^\20\3\2\2\2_`\7U\2\2`a\7W\2\2ab\7O\2\2b\22\3\2\2\2cd"+
		"\7O\2\2de\7K\2\2ef\7P\2\2f\24\3\2\2\2gh\7O\2\2hi\7C\2\2ij\7Z\2\2j\26\3"+
		"\2\2\2kl\7,\2\2l\30\3\2\2\2mn\7?\2\2n\32\3\2\2\2ou\5\61\31\2pu\5\63\32"+
		"\2qu\5\65\33\2ru\5\67\34\2su\59\35\2to\3\2\2\2tp\3\2\2\2tq\3\2\2\2tr\3"+
		"\2\2\2ts\3\2\2\2u\34\3\2\2\2vw\7u\2\2wx\7g\2\2xy\7n\2\2yz\7g\2\2z{\7e"+
		"\2\2{\u0089\7v\2\2|}\7U\2\2}~\7G\2\2~\177\7N\2\2\177\u0080\7G\2\2\u0080"+
		"\u0081\7E\2\2\u0081\u0089\7V\2\2\u0082\u0083\7U\2\2\u0083\u0084\7g\2\2"+
		"\u0084\u0085\7n\2\2\u0085\u0086\7g\2\2\u0086\u0087\7e\2\2\u0087\u0089"+
		"\7v\2\2\u0088v\3\2\2\2\u0088|\3\2\2\2\u0088\u0082\3\2\2\2\u0089\36\3\2"+
		"\2\2\u008a\u008b\7h\2\2\u008b\u008c\7t\2\2\u008c\u008d\7q\2\2\u008d\u0097"+
		"\7o\2\2\u008e\u008f\7H\2\2\u008f\u0090\7T\2\2\u0090\u0091\7Q\2\2\u0091"+
		"\u0097\7O\2\2\u0092\u0093\7H\2\2\u0093\u0094\7t\2\2\u0094\u0095\7q\2\2"+
		"\u0095\u0097\7o\2\2\u0096\u008a\3\2\2\2\u0096\u008e\3\2\2\2\u0096\u0092"+
		"\3\2\2\2\u0097 \3\2\2\2\u0098\u0099\7y\2\2\u0099\u009a\7j\2\2\u009a\u009b"+
		"\7g\2\2\u009b\u009c\7t\2\2\u009c\u00a8\7g\2\2\u009d\u009e\7Y\2\2\u009e"+
		"\u009f\7J\2\2\u009f\u00a0\7G\2\2\u00a0\u00a1\7T\2\2\u00a1\u00a8\7G\2\2"+
		"\u00a2\u00a3\7Y\2\2\u00a3\u00a4\7j\2\2\u00a4\u00a5\7g\2\2\u00a5\u00a6"+
		"\7t\2\2\u00a6\u00a8\7g\2\2\u00a7\u0098\3\2\2\2\u00a7\u009d\3\2\2\2\u00a7"+
		"\u00a2\3\2\2\2\u00a8\"\3\2\2\2\u00a9\u00aa\7k\2\2\u00aa\u00ab\7p\2\2\u00ab"+
		"\u00ac\7e\2\2\u00ac\u00ad\7n\2\2\u00ad\u00ae\7w\2\2\u00ae\u00af\7f\2\2"+
		"\u00af\u00bf\7g\2\2\u00b0\u00b1\7K\2\2\u00b1\u00b2\7P\2\2\u00b2\u00b3"+
		"\7E\2\2\u00b3\u00b4\7N\2\2\u00b4\u00b5\7W\2\2\u00b5\u00b6\7F\2\2\u00b6"+
		"\u00bf\7G\2\2\u00b7\u00b8\7K\2\2\u00b8\u00b9\7p\2\2\u00b9\u00ba\7e\2\2"+
		"\u00ba\u00bb\7n\2\2\u00bb\u00bc\7w\2\2\u00bc\u00bd\7f\2\2\u00bd\u00bf"+
		"\7g\2\2\u00be\u00a9\3\2\2\2\u00be\u00b0\3\2\2\2\u00be\u00b7\3\2\2\2\u00bf"+
		"$\3\2\2\2\u00c0\u00c1\7g\2\2\u00c1\u00c2\7p\2\2\u00c2\u00c3\7v\2\2\u00c3"+
		"\u00c4\7k\2\2\u00c4\u00c5\7v\2\2\u00c5\u00d3\7{\2\2\u00c6\u00c7\7G\2\2"+
		"\u00c7\u00c8\7P\2\2\u00c8\u00c9\7V\2\2\u00c9\u00ca\7K\2\2\u00ca\u00cb"+
		"\7V\2\2\u00cb\u00d3\7[\2\2\u00cc\u00cd\7G\2\2\u00cd\u00ce\7p\2\2\u00ce"+
		"\u00cf\7v\2\2\u00cf\u00d0\7k\2\2\u00d0\u00d1\7v\2\2\u00d1\u00d3\7{\2\2"+
		"\u00d2\u00c0\3\2\2\2\u00d2\u00c6\3\2\2\2\u00d2\u00cc\3\2\2\2\u00d3&\3"+
		"\2\2\2\u00d4\u00d5\7k\2\2\u00d5\u00d6\7p\2\2\u00d6\u00d7\7u\2\2\u00d7"+
		"\u00d8\7g\2\2\u00d8\u00d9\7t\2\2\u00d9\u00e7\7v\2\2\u00da\u00db\7K\2\2"+
		"\u00db\u00dc\7P\2\2\u00dc\u00dd\7U\2\2\u00dd\u00de\7G\2\2\u00de\u00df"+
		"\7T\2\2\u00df\u00e7\7V\2\2\u00e0\u00e1\7K\2\2\u00e1\u00e2\7p\2\2\u00e2"+
		"\u00e3\7u\2\2\u00e3\u00e4\7g\2\2\u00e4\u00e5\7t\2\2\u00e5\u00e7\7v\2\2"+
		"\u00e6\u00d4\3\2\2\2\u00e6\u00da\3\2\2\2\u00e6\u00e0\3\2\2\2\u00e7(\3"+
		"\2\2\2\u00e8\u00e9\7f\2\2\u00e9\u00ea\7g\2\2\u00ea\u00eb\7n\2\2\u00eb"+
		"\u00ec\7g\2\2\u00ec\u00ed\7v\2\2\u00ed\u00fb\7g\2\2\u00ee\u00ef\7F\2\2"+
		"\u00ef\u00f0\7G\2\2\u00f0\u00f1\7N\2\2\u00f1\u00f2\7G\2\2\u00f2\u00f3"+
		"\7V\2\2\u00f3\u00fb\7G\2\2\u00f4\u00f5\7F\2\2\u00f5\u00f6\7g\2\2\u00f6"+
		"\u00f7\7n\2\2\u00f7\u00f8\7g\2\2\u00f8\u00f9\7v\2\2\u00f9\u00fb\7g\2\2"+
		"\u00fa\u00e8\3\2\2\2\u00fa\u00ee\3\2\2\2\u00fa\u00f4\3\2\2\2\u00fb*\3"+
		"\2\2\2\u00fc\u00fd\7w\2\2\u00fd\u00fe\7r\2\2\u00fe\u00ff\7f\2\2\u00ff"+
		"\u0100\7c\2\2\u0100\u0101\7v\2\2\u0101\u010f\7g\2\2\u0102\u0103\7W\2\2"+
		"\u0103\u0104\7R\2\2\u0104\u0105\7F\2\2\u0105\u0106\7C\2\2\u0106\u0107"+
		"\7V\2\2\u0107\u010f\7G\2\2\u0108\u0109\7W\2\2\u0109\u010a\7r\2\2\u010a"+
		"\u010b\7f\2\2\u010b\u010c\7c\2\2\u010c\u010d\7v\2\2\u010d\u010f\7g\2\2"+
		"\u010e\u00fc\3\2\2\2\u010e\u0102\3\2\2\2\u010e\u0108\3\2\2\2\u010f,\3"+
		"\2\2\2\u0110\u0111\7~\2\2\u0111.\3\2\2\2\u0112\u0113\7<\2\2\u0113\60\3"+
		"\2\2\2\u0114\u0115\7?\2\2\u0115\u0116\7?\2\2\u0116\62\3\2\2\2\u0117\u0118"+
		"\7@\2\2\u0118\64\3\2\2\2\u0119\u011a\7@\2\2\u011a\u011b\7?\2\2\u011b\66"+
		"\3\2\2\2\u011c\u011d\7>\2\2\u011d8\3\2\2\2\u011e\u011f\7>\2\2\u011f\u0120"+
		"\7?\2\2\u0120:\3\2\2\2\u0121\u0122\7-\2\2\u0122\u0123\7?\2\2\u0123<\3"+
		"\2\2\2\u0124\u0125\7/\2\2\u0125\u0126\7?\2\2\u0126>\3\2\2\2\u0127\u0128"+
		"\t\2\2\2\u0128@\3\2\2\2\u0129\u012a\t\3\2\2\u012aB\3\2\2\2\u012b\u012e"+
		"\5? \2\u012c\u012e\5A!\2\u012d\u012b\3\2\2\2\u012d\u012c\3\2\2\2\u012e"+
		"\u012f\3\2\2\2\u012f\u012d\3\2\2\2\u012f\u0130\3\2\2\2\u0130D\3\2\2\2"+
		"\u0131\u0133\t\4\2\2\u0132\u0131\3\2\2\2\u0133\u0134\3\2\2\2\u0134\u0132"+
		"\3\2\2\2\u0134\u0135\3\2\2\2\u0135F\3\2\2\2\u0136\u013a\t\3\2\2\u0137"+
		"\u0139\t\2\2\2\u0138\u0137\3\2\2\2\u0139\u013c\3\2\2\2\u013a\u0138\3\2"+
		"\2\2\u013a\u013b\3\2\2\2\u013bH\3\2\2\2\u013c\u013a\3\2\2\2\u013d\u013f"+
		"\t\2\2\2\u013e\u013d\3\2\2\2\u013f\u0140\3\2\2\2\u0140\u013e\3\2\2\2\u0140"+
		"\u0141\3\2\2\2\u0141\u0145\3\2\2\2\u0142\u0144\t\4\2\2\u0143\u0142\3\2"+
		"\2\2\u0144\u0147\3\2\2\2\u0145\u0143\3\2\2\2\u0145\u0146\3\2\2\2\u0146"+
		"J\3\2\2\2\u0147\u0145\3\2\2\2\u0148\u014c\7$\2\2\u0149\u014b\13\2\2\2"+
		"\u014a\u0149\3\2\2\2\u014b\u014e\3\2\2\2\u014c\u014d\3\2\2\2\u014c\u014a"+
		"\3\2\2\2\u014d\u014f\3\2\2\2\u014e\u014c\3\2\2\2\u014f\u0150\7$\2\2\u0150"+
		"L\3\2\2\2\u0151\u0153\t\5\2\2\u0152\u0151\3\2\2\2\u0153\u0154\3\2\2\2"+
		"\u0154\u0152\3\2\2\2\u0154\u0155\3\2\2\2\u0155\u0156\3\2\2\2\u0156\u0157"+
		"\b\'\2\2\u0157N\3\2\2\2\24\2t\u0088\u0096\u00a7\u00be\u00d2\u00e6\u00fa"+
		"\u010e\u012d\u012f\u0134\u013a\u0140\u0145\u014c\u0154\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}