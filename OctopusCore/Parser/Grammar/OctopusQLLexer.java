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
		ENTITY=17, INSERT=18, DELETE=19, PIPELINE=20, COLON=21, ISEQUALS=22, EQUALS=23, 
		GT=24, GTE=25, LT=26, LTE=27, WORD=28, NUMBER=29, ENT=30, ENTREP=31, TEXT=32, 
		WHITESPACE=33;
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
			"ENTITY", "INSERT", "DELETE", "PIPELINE", "COLON", "ISEQUALS", "EQUALS", 
			"GT", "GTE", "LT", "LTE", "A", "C", "S", "Y", "H", "O", "U", "T", "F", 
			"R", "M", "W", "E", "LOWERCASE", "UPPERCASE", "WORD", "NUMBER", "ENT", 
			"ENTREP", "TEXT", "WHITESPACE"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2#\u016c\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\3\2\3\2\3\3\3\3\3\4\3\4\3\5"+
		"\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3"+
		"\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\5\r\u0087\n\r\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\5\16\u009b\n\16\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17\3\17"+
		"\3\17\3\17\3\17\5\17\u00a9\n\17\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\20\5\20\u00ba\n\20\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21"+
		"\3\21\3\21\3\21\5\21\u00d1\n\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\5\22\u00e5\n\22\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23"+
		"\3\23\3\23\3\23\5\23\u00f9\n\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u010d\n\24\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\32\3\33"+
		"\3\33\3\34\3\34\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3\"\3\""+
		"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3+\3+\3,\3,\6,\u0142"+
		"\n,\r,\16,\u0143\3-\6-\u0147\n-\r-\16-\u0148\3.\3.\7.\u014d\n.\f.\16."+
		"\u0150\13.\3/\6/\u0153\n/\r/\16/\u0154\3/\7/\u0158\n/\f/\16/\u015b\13"+
		"/\3\60\3\60\7\60\u015f\n\60\f\60\16\60\u0162\13\60\3\60\3\60\3\61\6\61"+
		"\u0167\n\61\r\61\16\61\u0168\3\61\3\61\3\u0160\2\62\3\3\5\4\7\5\t\6\13"+
		"\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'"+
		"\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\2;\2=\2?\2A\2C\2E\2G\2I\2"+
		"K\2M\2O\2Q\2S\2U\2W\36Y\37[ ]!_\"a#\3\2\23\4\2CCcc\4\2EEee\4\2UUuu\4\2"+
		"[[{{\4\2JJjj\4\2QQqq\4\2WWww\4\2VVvv\4\2HHhh\4\2TTtt\4\2OOoo\4\2YYyy\4"+
		"\2GGgg\3\2c|\3\2C\\\3\2\62;\5\2\13\f\17\17\"\"\2\u0176\2\3\3\2\2\2\2\5"+
		"\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2"+
		"\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33"+
		"\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2"+
		"\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2"+
		"\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2"+
		"\2]\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2\3c\3\2\2\2\5e\3\2\2\2\7g\3\2\2\2\ti"+
		"\3\2\2\2\13k\3\2\2\2\rm\3\2\2\2\17o\3\2\2\2\21s\3\2\2\2\23w\3\2\2\2\25"+
		"{\3\2\2\2\27\177\3\2\2\2\31\u0086\3\2\2\2\33\u009a\3\2\2\2\35\u00a8\3"+
		"\2\2\2\37\u00b9\3\2\2\2!\u00d0\3\2\2\2#\u00e4\3\2\2\2%\u00f8\3\2\2\2\'"+
		"\u010c\3\2\2\2)\u010e\3\2\2\2+\u0110\3\2\2\2-\u0112\3\2\2\2/\u0115\3\2"+
		"\2\2\61\u0117\3\2\2\2\63\u0119\3\2\2\2\65\u011c\3\2\2\2\67\u011e\3\2\2"+
		"\29\u0121\3\2\2\2;\u0123\3\2\2\2=\u0125\3\2\2\2?\u0127\3\2\2\2A\u0129"+
		"\3\2\2\2C\u012b\3\2\2\2E\u012d\3\2\2\2G\u012f\3\2\2\2I\u0131\3\2\2\2K"+
		"\u0133\3\2\2\2M\u0135\3\2\2\2O\u0137\3\2\2\2Q\u0139\3\2\2\2S\u013b\3\2"+
		"\2\2U\u013d\3\2\2\2W\u0141\3\2\2\2Y\u0146\3\2\2\2[\u014a\3\2\2\2]\u0152"+
		"\3\2\2\2_\u015c\3\2\2\2a\u0166\3\2\2\2cd\7*\2\2d\4\3\2\2\2ef\7+\2\2f\6"+
		"\3\2\2\2gh\7.\2\2h\b\3\2\2\2ij\7\60\2\2j\n\3\2\2\2kl\7]\2\2l\f\3\2\2\2"+
		"mn\7_\2\2n\16\3\2\2\2op\7C\2\2pq\7X\2\2qr\7I\2\2r\20\3\2\2\2st\7U\2\2"+
		"tu\7W\2\2uv\7O\2\2v\22\3\2\2\2wx\7O\2\2xy\7K\2\2yz\7P\2\2z\24\3\2\2\2"+
		"{|\7O\2\2|}\7C\2\2}~\7Z\2\2~\26\3\2\2\2\177\u0080\7,\2\2\u0080\30\3\2"+
		"\2\2\u0081\u0087\5-\27\2\u0082\u0087\5\61\31\2\u0083\u0087\5\63\32\2\u0084"+
		"\u0087\5\65\33\2\u0085\u0087\5\67\34\2\u0086\u0081\3\2\2\2\u0086\u0082"+
		"\3\2\2\2\u0086\u0083\3\2\2\2\u0086\u0084\3\2\2\2\u0086\u0085\3\2\2\2\u0087"+
		"\32\3\2\2\2\u0088\u0089\7u\2\2\u0089\u008a\7g\2\2\u008a\u008b\7n\2\2\u008b"+
		"\u008c\7g\2\2\u008c\u008d\7e\2\2\u008d\u009b\7v\2\2\u008e\u008f\7U\2\2"+
		"\u008f\u0090\7G\2\2\u0090\u0091\7N\2\2\u0091\u0092\7G\2\2\u0092\u0093"+
		"\7E\2\2\u0093\u009b\7V\2\2\u0094\u0095\7U\2\2\u0095\u0096\7g\2\2\u0096"+
		"\u0097\7n\2\2\u0097\u0098\7g\2\2\u0098\u0099\7e\2\2\u0099\u009b\7v\2\2"+
		"\u009a\u0088\3\2\2\2\u009a\u008e\3\2\2\2\u009a\u0094\3\2\2\2\u009b\34"+
		"\3\2\2\2\u009c\u009d\7h\2\2\u009d\u009e\7t\2\2\u009e\u009f\7q\2\2\u009f"+
		"\u00a9\7o\2\2\u00a0\u00a1\7H\2\2\u00a1\u00a2\7T\2\2\u00a2\u00a3\7Q\2\2"+
		"\u00a3\u00a9\7O\2\2\u00a4\u00a5\7H\2\2\u00a5\u00a6\7t\2\2\u00a6\u00a7"+
		"\7q\2\2\u00a7\u00a9\7o\2\2\u00a8\u009c\3\2\2\2\u00a8\u00a0\3\2\2\2\u00a8"+
		"\u00a4\3\2\2\2\u00a9\36\3\2\2\2\u00aa\u00ab\7y\2\2\u00ab\u00ac\7j\2\2"+
		"\u00ac\u00ad\7g\2\2\u00ad\u00ae\7t\2\2\u00ae\u00ba\7g\2\2\u00af\u00b0"+
		"\7Y\2\2\u00b0\u00b1\7J\2\2\u00b1\u00b2\7G\2\2\u00b2\u00b3\7T\2\2\u00b3"+
		"\u00ba\7G\2\2\u00b4\u00b5\7Y\2\2\u00b5\u00b6\7j\2\2\u00b6\u00b7\7g\2\2"+
		"\u00b7\u00b8\7t\2\2\u00b8\u00ba\7g\2\2\u00b9\u00aa\3\2\2\2\u00b9\u00af"+
		"\3\2\2\2\u00b9\u00b4\3\2\2\2\u00ba \3\2\2\2\u00bb\u00bc\7k\2\2\u00bc\u00bd"+
		"\7p\2\2\u00bd\u00be\7e\2\2\u00be\u00bf\7n\2\2\u00bf\u00c0\7w\2\2\u00c0"+
		"\u00c1\7f\2\2\u00c1\u00d1\7g\2\2\u00c2\u00c3\7K\2\2\u00c3\u00c4\7P\2\2"+
		"\u00c4\u00c5\7E\2\2\u00c5\u00c6\7N\2\2\u00c6\u00c7\7W\2\2\u00c7\u00c8"+
		"\7F\2\2\u00c8\u00d1\7G\2\2\u00c9\u00ca\7K\2\2\u00ca\u00cb\7p\2\2\u00cb"+
		"\u00cc\7e\2\2\u00cc\u00cd\7n\2\2\u00cd\u00ce\7w\2\2\u00ce\u00cf\7f\2\2"+
		"\u00cf\u00d1\7g\2\2\u00d0\u00bb\3\2\2\2\u00d0\u00c2\3\2\2\2\u00d0\u00c9"+
		"\3\2\2\2\u00d1\"\3\2\2\2\u00d2\u00d3\7g\2\2\u00d3\u00d4\7p\2\2\u00d4\u00d5"+
		"\7v\2\2\u00d5\u00d6\7k\2\2\u00d6\u00d7\7v\2\2\u00d7\u00e5\7{\2\2\u00d8"+
		"\u00d9\7G\2\2\u00d9\u00da\7P\2\2\u00da\u00db\7V\2\2\u00db\u00dc\7K\2\2"+
		"\u00dc\u00dd\7V\2\2\u00dd\u00e5\7[\2\2\u00de\u00df\7G\2\2\u00df\u00e0"+
		"\7p\2\2\u00e0\u00e1\7v\2\2\u00e1\u00e2\7k\2\2\u00e2\u00e3\7v\2\2\u00e3"+
		"\u00e5\7{\2\2\u00e4\u00d2\3\2\2\2\u00e4\u00d8\3\2\2\2\u00e4\u00de\3\2"+
		"\2\2\u00e5$\3\2\2\2\u00e6\u00e7\7k\2\2\u00e7\u00e8\7p\2\2\u00e8\u00e9"+
		"\7u\2\2\u00e9\u00ea\7g\2\2\u00ea\u00eb\7t\2\2\u00eb\u00f9\7v\2\2\u00ec"+
		"\u00ed\7K\2\2\u00ed\u00ee\7P\2\2\u00ee\u00ef\7U\2\2\u00ef\u00f0\7G\2\2"+
		"\u00f0\u00f1\7T\2\2\u00f1\u00f9\7V\2\2\u00f2\u00f3\7K\2\2\u00f3\u00f4"+
		"\7p\2\2\u00f4\u00f5\7u\2\2\u00f5\u00f6\7g\2\2\u00f6\u00f7\7t\2\2\u00f7"+
		"\u00f9\7v\2\2\u00f8\u00e6\3\2\2\2\u00f8\u00ec\3\2\2\2\u00f8\u00f2\3\2"+
		"\2\2\u00f9&\3\2\2\2\u00fa\u00fb\7f\2\2\u00fb\u00fc\7g\2\2\u00fc\u00fd"+
		"\7n\2\2\u00fd\u00fe\7g\2\2\u00fe\u00ff\7v\2\2\u00ff\u010d\7g\2\2\u0100"+
		"\u0101\7F\2\2\u0101\u0102\7G\2\2\u0102\u0103\7N\2\2\u0103\u0104\7G\2\2"+
		"\u0104\u0105\7V\2\2\u0105\u010d\7G\2\2\u0106\u0107\7F\2\2\u0107\u0108"+
		"\7g\2\2\u0108\u0109\7n\2\2\u0109\u010a\7g\2\2\u010a\u010b\7v\2\2\u010b"+
		"\u010d\7g\2\2\u010c\u00fa\3\2\2\2\u010c\u0100\3\2\2\2\u010c\u0106\3\2"+
		"\2\2\u010d(\3\2\2\2\u010e\u010f\7~\2\2\u010f*\3\2\2\2\u0110\u0111\7<\2"+
		"\2\u0111,\3\2\2\2\u0112\u0113\7?\2\2\u0113\u0114\7?\2\2\u0114.\3\2\2\2"+
		"\u0115\u0116\7?\2\2\u0116\60\3\2\2\2\u0117\u0118\7@\2\2\u0118\62\3\2\2"+
		"\2\u0119\u011a\7@\2\2\u011a\u011b\7?\2\2\u011b\64\3\2\2\2\u011c\u011d"+
		"\7>\2\2\u011d\66\3\2\2\2\u011e\u011f\7>\2\2\u011f\u0120\7?\2\2\u01208"+
		"\3\2\2\2\u0121\u0122\t\2\2\2\u0122:\3\2\2\2\u0123\u0124\t\3\2\2\u0124"+
		"<\3\2\2\2\u0125\u0126\t\4\2\2\u0126>\3\2\2\2\u0127\u0128\t\5\2\2\u0128"+
		"@\3\2\2\2\u0129\u012a\t\6\2\2\u012aB\3\2\2\2\u012b\u012c\t\7\2\2\u012c"+
		"D\3\2\2\2\u012d\u012e\t\b\2\2\u012eF\3\2\2\2\u012f\u0130\t\t\2\2\u0130"+
		"H\3\2\2\2\u0131\u0132\t\n\2\2\u0132J\3\2\2\2\u0133\u0134\t\13\2\2\u0134"+
		"L\3\2\2\2\u0135\u0136\t\f\2\2\u0136N\3\2\2\2\u0137\u0138\t\r\2\2\u0138"+
		"P\3\2\2\2\u0139\u013a\t\16\2\2\u013aR\3\2\2\2\u013b\u013c\t\17\2\2\u013c"+
		"T\3\2\2\2\u013d\u013e\t\20\2\2\u013eV\3\2\2\2\u013f\u0142\5S*\2\u0140"+
		"\u0142\5U+\2\u0141\u013f\3\2\2\2\u0141\u0140\3\2\2\2\u0142\u0143\3\2\2"+
		"\2\u0143\u0141\3\2\2\2\u0143\u0144\3\2\2\2\u0144X\3\2\2\2\u0145\u0147"+
		"\t\21\2\2\u0146\u0145\3\2\2\2\u0147\u0148\3\2\2\2\u0148\u0146\3\2\2\2"+
		"\u0148\u0149\3\2\2\2\u0149Z\3\2\2\2\u014a\u014e\t\20\2\2\u014b\u014d\t"+
		"\17\2\2\u014c\u014b\3\2\2\2\u014d\u0150\3\2\2\2\u014e\u014c\3\2\2\2\u014e"+
		"\u014f\3\2\2\2\u014f\\\3\2\2\2\u0150\u014e\3\2\2\2\u0151\u0153\t\17\2"+
		"\2\u0152\u0151\3\2\2\2\u0153\u0154\3\2\2\2\u0154\u0152\3\2\2\2\u0154\u0155"+
		"\3\2\2\2\u0155\u0159\3\2\2\2\u0156\u0158\t\21\2\2\u0157\u0156\3\2\2\2"+
		"\u0158\u015b\3\2\2\2\u0159\u0157\3\2\2\2\u0159\u015a\3\2\2\2\u015a^\3"+
		"\2\2\2\u015b\u0159\3\2\2\2\u015c\u0160\7$\2\2\u015d\u015f\13\2\2\2\u015e"+
		"\u015d\3\2\2\2\u015f\u0162\3\2\2\2\u0160\u0161\3\2\2\2\u0160\u015e\3\2"+
		"\2\2\u0161\u0163\3\2\2\2\u0162\u0160\3\2\2\2\u0163\u0164\7$\2\2\u0164"+
		"`\3\2\2\2\u0165\u0167\t\22\2\2\u0166\u0165\3\2\2\2\u0167\u0168\3\2\2\2"+
		"\u0168\u0166\3\2\2\2\u0168\u0169\3\2\2\2\u0169\u016a\3\2\2\2\u016a\u016b"+
		"\b\61\2\2\u016bb\3\2\2\2\23\2\u0086\u009a\u00a8\u00b9\u00d0\u00e4\u00f8"+
		"\u010c\u0141\u0143\u0148\u014e\u0154\u0159\u0160\u0168\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}