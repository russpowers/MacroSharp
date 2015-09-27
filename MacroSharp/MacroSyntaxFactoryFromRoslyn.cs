using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using InternalSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MacroSharp
{
    /// <summary>
    /// A class containing factory methods for constructing syntax nodes, tokens and trivia.
    /// </summary>
    public static partial class MacroSyntaxFactory
    {
        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// </summary>
        public static readonly SyntaxTrivia CarriageReturnLineFeed = F.CarriageReturnLineFeed;

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single line feed character.
        /// </summary>
        public static readonly SyntaxTrivia LineFeed = F.LineFeed;

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single carriage return character.
        /// </summary>
        public static readonly SyntaxTrivia CarriageReturn = F.CarriageReturn;

        /// <summary>
        ///  A trivia with kind WhitespaceTrivia containing a single space character.
        /// </summary>
        public static readonly SyntaxTrivia Space = F.Space;

        /// <summary>
        /// A trivia with kind WhitespaceTrivia containing a single tab character.
        /// </summary>
        public static readonly SyntaxTrivia Tab = F.Tab;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// Elastic trivia are used to denote trivia that was not produced by parsing source text, and are usually not
        /// preserved during formatting.
        /// </summary>
        public static readonly SyntaxTrivia ElasticCarriageReturnLineFeed = F.ElasticCarriageReturnLineFeed;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single line feed character. Elastic trivia are used
        /// to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public static readonly SyntaxTrivia ElasticLineFeed = F.ElasticLineFeed;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single carriage return character. Elastic trivia
        /// are used to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public static readonly SyntaxTrivia ElasticCarriageReturn = F.ElasticCarriageReturn;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single space character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public static readonly SyntaxTrivia ElasticSpace = F.ElasticSpace;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single tab character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public static readonly SyntaxTrivia ElasticTab = F.ElasticTab;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing no characters. Elastic marker trivia are included
        /// automatically by factory methods when trivia is not specified. Syntax formatting will replace elastic
        /// markers with appropriate trivia.
        /// </summary>
        public static readonly SyntaxTrivia ElasticMarker = F.ElasticMarker;

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. 
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public static SyntaxTrivia EndOfLine(string text) => F.EndOfLine(text);

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public static SyntaxTrivia ElasticEndOfLine(string text) => F.ElasticEndOfLine(text);

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public static SyntaxTrivia Whitespace(string text) => F.Whitespace(text);

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public static SyntaxTrivia ElasticWhitespace(string text) => F.ElasticWhitespace(text);

        /// <summary>
        /// Creates a trivia with kind either SingleLineCommentTrivia or MultiLineCommentTrivia containing the specified
        /// text.
        /// </summary>
        /// <param name="text">The entire text of the comment including the leading '//' token for single line comments
        /// or stop or start tokens for multiline comments.</param>
        public static SyntaxTrivia Comment(string text) => F.Comment(text);

        /// <summary>
        /// Creates a trivia with kind DisabledTextTrivia. Disabled text corresponds to any text between directives that
        /// is not considered active.
        /// </summary>
        public static SyntaxTrivia DisabledText(string text) => F.DisabledText(text);

        /// <summary>
        /// Creates a trivia with kind PreprocessingMessageTrivia.
        /// </summary>
        public static SyntaxTrivia PreprocessingMessage(string text) => F.PreprocessingMessage(text);

        /// <summary>
        /// Trivia nodes represents parts of the program text that are not parts of the
        /// syntactic grammar, such as spaces, newlines, comments, preprocessors
        /// directives, and disabled code.
        /// </summary>
        /// <param name="kind">
        /// A <cref c="SyntaxKind"/> representing the specific kind of SyntaxTrivia. One of
        /// WhitespaceTrivia, EndOfLineTrivia, CommentTrivia,
        /// DocumentationCommentExteriorTrivia, DisabledTextTrivia.
        /// </param>
        /// <param name="text">
        /// The actual text of this token.
        /// </param>
        public static SyntaxTrivia SyntaxTrivia(SyntaxKind kind, string text) => F.SyntaxTrivia(kind, text);

        /// <summary>
        /// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
        /// can be inferred by the kind alone.
        /// </summary>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <returns></returns>
        public static SyntaxToken Token(SyntaxKind kind) => F.Token(kind);

        /// <summary>
        /// Creates a token corresponding to syntax kind. This method can be used for token syntax kinds whose text can
        /// be inferred by the kind alone.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
        {
            return F.Token(leading, kind, trailing);
        }

        /// <summary>
        /// Creates a token corresponding to syntax kind. This method gives control over token Text and ValueText.
        /// 
        /// For example, consider the text '&lt;see cref="operator &amp;#43;"/&gt;'.  To create a token for the value of
        /// the operator symbol (&amp;#43;), one would call 
        /// Token(default(SyntaxTriviaList), SyntaxKind.PlusToken, "&amp;#43;", "+", default(SyntaxTriviaList)).
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="text">The text from which this this token was created (e.g. lexed).</param>
        /// <param name="valueText">How C# should interpret the text of this token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, string text, string valueText, SyntaxTriviaList trailing)
        {
            return F.Token(leading, kind, text, valueText, trailing);
        }

        /// <summary>
        /// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
        /// expected token is not found. A missing token has no text and normally has associated diagnostics.
        /// </summary>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        public static SyntaxToken MissingToken(SyntaxKind kind) => F.MissingToken(kind);

        /// <summary>
        /// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
        /// expected token is not found. A missing token has no text and normally has associated diagnostics.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken MissingToken(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
        {
            return F.MissingToken(leading, kind, trailing);
        }

        /// <summary>
        /// Creates a token with kind IdentifierToken containing the specified text.
        /// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
        /// character.</param>
        /// </summary>
        public static SyntaxToken Identifier(string text) => F.Identifier(text);

        /// <summary>
        /// Creates a token with kind IdentifierToken containing the specified text.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
        /// character.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Identifier(SyntaxTriviaList leading, string text, SyntaxTriviaList trailing)
        {
            return F.Identifier(leading, text, trailing);
        }

        /// <summary>
        /// Creates a verbatim token with kind IdentifierToken containing the specified text.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
        /// character as it is in source.</param>
        /// <param name="valueText">The canonical value of the token's text.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken VerbatimIdentifier(SyntaxTriviaList leading, string text, string valueText, SyntaxTriviaList trailing)
        {
            return F.VerbatimIdentifier(leading, text, valueText, trailing);
        }

        /// <summary>
        /// Creates a token with kind IdentifierToken containing the specified text.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="contextualKind">An alternative SyntaxKind that can be inferred for this token in special
        /// contexts. These are usually keywords.</param>
        /// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
        /// character.</param>
        /// <param name="valueText">The text of the identifier name without escapes or leading '@' character.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        /// <returns></returns>
        public static SyntaxToken Identifier(SyntaxTriviaList leading, SyntaxKind contextualKind, string text, string valueText, SyntaxTriviaList trailing)
        {
            return F.Identifier(leading, contextualKind, text, valueText, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from a 4-byte signed integer value.
        /// </summary>
        /// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(int value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte signed integer value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, int value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte signed integer value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, int value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from a 4-byte unsigned integer value.
        /// </summary>
        /// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(uint value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte unsigned integer value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, uint value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteraToken from the text and corresponding 4-byte unsigned integer value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, uint value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from an 8-byte signed integer value.
        /// </summary>
        /// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(long value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte signed integer value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, long value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte signed integer value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, long value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from an 8-byte unsigned integer value.
        /// </summary>
        /// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(ulong value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte unsigned integer value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, ulong value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte unsigned integer value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, ulong value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from a 4-byte floating point value.
        /// </summary>
        /// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
        public static SyntaxToken Literal(float value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte floating point value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, float value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte floating point value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, float value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from an 8-byte floating point value.
        /// </summary>
        /// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
        public static SyntaxToken Literal(double value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte floating point value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, double value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte floating point value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, double value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from a decimal value.
        /// </summary>
        /// <param name="value">The decimal value to be represented by the returned token.</param>
        public static SyntaxToken Literal(decimal value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding decimal value.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The decimal value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, decimal value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind NumericLiteralToken from the text and corresponding decimal value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The decimal value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, decimal value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind StringLiteralToken from a string value.
        /// </summary>
        /// <param name="value">The string value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind StringLiteralToken from the text and corresponding string value.
        /// </summary>
        /// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
        /// <param name="value">The string value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, string value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind StringLiteralToken from the text and corresponding string value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
        /// <param name="value">The string value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, string value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind CharacterLiteralToken from a character value.
        /// </summary>
        /// <param name="value">The character value to be represented by the returned token.</param>
        public static SyntaxToken Literal(char value) => F.Literal(value);

        /// <summary>
        /// Creates a token with kind CharacterLiteralToken from the text and corresponding character value.
        /// </summary>
        /// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
        /// <param name="value">The character value to be represented by the returned token.</param>
        public static SyntaxToken Literal(string text, char value) => F.Literal(text, value);

        /// <summary>
        /// Creates a token with kind CharacterLiteralToken from the text and corresponding character value.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
        /// <param name="value">The character value to be represented by the returned token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken Literal(SyntaxTriviaList leading, string text, char value, SyntaxTriviaList trailing)
        {
            return F.Literal(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind BadToken.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the bad token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken BadToken(SyntaxTriviaList leading, string text, SyntaxTriviaList trailing)
        {
            return F.BadToken(leading, text, trailing);
        }

        /// <summary>
        /// Creates a token with kind XmlTextLiteralToken.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The xml text value.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken XmlTextLiteral(SyntaxTriviaList leading, string text, string value, SyntaxTriviaList trailing)
        {
            return F.XmlTextLiteral(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind XmlTextLiteralNewLineToken.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The xml text new line value.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken XmlTextNewLine(SyntaxTriviaList leading, string text, string value, SyntaxTriviaList trailing)
        {
            return F.XmlTextNewLine(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a token with kind XmlEntityLiteralToken.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the literal.</param>
        /// <param name="value">The xml entity value.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public static SyntaxToken XmlEntity(SyntaxTriviaList leading, string text, string value, SyntaxTriviaList trailing)
        {
            return F.XmlEntity(leading, text, value, trailing);
        }

        /// <summary>
        /// Creates a trivia with kind DocumentationCommentExteriorTrivia.
        /// </summary>
        /// <param name="text">The raw text of the literal.</param>
        public static SyntaxTrivia DocumentationCommentExterior(string text)
        {
            return F.DocumentationCommentExterior(text);
        }

        /// <summary>
        /// Creates an empty list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public static SyntaxList<TNode> List<TNode>() where TNode : SyntaxNode
        {
            return F.List<TNode>();
        }

        /// <summary>
        /// Creates a singleton list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">The single element node.</param>
        /// <returns></returns>
        public static SyntaxList<TNode> SingletonList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return F.SingletonList<TNode>(node);
        }


        /// <summary>
        /// Creates a list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of element nodes.</param>
        public static SyntaxList<TNode> List<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
        {
            return F.List(nodes);
        }

        /// <summary>
        /// Creates an empty list of tokens.
        /// </summary>
        public static SyntaxTokenList TokenList()
        {
            return F.TokenList();
        }

        /// <summary>
        /// Creates a singleton list of tokens.
        /// </summary>
        /// <param name="token">The single token.</param>
        public static SyntaxTokenList TokenList(SyntaxToken token)
        {
            return F.TokenList(token);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens">An array of tokens.</param>
        public static SyntaxTokenList TokenList(params SyntaxToken[] tokens)
        {
            return F.TokenList(tokens);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public static SyntaxTokenList TokenList(IEnumerable<SyntaxToken> tokens)
        {
            return F.TokenList(tokens);
        }

        /// <summary>
        /// Creates a trivia from a StructuredTriviaSyntax node.
        /// </summary>
        public static SyntaxTrivia Trivia(StructuredTriviaSyntax node)
        {
            return F.Trivia(node);
        }

        /// <summary>
        /// Creates an empty list of trivia.
        /// </summary>
        public static SyntaxTriviaList TriviaList()
        {
            return F.TriviaList();
        }

        /// <summary>
        /// Creates a singleton list of trivia.
        /// </summary>
        /// <param name="trivia">A single trivia.</param>
        public static SyntaxTriviaList TriviaList(SyntaxTrivia trivia)
        {
            return F.TriviaList(trivia);
        }

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">An array of trivia.</param>
        public static SyntaxTriviaList TriviaList(params SyntaxTrivia[] trivias)
        {
            return F.TriviaList(trivias);
        }

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">A sequence of trivia.</param>
        public static SyntaxTriviaList TriviaList(IEnumerable<SyntaxTrivia> trivias)
        {
            return F.TriviaList(trivias);
        }

        /// <summary>
        /// Creates an empty separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public static SeparatedSyntaxList<TNode> SeparatedList<TNode>() where TNode : SyntaxNode
        {
            return F.SeparatedList<TNode>();
        }

        /// <summary>
        /// Creates a singleton separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">A single node.</param>
        public static SeparatedSyntaxList<TNode> SingletonSeparatedList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return F.SingletonSeparatedList<TNode>(node);
        }

        /// <summary>
        /// Creates a separated list of nodes from a sequence of nodes, synthesizing comma separators in between.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of syntax nodes.</param>
        public static SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
        {
            return F.SeparatedList<TNode>(nodes);
        }

        /// <summary>
        /// Creates a separated list of nodes from a sequence of nodes and a sequence of separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of syntax nodes.</param>
        /// <param name="separators">A sequence of token to be interleaved between the nodes. The number of tokens must
        /// be one less than the number of nodes.</param>
        public static SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes, IEnumerable<SyntaxToken> separators) where TNode : SyntaxNode
        {
            return F.SeparatedList<TNode>(nodes, separators);
        }

        /// <summary>
        /// Creates a separated list from a sequence of nodes and tokens, starting with a node and alternating between additional nodes and separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodesAndTokens">A sequence of nodes or tokens, alternating between nodes and separator tokens.</param>
        public static SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<SyntaxNodeOrToken> nodesAndTokens) where TNode : SyntaxNode
        {
            return F.SeparatedList<TNode>(nodesAndTokens);
        }

        /// <summary>
        /// Creates a separated list from a <see cref="SyntaxNodeOrTokenList"/>, where the list elements start with a node and then alternate between
        /// additional nodes and separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodesAndTokens">The list of nodes and tokens.</param>
        public static SeparatedSyntaxList<TNode> SeparatedList<TNode>(SyntaxNodeOrTokenList nodesAndTokens) where TNode : SyntaxNode
        {
            return F.SeparatedList<TNode>(nodesAndTokens);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from a sequence of <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The sequence of nodes and tokens</param>
        public static SyntaxNodeOrTokenList NodeOrTokenList(IEnumerable<SyntaxNodeOrToken> nodesAndTokens)
        {
            return F.NodeOrTokenList(nodesAndTokens);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from one or more <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The nodes and tokens</param>
        public static SyntaxNodeOrTokenList NodeOrTokenList(params SyntaxNodeOrToken[] nodesAndTokens)
        {
            return F.NodeOrTokenList(nodesAndTokens);
        }

        /// <summary>
        /// Creates an IdentifierNameSyntax node.
        /// </summary>
        /// <param name="name">The identifier name.</param>
        public static IdentifierNameSyntax IdentifierName(string name)
        {
            return F.IdentifierName(name);
        }

        // direct access to parsing for common grammar areas

        /// <summary>
        /// Create a new syntax tree from a syntax node.
        /// </summary>
        public static SyntaxTree SyntaxTree(SyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
        {
            return F.SyntaxTree(root, options, path, encoding);
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static SyntaxTree ParseSyntaxTree(
            string text,
            ParseOptions options = null,
            string path = "",
            Encoding encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return F.ParseSyntaxTree(text, options, path, encoding, cancellationToken);
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static SyntaxTree ParseSyntaxTree(
            SourceText text,
            ParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return F.ParseSyntaxTree(text, options, path, cancellationToken);
        }

        /// <summary>
        /// Parse a list of trivia rules for leading trivia.
        /// </summary>
        public static SyntaxTriviaList ParseLeadingTrivia(string text, int offset = 0)
        {
            return F.ParseLeadingTrivia(text, offset);
        }

        /// <summary>
        /// Parse a list of trivia using the parsing rules for trailing trivia.
        /// </summary>
        public static SyntaxTriviaList ParseTrailingTrivia(string text, int offset = 0)
        {
            return F.ParseTrailingTrivia(text, offset);
        }

        /// <summary>
        /// Parse a C# language token.
        /// </summary>
        /// <param name="text">The text of the token including leading and trailing trivia.</param>
        /// <param name="offset">Optional offset into text.</param>
        public static SyntaxToken ParseToken(string text, int offset = 0)
        {
            return F.ParseToken(text, offset);
        }

        /// <summary>
        /// Parse a sequence of C# language tokens.
        /// </summary>
        /// <param name="text">The text of all the tokens.</param>
        /// <param name="initialTokenPosition">An integer to use as the starting position of the first token.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">Parse options.</param>
        public static IEnumerable<SyntaxToken> ParseTokens(string text, int offset = 0, int initialTokenPosition = 0, CSharpParseOptions options = null)
        {
            return F.ParseTokens(text, offset, initialTokenPosition, options);
        }

        /// <summary>
        /// Parse a NameSyntax node using the grammar rule for names.
        /// </summary>
        public static NameSyntax ParseName(string text, int offset = 0, bool consumeFullText = true)
        {
            return F.ParseName(text, offset, consumeFullText);
        }

        /// <summary>
        /// Parse a TypeNameSyntax node using the grammar rule for type names.
        /// </summary>
        public static TypeSyntax ParseTypeName(string text, int offset = 0, bool consumeFullText = true)
        {
            return F.ParseTypeName(text, offset, consumeFullText);
        }

        /// <summary>
        /// Parse an ExpressionSyntax node using the lowest precedence grammar rule for expressions.
        /// </summary>
        /// <param name="text">The text of the expression.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static ExpressionSyntax ParseExpression(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseExpression(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse a StatementSyntaxNode using grammar rule for statements.
        /// </summary>
        /// <param name="text">The text of the statement.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static StatementSyntax ParseStatement(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseStatement(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse a CompilationUnitSyntax using the grammar rule for an entire compilation unit (file). To produce a
        /// SyntaxTree instance, use CSharpSyntaxTree.ParseText instead.
        /// </summary>
        /// <param name="text">The text of the compilation unit.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        public static CompilationUnitSyntax ParseCompilationUnit(string text, int offset = 0, CSharpParseOptions options = null)
        {
            return F.ParseCompilationUnit(text, offset, options);
        }

        /// <summary>
        /// Parse a ParameterListSyntax node.
        /// </summary>
        /// <param name="text">The text of the parenthesized parameter list.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static ParameterListSyntax ParseParameterList(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseParameterList(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse a BracketedParameterListSyntax node.
        /// </summary>
        /// <param name="text">The text of the bracketed parameter list.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static BracketedParameterListSyntax ParseBracketedParameterList(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseBracketedParameterList(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse an ArgumentListSyntax node.
        /// </summary>
        /// <param name="text">The text of the parenthesized argument list.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static ArgumentListSyntax ParseArgumentList(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseArgumentList(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse a BracketedArgumentListSyntax node.
        /// </summary>
        /// <param name="text">The text of the bracketed argument list.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static BracketedArgumentListSyntax ParseBracketedArgumentList(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseBracketedArgumentList(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Parse an AttributeArgumentListSyntax node.
        /// </summary>
        /// <param name="text">The text of the attribute argument list.</param>
        /// <param name="offset">Optional offset into text.</param>
        /// <param name="options">The optional parse options to use. If no options are specified default options are
        /// used.</param>
        /// <param name="consumeFullText">True if extra tokens in the input should be treated as an error</param>
        public static AttributeArgumentListSyntax ParseAttributeArgumentList(string text, int offset = 0, ParseOptions options = null, bool consumeFullText = true)
        {
            return F.ParseAttributeArgumentList(text, offset, options, consumeFullText);
        }

        /// <summary>
        /// Determines if two trees are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldTree">The original tree.</param>
        /// <param name="newTree">The new tree.</param>
        /// <param name="topLevel"> 
        /// If true then the trees are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public static bool AreEquivalent(SyntaxTree oldTree, SyntaxTree newTree, bool topLevel)
        {
            return F.AreEquivalent(oldTree, newTree, topLevel);
        }

        /// <summary>
        /// Determines if two syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldNode">The old node.</param>
        /// <param name="newNode">The new node.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public static bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode, bool topLevel)
        {
            return F.AreEquivalent(oldNode, newNode, topLevel);
        }

        /// <summary>
        /// Determines if two syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldNode">The old node.</param>
        /// <param name="newNode">The new node.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// It it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public static bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode, Func<SyntaxKind, bool> ignoreChildNode = null)
        {
            return F.AreEquivalent(oldNode, newNode, ignoreChildNode);
        }

        /// <summary>
        /// Determines if two syntax tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldToken">The old token.</param>
        /// <param name="newToken">The new token.</param>
        public static bool AreEquivalent(SyntaxToken oldToken, SyntaxToken newToken)
        {
            return F.AreEquivalent(oldToken, newToken);
        }

        /// <summary>
        /// Determines if two lists of tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old token list.</param>
        /// <param name="newList">The new token list.</param>
        public static bool AreEquivalent(SyntaxTokenList oldList, SyntaxTokenList newList)
        {
            return F.AreEquivalent(oldList, newList);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public static bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList, bool topLevel)
            where TNode : CSharpSyntaxNode
        {
            return F.AreEquivalent(oldList, newList, topLevel);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// It it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public static bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList, Func<SyntaxKind, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return F.AreEquivalent<TNode>(oldList, newList, ignoreChildNode);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public static bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList, bool topLevel)
            where TNode : SyntaxNode
        {
            return F.AreEquivalent<TNode>(oldList, newList, topLevel);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// It it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public static bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList, Func<SyntaxKind, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return F.AreEquivalent(oldList, newList, ignoreChildNode);
        }

        /// <summary>
        /// Gets the containing expression that is actually a language expression and not just typed
        /// as an ExpressionSyntax for convenience. For example, NameSyntax nodes on the right side
        /// of qualified names and member access expressions are not language expressions, yet the
        /// containing qualified names or member access expressions are indeed expressions.
        /// </summary>
        public static ExpressionSyntax GetStandaloneExpression(ExpressionSyntax expression)
        {
            return F.GetStandaloneExpression(expression);
        }

        /// <summary>
        /// Converts a generic name expression into one without the generic arguments.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static ExpressionSyntax GetNonGenericExpression(ExpressionSyntax expression)
        {
            return F.GetNonGenericExpression(expression);
        }

        /// <summary>
        /// Determines whether the given text is considered a syntactically complete submission.
        /// </summary>
        public static bool IsCompleteSubmission(SyntaxTree tree)
        {
            return F.IsCompleteSubmission(tree);
        }

        /// <summary>Creates a new CaseSwitchLabelSyntax instance.</summary>
        public static CaseSwitchLabelSyntax CaseSwitchLabel(ExpressionSyntax value)
        {
            return F.CaseSwitchLabel(value);
        }

        /// <summary>Creates a new DefaultSwitchLabelSyntax instance.</summary>
        public static DefaultSwitchLabelSyntax DefaultSwitchLabel()
        {
            return F.DefaultSwitchLabel();
        }

        /// <summary>Creates a new BlockSyntax instance.</summary>
        public static BlockSyntax Block(params StatementSyntax[] statements)
        {
            return F.Block(statements);
        }

        /// <summary>Creates a new BlockSyntax instance.</summary>
        public static BlockSyntax Block(IEnumerable<StatementSyntax> statements)
        {
            return F.Block(statements);
        }

        public static PropertyDeclarationSyntax PropertyDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            TypeSyntax type,
            ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier,
            SyntaxToken identifier,
            AccessorListSyntax accessorList)
        {
            return F.PropertyDeclaration(attributeLists, modifiers, type, explicitInterfaceSpecifier, identifier, accessorList);
        }

        public static MethodDeclarationSyntax MethodDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            TypeSyntax returnType,
            ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier,
            SyntaxToken identifier,
            TypeParameterListSyntax typeParameterList,
            ParameterListSyntax parameterList,
            SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses,
            BlockSyntax body,
            SyntaxToken semicolonToken)
        {
            return F.MethodDeclaration(attributeLists, modifiers, returnType, explicitInterfaceSpecifier,
                identifier, typeParameterList, parameterList, constraintClauses, body, semicolonToken);
        }

        public static ConversionOperatorDeclarationSyntax ConversionOperatorDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            SyntaxToken implicitOrExplicitKeyword,
            SyntaxToken operatorKeyword,
            TypeSyntax type,
            ParameterListSyntax parameterList,
            BlockSyntax body,
            SyntaxToken semicolonToken)
        {
            return F.ConversionOperatorDeclaration(attributeLists, modifiers, implicitOrExplicitKeyword,
                operatorKeyword, type, parameterList, body, semicolonToken);
        }

        public static OperatorDeclarationSyntax OperatorDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            TypeSyntax returnType,
            SyntaxToken operatorKeyword,
            SyntaxToken operatorToken,
            ParameterListSyntax parameterList,
            BlockSyntax body,
            SyntaxToken semicolonToken)
        {
            return F.OperatorDeclaration(attributeLists, modifiers, returnType, operatorKeyword,
                operatorToken, parameterList, body, semicolonToken);
        }

        public static IndexerDeclarationSyntax IndexerDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            TypeSyntax type,
            ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier,
            BracketedParameterListSyntax parameterList,
            AccessorListSyntax accessorList)
        {
            return F.IndexerDeclaration(attributeLists, modifiers, type, explicitInterfaceSpecifier,
                parameterList, accessorList);
        }

        /// <summary>Creates a new UsingDirectiveSyntax instance.</summary>
        public static UsingDirectiveSyntax UsingDirective(NameEqualsSyntax alias, NameSyntax name)
        {
            return F.UsingDirective(alias, name);
        }

        /* AnonymousMethodExpressionSyntax.cs */

        public static AnonymousMethodExpressionSyntax AnonymousMethodExpression()
        {
            return F.AnonymousMethodExpression();
        }

        /* TypeDeclarationSyntax.cs */

        public static TypeDeclarationSyntax TypeDeclaration(SyntaxKind kind, SyntaxToken identifier)
        {
            return F.TypeDeclaration(kind, identifier);
        }

        public static TypeDeclarationSyntax TypeDeclaration(SyntaxKind kind, string identifier)
        {
            return F.TypeDeclaration(kind, identifier);
        }

        public static TypeDeclarationSyntax TypeDeclaration(SyntaxKind kind, SyntaxList<AttributeListSyntax> attributes, SyntaxTokenList modifiers, SyntaxToken keyword, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxToken openBraceToken, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            return F.TypeDeclaration(kind, attributes, modifiers, keyword, identifier, typeParameterList, baseList, constraintClauses, openBraceToken, members, closeBraceToken, semicolonToken);
        }
    }
}
