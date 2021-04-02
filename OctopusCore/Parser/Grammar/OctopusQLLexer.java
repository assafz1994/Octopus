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
		T__9=10, T__10=11, ENTITY=12, EQUALS=13, COMPARATOR=14, SELECT=15, FROM=16, 
		WHERE=17, INCLUDE=18, INSERT=19, DELETE=20, UPDATE=21, ASSIGN=22, PIPELINE=23, 
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
			"T__9", "T__10", "ENTITY", "EQUALS", "COMPARATOR", "SELECT", "FROM", 
			"WHERE", "INCLUDE", "INSERT", "DELETE", "UPDATE", "ASSIGN", "PIPELINE", 
			"COLON", "ISEQUALS", "GT", "GTE", "LT", "LTE", "ADD", "REMOVE", "LOWERCASE", 
			"UPPERCASE", "WORD", "NUMBER", "ENT", "ENTREP", "TEXT", "WHITESPACE"
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
			"ENTITY", "EQUALS", "COMPARATOR", "SELECT", "FROM", "WHERE", "INCLUDE", 
			"INSERT", "DELETE", "UPDATE", "ASSIGN", "PIPELINE", "COLON", "ISEQUALS", 
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
		"\n\3\n\3\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r"+
		"\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u0082\n\r\3\16\3\16\3\17\3\17"+
		"\3\17\3\17\3\17\5\17\u008b\n\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u009f\n\20\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\5\21\u00ad\n\21"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\5\22\u00be\n\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\5\23\u00d5\n\23"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\5\24\u00e9\n\24\3\25\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\5\25\u00fd\n\25"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\5\26\u0111\n\26\3\27\3\27\3\27\5\27\u0116\n\27\3"+
		"\30\3\30\3\31\3\31\3\32\3\32\3\32\3\33\3\33\3\34\3\34\3\34\3\35\3\35\3"+
		"\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3 \3!\3!\3\"\3\"\3#\3#\6#\u0135\n#"+
		"\r#\16#\u0136\3$\6$\u013a\n$\r$\16$\u013b\3%\3%\7%\u0140\n%\f%\16%\u0143"+
		"\13%\3&\6&\u0146\n&\r&\16&\u0147\3&\7&\u014b\n&\f&\16&\u014e\13&\3\'\3"+
		"\'\7\'\u0152\n\'\f\'\16\'\u0155\13\'\3\'\3\'\3(\6(\u015a\n(\r(\16(\u015b"+
		"\3(\3(\3\u0153\2)\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31"+
		"\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65"+
		"\34\67\359\36;\37= ?!A\2C\2E\"G#I$K%M&O\'\3\2\6\3\2c|\3\2C\\\3\2\62;\5"+
		"\2\13\f\17\17\"\"\2\u017a\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2"+
		"\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2"+
		"\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3"+
		"\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2"+
		"\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67"+
		"\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2E\3\2\2\2\2G\3\2"+
		"\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2\3Q\3\2\2\2\5S\3\2\2\2"+
		"\7U\3\2\2\2\tW\3\2\2\2\13Y\3\2\2\2\r[\3\2\2\2\17]\3\2\2\2\21a\3\2\2\2"+
		"\23e\3\2\2\2\25i\3\2\2\2\27m\3\2\2\2\31\u0081\3\2\2\2\33\u0083\3\2\2\2"+
		"\35\u008a\3\2\2\2\37\u009e\3\2\2\2!\u00ac\3\2\2\2#\u00bd\3\2\2\2%\u00d4"+
		"\3\2\2\2\'\u00e8\3\2\2\2)\u00fc\3\2\2\2+\u0110\3\2\2\2-\u0115\3\2\2\2"+
		"/\u0117\3\2\2\2\61\u0119\3\2\2\2\63\u011b\3\2\2\2\65\u011e\3\2\2\2\67"+
		"\u0120\3\2\2\29\u0123\3\2\2\2;\u0125\3\2\2\2=\u0128\3\2\2\2?\u012b\3\2"+
		"\2\2A\u012e\3\2\2\2C\u0130\3\2\2\2E\u0134\3\2\2\2G\u0139\3\2\2\2I\u013d"+
		"\3\2\2\2K\u0145\3\2\2\2M\u014f\3\2\2\2O\u0159\3\2\2\2QR\7*\2\2R\4\3\2"+
		"\2\2ST\7+\2\2T\6\3\2\2\2UV\7.\2\2V\b\3\2\2\2WX\7\60\2\2X\n\3\2\2\2YZ\7"+
		"]\2\2Z\f\3\2\2\2[\\\7_\2\2\\\16\3\2\2\2]^\7C\2\2^_\7X\2\2_`\7I\2\2`\20"+
		"\3\2\2\2ab\7U\2\2bc\7W\2\2cd\7O\2\2d\22\3\2\2\2ef\7O\2\2fg\7K\2\2gh\7"+
		"P\2\2h\24\3\2\2\2ij\7O\2\2jk\7C\2\2kl\7Z\2\2l\26\3\2\2\2mn\7,\2\2n\30"+
		"\3\2\2\2op\7g\2\2pq\7p\2\2qr\7v\2\2rs\7k\2\2st\7v\2\2t\u0082\7{\2\2uv"+
		"\7G\2\2vw\7P\2\2wx\7V\2\2xy\7K\2\2yz\7V\2\2z\u0082\7[\2\2{|\7G\2\2|}\7"+
		"p\2\2}~\7v\2\2~\177\7k\2\2\177\u0080\7v\2\2\u0080\u0082\7{\2\2\u0081o"+
		"\3\2\2\2\u0081u\3\2\2\2\u0081{\3\2\2\2\u0082\32\3\2\2\2\u0083\u0084\7"+
		"?\2\2\u0084\34\3\2\2\2\u0085\u008b\5\63\32\2\u0086\u008b\5\65\33\2\u0087"+
		"\u008b\5\67\34\2\u0088\u008b\59\35\2\u0089\u008b\5;\36\2\u008a\u0085\3"+
		"\2\2\2\u008a\u0086\3\2\2\2\u008a\u0087\3\2\2\2\u008a\u0088\3\2\2\2\u008a"+
		"\u0089\3\2\2\2\u008b\36\3\2\2\2\u008c\u008d\7u\2\2\u008d\u008e\7g\2\2"+
		"\u008e\u008f\7n\2\2\u008f\u0090\7g\2\2\u0090\u0091\7e\2\2\u0091\u009f"+
		"\7v\2\2\u0092\u0093\7U\2\2\u0093\u0094\7G\2\2\u0094\u0095\7N\2\2\u0095"+
		"\u0096\7G\2\2\u0096\u0097\7E\2\2\u0097\u009f\7V\2\2\u0098\u0099\7U\2\2"+
		"\u0099\u009a\7g\2\2\u009a\u009b\7n\2\2\u009b\u009c\7g\2\2\u009c\u009d"+
		"\7e\2\2\u009d\u009f\7v\2\2\u009e\u008c\3\2\2\2\u009e\u0092\3\2\2\2\u009e"+
		"\u0098\3\2\2\2\u009f \3\2\2\2\u00a0\u00a1\7h\2\2\u00a1\u00a2\7t\2\2\u00a2"+
		"\u00a3\7q\2\2\u00a3\u00ad\7o\2\2\u00a4\u00a5\7H\2\2\u00a5\u00a6\7T\2\2"+
		"\u00a6\u00a7\7Q\2\2\u00a7\u00ad\7O\2\2\u00a8\u00a9\7H\2\2\u00a9\u00aa"+
		"\7t\2\2\u00aa\u00ab\7q\2\2\u00ab\u00ad\7o\2\2\u00ac\u00a0\3\2\2\2\u00ac"+
		"\u00a4\3\2\2\2\u00ac\u00a8\3\2\2\2\u00ad\"\3\2\2\2\u00ae\u00af\7y\2\2"+
		"\u00af\u00b0\7j\2\2\u00b0\u00b1\7g\2\2\u00b1\u00b2\7t\2\2\u00b2\u00be"+
		"\7g\2\2\u00b3\u00b4\7Y\2\2\u00b4\u00b5\7J\2\2\u00b5\u00b6\7G\2\2\u00b6"+
		"\u00b7\7T\2\2\u00b7\u00be\7G\2\2\u00b8\u00b9\7Y\2\2\u00b9\u00ba\7j\2\2"+
		"\u00ba\u00bb\7g\2\2\u00bb\u00bc\7t\2\2\u00bc\u00be\7g\2\2\u00bd\u00ae"+
		"\3\2\2\2\u00bd\u00b3\3\2\2\2\u00bd\u00b8\3\2\2\2\u00be$\3\2\2\2\u00bf"+
		"\u00c0\7k\2\2\u00c0\u00c1\7p\2\2\u00c1\u00c2\7e\2\2\u00c2\u00c3\7n\2\2"+
		"\u00c3\u00c4\7w\2\2\u00c4\u00c5\7f\2\2\u00c5\u00d5\7g\2\2\u00c6\u00c7"+
		"\7K\2\2\u00c7\u00c8\7P\2\2\u00c8\u00c9\7E\2\2\u00c9\u00ca\7N\2\2\u00ca"+
		"\u00cb\7W\2\2\u00cb\u00cc\7F\2\2\u00cc\u00d5\7G\2\2\u00cd\u00ce\7K\2\2"+
		"\u00ce\u00cf\7p\2\2\u00cf\u00d0\7e\2\2\u00d0\u00d1\7n\2\2\u00d1\u00d2"+
		"\7w\2\2\u00d2\u00d3\7f\2\2\u00d3\u00d5\7g\2\2\u00d4\u00bf\3\2\2\2\u00d4"+
		"\u00c6\3\2\2\2\u00d4\u00cd\3\2\2\2\u00d5&\3\2\2\2\u00d6\u00d7\7k\2\2\u00d7"+
		"\u00d8\7p\2\2\u00d8\u00d9\7u\2\2\u00d9\u00da\7g\2\2\u00da\u00db\7t\2\2"+
		"\u00db\u00e9\7v\2\2\u00dc\u00dd\7K\2\2\u00dd\u00de\7P\2\2\u00de\u00df"+
		"\7U\2\2\u00df\u00e0\7G\2\2\u00e0\u00e1\7T\2\2\u00e1\u00e9\7V\2\2\u00e2"+
		"\u00e3\7K\2\2\u00e3\u00e4\7p\2\2\u00e4\u00e5\7u\2\2\u00e5\u00e6\7g\2\2"+
		"\u00e6\u00e7\7t\2\2\u00e7\u00e9\7v\2\2\u00e8\u00d6\3\2\2\2\u00e8\u00dc"+
		"\3\2\2\2\u00e8\u00e2\3\2\2\2\u00e9(\3\2\2\2\u00ea\u00eb\7f\2\2\u00eb\u00ec"+
		"\7g\2\2\u00ec\u00ed\7n\2\2\u00ed\u00ee\7g\2\2\u00ee\u00ef\7v\2\2\u00ef"+
		"\u00fd\7g\2\2\u00f0\u00f1\7F\2\2\u00f1\u00f2\7G\2\2\u00f2\u00f3\7N\2\2"+
		"\u00f3\u00f4\7G\2\2\u00f4\u00f5\7V\2\2\u00f5\u00fd\7G\2\2\u00f6\u00f7"+
		"\7F\2\2\u00f7\u00f8\7g\2\2\u00f8\u00f9\7n\2\2\u00f9\u00fa\7g\2\2\u00fa"+
		"\u00fb\7v\2\2\u00fb\u00fd\7g\2\2\u00fc\u00ea\3\2\2\2\u00fc\u00f0\3\2\2"+
		"\2\u00fc\u00f6\3\2\2\2\u00fd*\3\2\2\2\u00fe\u00ff\7w\2\2\u00ff\u0100\7"+
		"r\2\2\u0100\u0101\7f\2\2\u0101\u0102\7c\2\2\u0102\u0103\7v\2\2\u0103\u0111"+
		"\7g\2\2\u0104\u0105\7W\2\2\u0105\u0106\7R\2\2\u0106\u0107\7F\2\2\u0107"+
		"\u0108\7C\2\2\u0108\u0109\7V\2\2\u0109\u0111\7G\2\2\u010a\u010b\7W\2\2"+
		"\u010b\u010c\7r\2\2\u010c\u010d\7f\2\2\u010d\u010e\7c\2\2\u010e\u010f"+
		"\7v\2\2\u010f\u0111\7g\2\2\u0110\u00fe\3\2\2\2\u0110\u0104\3\2\2\2\u0110"+
		"\u010a\3\2\2\2\u0111,\3\2\2\2\u0112\u0116\5\33\16\2\u0113\u0116\5=\37"+
		"\2\u0114\u0116\5? \2\u0115\u0112\3\2\2\2\u0115\u0113\3\2\2\2\u0115\u0114"+
		"\3\2\2\2\u0116.\3\2\2\2\u0117\u0118\7~\2\2\u0118\60\3\2\2\2\u0119\u011a"+
		"\7<\2\2\u011a\62\3\2\2\2\u011b\u011c\7?\2\2\u011c\u011d\7?\2\2\u011d\64"+
		"\3\2\2\2\u011e\u011f\7@\2\2\u011f\66\3\2\2\2\u0120\u0121\7@\2\2\u0121"+
		"\u0122\7?\2\2\u01228\3\2\2\2\u0123\u0124\7>\2\2\u0124:\3\2\2\2\u0125\u0126"+
		"\7>\2\2\u0126\u0127\7?\2\2\u0127<\3\2\2\2\u0128\u0129\7-\2\2\u0129\u012a"+
		"\7?\2\2\u012a>\3\2\2\2\u012b\u012c\7/\2\2\u012c\u012d\7?\2\2\u012d@\3"+
		"\2\2\2\u012e\u012f\t\2\2\2\u012fB\3\2\2\2\u0130\u0131\t\3\2\2\u0131D\3"+
		"\2\2\2\u0132\u0135\5A!\2\u0133\u0135\5C\"\2\u0134\u0132\3\2\2\2\u0134"+
		"\u0133\3\2\2\2\u0135\u0136\3\2\2\2\u0136\u0134\3\2\2\2\u0136\u0137\3\2"+
		"\2\2\u0137F\3\2\2\2\u0138\u013a\t\4\2\2\u0139\u0138\3\2\2\2\u013a\u013b"+
		"\3\2\2\2\u013b\u0139\3\2\2\2\u013b\u013c\3\2\2\2\u013cH\3\2\2\2\u013d"+
		"\u0141\t\3\2\2\u013e\u0140\t\2\2\2\u013f\u013e\3\2\2\2\u0140\u0143\3\2"+
		"\2\2\u0141\u013f\3\2\2\2\u0141\u0142\3\2\2\2\u0142J\3\2\2\2\u0143\u0141"+
		"\3\2\2\2\u0144\u0146\t\2\2\2\u0145\u0144\3\2\2\2\u0146\u0147\3\2\2\2\u0147"+
		"\u0145\3\2\2\2\u0147\u0148\3\2\2\2\u0148\u014c\3\2\2\2\u0149\u014b\t\4"+
		"\2\2\u014a\u0149\3\2\2\2\u014b\u014e\3\2\2\2\u014c\u014a\3\2\2\2\u014c"+
		"\u014d\3\2\2\2\u014dL\3\2\2\2\u014e\u014c\3\2\2\2\u014f\u0153\7$\2\2\u0150"+
		"\u0152\13\2\2\2\u0151\u0150\3\2\2\2\u0152\u0155\3\2\2\2\u0153\u0154\3"+
		"\2\2\2\u0153\u0151\3\2\2\2\u0154\u0156\3\2\2\2\u0155\u0153\3\2\2\2\u0156"+
		"\u0157\7$\2\2\u0157N\3\2\2\2\u0158\u015a\t\5\2\2\u0159\u0158\3\2\2\2\u015a"+
		"\u015b\3\2\2\2\u015b\u0159\3\2\2\2\u015b\u015c\3\2\2\2\u015c\u015d\3\2"+
		"\2\2\u015d\u015e\b(\2\2\u015eP\3\2\2\2\25\2\u0081\u008a\u009e\u00ac\u00bd"+
		"\u00d4\u00e8\u00fc\u0110\u0115\u0134\u0136\u013b\u0141\u0147\u014c\u0153"+
		"\u015b\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}