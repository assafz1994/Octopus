using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;

namespace OctopusCore.Parser.Grammer
{
    public class ThrowingErrorListener : BaseErrorListener
    {

        public static ThrowingErrorListener INSTANCE = new ThrowingErrorListener();

        // public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line,
        //     int charPositionInLine, string msg, RecognitionException e)
        // {
        //
        // }
    }
}
