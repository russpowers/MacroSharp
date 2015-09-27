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
    public static partial class MacroSyntaxFactory
    {

        public static IdentifierNameSyntax IdentifierName(SyntaxToken identifier)
        {
            return F.IdentifierName(identifier);
        }

        /// <summary>Creates a new QualifiedNameSyntax instance.</summary>
        public static QualifiedNameSyntax QualifiedName(NameSyntax left, SyntaxToken dotToken, SimpleNameSyntax right)
        {
            return F.QualifiedName(left, dotToken, right);
        }

        /// <summary>Creates a new QualifiedNameSyntax instance.</summary>
        public static QualifiedNameSyntax QualifiedName(NameSyntax left, SimpleNameSyntax right)
        {
            return F.QualifiedName(left, right);
        }

        /// <summary>Creates a new GenericNameSyntax instance.</summary>
        public static GenericNameSyntax GenericName(SyntaxToken identifier, TypeArgumentListSyntax typeArgumentList)
        {
            return F.GenericName(identifier, typeArgumentList);
        }

        /// <summary>Creates a new GenericNameSyntax instance.</summary>
        public static GenericNameSyntax GenericName(SyntaxToken identifier)
        {
            return F.GenericName(identifier);
        }

        /// <summary>Creates a new GenericNameSyntax instance.</summary>
        public static GenericNameSyntax GenericName(string identifier)
        {
            return F.GenericName(identifier);
        }

        /// <summary>Creates a new TypeArgumentListSyntax instance.</summary>
        public static TypeArgumentListSyntax TypeArgumentList(SyntaxToken lessThanToken, SeparatedSyntaxList<TypeSyntax> arguments, SyntaxToken greaterThanToken)
        {
            return F.TypeArgumentList(lessThanToken, arguments, greaterThanToken);
        }

        /// <summary>Creates a new TypeArgumentListSyntax instance.</summary>
        public static TypeArgumentListSyntax TypeArgumentList(SeparatedSyntaxList<TypeSyntax> arguments = default(SeparatedSyntaxList<TypeSyntax>))
        {
            return F.TypeArgumentList(arguments);
        }

        /// <summary>Creates a new AliasQualifiedNameSyntax instance.</summary>
        public static AliasQualifiedNameSyntax AliasQualifiedName(IdentifierNameSyntax alias, SyntaxToken colonColonToken, SimpleNameSyntax name)
        {
            return F.AliasQualifiedName(alias, colonColonToken, name);
        }

        /// <summary>Creates a new AliasQualifiedNameSyntax instance.</summary>
        public static AliasQualifiedNameSyntax AliasQualifiedName(IdentifierNameSyntax alias, SimpleNameSyntax name)
        {
            return F.AliasQualifiedName(alias, name);
        }

        /// <summary>Creates a new AliasQualifiedNameSyntax instance.</summary>
        public static AliasQualifiedNameSyntax AliasQualifiedName(string alias, SimpleNameSyntax name)
        {
            return F.AliasQualifiedName(alias, name);
        }

        /// <summary>Creates a new PredefinedTypeSyntax instance.</summary>
        public static PredefinedTypeSyntax PredefinedType(SyntaxToken keyword)
        {
            return F.PredefinedType(keyword);
        }

        /// <summary>Creates a new ArrayTypeSyntax instance.</summary>
        public static ArrayTypeSyntax ArrayType(TypeSyntax elementType, SyntaxList<ArrayRankSpecifierSyntax> rankSpecifiers)
        {
            return F.ArrayType(elementType, rankSpecifiers);
        }

        /// <summary>Creates a new ArrayTypeSyntax instance.</summary>
        public static ArrayTypeSyntax ArrayType(TypeSyntax elementType)
        {
            return F.ArrayType(elementType);
        }

        /// <summary>Creates a new ArrayRankSpecifierSyntax instance.</summary>
        public static ArrayRankSpecifierSyntax ArrayRankSpecifier(SyntaxToken openBracketToken, SeparatedSyntaxList<ExpressionSyntax> sizes, SyntaxToken closeBracketToken)
        {
            return F.ArrayRankSpecifier(openBracketToken, sizes, closeBracketToken);
        }

        /// <summary>Creates a new ArrayRankSpecifierSyntax instance.</summary>
        public static ArrayRankSpecifierSyntax ArrayRankSpecifier(SeparatedSyntaxList<ExpressionSyntax> sizes = default(SeparatedSyntaxList<ExpressionSyntax>))
        {
            return F.ArrayRankSpecifier(sizes);
        }

        /// <summary>Creates a new PointerTypeSyntax instance.</summary>
        public static PointerTypeSyntax PointerType(TypeSyntax elementType, SyntaxToken asteriskToken)
        {
            return F.PointerType(elementType, asteriskToken);
        }

        /// <summary>Creates a new PointerTypeSyntax instance.</summary>
        public static PointerTypeSyntax PointerType(TypeSyntax elementType)
        {
            return F.PointerType(elementType);
        }

        /// <summary>Creates a new NullableTypeSyntax instance.</summary>
        public static NullableTypeSyntax NullableType(TypeSyntax elementType, SyntaxToken questionToken)
        {
            return F.NullableType(elementType, questionToken);
        }

        /// <summary>Creates a new NullableTypeSyntax instance.</summary>
        public static NullableTypeSyntax NullableType(TypeSyntax elementType)
        {
            return F.NullableType(elementType);
        }

        /// <summary>Creates a new OmittedTypeArgumentSyntax instance.</summary>
        public static OmittedTypeArgumentSyntax OmittedTypeArgument(SyntaxToken omittedTypeArgumentToken)
        {
            return F.OmittedTypeArgument(omittedTypeArgumentToken);
        }

        /// <summary>Creates a new OmittedTypeArgumentSyntax instance.</summary>
        public static OmittedTypeArgumentSyntax OmittedTypeArgument()
        {
            return F.OmittedTypeArgument();
        }

        /// <summary>Creates a new ParenthesizedExpressionSyntax instance.</summary>
        public static ParenthesizedExpressionSyntax ParenthesizedExpression(SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken)
        {
            return F.ParenthesizedExpression(openParenToken, expression, closeParenToken);
        }

        /// <summary>Creates a new ParenthesizedExpressionSyntax instance.</summary>
        public static ParenthesizedExpressionSyntax ParenthesizedExpression(ExpressionSyntax expression)
        {
            return F.ParenthesizedExpression(expression);
        }

        /// <summary>Creates a new PrefixUnaryExpressionSyntax instance.</summary>
        public static PrefixUnaryExpressionSyntax PrefixUnaryExpression(SyntaxKind kind, SyntaxToken operatorToken, ExpressionSyntax operand)
        {
            return F.PrefixUnaryExpression(kind, operatorToken, operand);
        }

        /// <summary>Creates a new PrefixUnaryExpressionSyntax instance.</summary>
        public static PrefixUnaryExpressionSyntax PrefixUnaryExpression(SyntaxKind kind, ExpressionSyntax operand)
        {
            return F.PrefixUnaryExpression(kind, operand);
        }

        /// <summary>Creates a new AwaitExpressionSyntax instance.</summary>
        public static AwaitExpressionSyntax AwaitExpression(SyntaxToken awaitKeyword, ExpressionSyntax expression)
        {
            return F.AwaitExpression(awaitKeyword, expression);
        }

        /// <summary>Creates a new AwaitExpressionSyntax instance.</summary>
        public static AwaitExpressionSyntax AwaitExpression(ExpressionSyntax expression)
        {
            return F.AwaitExpression(expression);
        }

        /// <summary>Creates a new PostfixUnaryExpressionSyntax instance.</summary>
        public static PostfixUnaryExpressionSyntax PostfixUnaryExpression(SyntaxKind kind, ExpressionSyntax operand, SyntaxToken operatorToken)
        {
            return F.PostfixUnaryExpression(kind, operand, operatorToken);
        }

        /// <summary>Creates a new PostfixUnaryExpressionSyntax instance.</summary>
        public static PostfixUnaryExpressionSyntax PostfixUnaryExpression(SyntaxKind kind, ExpressionSyntax operand)
        {
            return F.PostfixUnaryExpression(kind, operand);
        }

        /// <summary>Creates a new MemberAccessExpressionSyntax instance.</summary>
        public static MemberAccessExpressionSyntax MemberAccessExpression(SyntaxKind kind, ExpressionSyntax expression, SyntaxToken operatorToken, SimpleNameSyntax name)
        {
            return F.MemberAccessExpression(kind, expression, operatorToken, name);
        }

        /// <summary>Creates a new MemberAccessExpressionSyntax instance.</summary>
        public static MemberAccessExpressionSyntax MemberAccessExpression(SyntaxKind kind, ExpressionSyntax expression, SimpleNameSyntax name)
        {
            return F.MemberAccessExpression(kind, expression, name);
        }

        /// <summary>Creates a new ConditionalAccessExpressionSyntax instance.</summary>
        public static ConditionalAccessExpressionSyntax ConditionalAccessExpression(ExpressionSyntax expression, SyntaxToken operatorToken, ExpressionSyntax whenNotNull)
        {
            return F.ConditionalAccessExpression(expression, operatorToken, whenNotNull);
        }

        /// <summary>Creates a new ConditionalAccessExpressionSyntax instance.</summary>
        public static ConditionalAccessExpressionSyntax ConditionalAccessExpression(ExpressionSyntax expression, ExpressionSyntax whenNotNull)
        {
            return F.ConditionalAccessExpression(expression, whenNotNull);
        }

        /// <summary>Creates a new MemberBindingExpressionSyntax instance.</summary>
        public static MemberBindingExpressionSyntax MemberBindingExpression(SyntaxToken operatorToken, SimpleNameSyntax name)
        {
            return F.MemberBindingExpression(operatorToken, name);
        }

        /// <summary>Creates a new MemberBindingExpressionSyntax instance.</summary>
        public static MemberBindingExpressionSyntax MemberBindingExpression(SimpleNameSyntax name)
        {
            return F.MemberBindingExpression(name);
        }

        /// <summary>Creates a new ElementBindingExpressionSyntax instance.</summary>
        public static ElementBindingExpressionSyntax ElementBindingExpression(BracketedArgumentListSyntax argumentList)
        {
            return F.ElementBindingExpression(argumentList);
        }

        /// <summary>Creates a new ElementBindingExpressionSyntax instance.</summary>
        public static ElementBindingExpressionSyntax ElementBindingExpression()
        {
            return F.ElementBindingExpression();
        }

        /// <summary>Creates a new ImplicitElementAccessSyntax instance.</summary>
        public static ImplicitElementAccessSyntax ImplicitElementAccess(BracketedArgumentListSyntax argumentList)
        {
            return F.ImplicitElementAccess(argumentList);
        }

        /// <summary>Creates a new ImplicitElementAccessSyntax instance.</summary>
        public static ImplicitElementAccessSyntax ImplicitElementAccess()
        {
            return F.ImplicitElementAccess();
        }

        /// <summary>Creates a new BinaryExpressionSyntax instance.</summary>
        public static BinaryExpressionSyntax BinaryExpression(SyntaxKind kind, ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
        {
            return F.BinaryExpression(kind, left, operatorToken, right);
        }

        /// <summary>Creates a new BinaryExpressionSyntax instance.</summary>
        public static BinaryExpressionSyntax BinaryExpression(SyntaxKind kind, ExpressionSyntax left, ExpressionSyntax right)
        {
            return F.BinaryExpression(kind, left, right);
        }

        /// <summary>Creates a new AssignmentExpressionSyntax instance.</summary>
        public static AssignmentExpressionSyntax AssignmentExpression(SyntaxKind kind, ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
        {
            return F.AssignmentExpression(kind, left, operatorToken, right);
        }

        /// <summary>Creates a new AssignmentExpressionSyntax instance.</summary>
        public static AssignmentExpressionSyntax AssignmentExpression(SyntaxKind kind, ExpressionSyntax left, ExpressionSyntax right)
        {
            return F.AssignmentExpression(kind, left, right);
        }

        /// <summary>Creates a new ConditionalExpressionSyntax instance.</summary>
        public static ConditionalExpressionSyntax ConditionalExpression(ExpressionSyntax condition, SyntaxToken questionToken, ExpressionSyntax whenTrue, SyntaxToken colonToken, ExpressionSyntax whenFalse)
        {
            return F.ConditionalExpression(condition, questionToken, whenTrue, colonToken, whenFalse);
        }

        /// <summary>Creates a new ConditionalExpressionSyntax instance.</summary>
        public static ConditionalExpressionSyntax ConditionalExpression(ExpressionSyntax condition, ExpressionSyntax whenTrue, ExpressionSyntax whenFalse)
        {
            return F.ConditionalExpression(condition, whenTrue, whenFalse);
        }

        /// <summary>Creates a new ThisExpressionSyntax instance.</summary>
        public static ThisExpressionSyntax ThisExpression(SyntaxToken token)
        {
            return F.ThisExpression(token);
        }

        /// <summary>Creates a new ThisExpressionSyntax instance.</summary>
        public static ThisExpressionSyntax ThisExpression()
        {
            return F.ThisExpression();
        }

        /// <summary>Creates a new BaseExpressionSyntax instance.</summary>
        public static BaseExpressionSyntax BaseExpression(SyntaxToken token)
        {
            return F.BaseExpression(token);
        }

        /// <summary>Creates a new BaseExpressionSyntax instance.</summary>
        public static BaseExpressionSyntax BaseExpression()
        {
            return F.BaseExpression();
        }

        /// <summary>Creates a new LiteralExpressionSyntax instance.</summary>
        public static LiteralExpressionSyntax LiteralExpression(SyntaxKind kind, SyntaxToken token)
        {
            return F.LiteralExpression(kind, token);
        }

        /// <summary>Creates a new LiteralExpressionSyntax instance.</summary>
        public static LiteralExpressionSyntax LiteralExpression(SyntaxKind kind)
        {
            return F.LiteralExpression(kind);
        }

        /// <summary>Creates a new MakeRefExpressionSyntax instance.</summary>
        public static MakeRefExpressionSyntax MakeRefExpression(SyntaxToken keyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken)
        {
            return F.MakeRefExpression(keyword, openParenToken, expression, closeParenToken);
        }

        /// <summary>Creates a new MakeRefExpressionSyntax instance.</summary>
        public static MakeRefExpressionSyntax MakeRefExpression(ExpressionSyntax expression)
        {
            return F.MakeRefExpression(expression);
        }

        /// <summary>Creates a new RefTypeExpressionSyntax instance.</summary>
        public static RefTypeExpressionSyntax RefTypeExpression(SyntaxToken keyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken)
        {
            return F.RefTypeExpression(keyword, openParenToken, expression, closeParenToken);
        }

        /// <summary>Creates a new RefTypeExpressionSyntax instance.</summary>
        public static RefTypeExpressionSyntax RefTypeExpression(ExpressionSyntax expression)
        {
            return F.RefTypeExpression(expression);
        }

        /// <summary>Creates a new RefValueExpressionSyntax instance.</summary>
        public static RefValueExpressionSyntax RefValueExpression(SyntaxToken keyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken comma, TypeSyntax type, SyntaxToken closeParenToken)
        {
            return F.RefValueExpression(keyword, openParenToken, expression, comma, type, closeParenToken);
        }

        /// <summary>Creates a new RefValueExpressionSyntax instance.</summary>
        public static RefValueExpressionSyntax RefValueExpression(ExpressionSyntax expression, TypeSyntax type)
        {
            return F.RefValueExpression(expression, type);
        }

        /// <summary>Creates a new CheckedExpressionSyntax instance.</summary>
        public static CheckedExpressionSyntax CheckedExpression(SyntaxKind kind, SyntaxToken keyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken)
        {
            return F.CheckedExpression(kind, keyword, openParenToken, expression, closeParenToken);
        }

        /// <summary>Creates a new CheckedExpressionSyntax instance.</summary>
        public static CheckedExpressionSyntax CheckedExpression(SyntaxKind kind, ExpressionSyntax expression)
        {
            return F.CheckedExpression(kind, expression);
        }

        /// <summary>Creates a new DefaultExpressionSyntax instance.</summary>
        public static DefaultExpressionSyntax DefaultExpression(SyntaxToken keyword, SyntaxToken openParenToken, TypeSyntax type, SyntaxToken closeParenToken)
        {
            return F.DefaultExpression(keyword, openParenToken, type, closeParenToken);
        }

        /// <summary>Creates a new DefaultExpressionSyntax instance.</summary>
        public static DefaultExpressionSyntax DefaultExpression(TypeSyntax type)
        {
            return F.DefaultExpression(type);
        }

        /// <summary>Creates a new TypeOfExpressionSyntax instance.</summary>
        public static TypeOfExpressionSyntax TypeOfExpression(SyntaxToken keyword, SyntaxToken openParenToken, TypeSyntax type, SyntaxToken closeParenToken)
        {
            return F.TypeOfExpression(keyword, openParenToken, type, closeParenToken);
        }

        /// <summary>Creates a new TypeOfExpressionSyntax instance.</summary>
        public static TypeOfExpressionSyntax TypeOfExpression(TypeSyntax type)
        {
            return F.TypeOfExpression(type);
        }

        /// <summary>Creates a new SizeOfExpressionSyntax instance.</summary>
        public static SizeOfExpressionSyntax SizeOfExpression(SyntaxToken keyword, SyntaxToken openParenToken, TypeSyntax type, SyntaxToken closeParenToken)
        {
            return F.SizeOfExpression(keyword, openParenToken, type, closeParenToken);
        }

        /// <summary>Creates a new SizeOfExpressionSyntax instance.</summary>
        public static SizeOfExpressionSyntax SizeOfExpression(TypeSyntax type)
        {
            return F.SizeOfExpression(type);
        }

        /// <summary>Creates a new InvocationExpressionSyntax instance.</summary>
        public static InvocationExpressionSyntax InvocationExpression(ExpressionSyntax expression, ArgumentListSyntax argumentList)
        {
            return F.InvocationExpression(expression, argumentList);
        }

        /// <summary>Creates a new InvocationExpressionSyntax instance.</summary>
        public static InvocationExpressionSyntax InvocationExpression(ExpressionSyntax expression)
        {
            return F.InvocationExpression(expression);
        }

        /// <summary>Creates a new ElementAccessExpressionSyntax instance.</summary>
        public static ElementAccessExpressionSyntax ElementAccessExpression(ExpressionSyntax expression, BracketedArgumentListSyntax argumentList)
        {
            return F.ElementAccessExpression(expression, argumentList);
        }

        /// <summary>Creates a new ElementAccessExpressionSyntax instance.</summary>
        public static ElementAccessExpressionSyntax ElementAccessExpression(ExpressionSyntax expression)
        {
            return F.ElementAccessExpression(expression);
        }

        /// <summary>Creates a new ArgumentListSyntax instance.</summary>
        public static ArgumentListSyntax ArgumentList(SyntaxToken openParenToken, SeparatedSyntaxList<ArgumentSyntax> arguments, SyntaxToken closeParenToken)
        {
            return F.ArgumentList(openParenToken, arguments, closeParenToken);
        }

        /// <summary>Creates a new ArgumentListSyntax instance.</summary>
        public static ArgumentListSyntax ArgumentList(SeparatedSyntaxList<ArgumentSyntax> arguments = default(SeparatedSyntaxList<ArgumentSyntax>))
        {
            return F.ArgumentList(arguments);
        }

        /// <summary>Creates a new BracketedArgumentListSyntax instance.</summary>
        public static BracketedArgumentListSyntax BracketedArgumentList(SyntaxToken openBracketToken, SeparatedSyntaxList<ArgumentSyntax> arguments, SyntaxToken closeBracketToken)
        {
            return F.BracketedArgumentList(openBracketToken, arguments, closeBracketToken);
        }

        /// <summary>Creates a new BracketedArgumentListSyntax instance.</summary>
        public static BracketedArgumentListSyntax BracketedArgumentList(SeparatedSyntaxList<ArgumentSyntax> arguments = default(SeparatedSyntaxList<ArgumentSyntax>))
        {
            return F.BracketedArgumentList(arguments);
        }

        /// <summary>Creates a new ArgumentSyntax instance.</summary>
        public static ArgumentSyntax Argument(NameColonSyntax nameColon, SyntaxToken refOrOutKeyword, ExpressionSyntax expression)
        {
            return F.Argument(nameColon, refOrOutKeyword, expression);
        }

        /// <summary>Creates a new ArgumentSyntax instance.</summary>
        public static ArgumentSyntax Argument(ExpressionSyntax expression)
        {
            return F.Argument(expression);
        }

        /// <summary>Creates a new NameColonSyntax instance.</summary>
        public static NameColonSyntax NameColon(IdentifierNameSyntax name, SyntaxToken colonToken)
        {
            return F.NameColon(name, colonToken);
        }

        /// <summary>Creates a new NameColonSyntax instance.</summary>
        public static NameColonSyntax NameColon(IdentifierNameSyntax name)
        {
            return F.NameColon(name);
        }

        /// <summary>Creates a new NameColonSyntax instance.</summary>
        public static NameColonSyntax NameColon(string name)
        {
            return F.NameColon(name);
        }

        /// <summary>Creates a new CastExpressionSyntax instance.</summary>
        public static CastExpressionSyntax CastExpression(SyntaxToken openParenToken, TypeSyntax type, SyntaxToken closeParenToken, ExpressionSyntax expression)
        {
            return F.CastExpression(openParenToken, type, closeParenToken, expression);
        }

        /// <summary>Creates a new CastExpressionSyntax instance.</summary>
        public static CastExpressionSyntax CastExpression(TypeSyntax type, ExpressionSyntax expression)
        {
            return F.CastExpression(type, expression);
        }

        /// <summary>Creates a new AnonymousMethodExpressionSyntax instance.</summary>
        public static AnonymousMethodExpressionSyntax AnonymousMethodExpression(SyntaxToken asyncKeyword, SyntaxToken delegateKeyword, ParameterListSyntax parameterList, CSharpSyntaxNode body)
        {
            return F.AnonymousMethodExpression(asyncKeyword, delegateKeyword, parameterList, body);
        }

        /// <summary>Creates a new AnonymousMethodExpressionSyntax instance.</summary>
        public static AnonymousMethodExpressionSyntax AnonymousMethodExpression(ParameterListSyntax parameterList, CSharpSyntaxNode body)
        {
            return F.AnonymousMethodExpression(parameterList, body);
        }

        /// <summary>Creates a new AnonymousMethodExpressionSyntax instance.</summary>
        public static AnonymousMethodExpressionSyntax AnonymousMethodExpression(CSharpSyntaxNode body)
        {
            return F.AnonymousMethodExpression(body);
        }

        /// <summary>Creates a new SimpleLambdaExpressionSyntax instance.</summary>
        public static SimpleLambdaExpressionSyntax SimpleLambdaExpression(SyntaxToken asyncKeyword, ParameterSyntax parameter, SyntaxToken arrowToken, CSharpSyntaxNode body)
        {
            return F.SimpleLambdaExpression(asyncKeyword, parameter, arrowToken, body);
        }

        /// <summary>Creates a new SimpleLambdaExpressionSyntax instance.</summary>
        public static SimpleLambdaExpressionSyntax SimpleLambdaExpression(ParameterSyntax parameter, CSharpSyntaxNode body)
        {
            return F.SimpleLambdaExpression(parameter, body);
        }

        /// <summary>Creates a new ParenthesizedLambdaExpressionSyntax instance.</summary>
        public static ParenthesizedLambdaExpressionSyntax ParenthesizedLambdaExpression(SyntaxToken asyncKeyword, ParameterListSyntax parameterList, SyntaxToken arrowToken, CSharpSyntaxNode body)
        {
            return F.ParenthesizedLambdaExpression(asyncKeyword, parameterList, arrowToken, body);
        }

        /// <summary>Creates a new ParenthesizedLambdaExpressionSyntax instance.</summary>
        public static ParenthesizedLambdaExpressionSyntax ParenthesizedLambdaExpression(ParameterListSyntax parameterList, CSharpSyntaxNode body)
        {
            return F.ParenthesizedLambdaExpression(parameterList, body);
        }

        /// <summary>Creates a new ParenthesizedLambdaExpressionSyntax instance.</summary>
        public static ParenthesizedLambdaExpressionSyntax ParenthesizedLambdaExpression(CSharpSyntaxNode body)
        {
            return F.ParenthesizedLambdaExpression(body);
        }

        /// <summary>Creates a new InitializerExpressionSyntax instance.</summary>
        public static InitializerExpressionSyntax InitializerExpression(SyntaxKind kind, SyntaxToken openBraceToken, SeparatedSyntaxList<ExpressionSyntax> expressions, SyntaxToken closeBraceToken)
        {
            return F.InitializerExpression(kind, openBraceToken, expressions, closeBraceToken);
        }

        /// <summary>Creates a new InitializerExpressionSyntax instance.</summary>
        public static InitializerExpressionSyntax InitializerExpression(SyntaxKind kind, SeparatedSyntaxList<ExpressionSyntax> expressions = default(SeparatedSyntaxList<ExpressionSyntax>))
        {
            return F.InitializerExpression(kind, expressions);
        }

        /// <summary>Creates a new ObjectCreationExpressionSyntax instance.</summary>
        public static ObjectCreationExpressionSyntax ObjectCreationExpression(SyntaxToken newKeyword, TypeSyntax type, ArgumentListSyntax argumentList, InitializerExpressionSyntax initializer)
        {
            return F.ObjectCreationExpression(newKeyword, type, argumentList, initializer);
        }

        /// <summary>Creates a new ObjectCreationExpressionSyntax instance.</summary>
        public static ObjectCreationExpressionSyntax ObjectCreationExpression(TypeSyntax type, ArgumentListSyntax argumentList, InitializerExpressionSyntax initializer)
        {
            return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), type, argumentList, initializer);
        }

        /// <summary>Creates a new ObjectCreationExpressionSyntax instance.</summary>
        public static ObjectCreationExpressionSyntax ObjectCreationExpression(TypeSyntax type)
        {
            return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), type, default(ArgumentListSyntax), default(InitializerExpressionSyntax));
        }

        /// <summary>Creates a new AnonymousObjectMemberDeclaratorSyntax instance.</summary>
        public static AnonymousObjectMemberDeclaratorSyntax AnonymousObjectMemberDeclarator(NameEqualsSyntax nameEquals, ExpressionSyntax expression)
        {
            return F.AnonymousObjectMemberDeclarator(nameEquals, expression);
        }

        /// <summary>Creates a new AnonymousObjectMemberDeclaratorSyntax instance.</summary>
        public static AnonymousObjectMemberDeclaratorSyntax AnonymousObjectMemberDeclarator(ExpressionSyntax expression)
        {
            return SyntaxFactory.AnonymousObjectMemberDeclarator(default(NameEqualsSyntax), expression);
        }

        /// <summary>Creates a new AnonymousObjectCreationExpressionSyntax instance.</summary>
        public static AnonymousObjectCreationExpressionSyntax AnonymousObjectCreationExpression(SyntaxToken newKeyword, SyntaxToken openBraceToken, SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> initializers, SyntaxToken closeBraceToken)
        {
            return F.AnonymousObjectCreationExpression(newKeyword, openBraceToken, initializers, closeBraceToken);
        }

        /// <summary>Creates a new AnonymousObjectCreationExpressionSyntax instance.</summary>
        public static AnonymousObjectCreationExpressionSyntax AnonymousObjectCreationExpression(SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> initializers = default(SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax>))
        {
            return SyntaxFactory.AnonymousObjectCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), initializers, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new ArrayCreationExpressionSyntax instance.</summary>
        public static ArrayCreationExpressionSyntax ArrayCreationExpression(SyntaxToken newKeyword, ArrayTypeSyntax type, InitializerExpressionSyntax initializer)
        {
            return F.ArrayCreationExpression(newKeyword, type, initializer);
        }

        /// <summary>Creates a new ArrayCreationExpressionSyntax instance.</summary>
        public static ArrayCreationExpressionSyntax ArrayCreationExpression(ArrayTypeSyntax type, InitializerExpressionSyntax initializer)
        {
            return SyntaxFactory.ArrayCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), type, initializer);
        }

        /// <summary>Creates a new ArrayCreationExpressionSyntax instance.</summary>
        public static ArrayCreationExpressionSyntax ArrayCreationExpression(ArrayTypeSyntax type)
        {
            return SyntaxFactory.ArrayCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), type, default(InitializerExpressionSyntax));
        }

        /// <summary>Creates a new ImplicitArrayCreationExpressionSyntax instance.</summary>
        public static ImplicitArrayCreationExpressionSyntax ImplicitArrayCreationExpression(SyntaxToken newKeyword, SyntaxToken openBracketToken, SyntaxTokenList commas, SyntaxToken closeBracketToken, InitializerExpressionSyntax initializer)
        {
            return F.ImplicitArrayCreationExpression(newKeyword, openBracketToken, commas, closeBracketToken, initializer);
        }

        /// <summary>Creates a new ImplicitArrayCreationExpressionSyntax instance.</summary>
        public static ImplicitArrayCreationExpressionSyntax ImplicitArrayCreationExpression(SyntaxTokenList commas, InitializerExpressionSyntax initializer)
        {
            return SyntaxFactory.ImplicitArrayCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), SyntaxFactory.Token(SyntaxKind.OpenBracketToken), commas, SyntaxFactory.Token(SyntaxKind.CloseBracketToken), initializer);
        }

        /// <summary>Creates a new ImplicitArrayCreationExpressionSyntax instance.</summary>
        public static ImplicitArrayCreationExpressionSyntax ImplicitArrayCreationExpression(InitializerExpressionSyntax initializer)
        {
            return SyntaxFactory.ImplicitArrayCreationExpression(SyntaxFactory.Token(SyntaxKind.NewKeyword), SyntaxFactory.Token(SyntaxKind.OpenBracketToken), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.CloseBracketToken), initializer);
        }

        /// <summary>Creates a new StackAllocArrayCreationExpressionSyntax instance.</summary>
        public static StackAllocArrayCreationExpressionSyntax StackAllocArrayCreationExpression(SyntaxToken stackAllocKeyword, TypeSyntax type)
        {
            return F.StackAllocArrayCreationExpression(stackAllocKeyword, type);
        }

        /// <summary>Creates a new StackAllocArrayCreationExpressionSyntax instance.</summary>
        public static StackAllocArrayCreationExpressionSyntax StackAllocArrayCreationExpression(TypeSyntax type)
        {
            return SyntaxFactory.StackAllocArrayCreationExpression(SyntaxFactory.Token(SyntaxKind.StackAllocKeyword), type);
        }

        /// <summary>Creates a new QueryExpressionSyntax instance.</summary>
        public static QueryExpressionSyntax QueryExpression(FromClauseSyntax fromClause, QueryBodySyntax body)
        {
            return F.QueryExpression(fromClause, body);
        }

        /// <summary>Creates a new QueryBodySyntax instance.</summary>
        public static QueryBodySyntax QueryBody(SyntaxList<QueryClauseSyntax> clauses, SelectOrGroupClauseSyntax selectOrGroup, QueryContinuationSyntax continuation)
        {
            return F.QueryBody(clauses, selectOrGroup, continuation);
        }

        /// <summary>Creates a new QueryBodySyntax instance.</summary>
        public static QueryBodySyntax QueryBody(SelectOrGroupClauseSyntax selectOrGroup)
        {
            return SyntaxFactory.QueryBody(default(SyntaxList<QueryClauseSyntax>), selectOrGroup, default(QueryContinuationSyntax));
        }

        /// <summary>Creates a new FromClauseSyntax instance.</summary>
        public static FromClauseSyntax FromClause(SyntaxToken fromKeyword, TypeSyntax type, SyntaxToken identifier, SyntaxToken inKeyword, ExpressionSyntax expression)
        {
            return F.FromClause(fromKeyword, type, identifier, inKeyword, expression);
        }

        /// <summary>Creates a new FromClauseSyntax instance.</summary>
        public static FromClauseSyntax FromClause(TypeSyntax type, SyntaxToken identifier, ExpressionSyntax expression)
        {
            return SyntaxFactory.FromClause(SyntaxFactory.Token(SyntaxKind.FromKeyword), type, identifier, SyntaxFactory.Token(SyntaxKind.InKeyword), expression);
        }

        /// <summary>Creates a new FromClauseSyntax instance.</summary>
        public static FromClauseSyntax FromClause(SyntaxToken identifier, ExpressionSyntax expression)
        {
            return SyntaxFactory.FromClause(SyntaxFactory.Token(SyntaxKind.FromKeyword), default(TypeSyntax), identifier, SyntaxFactory.Token(SyntaxKind.InKeyword), expression);
        }

        /// <summary>Creates a new FromClauseSyntax instance.</summary>
        public static FromClauseSyntax FromClause(string identifier, ExpressionSyntax expression)
        {
            return SyntaxFactory.FromClause(SyntaxFactory.Token(SyntaxKind.FromKeyword), default(TypeSyntax), SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.InKeyword), expression);
        }

        /// <summary>Creates a new LetClauseSyntax instance.</summary>
        public static LetClauseSyntax LetClause(SyntaxToken letKeyword, SyntaxToken identifier, SyntaxToken equalsToken, ExpressionSyntax expression)
        {
            return F.LetClause(letKeyword, identifier, equalsToken, expression);
        }

        /// <summary>Creates a new LetClauseSyntax instance.</summary>
        public static LetClauseSyntax LetClause(SyntaxToken identifier, ExpressionSyntax expression)
        {
            return SyntaxFactory.LetClause(SyntaxFactory.Token(SyntaxKind.LetKeyword), identifier, SyntaxFactory.Token(SyntaxKind.EqualsToken), expression);
        }

        /// <summary>Creates a new LetClauseSyntax instance.</summary>
        public static LetClauseSyntax LetClause(string identifier, ExpressionSyntax expression)
        {
            return SyntaxFactory.LetClause(SyntaxFactory.Token(SyntaxKind.LetKeyword), SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.EqualsToken), expression);
        }

        /// <summary>Creates a new JoinClauseSyntax instance.</summary>
        public static JoinClauseSyntax JoinClause(SyntaxToken joinKeyword, TypeSyntax type, SyntaxToken identifier, SyntaxToken inKeyword, ExpressionSyntax inExpression, SyntaxToken onKeyword, ExpressionSyntax leftExpression, SyntaxToken equalsKeyword, ExpressionSyntax rightExpression, JoinIntoClauseSyntax into)
        {
            return F.JoinClause(joinKeyword, type, identifier, inKeyword, inExpression, onKeyword, leftExpression, equalsKeyword, rightExpression, into);
        }

        /// <summary>Creates a new JoinClauseSyntax instance.</summary>
        public static JoinClauseSyntax JoinClause(TypeSyntax type, SyntaxToken identifier, ExpressionSyntax inExpression, ExpressionSyntax leftExpression, ExpressionSyntax rightExpression, JoinIntoClauseSyntax into)
        {
            return SyntaxFactory.JoinClause(SyntaxFactory.Token(SyntaxKind.JoinKeyword), type, identifier, SyntaxFactory.Token(SyntaxKind.InKeyword), inExpression, SyntaxFactory.Token(SyntaxKind.OnKeyword), leftExpression, SyntaxFactory.Token(SyntaxKind.EqualsKeyword), rightExpression, into);
        }

        /// <summary>Creates a new JoinClauseSyntax instance.</summary>
        public static JoinClauseSyntax JoinClause(SyntaxToken identifier, ExpressionSyntax inExpression, ExpressionSyntax leftExpression, ExpressionSyntax rightExpression)
        {
            return SyntaxFactory.JoinClause(SyntaxFactory.Token(SyntaxKind.JoinKeyword), default(TypeSyntax), identifier, SyntaxFactory.Token(SyntaxKind.InKeyword), inExpression, SyntaxFactory.Token(SyntaxKind.OnKeyword), leftExpression, SyntaxFactory.Token(SyntaxKind.EqualsKeyword), rightExpression, default(JoinIntoClauseSyntax));
        }

        /// <summary>Creates a new JoinClauseSyntax instance.</summary>
        public static JoinClauseSyntax JoinClause(string identifier, ExpressionSyntax inExpression, ExpressionSyntax leftExpression, ExpressionSyntax rightExpression)
        {
            return SyntaxFactory.JoinClause(SyntaxFactory.Token(SyntaxKind.JoinKeyword), default(TypeSyntax), SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.InKeyword), inExpression, SyntaxFactory.Token(SyntaxKind.OnKeyword), leftExpression, SyntaxFactory.Token(SyntaxKind.EqualsKeyword), rightExpression, default(JoinIntoClauseSyntax));
        }

        /// <summary>Creates a new JoinIntoClauseSyntax instance.</summary>
        public static JoinIntoClauseSyntax JoinIntoClause(SyntaxToken intoKeyword, SyntaxToken identifier)
        {
            return F.JoinIntoClause(intoKeyword, identifier);
        }

        /// <summary>Creates a new JoinIntoClauseSyntax instance.</summary>
        public static JoinIntoClauseSyntax JoinIntoClause(SyntaxToken identifier)
        {
            return SyntaxFactory.JoinIntoClause(SyntaxFactory.Token(SyntaxKind.IntoKeyword), identifier);
        }

        /// <summary>Creates a new JoinIntoClauseSyntax instance.</summary>
        public static JoinIntoClauseSyntax JoinIntoClause(string identifier)
        {
            return SyntaxFactory.JoinIntoClause(SyntaxFactory.Token(SyntaxKind.IntoKeyword), SyntaxFactory.Identifier(identifier));
        }

        /// <summary>Creates a new WhereClauseSyntax instance.</summary>
        public static WhereClauseSyntax WhereClause(SyntaxToken whereKeyword, ExpressionSyntax condition)
        {
            return F.WhereClause(whereKeyword, condition);
        }

        /// <summary>Creates a new WhereClauseSyntax instance.</summary>
        public static WhereClauseSyntax WhereClause(ExpressionSyntax condition)
        {
            return SyntaxFactory.WhereClause(SyntaxFactory.Token(SyntaxKind.WhereKeyword), condition);
        }

        /// <summary>Creates a new OrderByClauseSyntax instance.</summary>
        public static OrderByClauseSyntax OrderByClause(SyntaxToken orderByKeyword, SeparatedSyntaxList<OrderingSyntax> orderings)
        {
            return F.OrderByClause(orderByKeyword, orderings);
        }

        /// <summary>Creates a new OrderByClauseSyntax instance.</summary>
        public static OrderByClauseSyntax OrderByClause(SeparatedSyntaxList<OrderingSyntax> orderings = default(SeparatedSyntaxList<OrderingSyntax>))
        {
            return SyntaxFactory.OrderByClause(SyntaxFactory.Token(SyntaxKind.OrderByKeyword), orderings);
        }

        /// <summary>Creates a new OrderingSyntax instance.</summary>
        public static OrderingSyntax Ordering(SyntaxKind kind, ExpressionSyntax expression, SyntaxToken ascendingOrDescendingKeyword)
        {
            return F.Ordering(kind, expression, ascendingOrDescendingKeyword);
        }

        /// <summary>Creates a new OrderingSyntax instance.</summary>
        public static OrderingSyntax Ordering(SyntaxKind kind, ExpressionSyntax expression)
        {
            return SyntaxFactory.Ordering(kind, expression, default(SyntaxToken));
        }

        /// <summary>Creates a new SelectClauseSyntax instance.</summary>
        public static SelectClauseSyntax SelectClause(SyntaxToken selectKeyword, ExpressionSyntax expression)
        {
            return F.SelectClause(selectKeyword, expression);
        }

        /// <summary>Creates a new SelectClauseSyntax instance.</summary>
        public static SelectClauseSyntax SelectClause(ExpressionSyntax expression)
        {
            return SyntaxFactory.SelectClause(SyntaxFactory.Token(SyntaxKind.SelectKeyword), expression);
        }

        /// <summary>Creates a new GroupClauseSyntax instance.</summary>
        public static GroupClauseSyntax GroupClause(SyntaxToken groupKeyword, ExpressionSyntax groupExpression, SyntaxToken byKeyword, ExpressionSyntax byExpression)
        {
            return F.GroupClause(groupKeyword, groupExpression, byKeyword, byExpression);
        }

        /// <summary>Creates a new GroupClauseSyntax instance.</summary>
        public static GroupClauseSyntax GroupClause(ExpressionSyntax groupExpression, ExpressionSyntax byExpression)
        {
            return SyntaxFactory.GroupClause(SyntaxFactory.Token(SyntaxKind.GroupKeyword), groupExpression, SyntaxFactory.Token(SyntaxKind.ByKeyword), byExpression);
        }

        /// <summary>Creates a new QueryContinuationSyntax instance.</summary>
        public static QueryContinuationSyntax QueryContinuation(SyntaxToken intoKeyword, SyntaxToken identifier, QueryBodySyntax body)
        {
            return F.QueryContinuation(intoKeyword, identifier, body);
        }

        /// <summary>Creates a new QueryContinuationSyntax instance.</summary>
        public static QueryContinuationSyntax QueryContinuation(SyntaxToken identifier, QueryBodySyntax body)
        {
            return SyntaxFactory.QueryContinuation(SyntaxFactory.Token(SyntaxKind.IntoKeyword), identifier, body);
        }

        /// <summary>Creates a new QueryContinuationSyntax instance.</summary>
        public static QueryContinuationSyntax QueryContinuation(string identifier, QueryBodySyntax body)
        {
            return SyntaxFactory.QueryContinuation(SyntaxFactory.Token(SyntaxKind.IntoKeyword), SyntaxFactory.Identifier(identifier), body);
        }

        /// <summary>Creates a new OmittedArraySizeExpressionSyntax instance.</summary>
        public static OmittedArraySizeExpressionSyntax OmittedArraySizeExpression(SyntaxToken omittedArraySizeExpressionToken)
        {
            return F.OmittedArraySizeExpression(omittedArraySizeExpressionToken);
        }

        /// <summary>Creates a new OmittedArraySizeExpressionSyntax instance.</summary>
        public static OmittedArraySizeExpressionSyntax OmittedArraySizeExpression()
        {
            return SyntaxFactory.OmittedArraySizeExpression(SyntaxFactory.Token(SyntaxKind.OmittedArraySizeExpressionToken));
        }

        /// <summary>Creates a new InterpolatedStringExpressionSyntax instance.</summary>
        public static InterpolatedStringExpressionSyntax InterpolatedStringExpression(SyntaxToken stringStartToken, SyntaxList<InterpolatedStringContentSyntax> contents, SyntaxToken stringEndToken)
        {
            return F.InterpolatedStringExpression(stringStartToken, contents, stringEndToken);
        }

        /// <summary>Creates a new InterpolatedStringExpressionSyntax instance.</summary>
        public static InterpolatedStringExpressionSyntax InterpolatedStringExpression(SyntaxToken stringStartToken, SyntaxList<InterpolatedStringContentSyntax> contents)
        {
            return SyntaxFactory.InterpolatedStringExpression(stringStartToken, contents, SyntaxFactory.Token(SyntaxKind.InterpolatedStringEndToken));
        }

        /// <summary>Creates a new InterpolatedStringExpressionSyntax instance.</summary>
        public static InterpolatedStringExpressionSyntax InterpolatedStringExpression(SyntaxToken stringStartToken)
        {
            return SyntaxFactory.InterpolatedStringExpression(stringStartToken, default(SyntaxList<InterpolatedStringContentSyntax>), SyntaxFactory.Token(SyntaxKind.InterpolatedStringEndToken));
        }

        /// <summary>Creates a new InterpolatedStringTextSyntax instance.</summary>
        public static InterpolatedStringTextSyntax InterpolatedStringText(SyntaxToken textToken)
        {
            return F.InterpolatedStringText(textToken);
        }

        /// <summary>Creates a new InterpolatedStringTextSyntax instance.</summary>
        public static InterpolatedStringTextSyntax InterpolatedStringText()
        {
            return SyntaxFactory.InterpolatedStringText(SyntaxFactory.Token(SyntaxKind.InterpolatedStringTextToken));
        }

        /// <summary>Creates a new InterpolationSyntax instance.</summary>
        public static InterpolationSyntax Interpolation(SyntaxToken openBraceToken, ExpressionSyntax expression, InterpolationAlignmentClauseSyntax alignmentClause, InterpolationFormatClauseSyntax formatClause, SyntaxToken closeBraceToken)
        {
            return F.Interpolation(openBraceToken, expression, alignmentClause, formatClause, closeBraceToken);
        }

        /// <summary>Creates a new InterpolationSyntax instance.</summary>
        public static InterpolationSyntax Interpolation(ExpressionSyntax expression, InterpolationAlignmentClauseSyntax alignmentClause, InterpolationFormatClauseSyntax formatClause)
        {
            return SyntaxFactory.Interpolation(SyntaxFactory.Token(SyntaxKind.OpenBraceToken), expression, alignmentClause, formatClause, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new InterpolationSyntax instance.</summary>
        public static InterpolationSyntax Interpolation(ExpressionSyntax expression)
        {
            return SyntaxFactory.Interpolation(SyntaxFactory.Token(SyntaxKind.OpenBraceToken), expression, default(InterpolationAlignmentClauseSyntax), default(InterpolationFormatClauseSyntax), SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new InterpolationAlignmentClauseSyntax instance.</summary>
        public static InterpolationAlignmentClauseSyntax InterpolationAlignmentClause(SyntaxToken commaToken, ExpressionSyntax value)
        {
            return F.InterpolationAlignmentClause(commaToken, value);
        }

        /// <summary>Creates a new InterpolationFormatClauseSyntax instance.</summary>
        public static InterpolationFormatClauseSyntax InterpolationFormatClause(SyntaxToken colonToken, SyntaxToken formatStringToken)
        {
            return F.InterpolationFormatClause(colonToken, formatStringToken);
        }

        /// <summary>Creates a new InterpolationFormatClauseSyntax instance.</summary>
        public static InterpolationFormatClauseSyntax InterpolationFormatClause(SyntaxToken colonToken)
        {
            return SyntaxFactory.InterpolationFormatClause(colonToken, SyntaxFactory.Token(SyntaxKind.InterpolatedStringTextToken));
        }

        /// <summary>Creates a new GlobalStatementSyntax instance.</summary>
        public static GlobalStatementSyntax GlobalStatement(StatementSyntax statement)
        {
            return F.GlobalStatement(statement);
        }

        /// <summary>Creates a new BlockSyntax instance.</summary>
        public static BlockSyntax Block(SyntaxToken openBraceToken, SyntaxList<StatementSyntax> statements, SyntaxToken closeBraceToken)
        {
            return F.Block(openBraceToken, statements, closeBraceToken);
        }

        /// <summary>Creates a new BlockSyntax instance.</summary>
        public static BlockSyntax Block(SyntaxList<StatementSyntax> statements = default(SyntaxList<StatementSyntax>))
        {
            return SyntaxFactory.Block(SyntaxFactory.Token(SyntaxKind.OpenBraceToken), statements, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new LocalDeclarationStatementSyntax instance.</summary>
        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(SyntaxTokenList modifiers, VariableDeclarationSyntax declaration, SyntaxToken semicolonToken)
        {
            return F.LocalDeclarationStatement(modifiers, declaration, semicolonToken);
        }

        /// <summary>Creates a new LocalDeclarationStatementSyntax instance.</summary>
        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(SyntaxTokenList modifiers, VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.LocalDeclarationStatement(modifiers, declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new LocalDeclarationStatementSyntax instance.</summary>
        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.LocalDeclarationStatement(default(SyntaxTokenList), declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new VariableDeclarationSyntax instance.</summary>
        public static VariableDeclarationSyntax VariableDeclaration(TypeSyntax type, SeparatedSyntaxList<VariableDeclaratorSyntax> variables)
        {
            return F.VariableDeclaration(type, variables);
        }

        /// <summary>Creates a new VariableDeclarationSyntax instance.</summary>
        public static VariableDeclarationSyntax VariableDeclaration(TypeSyntax type)
        {
            return SyntaxFactory.VariableDeclaration(type, default(SeparatedSyntaxList<VariableDeclaratorSyntax>));
        }

        /// <summary>Creates a new VariableDeclaratorSyntax instance.</summary>
        public static VariableDeclaratorSyntax VariableDeclarator(SyntaxToken identifier, BracketedArgumentListSyntax argumentList, EqualsValueClauseSyntax initializer)
        {
            return F.VariableDeclarator(identifier, argumentList, initializer);
        }

        /// <summary>Creates a new VariableDeclaratorSyntax instance.</summary>
        public static VariableDeclaratorSyntax VariableDeclarator(SyntaxToken identifier)
        {
            return SyntaxFactory.VariableDeclarator(identifier, default(BracketedArgumentListSyntax), default(EqualsValueClauseSyntax));
        }

        /// <summary>Creates a new VariableDeclaratorSyntax instance.</summary>
        public static VariableDeclaratorSyntax VariableDeclarator(string identifier)
        {
            return SyntaxFactory.VariableDeclarator(SyntaxFactory.Identifier(identifier), default(BracketedArgumentListSyntax), default(EqualsValueClauseSyntax));
        }

        /// <summary>Creates a new EqualsValueClauseSyntax instance.</summary>
        public static EqualsValueClauseSyntax EqualsValueClause(SyntaxToken equalsToken, ExpressionSyntax value)
        {
            return F.EqualsValueClause(equalsToken, value);
        }

        /// <summary>Creates a new EqualsValueClauseSyntax instance.</summary>
        public static EqualsValueClauseSyntax EqualsValueClause(ExpressionSyntax value)
        {
            return SyntaxFactory.EqualsValueClause(SyntaxFactory.Token(SyntaxKind.EqualsToken), value);
        }
        /*
        /// <summary>Creates a new ExpressionStatementSyntax instance.</summary>
        public static ExpressionStatementSyntax ExpressionStatement(ExpressionSyntax expression, SyntaxToken semicolonToken)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ExpressionStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ExpressionStatement(expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ExpressionStatementSyntax instance.</summary>
        public static ExpressionStatementSyntax ExpressionStatement(ExpressionSyntax expression)
        {
            return SyntaxFactory.ExpressionStatement(expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new EmptyStatementSyntax instance.</summary>
        public static EmptyStatementSyntax EmptyStatement(SyntaxToken semicolonToken)
        {
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (EmptyStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EmptyStatement((Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new EmptyStatementSyntax instance.</summary>
        public static EmptyStatementSyntax EmptyStatement()
        {
            return SyntaxFactory.EmptyStatement(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new LabeledStatementSyntax instance.</summary>
        public static LabeledStatementSyntax LabeledStatement(SyntaxToken identifier, SyntaxToken colonToken, StatementSyntax statement)
        {
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (LabeledStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.LabeledStatement((Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new LabeledStatementSyntax instance.</summary>
        public static LabeledStatementSyntax LabeledStatement(SyntaxToken identifier, StatementSyntax statement)
        {
            return SyntaxFactory.LabeledStatement(identifier, SyntaxFactory.Token(SyntaxKind.ColonToken), statement);
        }

        /// <summary>Creates a new LabeledStatementSyntax instance.</summary>
        public static LabeledStatementSyntax LabeledStatement(string identifier, StatementSyntax statement)
        {
            return SyntaxFactory.LabeledStatement(SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.ColonToken), statement);
        }

        /// <summary>Creates a new GotoStatementSyntax instance.</summary>
        public static GotoStatementSyntax GotoStatement(SyntaxKind kind, SyntaxToken gotoKeyword, SyntaxToken caseOrDefaultKeyword, ExpressionSyntax expression, SyntaxToken semicolonToken)
        {
            switch (kind)
            {
                case SyntaxKind.GotoStatement:
                case SyntaxKind.GotoCaseStatement:
                case SyntaxKind.GotoDefaultStatement:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (gotoKeyword.Kind())
            {
                case SyntaxKind.GotoKeyword:
                    break;
                default:
                    throw new ArgumentException("gotoKeyword");
            }
            switch (caseOrDefaultKeyword.Kind())
            {
                case SyntaxKind.CaseKeyword:
                case SyntaxKind.DefaultKeyword:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("caseOrDefaultKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (GotoStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.GotoStatement(kind, (Syntax.InternalSyntax.SyntaxToken)gotoKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)caseOrDefaultKeyword.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new GotoStatementSyntax instance.</summary>
        public static GotoStatementSyntax GotoStatement(SyntaxKind kind, SyntaxToken caseOrDefaultKeyword, ExpressionSyntax expression)
        {
            return SyntaxFactory.GotoStatement(kind, SyntaxFactory.Token(SyntaxKind.GotoKeyword), caseOrDefaultKeyword, expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new GotoStatementSyntax instance.</summary>
        public static GotoStatementSyntax GotoStatement(SyntaxKind kind, ExpressionSyntax expression = default(ExpressionSyntax))
        {
            return SyntaxFactory.GotoStatement(kind, SyntaxFactory.Token(SyntaxKind.GotoKeyword), default(SyntaxToken), expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new BreakStatementSyntax instance.</summary>
        public static BreakStatementSyntax BreakStatement(SyntaxToken breakKeyword, SyntaxToken semicolonToken)
        {
            switch (breakKeyword.Kind())
            {
                case SyntaxKind.BreakKeyword:
                    break;
                default:
                    throw new ArgumentException("breakKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (BreakStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.BreakStatement((Syntax.InternalSyntax.SyntaxToken)breakKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new BreakStatementSyntax instance.</summary>
        public static BreakStatementSyntax BreakStatement()
        {
            return SyntaxFactory.BreakStatement(SyntaxFactory.Token(SyntaxKind.BreakKeyword), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ContinueStatementSyntax instance.</summary>
        public static ContinueStatementSyntax ContinueStatement(SyntaxToken continueKeyword, SyntaxToken semicolonToken)
        {
            switch (continueKeyword.Kind())
            {
                case SyntaxKind.ContinueKeyword:
                    break;
                default:
                    throw new ArgumentException("continueKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ContinueStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ContinueStatement((Syntax.InternalSyntax.SyntaxToken)continueKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ContinueStatementSyntax instance.</summary>
        public static ContinueStatementSyntax ContinueStatement()
        {
            return SyntaxFactory.ContinueStatement(SyntaxFactory.Token(SyntaxKind.ContinueKeyword), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ReturnStatementSyntax instance.</summary>
        public static ReturnStatementSyntax ReturnStatement(SyntaxToken returnKeyword, ExpressionSyntax expression, SyntaxToken semicolonToken)
        {
            switch (returnKeyword.Kind())
            {
                case SyntaxKind.ReturnKeyword:
                    break;
                default:
                    throw new ArgumentException("returnKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ReturnStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ReturnStatement((Syntax.InternalSyntax.SyntaxToken)returnKeyword.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ReturnStatementSyntax instance.</summary>
        public static ReturnStatementSyntax ReturnStatement(ExpressionSyntax expression = default(ExpressionSyntax))
        {
            return SyntaxFactory.ReturnStatement(SyntaxFactory.Token(SyntaxKind.ReturnKeyword), expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ThrowStatementSyntax instance.</summary>
        public static ThrowStatementSyntax ThrowStatement(SyntaxToken throwKeyword, ExpressionSyntax expression, SyntaxToken semicolonToken)
        {
            switch (throwKeyword.Kind())
            {
                case SyntaxKind.ThrowKeyword:
                    break;
                default:
                    throw new ArgumentException("throwKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ThrowStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ThrowStatement((Syntax.InternalSyntax.SyntaxToken)throwKeyword.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ThrowStatementSyntax instance.</summary>
        public static ThrowStatementSyntax ThrowStatement(ExpressionSyntax expression = default(ExpressionSyntax))
        {
            return SyntaxFactory.ThrowStatement(SyntaxFactory.Token(SyntaxKind.ThrowKeyword), expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new YieldStatementSyntax instance.</summary>
        public static YieldStatementSyntax YieldStatement(SyntaxKind kind, SyntaxToken yieldKeyword, SyntaxToken returnOrBreakKeyword, ExpressionSyntax expression, SyntaxToken semicolonToken)
        {
            switch (kind)
            {
                case SyntaxKind.YieldReturnStatement:
                case SyntaxKind.YieldBreakStatement:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (yieldKeyword.Kind())
            {
                case SyntaxKind.YieldKeyword:
                    break;
                default:
                    throw new ArgumentException("yieldKeyword");
            }
            switch (returnOrBreakKeyword.Kind())
            {
                case SyntaxKind.ReturnKeyword:
                case SyntaxKind.BreakKeyword:
                    break;
                default:
                    throw new ArgumentException("returnOrBreakKeyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (YieldStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.YieldStatement(kind, (Syntax.InternalSyntax.SyntaxToken)yieldKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)returnOrBreakKeyword.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new YieldStatementSyntax instance.</summary>
        public static YieldStatementSyntax YieldStatement(SyntaxKind kind, ExpressionSyntax expression = default(ExpressionSyntax))
        {
            return SyntaxFactory.YieldStatement(kind, SyntaxFactory.Token(SyntaxKind.YieldKeyword), SyntaxFactory.Token(GetYieldStatementReturnOrBreakKeywordKind(kind)), expression, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new WhileStatementSyntax instance.</summary>
        public static WhileStatementSyntax WhileStatement(SyntaxToken whileKeyword, SyntaxToken openParenToken, ExpressionSyntax condition, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (whileKeyword.Kind())
            {
                case SyntaxKind.WhileKeyword:
                    break;
                default:
                    throw new ArgumentException("whileKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (WhileStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.WhileStatement((Syntax.InternalSyntax.SyntaxToken)whileKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new WhileStatementSyntax instance.</summary>
        public static WhileStatementSyntax WhileStatement(ExpressionSyntax condition, StatementSyntax statement)
        {
            return SyntaxFactory.WhileStatement(SyntaxFactory.Token(SyntaxKind.WhileKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), condition, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new DoStatementSyntax instance.</summary>
        public static DoStatementSyntax DoStatement(SyntaxToken doKeyword, StatementSyntax statement, SyntaxToken whileKeyword, SyntaxToken openParenToken, ExpressionSyntax condition, SyntaxToken closeParenToken, SyntaxToken semicolonToken)
        {
            switch (doKeyword.Kind())
            {
                case SyntaxKind.DoKeyword:
                    break;
                default:
                    throw new ArgumentException("doKeyword");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            switch (whileKeyword.Kind())
            {
                case SyntaxKind.WhileKeyword:
                    break;
                default:
                    throw new ArgumentException("whileKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (DoStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DoStatement((Syntax.InternalSyntax.SyntaxToken)doKeyword.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green, (Syntax.InternalSyntax.SyntaxToken)whileKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new DoStatementSyntax instance.</summary>
        public static DoStatementSyntax DoStatement(StatementSyntax statement, ExpressionSyntax condition)
        {
            return SyntaxFactory.DoStatement(SyntaxFactory.Token(SyntaxKind.DoKeyword), statement, SyntaxFactory.Token(SyntaxKind.WhileKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), condition, SyntaxFactory.Token(SyntaxKind.CloseParenToken), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ForStatementSyntax instance.</summary>
        public static ForStatementSyntax ForStatement(SyntaxToken forKeyword, SyntaxToken openParenToken, VariableDeclarationSyntax declaration, SeparatedSyntaxList<ExpressionSyntax> initializers, SyntaxToken firstSemicolonToken, ExpressionSyntax condition, SyntaxToken secondSemicolonToken, SeparatedSyntaxList<ExpressionSyntax> incrementors, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (forKeyword.Kind())
            {
                case SyntaxKind.ForKeyword:
                    break;
                default:
                    throw new ArgumentException("forKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (firstSemicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("firstSemicolonToken");
            }
            switch (secondSemicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("secondSemicolonToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (ForStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ForStatement((Syntax.InternalSyntax.SyntaxToken)forKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.VariableDeclarationSyntax)declaration.Green, initializers.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax>(), (Syntax.InternalSyntax.SyntaxToken)firstSemicolonToken.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)secondSemicolonToken.Node, incrementors.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new ForStatementSyntax instance.</summary>
        public static ForStatementSyntax ForStatement(VariableDeclarationSyntax declaration, SeparatedSyntaxList<ExpressionSyntax> initializers, ExpressionSyntax condition, SeparatedSyntaxList<ExpressionSyntax> incrementors, StatementSyntax statement)
        {
            return SyntaxFactory.ForStatement(SyntaxFactory.Token(SyntaxKind.ForKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), declaration, initializers, SyntaxFactory.Token(SyntaxKind.SemicolonToken), condition, SyntaxFactory.Token(SyntaxKind.SemicolonToken), incrementors, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new ForStatementSyntax instance.</summary>
        public static ForStatementSyntax ForStatement(StatementSyntax statement)
        {
            return SyntaxFactory.ForStatement(SyntaxFactory.Token(SyntaxKind.ForKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), default(VariableDeclarationSyntax), default(SeparatedSyntaxList<ExpressionSyntax>), SyntaxFactory.Token(SyntaxKind.SemicolonToken), default(ExpressionSyntax), SyntaxFactory.Token(SyntaxKind.SemicolonToken), default(SeparatedSyntaxList<ExpressionSyntax>), SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new ForEachStatementSyntax instance.</summary>
        public static ForEachStatementSyntax ForEachStatement(SyntaxToken forEachKeyword, SyntaxToken openParenToken, TypeSyntax type, SyntaxToken identifier, SyntaxToken inKeyword, ExpressionSyntax expression, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (forEachKeyword.Kind())
            {
                case SyntaxKind.ForEachKeyword:
                    break;
                default:
                    throw new ArgumentException("forEachKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (inKeyword.Kind())
            {
                case SyntaxKind.InKeyword:
                    break;
                default:
                    throw new ArgumentException("inKeyword");
            }
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (ForEachStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ForEachStatement((Syntax.InternalSyntax.SyntaxToken)forEachKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)inKeyword.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new ForEachStatementSyntax instance.</summary>
        public static ForEachStatementSyntax ForEachStatement(TypeSyntax type, SyntaxToken identifier, ExpressionSyntax expression, StatementSyntax statement)
        {
            return SyntaxFactory.ForEachStatement(SyntaxFactory.Token(SyntaxKind.ForEachKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), type, identifier, SyntaxFactory.Token(SyntaxKind.InKeyword), expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new ForEachStatementSyntax instance.</summary>
        public static ForEachStatementSyntax ForEachStatement(TypeSyntax type, string identifier, ExpressionSyntax expression, StatementSyntax statement)
        {
            return SyntaxFactory.ForEachStatement(SyntaxFactory.Token(SyntaxKind.ForEachKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), type, SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.InKeyword), expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new UsingStatementSyntax instance.</summary>
        public static UsingStatementSyntax UsingStatement(SyntaxToken usingKeyword, SyntaxToken openParenToken, VariableDeclarationSyntax declaration, ExpressionSyntax expression, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (usingKeyword.Kind())
            {
                case SyntaxKind.UsingKeyword:
                    break;
                default:
                    throw new ArgumentException("usingKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (UsingStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.UsingStatement((Syntax.InternalSyntax.SyntaxToken)usingKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.VariableDeclarationSyntax)declaration.Green, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new UsingStatementSyntax instance.</summary>
        public static UsingStatementSyntax UsingStatement(VariableDeclarationSyntax declaration, ExpressionSyntax expression, StatementSyntax statement)
        {
            return SyntaxFactory.UsingStatement(SyntaxFactory.Token(SyntaxKind.UsingKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), declaration, expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new UsingStatementSyntax instance.</summary>
        public static UsingStatementSyntax UsingStatement(StatementSyntax statement)
        {
            return SyntaxFactory.UsingStatement(SyntaxFactory.Token(SyntaxKind.UsingKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), default(VariableDeclarationSyntax), default(ExpressionSyntax), SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new FixedStatementSyntax instance.</summary>
        public static FixedStatementSyntax FixedStatement(SyntaxToken fixedKeyword, SyntaxToken openParenToken, VariableDeclarationSyntax declaration, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (fixedKeyword.Kind())
            {
                case SyntaxKind.FixedKeyword:
                    break;
                default:
                    throw new ArgumentException("fixedKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (declaration == null)
                throw new ArgumentNullException(nameof(declaration));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (FixedStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.FixedStatement((Syntax.InternalSyntax.SyntaxToken)fixedKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.VariableDeclarationSyntax)declaration.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new FixedStatementSyntax instance.</summary>
        public static FixedStatementSyntax FixedStatement(VariableDeclarationSyntax declaration, StatementSyntax statement)
        {
            return SyntaxFactory.FixedStatement(SyntaxFactory.Token(SyntaxKind.FixedKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), declaration, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new CheckedStatementSyntax instance.</summary>
        public static CheckedStatementSyntax CheckedStatement(SyntaxKind kind, SyntaxToken keyword, BlockSyntax block)
        {
            switch (kind)
            {
                case SyntaxKind.CheckedStatement:
                case SyntaxKind.UncheckedStatement:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (keyword.Kind())
            {
                case SyntaxKind.CheckedKeyword:
                case SyntaxKind.UncheckedKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            if (block == null)
                throw new ArgumentNullException(nameof(block));
            return (CheckedStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CheckedStatement(kind, (Syntax.InternalSyntax.SyntaxToken)keyword.Node, block == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)block.Green).CreateRed();
        }

        /// <summary>Creates a new CheckedStatementSyntax instance.</summary>
        public static CheckedStatementSyntax CheckedStatement(SyntaxKind kind, BlockSyntax block = default(BlockSyntax))
        {
            return SyntaxFactory.CheckedStatement(kind, SyntaxFactory.Token(GetCheckedStatementKeywordKind(kind)), block ?? SyntaxFactory.Block());
        }

        /// <summary>Creates a new UnsafeStatementSyntax instance.</summary>
        public static UnsafeStatementSyntax UnsafeStatement(SyntaxToken unsafeKeyword, BlockSyntax block)
        {
            switch (unsafeKeyword.Kind())
            {
                case SyntaxKind.UnsafeKeyword:
                    break;
                default:
                    throw new ArgumentException("unsafeKeyword");
            }
            if (block == null)
                throw new ArgumentNullException(nameof(block));
            return (UnsafeStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.UnsafeStatement((Syntax.InternalSyntax.SyntaxToken)unsafeKeyword.Node, block == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)block.Green).CreateRed();
        }

        /// <summary>Creates a new UnsafeStatementSyntax instance.</summary>
        public static UnsafeStatementSyntax UnsafeStatement(BlockSyntax block = default(BlockSyntax))
        {
            return SyntaxFactory.UnsafeStatement(SyntaxFactory.Token(SyntaxKind.UnsafeKeyword), block ?? SyntaxFactory.Block());
        }

        /// <summary>Creates a new LockStatementSyntax instance.</summary>
        public static LockStatementSyntax LockStatement(SyntaxToken lockKeyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            switch (lockKeyword.Kind())
            {
                case SyntaxKind.LockKeyword:
                    break;
                default:
                    throw new ArgumentException("lockKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (LockStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.LockStatement((Syntax.InternalSyntax.SyntaxToken)lockKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new LockStatementSyntax instance.</summary>
        public static LockStatementSyntax LockStatement(ExpressionSyntax expression, StatementSyntax statement)
        {
            return SyntaxFactory.LockStatement(SyntaxFactory.Token(SyntaxKind.LockKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement);
        }

        /// <summary>Creates a new IfStatementSyntax instance.</summary>
        public static IfStatementSyntax IfStatement(SyntaxToken ifKeyword, SyntaxToken openParenToken, ExpressionSyntax condition, SyntaxToken closeParenToken, StatementSyntax statement, ElseClauseSyntax @else)
        {
            switch (ifKeyword.Kind())
            {
                case SyntaxKind.IfKeyword:
                    break;
                default:
                    throw new ArgumentException("ifKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (IfStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.IfStatement((Syntax.InternalSyntax.SyntaxToken)ifKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green, @else == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ElseClauseSyntax)@else.Green).CreateRed();
        }

        /// <summary>Creates a new IfStatementSyntax instance.</summary>
        public static IfStatementSyntax IfStatement(ExpressionSyntax condition, StatementSyntax statement, ElseClauseSyntax @else)
        {
            return SyntaxFactory.IfStatement(SyntaxFactory.Token(SyntaxKind.IfKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), condition, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement, @else);
        }

        /// <summary>Creates a new IfStatementSyntax instance.</summary>
        public static IfStatementSyntax IfStatement(ExpressionSyntax condition, StatementSyntax statement)
        {
            return SyntaxFactory.IfStatement(SyntaxFactory.Token(SyntaxKind.IfKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), condition, SyntaxFactory.Token(SyntaxKind.CloseParenToken), statement, default(ElseClauseSyntax));
        }

        /// <summary>Creates a new ElseClauseSyntax instance.</summary>
        public static ElseClauseSyntax ElseClause(SyntaxToken elseKeyword, StatementSyntax statement)
        {
            switch (elseKeyword.Kind())
            {
                case SyntaxKind.ElseKeyword:
                    break;
                default:
                    throw new ArgumentException("elseKeyword");
            }
            if (statement == null)
                throw new ArgumentNullException(nameof(statement));
            return (ElseClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ElseClause((Syntax.InternalSyntax.SyntaxToken)elseKeyword.Node, statement == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax)statement.Green).CreateRed();
        }

        /// <summary>Creates a new ElseClauseSyntax instance.</summary>
        public static ElseClauseSyntax ElseClause(StatementSyntax statement)
        {
            return SyntaxFactory.ElseClause(SyntaxFactory.Token(SyntaxKind.ElseKeyword), statement);
        }

        /// <summary>Creates a new SwitchStatementSyntax instance.</summary>
        public static SwitchStatementSyntax SwitchStatement(SyntaxToken switchKeyword, SyntaxToken openParenToken, ExpressionSyntax expression, SyntaxToken closeParenToken, SyntaxToken openBraceToken, SyntaxList<SwitchSectionSyntax> sections, SyntaxToken closeBraceToken)
        {
            switch (switchKeyword.Kind())
            {
                case SyntaxKind.SwitchKeyword:
                    break;
                default:
                    throw new ArgumentException("switchKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            return (SwitchStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.SwitchStatement((Syntax.InternalSyntax.SyntaxToken)switchKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node, (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, sections.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SwitchSectionSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node).CreateRed();
        }

        /// <summary>Creates a new SwitchStatementSyntax instance.</summary>
        public static SwitchStatementSyntax SwitchStatement(ExpressionSyntax expression, SyntaxList<SwitchSectionSyntax> sections)
        {
            return SyntaxFactory.SwitchStatement(SyntaxFactory.Token(SyntaxKind.SwitchKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), sections, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new SwitchStatementSyntax instance.</summary>
        public static SwitchStatementSyntax SwitchStatement(ExpressionSyntax expression)
        {
            return SyntaxFactory.SwitchStatement(SyntaxFactory.Token(SyntaxKind.SwitchKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), expression, SyntaxFactory.Token(SyntaxKind.CloseParenToken), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<SwitchSectionSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new SwitchSectionSyntax instance.</summary>
        public static SwitchSectionSyntax SwitchSection(SyntaxList<SwitchLabelSyntax> labels, SyntaxList<StatementSyntax> statements)
        {
            return (SwitchSectionSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.SwitchSection(labels.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SwitchLabelSyntax>(), statements.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.StatementSyntax>()).CreateRed();
        }

        /// <summary>Creates a new SwitchSectionSyntax instance.</summary>
        public static SwitchSectionSyntax SwitchSection()
        {
            return SyntaxFactory.SwitchSection(default(SyntaxList<SwitchLabelSyntax>), default(SyntaxList<StatementSyntax>));
        }

        /// <summary>Creates a new CaseSwitchLabelSyntax instance.</summary>
        public static CaseSwitchLabelSyntax CaseSwitchLabel(SyntaxToken keyword, ExpressionSyntax value, SyntaxToken colonToken)
        {
            switch (keyword.Kind())
            {
                case SyntaxKind.CaseKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return (CaseSwitchLabelSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CaseSwitchLabel((Syntax.InternalSyntax.SyntaxToken)keyword.Node, value == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)value.Green, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node).CreateRed();
        }

        /// <summary>Creates a new CaseSwitchLabelSyntax instance.</summary>
        public static CaseSwitchLabelSyntax CaseSwitchLabel(ExpressionSyntax value, SyntaxToken colonToken)
        {
            return SyntaxFactory.CaseSwitchLabel(SyntaxFactory.Token(SyntaxKind.CaseKeyword), value, colonToken);
        }

        /// <summary>Creates a new DefaultSwitchLabelSyntax instance.</summary>
        public static DefaultSwitchLabelSyntax DefaultSwitchLabel(SyntaxToken keyword, SyntaxToken colonToken)
        {
            switch (keyword.Kind())
            {
                case SyntaxKind.DefaultKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            return (DefaultSwitchLabelSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DefaultSwitchLabel((Syntax.InternalSyntax.SyntaxToken)keyword.Node, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node).CreateRed();
        }

        /// <summary>Creates a new DefaultSwitchLabelSyntax instance.</summary>
        public static DefaultSwitchLabelSyntax DefaultSwitchLabel(SyntaxToken colonToken)
        {
            return SyntaxFactory.DefaultSwitchLabel(SyntaxFactory.Token(SyntaxKind.DefaultKeyword), colonToken);
        }

        /// <summary>Creates a new TryStatementSyntax instance.</summary>
        public static TryStatementSyntax TryStatement(SyntaxToken tryKeyword, BlockSyntax block, SyntaxList<CatchClauseSyntax> catches, FinallyClauseSyntax @finally)
        {
            switch (tryKeyword.Kind())
            {
                case SyntaxKind.TryKeyword:
                    break;
                default:
                    throw new ArgumentException("tryKeyword");
            }
            if (block == null)
                throw new ArgumentNullException(nameof(block));
            return (TryStatementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TryStatement((Syntax.InternalSyntax.SyntaxToken)tryKeyword.Node, block == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)block.Green, catches.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CatchClauseSyntax>(), @finally == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.FinallyClauseSyntax)@finally.Green).CreateRed();
        }

        /// <summary>Creates a new TryStatementSyntax instance.</summary>
        public static TryStatementSyntax TryStatement(BlockSyntax block, SyntaxList<CatchClauseSyntax> catches, FinallyClauseSyntax @finally)
        {
            return SyntaxFactory.TryStatement(SyntaxFactory.Token(SyntaxKind.TryKeyword), block, catches, @finally);
        }

        /// <summary>Creates a new TryStatementSyntax instance.</summary>
        public static TryStatementSyntax TryStatement(SyntaxList<CatchClauseSyntax> catches = default(SyntaxList<CatchClauseSyntax>))
        {
            return SyntaxFactory.TryStatement(SyntaxFactory.Token(SyntaxKind.TryKeyword), SyntaxFactory.Block(), catches, default(FinallyClauseSyntax));
        }

        /// <summary>Creates a new CatchClauseSyntax instance.</summary>
        public static CatchClauseSyntax CatchClause(SyntaxToken catchKeyword, CatchDeclarationSyntax declaration, CatchFilterClauseSyntax filter, BlockSyntax block)
        {
            switch (catchKeyword.Kind())
            {
                case SyntaxKind.CatchKeyword:
                    break;
                default:
                    throw new ArgumentException("catchKeyword");
            }
            if (block == null)
                throw new ArgumentNullException(nameof(block));
            return (CatchClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CatchClause((Syntax.InternalSyntax.SyntaxToken)catchKeyword.Node, declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CatchDeclarationSyntax)declaration.Green, filter == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CatchFilterClauseSyntax)filter.Green, block == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)block.Green).CreateRed();
        }

        /// <summary>Creates a new CatchClauseSyntax instance.</summary>
        public static CatchClauseSyntax CatchClause(CatchDeclarationSyntax declaration, CatchFilterClauseSyntax filter, BlockSyntax block)
        {
            return SyntaxFactory.CatchClause(SyntaxFactory.Token(SyntaxKind.CatchKeyword), declaration, filter, block);
        }

        /// <summary>Creates a new CatchClauseSyntax instance.</summary>
        public static CatchClauseSyntax CatchClause()
        {
            return SyntaxFactory.CatchClause(SyntaxFactory.Token(SyntaxKind.CatchKeyword), default(CatchDeclarationSyntax), default(CatchFilterClauseSyntax), SyntaxFactory.Block());
        }

        /// <summary>Creates a new CatchDeclarationSyntax instance.</summary>
        public static CatchDeclarationSyntax CatchDeclaration(SyntaxToken openParenToken, TypeSyntax type, SyntaxToken identifier, SyntaxToken closeParenToken)
        {
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (CatchDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CatchDeclaration((Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new CatchDeclarationSyntax instance.</summary>
        public static CatchDeclarationSyntax CatchDeclaration(TypeSyntax type, SyntaxToken identifier)
        {
            return SyntaxFactory.CatchDeclaration(SyntaxFactory.Token(SyntaxKind.OpenParenToken), type, identifier, SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new CatchDeclarationSyntax instance.</summary>
        public static CatchDeclarationSyntax CatchDeclaration(TypeSyntax type)
        {
            return SyntaxFactory.CatchDeclaration(SyntaxFactory.Token(SyntaxKind.OpenParenToken), type, default(SyntaxToken), SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new CatchFilterClauseSyntax instance.</summary>
        public static CatchFilterClauseSyntax CatchFilterClause(SyntaxToken whenKeyword, SyntaxToken openParenToken, ExpressionSyntax filterExpression, SyntaxToken closeParenToken)
        {
            switch (whenKeyword.Kind())
            {
                case SyntaxKind.WhenKeyword:
                    break;
                default:
                    throw new ArgumentException("whenKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            if (filterExpression == null)
                throw new ArgumentNullException(nameof(filterExpression));
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (CatchFilterClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CatchFilterClause((Syntax.InternalSyntax.SyntaxToken)whenKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, filterExpression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)filterExpression.Green, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new CatchFilterClauseSyntax instance.</summary>
        public static CatchFilterClauseSyntax CatchFilterClause(ExpressionSyntax filterExpression)
        {
            return SyntaxFactory.CatchFilterClause(SyntaxFactory.Token(SyntaxKind.WhenKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), filterExpression, SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new FinallyClauseSyntax instance.</summary>
        public static FinallyClauseSyntax FinallyClause(SyntaxToken finallyKeyword, BlockSyntax block)
        {
            switch (finallyKeyword.Kind())
            {
                case SyntaxKind.FinallyKeyword:
                    break;
                default:
                    throw new ArgumentException("finallyKeyword");
            }
            if (block == null)
                throw new ArgumentNullException(nameof(block));
            return (FinallyClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.FinallyClause((Syntax.InternalSyntax.SyntaxToken)finallyKeyword.Node, block == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)block.Green).CreateRed();
        }

        /// <summary>Creates a new FinallyClauseSyntax instance.</summary>
        public static FinallyClauseSyntax FinallyClause(BlockSyntax block = default(BlockSyntax))
        {
            return SyntaxFactory.FinallyClause(SyntaxFactory.Token(SyntaxKind.FinallyKeyword), block ?? SyntaxFactory.Block());
        }

        /// <summary>Creates a new CompilationUnitSyntax instance.</summary>
        public static CompilationUnitSyntax CompilationUnit(SyntaxList<ExternAliasDirectiveSyntax> externs, SyntaxList<UsingDirectiveSyntax> usings, SyntaxList<AttributeListSyntax> attributeLists, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken endOfFileToken)
        {
            switch (endOfFileToken.Kind())
            {
                case SyntaxKind.EndOfFileToken:
                    break;
                default:
                    throw new ArgumentException("endOfFileToken");
            }
            return (CompilationUnitSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CompilationUnit(externs.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExternAliasDirectiveSyntax>(), usings.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.UsingDirectiveSyntax>(), attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), members.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)endOfFileToken.Node).CreateRed();
        }

        /// <summary>Creates a new CompilationUnitSyntax instance.</summary>
        public static CompilationUnitSyntax CompilationUnit(SyntaxList<ExternAliasDirectiveSyntax> externs, SyntaxList<UsingDirectiveSyntax> usings, SyntaxList<AttributeListSyntax> attributeLists, SyntaxList<MemberDeclarationSyntax> members)
        {
            return SyntaxFactory.CompilationUnit(externs, usings, attributeLists, members, SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
        }

        /// <summary>Creates a new CompilationUnitSyntax instance.</summary>
        public static CompilationUnitSyntax CompilationUnit()
        {
            return SyntaxFactory.CompilationUnit(default(SyntaxList<ExternAliasDirectiveSyntax>), default(SyntaxList<UsingDirectiveSyntax>), default(SyntaxList<AttributeListSyntax>), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
        }

        /// <summary>Creates a new ExternAliasDirectiveSyntax instance.</summary>
        public static ExternAliasDirectiveSyntax ExternAliasDirective(SyntaxToken externKeyword, SyntaxToken aliasKeyword, SyntaxToken identifier, SyntaxToken semicolonToken)
        {
            switch (externKeyword.Kind())
            {
                case SyntaxKind.ExternKeyword:
                    break;
                default:
                    throw new ArgumentException("externKeyword");
            }
            switch (aliasKeyword.Kind())
            {
                case SyntaxKind.AliasKeyword:
                    break;
                default:
                    throw new ArgumentException("aliasKeyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ExternAliasDirectiveSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ExternAliasDirective((Syntax.InternalSyntax.SyntaxToken)externKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)aliasKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ExternAliasDirectiveSyntax instance.</summary>
        public static ExternAliasDirectiveSyntax ExternAliasDirective(SyntaxToken identifier)
        {
            return SyntaxFactory.ExternAliasDirective(SyntaxFactory.Token(SyntaxKind.ExternKeyword), SyntaxFactory.Token(SyntaxKind.AliasKeyword), identifier, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ExternAliasDirectiveSyntax instance.</summary>
        public static ExternAliasDirectiveSyntax ExternAliasDirective(string identifier)
        {
            return SyntaxFactory.ExternAliasDirective(SyntaxFactory.Token(SyntaxKind.ExternKeyword), SyntaxFactory.Token(SyntaxKind.AliasKeyword), SyntaxFactory.Identifier(identifier), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new UsingDirectiveSyntax instance.</summary>
        public static UsingDirectiveSyntax UsingDirective(SyntaxToken usingKeyword, SyntaxToken staticKeyword, NameEqualsSyntax alias, NameSyntax name, SyntaxToken semicolonToken)
        {
            switch (usingKeyword.Kind())
            {
                case SyntaxKind.UsingKeyword:
                    break;
                default:
                    throw new ArgumentException("usingKeyword");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (UsingDirectiveSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.UsingDirective((Syntax.InternalSyntax.SyntaxToken)usingKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)staticKeyword.Node, alias == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameEqualsSyntax)alias.Green, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new UsingDirectiveSyntax instance.</summary>
        public static UsingDirectiveSyntax UsingDirective(SyntaxToken staticKeyword, NameEqualsSyntax alias, NameSyntax name)
        {
            return SyntaxFactory.UsingDirective(SyntaxFactory.Token(SyntaxKind.UsingKeyword), staticKeyword, alias, name, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new UsingDirectiveSyntax instance.</summary>
        public static UsingDirectiveSyntax UsingDirective(NameSyntax name)
        {
            return SyntaxFactory.UsingDirective(SyntaxFactory.Token(SyntaxKind.UsingKeyword), default(SyntaxToken), default(NameEqualsSyntax), name, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new NamespaceDeclarationSyntax instance.</summary>
        public static NamespaceDeclarationSyntax NamespaceDeclaration(SyntaxToken namespaceKeyword, NameSyntax name, SyntaxToken openBraceToken, SyntaxList<ExternAliasDirectiveSyntax> externs, SyntaxList<UsingDirectiveSyntax> usings, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            switch (namespaceKeyword.Kind())
            {
                case SyntaxKind.NamespaceKeyword:
                    break;
                default:
                    throw new ArgumentException("namespaceKeyword");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (NamespaceDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.NamespaceDeclaration((Syntax.InternalSyntax.SyntaxToken)namespaceKeyword.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, externs.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExternAliasDirectiveSyntax>(), usings.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.UsingDirectiveSyntax>(), members.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new NamespaceDeclarationSyntax instance.</summary>
        public static NamespaceDeclarationSyntax NamespaceDeclaration(NameSyntax name, SyntaxList<ExternAliasDirectiveSyntax> externs, SyntaxList<UsingDirectiveSyntax> usings, SyntaxList<MemberDeclarationSyntax> members)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword), name, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), externs, usings, members, SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new NamespaceDeclarationSyntax instance.</summary>
        public static NamespaceDeclarationSyntax NamespaceDeclaration(NameSyntax name)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.Token(SyntaxKind.NamespaceKeyword), name, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<ExternAliasDirectiveSyntax>), default(SyntaxList<UsingDirectiveSyntax>), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new AttributeListSyntax instance.</summary>
        public static AttributeListSyntax AttributeList(SyntaxToken openBracketToken, AttributeTargetSpecifierSyntax target, SeparatedSyntaxList<AttributeSyntax> attributes, SyntaxToken closeBracketToken)
        {
            switch (openBracketToken.Kind())
            {
                case SyntaxKind.OpenBracketToken:
                    break;
                default:
                    throw new ArgumentException("openBracketToken");
            }
            switch (closeBracketToken.Kind())
            {
                case SyntaxKind.CloseBracketToken:
                    break;
                default:
                    throw new ArgumentException("closeBracketToken");
            }
            return (AttributeListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AttributeList((Syntax.InternalSyntax.SyntaxToken)openBracketToken.Node, target == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeTargetSpecifierSyntax)target.Green, attributes.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBracketToken.Node).CreateRed();
        }

        /// <summary>Creates a new AttributeListSyntax instance.</summary>
        public static AttributeListSyntax AttributeList(AttributeTargetSpecifierSyntax target, SeparatedSyntaxList<AttributeSyntax> attributes)
        {
            return SyntaxFactory.AttributeList(SyntaxFactory.Token(SyntaxKind.OpenBracketToken), target, attributes, SyntaxFactory.Token(SyntaxKind.CloseBracketToken));
        }

        /// <summary>Creates a new AttributeListSyntax instance.</summary>
        public static AttributeListSyntax AttributeList(SeparatedSyntaxList<AttributeSyntax> attributes = default(SeparatedSyntaxList<AttributeSyntax>))
        {
            return SyntaxFactory.AttributeList(SyntaxFactory.Token(SyntaxKind.OpenBracketToken), default(AttributeTargetSpecifierSyntax), attributes, SyntaxFactory.Token(SyntaxKind.CloseBracketToken));
        }

        /// <summary>Creates a new AttributeTargetSpecifierSyntax instance.</summary>
        public static AttributeTargetSpecifierSyntax AttributeTargetSpecifier(SyntaxToken identifier, SyntaxToken colonToken)
        {
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            return (AttributeTargetSpecifierSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AttributeTargetSpecifier((Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node).CreateRed();
        }

        /// <summary>Creates a new AttributeTargetSpecifierSyntax instance.</summary>
        public static AttributeTargetSpecifierSyntax AttributeTargetSpecifier(SyntaxToken identifier)
        {
            return SyntaxFactory.AttributeTargetSpecifier(identifier, SyntaxFactory.Token(SyntaxKind.ColonToken));
        }

        /// <summary>Creates a new AttributeSyntax instance.</summary>
        public static AttributeSyntax Attribute(NameSyntax name, AttributeArgumentListSyntax argumentList)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return (AttributeSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.Attribute(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameSyntax)name.Green, argumentList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeArgumentListSyntax)argumentList.Green).CreateRed();
        }

        /// <summary>Creates a new AttributeSyntax instance.</summary>
        public static AttributeSyntax Attribute(NameSyntax name)
        {
            return SyntaxFactory.Attribute(name, default(AttributeArgumentListSyntax));
        }

        /// <summary>Creates a new AttributeArgumentListSyntax instance.</summary>
        public static AttributeArgumentListSyntax AttributeArgumentList(SyntaxToken openParenToken, SeparatedSyntaxList<AttributeArgumentSyntax> arguments, SyntaxToken closeParenToken)
        {
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (AttributeArgumentListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AttributeArgumentList((Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, arguments.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeArgumentSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new AttributeArgumentListSyntax instance.</summary>
        public static AttributeArgumentListSyntax AttributeArgumentList(SeparatedSyntaxList<AttributeArgumentSyntax> arguments = default(SeparatedSyntaxList<AttributeArgumentSyntax>))
        {
            return SyntaxFactory.AttributeArgumentList(SyntaxFactory.Token(SyntaxKind.OpenParenToken), arguments, SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new AttributeArgumentSyntax instance.</summary>
        public static AttributeArgumentSyntax AttributeArgument(NameEqualsSyntax nameEquals, NameColonSyntax nameColon, ExpressionSyntax expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            return (AttributeArgumentSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AttributeArgument(nameEquals == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameEqualsSyntax)nameEquals.Green, nameColon == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameColonSyntax)nameColon.Green, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green).CreateRed();
        }

        /// <summary>Creates a new AttributeArgumentSyntax instance.</summary>
        public static AttributeArgumentSyntax AttributeArgument(ExpressionSyntax expression)
        {
            return SyntaxFactory.AttributeArgument(default(NameEqualsSyntax), default(NameColonSyntax), expression);
        }

        /// <summary>Creates a new NameEqualsSyntax instance.</summary>
        public static NameEqualsSyntax NameEquals(IdentifierNameSyntax name, SyntaxToken equalsToken)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (equalsToken.Kind())
            {
                case SyntaxKind.EqualsToken:
                    break;
                default:
                    throw new ArgumentException("equalsToken");
            }
            return (NameEqualsSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.NameEquals(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.IdentifierNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)equalsToken.Node).CreateRed();
        }

        /// <summary>Creates a new NameEqualsSyntax instance.</summary>
        public static NameEqualsSyntax NameEquals(IdentifierNameSyntax name)
        {
            return SyntaxFactory.NameEquals(name, SyntaxFactory.Token(SyntaxKind.EqualsToken));
        }

        /// <summary>Creates a new NameEqualsSyntax instance.</summary>
        public static NameEqualsSyntax NameEquals(string name)
        {
            return SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName(name), SyntaxFactory.Token(SyntaxKind.EqualsToken));
        }

        /// <summary>Creates a new TypeParameterListSyntax instance.</summary>
        public static TypeParameterListSyntax TypeParameterList(SyntaxToken lessThanToken, SeparatedSyntaxList<TypeParameterSyntax> parameters, SyntaxToken greaterThanToken)
        {
            switch (lessThanToken.Kind())
            {
                case SyntaxKind.LessThanToken:
                    break;
                default:
                    throw new ArgumentException("lessThanToken");
            }
            switch (greaterThanToken.Kind())
            {
                case SyntaxKind.GreaterThanToken:
                    break;
                default:
                    throw new ArgumentException("greaterThanToken");
            }
            return (TypeParameterListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TypeParameterList((Syntax.InternalSyntax.SyntaxToken)lessThanToken.Node, parameters.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterSyntax>(), (Syntax.InternalSyntax.SyntaxToken)greaterThanToken.Node).CreateRed();
        }

        /// <summary>Creates a new TypeParameterListSyntax instance.</summary>
        public static TypeParameterListSyntax TypeParameterList(SeparatedSyntaxList<TypeParameterSyntax> parameters = default(SeparatedSyntaxList<TypeParameterSyntax>))
        {
            return SyntaxFactory.TypeParameterList(SyntaxFactory.Token(SyntaxKind.LessThanToken), parameters, SyntaxFactory.Token(SyntaxKind.GreaterThanToken));
        }

        /// <summary>Creates a new TypeParameterSyntax instance.</summary>
        public static TypeParameterSyntax TypeParameter(SyntaxList<AttributeListSyntax> attributeLists, SyntaxToken varianceKeyword, SyntaxToken identifier)
        {
            switch (varianceKeyword.Kind())
            {
                case SyntaxKind.InKeyword:
                case SyntaxKind.OutKeyword:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("varianceKeyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            return (TypeParameterSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TypeParameter(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), (Syntax.InternalSyntax.SyntaxToken)varianceKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node).CreateRed();
        }

        /// <summary>Creates a new TypeParameterSyntax instance.</summary>
        public static TypeParameterSyntax TypeParameter(SyntaxToken identifier)
        {
            return SyntaxFactory.TypeParameter(default(SyntaxList<AttributeListSyntax>), default(SyntaxToken), identifier);
        }

        /// <summary>Creates a new TypeParameterSyntax instance.</summary>
        public static TypeParameterSyntax TypeParameter(string identifier)
        {
            return SyntaxFactory.TypeParameter(default(SyntaxList<AttributeListSyntax>), default(SyntaxToken), SyntaxFactory.Identifier(identifier));
        }

        /// <summary>Creates a new ClassDeclarationSyntax instance.</summary>
        public static ClassDeclarationSyntax ClassDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken keyword, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxToken openBraceToken, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            switch (keyword.Kind())
            {
                case SyntaxKind.ClassKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ClassDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ClassDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)keyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, typeParameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterListSyntax)typeParameterList.Green, baseList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BaseListSyntax)baseList.Green, constraintClauses.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintClauseSyntax>(), (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, members.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ClassDeclarationSyntax instance.</summary>
        public static ClassDeclarationSyntax ClassDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxList<MemberDeclarationSyntax> members)
        {
            return SyntaxFactory.ClassDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.ClassKeyword), identifier, typeParameterList, baseList, constraintClauses, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), members, SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new ClassDeclarationSyntax instance.</summary>
        public static ClassDeclarationSyntax ClassDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.ClassDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.ClassKeyword), identifier, default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new ClassDeclarationSyntax instance.</summary>
        public static ClassDeclarationSyntax ClassDeclaration(string identifier)
        {
            return SyntaxFactory.ClassDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.ClassKeyword), SyntaxFactory.Identifier(identifier), default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new StructDeclarationSyntax instance.</summary>
        public static StructDeclarationSyntax StructDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken keyword, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxToken openBraceToken, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            switch (keyword.Kind())
            {
                case SyntaxKind.StructKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (StructDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.StructDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)keyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, typeParameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterListSyntax)typeParameterList.Green, baseList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BaseListSyntax)baseList.Green, constraintClauses.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintClauseSyntax>(), (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, members.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new StructDeclarationSyntax instance.</summary>
        public static StructDeclarationSyntax StructDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxList<MemberDeclarationSyntax> members)
        {
            return SyntaxFactory.StructDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.StructKeyword), identifier, typeParameterList, baseList, constraintClauses, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), members, SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new StructDeclarationSyntax instance.</summary>
        public static StructDeclarationSyntax StructDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.StructDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.StructKeyword), identifier, default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new StructDeclarationSyntax instance.</summary>
        public static StructDeclarationSyntax StructDeclaration(string identifier)
        {
            return SyntaxFactory.StructDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.StructKeyword), SyntaxFactory.Identifier(identifier), default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new InterfaceDeclarationSyntax instance.</summary>
        public static InterfaceDeclarationSyntax InterfaceDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken keyword, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxToken openBraceToken, SyntaxList<MemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            switch (keyword.Kind())
            {
                case SyntaxKind.InterfaceKeyword:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (InterfaceDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.InterfaceDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)keyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, typeParameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterListSyntax)typeParameterList.Green, baseList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BaseListSyntax)baseList.Green, constraintClauses.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintClauseSyntax>(), (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, members.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new InterfaceDeclarationSyntax instance.</summary>
        public static InterfaceDeclarationSyntax InterfaceDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, BaseListSyntax baseList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxList<MemberDeclarationSyntax> members)
        {
            return SyntaxFactory.InterfaceDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.InterfaceKeyword), identifier, typeParameterList, baseList, constraintClauses, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), members, SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new InterfaceDeclarationSyntax instance.</summary>
        public static InterfaceDeclarationSyntax InterfaceDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.InterfaceDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.InterfaceKeyword), identifier, default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new InterfaceDeclarationSyntax instance.</summary>
        public static InterfaceDeclarationSyntax InterfaceDeclaration(string identifier)
        {
            return SyntaxFactory.InterfaceDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.InterfaceKeyword), SyntaxFactory.Identifier(identifier), default(TypeParameterListSyntax), default(BaseListSyntax), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SyntaxList<MemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new EnumDeclarationSyntax instance.</summary>
        public static EnumDeclarationSyntax EnumDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken enumKeyword, SyntaxToken identifier, BaseListSyntax baseList, SyntaxToken openBraceToken, SeparatedSyntaxList<EnumMemberDeclarationSyntax> members, SyntaxToken closeBraceToken, SyntaxToken semicolonToken)
        {
            switch (enumKeyword.Kind())
            {
                case SyntaxKind.EnumKeyword:
                    break;
                default:
                    throw new ArgumentException("enumKeyword");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (EnumDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EnumDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)enumKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, baseList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BaseListSyntax)baseList.Green, (Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, members.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.EnumMemberDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new EnumDeclarationSyntax instance.</summary>
        public static EnumDeclarationSyntax EnumDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, BaseListSyntax baseList, SeparatedSyntaxList<EnumMemberDeclarationSyntax> members)
        {
            return SyntaxFactory.EnumDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.EnumKeyword), identifier, baseList, SyntaxFactory.Token(SyntaxKind.OpenBraceToken), members, SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new EnumDeclarationSyntax instance.</summary>
        public static EnumDeclarationSyntax EnumDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.EnumDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.EnumKeyword), identifier, default(BaseListSyntax), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SeparatedSyntaxList<EnumMemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new EnumDeclarationSyntax instance.</summary>
        public static EnumDeclarationSyntax EnumDeclaration(string identifier)
        {
            return SyntaxFactory.EnumDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.EnumKeyword), SyntaxFactory.Identifier(identifier), default(BaseListSyntax), SyntaxFactory.Token(SyntaxKind.OpenBraceToken), default(SeparatedSyntaxList<EnumMemberDeclarationSyntax>), SyntaxFactory.Token(SyntaxKind.CloseBraceToken), default(SyntaxToken));
        }

        /// <summary>Creates a new DelegateDeclarationSyntax instance.</summary>
        public static DelegateDeclarationSyntax DelegateDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken delegateKeyword, TypeSyntax returnType, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, ParameterListSyntax parameterList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, SyntaxToken semicolonToken)
        {
            switch (delegateKeyword.Kind())
            {
                case SyntaxKind.DelegateKeyword:
                    break;
                default:
                    throw new ArgumentException("delegateKeyword");
            }
            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (DelegateDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DelegateDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)delegateKeyword.Node, returnType == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)returnType.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, typeParameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterListSyntax)typeParameterList.Green, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, constraintClauses.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintClauseSyntax>(), (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new DelegateDeclarationSyntax instance.</summary>
        public static DelegateDeclarationSyntax DelegateDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax returnType, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, ParameterListSyntax parameterList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses)
        {
            return SyntaxFactory.DelegateDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.DelegateKeyword), returnType, identifier, typeParameterList, parameterList, constraintClauses, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new DelegateDeclarationSyntax instance.</summary>
        public static DelegateDeclarationSyntax DelegateDeclaration(TypeSyntax returnType, SyntaxToken identifier)
        {
            return SyntaxFactory.DelegateDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.DelegateKeyword), returnType, identifier, default(TypeParameterListSyntax), SyntaxFactory.ParameterList(), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new DelegateDeclarationSyntax instance.</summary>
        public static DelegateDeclarationSyntax DelegateDeclaration(TypeSyntax returnType, string identifier)
        {
            return SyntaxFactory.DelegateDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.DelegateKeyword), returnType, SyntaxFactory.Identifier(identifier), default(TypeParameterListSyntax), SyntaxFactory.ParameterList(), default(SyntaxList<TypeParameterConstraintClauseSyntax>), SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new EnumMemberDeclarationSyntax instance.</summary>
        public static EnumMemberDeclarationSyntax EnumMemberDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxToken identifier, EqualsValueClauseSyntax equalsValue)
        {
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            return (EnumMemberDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EnumMemberDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), (Syntax.InternalSyntax.SyntaxToken)identifier.Node, equalsValue == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.EqualsValueClauseSyntax)equalsValue.Green).CreateRed();
        }

        /// <summary>Creates a new EnumMemberDeclarationSyntax instance.</summary>
        public static EnumMemberDeclarationSyntax EnumMemberDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.EnumMemberDeclaration(default(SyntaxList<AttributeListSyntax>), identifier, default(EqualsValueClauseSyntax));
        }

        /// <summary>Creates a new EnumMemberDeclarationSyntax instance.</summary>
        public static EnumMemberDeclarationSyntax EnumMemberDeclaration(string identifier)
        {
            return SyntaxFactory.EnumMemberDeclaration(default(SyntaxList<AttributeListSyntax>), SyntaxFactory.Identifier(identifier), default(EqualsValueClauseSyntax));
        }

        /// <summary>Creates a new BaseListSyntax instance.</summary>
        public static BaseListSyntax BaseList(SyntaxToken colonToken, SeparatedSyntaxList<BaseTypeSyntax> types)
        {
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            return (BaseListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.BaseList((Syntax.InternalSyntax.SyntaxToken)colonToken.Node, types.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BaseTypeSyntax>()).CreateRed();
        }

        /// <summary>Creates a new BaseListSyntax instance.</summary>
        public static BaseListSyntax BaseList(SeparatedSyntaxList<BaseTypeSyntax> types = default(SeparatedSyntaxList<BaseTypeSyntax>))
        {
            return SyntaxFactory.BaseList(SyntaxFactory.Token(SyntaxKind.ColonToken), types);
        }

        /// <summary>Creates a new SimpleBaseTypeSyntax instance.</summary>
        public static SimpleBaseTypeSyntax SimpleBaseType(TypeSyntax type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (SimpleBaseTypeSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.SimpleBaseType(type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green).CreateRed();
        }

        /// <summary>Creates a new TypeParameterConstraintClauseSyntax instance.</summary>
        public static TypeParameterConstraintClauseSyntax TypeParameterConstraintClause(SyntaxToken whereKeyword, IdentifierNameSyntax name, SyntaxToken colonToken, SeparatedSyntaxList<TypeParameterConstraintSyntax> constraints)
        {
            switch (whereKeyword.Kind())
            {
                case SyntaxKind.WhereKeyword:
                    break;
                default:
                    throw new ArgumentException("whereKeyword");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            return (TypeParameterConstraintClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TypeParameterConstraintClause((Syntax.InternalSyntax.SyntaxToken)whereKeyword.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.IdentifierNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node, constraints.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintSyntax>()).CreateRed();
        }

        /// <summary>Creates a new TypeParameterConstraintClauseSyntax instance.</summary>
        public static TypeParameterConstraintClauseSyntax TypeParameterConstraintClause(IdentifierNameSyntax name, SeparatedSyntaxList<TypeParameterConstraintSyntax> constraints)
        {
            return SyntaxFactory.TypeParameterConstraintClause(SyntaxFactory.Token(SyntaxKind.WhereKeyword), name, SyntaxFactory.Token(SyntaxKind.ColonToken), constraints);
        }

        /// <summary>Creates a new TypeParameterConstraintClauseSyntax instance.</summary>
        public static TypeParameterConstraintClauseSyntax TypeParameterConstraintClause(IdentifierNameSyntax name)
        {
            return SyntaxFactory.TypeParameterConstraintClause(SyntaxFactory.Token(SyntaxKind.WhereKeyword), name, SyntaxFactory.Token(SyntaxKind.ColonToken), default(SeparatedSyntaxList<TypeParameterConstraintSyntax>));
        }

        /// <summary>Creates a new TypeParameterConstraintClauseSyntax instance.</summary>
        public static TypeParameterConstraintClauseSyntax TypeParameterConstraintClause(string name)
        {
            return SyntaxFactory.TypeParameterConstraintClause(SyntaxFactory.Token(SyntaxKind.WhereKeyword), SyntaxFactory.IdentifierName(name), SyntaxFactory.Token(SyntaxKind.ColonToken), default(SeparatedSyntaxList<TypeParameterConstraintSyntax>));
        }

        /// <summary>Creates a new ConstructorConstraintSyntax instance.</summary>
        public static ConstructorConstraintSyntax ConstructorConstraint(SyntaxToken newKeyword, SyntaxToken openParenToken, SyntaxToken closeParenToken)
        {
            switch (newKeyword.Kind())
            {
                case SyntaxKind.NewKeyword:
                    break;
                default:
                    throw new ArgumentException("newKeyword");
            }
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (ConstructorConstraintSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ConstructorConstraint((Syntax.InternalSyntax.SyntaxToken)newKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new ConstructorConstraintSyntax instance.</summary>
        public static ConstructorConstraintSyntax ConstructorConstraint()
        {
            return SyntaxFactory.ConstructorConstraint(SyntaxFactory.Token(SyntaxKind.NewKeyword), SyntaxFactory.Token(SyntaxKind.OpenParenToken), SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new ClassOrStructConstraintSyntax instance.</summary>
        public static ClassOrStructConstraintSyntax ClassOrStructConstraint(SyntaxKind kind, SyntaxToken classOrStructKeyword)
        {
            switch (kind)
            {
                case SyntaxKind.ClassConstraint:
                case SyntaxKind.StructConstraint:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (classOrStructKeyword.Kind())
            {
                case SyntaxKind.ClassKeyword:
                case SyntaxKind.StructKeyword:
                    break;
                default:
                    throw new ArgumentException("classOrStructKeyword");
            }
            return (ClassOrStructConstraintSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ClassOrStructConstraint(kind, (Syntax.InternalSyntax.SyntaxToken)classOrStructKeyword.Node).CreateRed();
        }

        /// <summary>Creates a new ClassOrStructConstraintSyntax instance.</summary>
        public static ClassOrStructConstraintSyntax ClassOrStructConstraint(SyntaxKind kind)
        {
            return SyntaxFactory.ClassOrStructConstraint(kind, SyntaxFactory.Token(GetClassOrStructConstraintClassOrStructKeywordKind(kind)));
        }

        /// <summary>Creates a new TypeConstraintSyntax instance.</summary>
        public static TypeConstraintSyntax TypeConstraint(TypeSyntax type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (TypeConstraintSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TypeConstraint(type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green).CreateRed();
        }

        /// <summary>Creates a new FieldDeclarationSyntax instance.</summary>
        public static FieldDeclarationSyntax FieldDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, VariableDeclarationSyntax declaration, SyntaxToken semicolonToken)
        {
            if (declaration == null)
                throw new ArgumentNullException(nameof(declaration));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (FieldDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.FieldDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.VariableDeclarationSyntax)declaration.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new FieldDeclarationSyntax instance.</summary>
        public static FieldDeclarationSyntax FieldDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.FieldDeclaration(attributeLists, modifiers, declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new FieldDeclarationSyntax instance.</summary>
        public static FieldDeclarationSyntax FieldDeclaration(VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.FieldDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new EventFieldDeclarationSyntax instance.</summary>
        public static EventFieldDeclarationSyntax EventFieldDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken eventKeyword, VariableDeclarationSyntax declaration, SyntaxToken semicolonToken)
        {
            switch (eventKeyword.Kind())
            {
                case SyntaxKind.EventKeyword:
                    break;
                default:
                    throw new ArgumentException("eventKeyword");
            }
            if (declaration == null)
                throw new ArgumentNullException(nameof(declaration));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (EventFieldDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EventFieldDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)eventKeyword.Node, declaration == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.VariableDeclarationSyntax)declaration.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new EventFieldDeclarationSyntax instance.</summary>
        public static EventFieldDeclarationSyntax EventFieldDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.EventFieldDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.EventKeyword), declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new EventFieldDeclarationSyntax instance.</summary>
        public static EventFieldDeclarationSyntax EventFieldDeclaration(VariableDeclarationSyntax declaration)
        {
            return SyntaxFactory.EventFieldDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.EventKeyword), declaration, SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        /// <summary>Creates a new ExplicitInterfaceSpecifierSyntax instance.</summary>
        public static ExplicitInterfaceSpecifierSyntax ExplicitInterfaceSpecifier(NameSyntax name, SyntaxToken dotToken)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (dotToken.Kind())
            {
                case SyntaxKind.DotToken:
                    break;
                default:
                    throw new ArgumentException("dotToken");
            }
            return (ExplicitInterfaceSpecifierSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ExplicitInterfaceSpecifier(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.NameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)dotToken.Node).CreateRed();
        }

        /// <summary>Creates a new ExplicitInterfaceSpecifierSyntax instance.</summary>
        public static ExplicitInterfaceSpecifierSyntax ExplicitInterfaceSpecifier(NameSyntax name)
        {
            return SyntaxFactory.ExplicitInterfaceSpecifier(name, SyntaxFactory.Token(SyntaxKind.DotToken));
        }

        /// <summary>Creates a new MethodDeclarationSyntax instance.</summary>
        public static MethodDeclarationSyntax MethodDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax returnType, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, ParameterListSyntax parameterList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, SyntaxToken semicolonToken)
        {
            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (MethodDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.MethodDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), returnType == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)returnType.Green, explicitInterfaceSpecifier == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExplicitInterfaceSpecifierSyntax)explicitInterfaceSpecifier.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, typeParameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterListSyntax)typeParameterList.Green, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, constraintClauses.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeParameterConstraintClauseSyntax>(), body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, expressionBody == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArrowExpressionClauseSyntax)expressionBody.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new MethodDeclarationSyntax instance.</summary>
        public static MethodDeclarationSyntax MethodDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax returnType, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, TypeParameterListSyntax typeParameterList, ParameterListSyntax parameterList, SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody)
        {
            return SyntaxFactory.MethodDeclaration(attributeLists, modifiers, returnType, explicitInterfaceSpecifier, identifier, typeParameterList, parameterList, constraintClauses, body, expressionBody, default(SyntaxToken));
        }

        /// <summary>Creates a new MethodDeclarationSyntax instance.</summary>
        public static MethodDeclarationSyntax MethodDeclaration(TypeSyntax returnType, SyntaxToken identifier)
        {
            return SyntaxFactory.MethodDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), returnType, default(ExplicitInterfaceSpecifierSyntax), identifier, default(TypeParameterListSyntax), SyntaxFactory.ParameterList(), default(SyntaxList<TypeParameterConstraintClauseSyntax>), default(BlockSyntax), default(ArrowExpressionClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new MethodDeclarationSyntax instance.</summary>
        public static MethodDeclarationSyntax MethodDeclaration(TypeSyntax returnType, string identifier)
        {
            return SyntaxFactory.MethodDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), returnType, default(ExplicitInterfaceSpecifierSyntax), SyntaxFactory.Identifier(identifier), default(TypeParameterListSyntax), SyntaxFactory.ParameterList(), default(SyntaxList<TypeParameterConstraintClauseSyntax>), default(BlockSyntax), default(ArrowExpressionClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new OperatorDeclarationSyntax instance.</summary>
        public static OperatorDeclarationSyntax OperatorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax returnType, SyntaxToken operatorKeyword, SyntaxToken operatorToken, ParameterListSyntax parameterList, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, SyntaxToken semicolonToken)
        {
            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));
            switch (operatorKeyword.Kind())
            {
                case SyntaxKind.OperatorKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorKeyword");
            }
            switch (operatorToken.Kind())
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.ExclamationToken:
                case SyntaxKind.TildeToken:
                case SyntaxKind.PlusPlusToken:
                case SyntaxKind.MinusMinusToken:
                case SyntaxKind.AsteriskToken:
                case SyntaxKind.SlashToken:
                case SyntaxKind.PercentToken:
                case SyntaxKind.LessThanLessThanToken:
                case SyntaxKind.GreaterThanGreaterThanToken:
                case SyntaxKind.BarToken:
                case SyntaxKind.AmpersandToken:
                case SyntaxKind.CaretToken:
                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.ExclamationEqualsToken:
                case SyntaxKind.LessThanToken:
                case SyntaxKind.LessThanEqualsToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.GreaterThanEqualsToken:
                case SyntaxKind.FalseKeyword:
                case SyntaxKind.TrueKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorToken");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (OperatorDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.OperatorDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), returnType == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)returnType.Green, (Syntax.InternalSyntax.SyntaxToken)operatorKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)operatorToken.Node, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, expressionBody == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArrowExpressionClauseSyntax)expressionBody.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new OperatorDeclarationSyntax instance.</summary>
        public static OperatorDeclarationSyntax OperatorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax returnType, SyntaxToken operatorToken, ParameterListSyntax parameterList, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody)
        {
            return SyntaxFactory.OperatorDeclaration(attributeLists, modifiers, returnType, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), operatorToken, parameterList, body, expressionBody, default(SyntaxToken));
        }

        /// <summary>Creates a new OperatorDeclarationSyntax instance.</summary>
        public static OperatorDeclarationSyntax OperatorDeclaration(TypeSyntax returnType, SyntaxToken operatorToken)
        {
            return SyntaxFactory.OperatorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), returnType, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), operatorToken, SyntaxFactory.ParameterList(), default(BlockSyntax), default(ArrowExpressionClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new ConversionOperatorDeclarationSyntax instance.</summary>
        public static ConversionOperatorDeclarationSyntax ConversionOperatorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken implicitOrExplicitKeyword, SyntaxToken operatorKeyword, TypeSyntax type, ParameterListSyntax parameterList, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, SyntaxToken semicolonToken)
        {
            switch (implicitOrExplicitKeyword.Kind())
            {
                case SyntaxKind.ImplicitKeyword:
                case SyntaxKind.ExplicitKeyword:
                    break;
                default:
                    throw new ArgumentException("implicitOrExplicitKeyword");
            }
            switch (operatorKeyword.Kind())
            {
                case SyntaxKind.OperatorKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorKeyword");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ConversionOperatorDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ConversionOperatorDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)implicitOrExplicitKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)operatorKeyword.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, expressionBody == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArrowExpressionClauseSyntax)expressionBody.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ConversionOperatorDeclarationSyntax instance.</summary>
        public static ConversionOperatorDeclarationSyntax ConversionOperatorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken implicitOrExplicitKeyword, TypeSyntax type, ParameterListSyntax parameterList, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody)
        {
            return SyntaxFactory.ConversionOperatorDeclaration(attributeLists, modifiers, implicitOrExplicitKeyword, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), type, parameterList, body, expressionBody, default(SyntaxToken));
        }

        /// <summary>Creates a new ConversionOperatorDeclarationSyntax instance.</summary>
        public static ConversionOperatorDeclarationSyntax ConversionOperatorDeclaration(SyntaxToken implicitOrExplicitKeyword, TypeSyntax type)
        {
            return SyntaxFactory.ConversionOperatorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), implicitOrExplicitKeyword, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), type, SyntaxFactory.ParameterList(), default(BlockSyntax), default(ArrowExpressionClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new ConstructorDeclarationSyntax instance.</summary>
        public static ConstructorDeclarationSyntax ConstructorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, ParameterListSyntax parameterList, ConstructorInitializerSyntax initializer, BlockSyntax body, SyntaxToken semicolonToken)
        {
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (ConstructorDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ConstructorDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)identifier.Node, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, initializer == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ConstructorInitializerSyntax)initializer.Green, body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new ConstructorDeclarationSyntax instance.</summary>
        public static ConstructorDeclarationSyntax ConstructorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, ParameterListSyntax parameterList, ConstructorInitializerSyntax initializer, BlockSyntax body)
        {
            return SyntaxFactory.ConstructorDeclaration(attributeLists, modifiers, identifier, parameterList, initializer, body, default(SyntaxToken));
        }

        /// <summary>Creates a new ConstructorDeclarationSyntax instance.</summary>
        public static ConstructorDeclarationSyntax ConstructorDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.ConstructorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), identifier, SyntaxFactory.ParameterList(), default(ConstructorInitializerSyntax), default(BlockSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new ConstructorDeclarationSyntax instance.</summary>
        public static ConstructorDeclarationSyntax ConstructorDeclaration(string identifier)
        {
            return SyntaxFactory.ConstructorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Identifier(identifier), SyntaxFactory.ParameterList(), default(ConstructorInitializerSyntax), default(BlockSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new ConstructorInitializerSyntax instance.</summary>
        public static ConstructorInitializerSyntax ConstructorInitializer(SyntaxKind kind, SyntaxToken colonToken, SyntaxToken thisOrBaseKeyword, ArgumentListSyntax argumentList)
        {
            switch (kind)
            {
                case SyntaxKind.BaseConstructorInitializer:
                case SyntaxKind.ThisConstructorInitializer:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            switch (thisOrBaseKeyword.Kind())
            {
                case SyntaxKind.BaseKeyword:
                case SyntaxKind.ThisKeyword:
                    break;
                default:
                    throw new ArgumentException("thisOrBaseKeyword");
            }
            if (argumentList == null)
                throw new ArgumentNullException(nameof(argumentList));
            return (ConstructorInitializerSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ConstructorInitializer(kind, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node, (Syntax.InternalSyntax.SyntaxToken)thisOrBaseKeyword.Node, argumentList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArgumentListSyntax)argumentList.Green).CreateRed();
        }

        /// <summary>Creates a new ConstructorInitializerSyntax instance.</summary>
        public static ConstructorInitializerSyntax ConstructorInitializer(SyntaxKind kind, ArgumentListSyntax argumentList = default(ArgumentListSyntax))
        {
            return SyntaxFactory.ConstructorInitializer(kind, SyntaxFactory.Token(SyntaxKind.ColonToken), SyntaxFactory.Token(GetConstructorInitializerThisOrBaseKeywordKind(kind)), argumentList ?? SyntaxFactory.ArgumentList());
        }

        /// <summary>Creates a new DestructorDeclarationSyntax instance.</summary>
        public static DestructorDeclarationSyntax DestructorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken tildeToken, SyntaxToken identifier, ParameterListSyntax parameterList, BlockSyntax body, SyntaxToken semicolonToken)
        {
            switch (tildeToken.Kind())
            {
                case SyntaxKind.TildeToken:
                    break;
                default:
                    throw new ArgumentException("tildeToken");
            }
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (DestructorDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DestructorDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)tildeToken.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterListSyntax)parameterList.Green, body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new DestructorDeclarationSyntax instance.</summary>
        public static DestructorDeclarationSyntax DestructorDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, ParameterListSyntax parameterList, BlockSyntax body)
        {
            return SyntaxFactory.DestructorDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.TildeToken), identifier, parameterList, body, default(SyntaxToken));
        }

        /// <summary>Creates a new DestructorDeclarationSyntax instance.</summary>
        public static DestructorDeclarationSyntax DestructorDeclaration(SyntaxToken identifier)
        {
            return SyntaxFactory.DestructorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.TildeToken), identifier, SyntaxFactory.ParameterList(), default(BlockSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new DestructorDeclarationSyntax instance.</summary>
        public static DestructorDeclarationSyntax DestructorDeclaration(string identifier)
        {
            return SyntaxFactory.DestructorDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.TildeToken), SyntaxFactory.Identifier(identifier), SyntaxFactory.ParameterList(), default(BlockSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new PropertyDeclarationSyntax instance.</summary>
        public static PropertyDeclarationSyntax PropertyDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, AccessorListSyntax accessorList, ArrowExpressionClauseSyntax expressionBody, EqualsValueClauseSyntax initializer, SyntaxToken semicolonToken)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (PropertyDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.PropertyDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, explicitInterfaceSpecifier == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExplicitInterfaceSpecifierSyntax)explicitInterfaceSpecifier.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, accessorList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AccessorListSyntax)accessorList.Green, expressionBody == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArrowExpressionClauseSyntax)expressionBody.Green, initializer == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.EqualsValueClauseSyntax)initializer.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new PropertyDeclarationSyntax instance.</summary>
        public static PropertyDeclarationSyntax PropertyDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, AccessorListSyntax accessorList, ArrowExpressionClauseSyntax expressionBody, EqualsValueClauseSyntax initializer)
        {
            return SyntaxFactory.PropertyDeclaration(attributeLists, modifiers, type, explicitInterfaceSpecifier, identifier, accessorList, expressionBody, initializer, default(SyntaxToken));
        }

        /// <summary>Creates a new PropertyDeclarationSyntax instance.</summary>
        public static PropertyDeclarationSyntax PropertyDeclaration(TypeSyntax type, SyntaxToken identifier)
        {
            return SyntaxFactory.PropertyDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), type, default(ExplicitInterfaceSpecifierSyntax), identifier, default(AccessorListSyntax), default(ArrowExpressionClauseSyntax), default(EqualsValueClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new PropertyDeclarationSyntax instance.</summary>
        public static PropertyDeclarationSyntax PropertyDeclaration(TypeSyntax type, string identifier)
        {
            return SyntaxFactory.PropertyDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), type, default(ExplicitInterfaceSpecifierSyntax), SyntaxFactory.Identifier(identifier), default(AccessorListSyntax), default(ArrowExpressionClauseSyntax), default(EqualsValueClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new ArrowExpressionClauseSyntax instance.</summary>
        public static ArrowExpressionClauseSyntax ArrowExpressionClause(SyntaxToken arrowToken, ExpressionSyntax expression)
        {
            switch (arrowToken.Kind())
            {
                case SyntaxKind.EqualsGreaterThanToken:
                    break;
                default:
                    throw new ArgumentException("arrowToken");
            }
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            return (ArrowExpressionClauseSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ArrowExpressionClause((Syntax.InternalSyntax.SyntaxToken)arrowToken.Node, expression == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)expression.Green).CreateRed();
        }

        /// <summary>Creates a new ArrowExpressionClauseSyntax instance.</summary>
        public static ArrowExpressionClauseSyntax ArrowExpressionClause(ExpressionSyntax expression)
        {
            return SyntaxFactory.ArrowExpressionClause(SyntaxFactory.Token(SyntaxKind.EqualsGreaterThanToken), expression);
        }

        /// <summary>Creates a new EventDeclarationSyntax instance.</summary>
        public static EventDeclarationSyntax EventDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken eventKeyword, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, AccessorListSyntax accessorList)
        {
            switch (eventKeyword.Kind())
            {
                case SyntaxKind.EventKeyword:
                    break;
                default:
                    throw new ArgumentException("eventKeyword");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            if (accessorList == null)
                throw new ArgumentNullException(nameof(accessorList));
            return (EventDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EventDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)eventKeyword.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, explicitInterfaceSpecifier == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExplicitInterfaceSpecifierSyntax)explicitInterfaceSpecifier.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, accessorList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AccessorListSyntax)accessorList.Green).CreateRed();
        }

        /// <summary>Creates a new EventDeclarationSyntax instance.</summary>
        public static EventDeclarationSyntax EventDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken identifier, AccessorListSyntax accessorList)
        {
            return SyntaxFactory.EventDeclaration(attributeLists, modifiers, SyntaxFactory.Token(SyntaxKind.EventKeyword), type, explicitInterfaceSpecifier, identifier, accessorList);
        }

        /// <summary>Creates a new EventDeclarationSyntax instance.</summary>
        public static EventDeclarationSyntax EventDeclaration(TypeSyntax type, SyntaxToken identifier)
        {
            return SyntaxFactory.EventDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.EventKeyword), type, default(ExplicitInterfaceSpecifierSyntax), identifier, SyntaxFactory.AccessorList());
        }

        /// <summary>Creates a new EventDeclarationSyntax instance.</summary>
        public static EventDeclarationSyntax EventDeclaration(TypeSyntax type, string identifier)
        {
            return SyntaxFactory.EventDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.EventKeyword), type, default(ExplicitInterfaceSpecifierSyntax), SyntaxFactory.Identifier(identifier), SyntaxFactory.AccessorList());
        }

        /// <summary>Creates a new IndexerDeclarationSyntax instance.</summary>
        public static IndexerDeclarationSyntax IndexerDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, SyntaxToken thisKeyword, BracketedParameterListSyntax parameterList, AccessorListSyntax accessorList, ArrowExpressionClauseSyntax expressionBody, SyntaxToken semicolonToken)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            switch (thisKeyword.Kind())
            {
                case SyntaxKind.ThisKeyword:
                    break;
                default:
                    throw new ArgumentException("thisKeyword");
            }
            if (parameterList == null)
                throw new ArgumentNullException(nameof(parameterList));
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (IndexerDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.IndexerDeclaration(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, explicitInterfaceSpecifier == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExplicitInterfaceSpecifierSyntax)explicitInterfaceSpecifier.Green, (Syntax.InternalSyntax.SyntaxToken)thisKeyword.Node, parameterList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BracketedParameterListSyntax)parameterList.Green, accessorList == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AccessorListSyntax)accessorList.Green, expressionBody == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ArrowExpressionClauseSyntax)expressionBody.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new IndexerDeclarationSyntax instance.</summary>
        public static IndexerDeclarationSyntax IndexerDeclaration(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier, BracketedParameterListSyntax parameterList, AccessorListSyntax accessorList, ArrowExpressionClauseSyntax expressionBody)
        {
            return SyntaxFactory.IndexerDeclaration(attributeLists, modifiers, type, explicitInterfaceSpecifier, SyntaxFactory.Token(SyntaxKind.ThisKeyword), parameterList, accessorList, expressionBody, default(SyntaxToken));
        }

        /// <summary>Creates a new IndexerDeclarationSyntax instance.</summary>
        public static IndexerDeclarationSyntax IndexerDeclaration(TypeSyntax type)
        {
            return SyntaxFactory.IndexerDeclaration(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), type, default(ExplicitInterfaceSpecifierSyntax), SyntaxFactory.Token(SyntaxKind.ThisKeyword), SyntaxFactory.BracketedParameterList(), default(AccessorListSyntax), default(ArrowExpressionClauseSyntax), default(SyntaxToken));
        }

        /// <summary>Creates a new AccessorListSyntax instance.</summary>
        public static AccessorListSyntax AccessorList(SyntaxToken openBraceToken, SyntaxList<AccessorDeclarationSyntax> accessors, SyntaxToken closeBraceToken)
        {
            switch (openBraceToken.Kind())
            {
                case SyntaxKind.OpenBraceToken:
                    break;
                default:
                    throw new ArgumentException("openBraceToken");
            }
            switch (closeBraceToken.Kind())
            {
                case SyntaxKind.CloseBraceToken:
                    break;
                default:
                    throw new ArgumentException("closeBraceToken");
            }
            return (AccessorListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AccessorList((Syntax.InternalSyntax.SyntaxToken)openBraceToken.Node, accessors.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AccessorDeclarationSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBraceToken.Node).CreateRed();
        }

        /// <summary>Creates a new AccessorListSyntax instance.</summary>
        public static AccessorListSyntax AccessorList(SyntaxList<AccessorDeclarationSyntax> accessors = default(SyntaxList<AccessorDeclarationSyntax>))
        {
            return SyntaxFactory.AccessorList(SyntaxFactory.Token(SyntaxKind.OpenBraceToken), accessors, SyntaxFactory.Token(SyntaxKind.CloseBraceToken));
        }

        /// <summary>Creates a new AccessorDeclarationSyntax instance.</summary>
        public static AccessorDeclarationSyntax AccessorDeclaration(SyntaxKind kind, SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, SyntaxToken keyword, BlockSyntax body, SyntaxToken semicolonToken)
        {
            switch (kind)
            {
                case SyntaxKind.GetAccessorDeclaration:
                case SyntaxKind.SetAccessorDeclaration:
                case SyntaxKind.AddAccessorDeclaration:
                case SyntaxKind.RemoveAccessorDeclaration:
                case SyntaxKind.UnknownAccessorDeclaration:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (keyword.Kind())
            {
                case SyntaxKind.GetKeyword:
                case SyntaxKind.SetKeyword:
                case SyntaxKind.AddKeyword:
                case SyntaxKind.RemoveKeyword:
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("keyword");
            }
            switch (semicolonToken.Kind())
            {
                case SyntaxKind.SemicolonToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("semicolonToken");
            }
            return (AccessorDeclarationSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.AccessorDeclaration(kind, attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)keyword.Node, body == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.BlockSyntax)body.Green, (Syntax.InternalSyntax.SyntaxToken)semicolonToken.Node).CreateRed();
        }

        /// <summary>Creates a new AccessorDeclarationSyntax instance.</summary>
        public static AccessorDeclarationSyntax AccessorDeclaration(SyntaxKind kind, SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, BlockSyntax body)
        {
            return SyntaxFactory.AccessorDeclaration(kind, attributeLists, modifiers, SyntaxFactory.Token(GetAccessorDeclarationKeywordKind(kind)), body, default(SyntaxToken));
        }

        /// <summary>Creates a new AccessorDeclarationSyntax instance.</summary>
        public static AccessorDeclarationSyntax AccessorDeclaration(SyntaxKind kind, BlockSyntax body = default(BlockSyntax))
        {
            return SyntaxFactory.AccessorDeclaration(kind, default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), SyntaxFactory.Token(GetAccessorDeclarationKeywordKind(kind)), body, default(SyntaxToken));
        }

        /// <summary>Creates a new ParameterListSyntax instance.</summary>
        public static ParameterListSyntax ParameterList(SyntaxToken openParenToken, SeparatedSyntaxList<ParameterSyntax> parameters, SyntaxToken closeParenToken)
        {
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (ParameterListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ParameterList((Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, parameters.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new ParameterListSyntax instance.</summary>
        public static ParameterListSyntax ParameterList(SeparatedSyntaxList<ParameterSyntax> parameters = default(SeparatedSyntaxList<ParameterSyntax>))
        {
            return SyntaxFactory.ParameterList(SyntaxFactory.Token(SyntaxKind.OpenParenToken), parameters, SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new BracketedParameterListSyntax instance.</summary>
        public static BracketedParameterListSyntax BracketedParameterList(SyntaxToken openBracketToken, SeparatedSyntaxList<ParameterSyntax> parameters, SyntaxToken closeBracketToken)
        {
            switch (openBracketToken.Kind())
            {
                case SyntaxKind.OpenBracketToken:
                    break;
                default:
                    throw new ArgumentException("openBracketToken");
            }
            switch (closeBracketToken.Kind())
            {
                case SyntaxKind.CloseBracketToken:
                    break;
                default:
                    throw new ArgumentException("closeBracketToken");
            }
            return (BracketedParameterListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.BracketedParameterList((Syntax.InternalSyntax.SyntaxToken)openBracketToken.Node, parameters.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ParameterSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBracketToken.Node).CreateRed();
        }

        /// <summary>Creates a new BracketedParameterListSyntax instance.</summary>
        public static BracketedParameterListSyntax BracketedParameterList(SeparatedSyntaxList<ParameterSyntax> parameters = default(SeparatedSyntaxList<ParameterSyntax>))
        {
            return SyntaxFactory.BracketedParameterList(SyntaxFactory.Token(SyntaxKind.OpenBracketToken), parameters, SyntaxFactory.Token(SyntaxKind.CloseBracketToken));
        }

        /// <summary>Creates a new ParameterSyntax instance.</summary>
        public static ParameterSyntax Parameter(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type, SyntaxToken identifier, EqualsValueClauseSyntax @default)
        {
            switch (identifier.Kind())
            {
                case SyntaxKind.IdentifierToken:
                case SyntaxKind.ArgListKeyword:
                    break;
                default:
                    throw new ArgumentException("identifier");
            }
            return (ParameterSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.Parameter(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, @default == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.EqualsValueClauseSyntax)@default.Green).CreateRed();
        }

        /// <summary>Creates a new ParameterSyntax instance.</summary>
        public static ParameterSyntax Parameter(SyntaxToken identifier)
        {
            return SyntaxFactory.Parameter(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), default(TypeSyntax), identifier, default(EqualsValueClauseSyntax));
        }

        /// <summary>Creates a new IncompleteMemberSyntax instance.</summary>
        public static IncompleteMemberSyntax IncompleteMember(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, TypeSyntax type)
        {
            return (IncompleteMemberSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.IncompleteMember(attributeLists.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.AttributeListSyntax>(), modifiers.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green).CreateRed();
        }

        /// <summary>Creates a new IncompleteMemberSyntax instance.</summary>
        public static IncompleteMemberSyntax IncompleteMember(TypeSyntax type = default(TypeSyntax))
        {
            return SyntaxFactory.IncompleteMember(default(SyntaxList<AttributeListSyntax>), default(SyntaxTokenList), type);
        }

        /// <summary>Creates a new SkippedTokensTriviaSyntax instance.</summary>
        public static SkippedTokensTriviaSyntax SkippedTokensTrivia(SyntaxTokenList tokens)
        {
            return (SkippedTokensTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.SkippedTokensTrivia(tokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>()).CreateRed();
        }

        /// <summary>Creates a new SkippedTokensTriviaSyntax instance.</summary>
        public static SkippedTokensTriviaSyntax SkippedTokensTrivia()
        {
            return SyntaxFactory.SkippedTokensTrivia(default(SyntaxTokenList));
        }

        /// <summary>Creates a new DocumentationCommentTriviaSyntax instance.</summary>
        public static DocumentationCommentTriviaSyntax DocumentationCommentTrivia(SyntaxKind kind, SyntaxList<XmlNodeSyntax> content, SyntaxToken endOfComment)
        {
            switch (kind)
            {
                case SyntaxKind.SingleLineDocumentationCommentTrivia:
                case SyntaxKind.MultiLineDocumentationCommentTrivia:
                    break;
                default:
                    throw new ArgumentException("kind");
            }
            switch (endOfComment.Kind())
            {
                case SyntaxKind.EndOfDocumentationCommentToken:
                    break;
                default:
                    throw new ArgumentException("endOfComment");
            }
            return (DocumentationCommentTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DocumentationCommentTrivia(kind, content.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNodeSyntax>(), (Syntax.InternalSyntax.SyntaxToken)endOfComment.Node).CreateRed();
        }

        /// <summary>Creates a new DocumentationCommentTriviaSyntax instance.</summary>
        public static DocumentationCommentTriviaSyntax DocumentationCommentTrivia(SyntaxKind kind, SyntaxList<XmlNodeSyntax> content = default(SyntaxList<XmlNodeSyntax>))
        {
            return SyntaxFactory.DocumentationCommentTrivia(kind, content, SyntaxFactory.Token(SyntaxKind.EndOfDocumentationCommentToken));
        }

        /// <summary>Creates a new TypeCrefSyntax instance.</summary>
        public static TypeCrefSyntax TypeCref(TypeSyntax type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (TypeCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.TypeCref(type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green).CreateRed();
        }

        /// <summary>Creates a new QualifiedCrefSyntax instance.</summary>
        public static QualifiedCrefSyntax QualifiedCref(TypeSyntax container, SyntaxToken dotToken, MemberCrefSyntax member)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));
            switch (dotToken.Kind())
            {
                case SyntaxKind.DotToken:
                    break;
                default:
                    throw new ArgumentException("dotToken");
            }
            if (member == null)
                throw new ArgumentNullException(nameof(member));
            return (QualifiedCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.QualifiedCref(container == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)container.Green, (Syntax.InternalSyntax.SyntaxToken)dotToken.Node, member == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.MemberCrefSyntax)member.Green).CreateRed();
        }

        /// <summary>Creates a new QualifiedCrefSyntax instance.</summary>
        public static QualifiedCrefSyntax QualifiedCref(TypeSyntax container, MemberCrefSyntax member)
        {
            return SyntaxFactory.QualifiedCref(container, SyntaxFactory.Token(SyntaxKind.DotToken), member);
        }

        /// <summary>Creates a new NameMemberCrefSyntax instance.</summary>
        public static NameMemberCrefSyntax NameMemberCref(TypeSyntax name, CrefParameterListSyntax parameters)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return (NameMemberCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.NameMemberCref(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)name.Green, parameters == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefParameterListSyntax)parameters.Green).CreateRed();
        }

        /// <summary>Creates a new NameMemberCrefSyntax instance.</summary>
        public static NameMemberCrefSyntax NameMemberCref(TypeSyntax name)
        {
            return SyntaxFactory.NameMemberCref(name, default(CrefParameterListSyntax));
        }

        /// <summary>Creates a new IndexerMemberCrefSyntax instance.</summary>
        public static IndexerMemberCrefSyntax IndexerMemberCref(SyntaxToken thisKeyword, CrefBracketedParameterListSyntax parameters)
        {
            switch (thisKeyword.Kind())
            {
                case SyntaxKind.ThisKeyword:
                    break;
                default:
                    throw new ArgumentException("thisKeyword");
            }
            return (IndexerMemberCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.IndexerMemberCref((Syntax.InternalSyntax.SyntaxToken)thisKeyword.Node, parameters == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefBracketedParameterListSyntax)parameters.Green).CreateRed();
        }

        /// <summary>Creates a new IndexerMemberCrefSyntax instance.</summary>
        public static IndexerMemberCrefSyntax IndexerMemberCref(CrefBracketedParameterListSyntax parameters = default(CrefBracketedParameterListSyntax))
        {
            return SyntaxFactory.IndexerMemberCref(SyntaxFactory.Token(SyntaxKind.ThisKeyword), parameters);
        }

        /// <summary>Creates a new OperatorMemberCrefSyntax instance.</summary>
        public static OperatorMemberCrefSyntax OperatorMemberCref(SyntaxToken operatorKeyword, SyntaxToken operatorToken, CrefParameterListSyntax parameters)
        {
            switch (operatorKeyword.Kind())
            {
                case SyntaxKind.OperatorKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorKeyword");
            }
            switch (operatorToken.Kind())
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.ExclamationToken:
                case SyntaxKind.TildeToken:
                case SyntaxKind.PlusPlusToken:
                case SyntaxKind.MinusMinusToken:
                case SyntaxKind.AsteriskToken:
                case SyntaxKind.SlashToken:
                case SyntaxKind.PercentToken:
                case SyntaxKind.LessThanLessThanToken:
                case SyntaxKind.GreaterThanGreaterThanToken:
                case SyntaxKind.BarToken:
                case SyntaxKind.AmpersandToken:
                case SyntaxKind.CaretToken:
                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.ExclamationEqualsToken:
                case SyntaxKind.LessThanToken:
                case SyntaxKind.LessThanEqualsToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.GreaterThanEqualsToken:
                case SyntaxKind.FalseKeyword:
                case SyntaxKind.TrueKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorToken");
            }
            return (OperatorMemberCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.OperatorMemberCref((Syntax.InternalSyntax.SyntaxToken)operatorKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)operatorToken.Node, parameters == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefParameterListSyntax)parameters.Green).CreateRed();
        }

        /// <summary>Creates a new OperatorMemberCrefSyntax instance.</summary>
        public static OperatorMemberCrefSyntax OperatorMemberCref(SyntaxToken operatorToken, CrefParameterListSyntax parameters)
        {
            return SyntaxFactory.OperatorMemberCref(SyntaxFactory.Token(SyntaxKind.OperatorKeyword), operatorToken, parameters);
        }

        /// <summary>Creates a new OperatorMemberCrefSyntax instance.</summary>
        public static OperatorMemberCrefSyntax OperatorMemberCref(SyntaxToken operatorToken)
        {
            return SyntaxFactory.OperatorMemberCref(SyntaxFactory.Token(SyntaxKind.OperatorKeyword), operatorToken, default(CrefParameterListSyntax));
        }

        /// <summary>Creates a new ConversionOperatorMemberCrefSyntax instance.</summary>
        public static ConversionOperatorMemberCrefSyntax ConversionOperatorMemberCref(SyntaxToken implicitOrExplicitKeyword, SyntaxToken operatorKeyword, TypeSyntax type, CrefParameterListSyntax parameters)
        {
            switch (implicitOrExplicitKeyword.Kind())
            {
                case SyntaxKind.ImplicitKeyword:
                case SyntaxKind.ExplicitKeyword:
                    break;
                default:
                    throw new ArgumentException("implicitOrExplicitKeyword");
            }
            switch (operatorKeyword.Kind())
            {
                case SyntaxKind.OperatorKeyword:
                    break;
                default:
                    throw new ArgumentException("operatorKeyword");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (ConversionOperatorMemberCrefSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ConversionOperatorMemberCref((Syntax.InternalSyntax.SyntaxToken)implicitOrExplicitKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)operatorKeyword.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green, parameters == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefParameterListSyntax)parameters.Green).CreateRed();
        }

        /// <summary>Creates a new ConversionOperatorMemberCrefSyntax instance.</summary>
        public static ConversionOperatorMemberCrefSyntax ConversionOperatorMemberCref(SyntaxToken implicitOrExplicitKeyword, TypeSyntax type, CrefParameterListSyntax parameters)
        {
            return SyntaxFactory.ConversionOperatorMemberCref(implicitOrExplicitKeyword, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), type, parameters);
        }

        /// <summary>Creates a new ConversionOperatorMemberCrefSyntax instance.</summary>
        public static ConversionOperatorMemberCrefSyntax ConversionOperatorMemberCref(SyntaxToken implicitOrExplicitKeyword, TypeSyntax type)
        {
            return SyntaxFactory.ConversionOperatorMemberCref(implicitOrExplicitKeyword, SyntaxFactory.Token(SyntaxKind.OperatorKeyword), type, default(CrefParameterListSyntax));
        }

        /// <summary>Creates a new CrefParameterListSyntax instance.</summary>
        public static CrefParameterListSyntax CrefParameterList(SyntaxToken openParenToken, SeparatedSyntaxList<CrefParameterSyntax> parameters, SyntaxToken closeParenToken)
        {
            switch (openParenToken.Kind())
            {
                case SyntaxKind.OpenParenToken:
                    break;
                default:
                    throw new ArgumentException("openParenToken");
            }
            switch (closeParenToken.Kind())
            {
                case SyntaxKind.CloseParenToken:
                    break;
                default:
                    throw new ArgumentException("closeParenToken");
            }
            return (CrefParameterListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CrefParameterList((Syntax.InternalSyntax.SyntaxToken)openParenToken.Node, parameters.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefParameterSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeParenToken.Node).CreateRed();
        }

        /// <summary>Creates a new CrefParameterListSyntax instance.</summary>
        public static CrefParameterListSyntax CrefParameterList(SeparatedSyntaxList<CrefParameterSyntax> parameters = default(SeparatedSyntaxList<CrefParameterSyntax>))
        {
            return SyntaxFactory.CrefParameterList(SyntaxFactory.Token(SyntaxKind.OpenParenToken), parameters, SyntaxFactory.Token(SyntaxKind.CloseParenToken));
        }

        /// <summary>Creates a new CrefBracketedParameterListSyntax instance.</summary>
        public static CrefBracketedParameterListSyntax CrefBracketedParameterList(SyntaxToken openBracketToken, SeparatedSyntaxList<CrefParameterSyntax> parameters, SyntaxToken closeBracketToken)
        {
            switch (openBracketToken.Kind())
            {
                case SyntaxKind.OpenBracketToken:
                    break;
                default:
                    throw new ArgumentException("openBracketToken");
            }
            switch (closeBracketToken.Kind())
            {
                case SyntaxKind.CloseBracketToken:
                    break;
                default:
                    throw new ArgumentException("closeBracketToken");
            }
            return (CrefBracketedParameterListSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CrefBracketedParameterList((Syntax.InternalSyntax.SyntaxToken)openBracketToken.Node, parameters.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefParameterSyntax>(), (Syntax.InternalSyntax.SyntaxToken)closeBracketToken.Node).CreateRed();
        }

        /// <summary>Creates a new CrefBracketedParameterListSyntax instance.</summary>
        public static CrefBracketedParameterListSyntax CrefBracketedParameterList(SeparatedSyntaxList<CrefParameterSyntax> parameters = default(SeparatedSyntaxList<CrefParameterSyntax>))
        {
            return SyntaxFactory.CrefBracketedParameterList(SyntaxFactory.Token(SyntaxKind.OpenBracketToken), parameters, SyntaxFactory.Token(SyntaxKind.CloseBracketToken));
        }

        /// <summary>Creates a new CrefParameterSyntax instance.</summary>
        public static CrefParameterSyntax CrefParameter(SyntaxToken refOrOutKeyword, TypeSyntax type)
        {
            switch (refOrOutKeyword.Kind())
            {
                case SyntaxKind.RefKeyword:
                case SyntaxKind.OutKeyword:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("refOrOutKeyword");
            }
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            return (CrefParameterSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.CrefParameter((Syntax.InternalSyntax.SyntaxToken)refOrOutKeyword.Node, type == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.TypeSyntax)type.Green).CreateRed();
        }

        /// <summary>Creates a new CrefParameterSyntax instance.</summary>
        public static CrefParameterSyntax CrefParameter(TypeSyntax type)
        {
            return SyntaxFactory.CrefParameter(default(SyntaxToken), type);
        }

        /// <summary>Creates a new XmlElementSyntax instance.</summary>
        public static XmlElementSyntax XmlElement(XmlElementStartTagSyntax startTag, SyntaxList<XmlNodeSyntax> content, XmlElementEndTagSyntax endTag)
        {
            if (startTag == null)
                throw new ArgumentNullException(nameof(startTag));
            if (endTag == null)
                throw new ArgumentNullException(nameof(endTag));
            return (XmlElementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlElement(startTag == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlElementStartTagSyntax)startTag.Green, content.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNodeSyntax>(), endTag == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlElementEndTagSyntax)endTag.Green).CreateRed();
        }

        /// <summary>Creates a new XmlElementSyntax instance.</summary>
        public static XmlElementSyntax XmlElement(XmlElementStartTagSyntax startTag, XmlElementEndTagSyntax endTag)
        {
            return SyntaxFactory.XmlElement(startTag, default(SyntaxList<XmlNodeSyntax>), endTag);
        }

        /// <summary>Creates a new XmlElementStartTagSyntax instance.</summary>
        public static XmlElementStartTagSyntax XmlElementStartTag(SyntaxToken lessThanToken, XmlNameSyntax name, SyntaxList<XmlAttributeSyntax> attributes, SyntaxToken greaterThanToken)
        {
            switch (lessThanToken.Kind())
            {
                case SyntaxKind.LessThanToken:
                    break;
                default:
                    throw new ArgumentException("lessThanToken");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (greaterThanToken.Kind())
            {
                case SyntaxKind.GreaterThanToken:
                    break;
                default:
                    throw new ArgumentException("greaterThanToken");
            }
            return (XmlElementStartTagSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlElementStartTag((Syntax.InternalSyntax.SyntaxToken)lessThanToken.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, attributes.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlAttributeSyntax>(), (Syntax.InternalSyntax.SyntaxToken)greaterThanToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlElementStartTagSyntax instance.</summary>
        public static XmlElementStartTagSyntax XmlElementStartTag(XmlNameSyntax name, SyntaxList<XmlAttributeSyntax> attributes)
        {
            return SyntaxFactory.XmlElementStartTag(SyntaxFactory.Token(SyntaxKind.LessThanToken), name, attributes, SyntaxFactory.Token(SyntaxKind.GreaterThanToken));
        }

        /// <summary>Creates a new XmlElementStartTagSyntax instance.</summary>
        public static XmlElementStartTagSyntax XmlElementStartTag(XmlNameSyntax name)
        {
            return SyntaxFactory.XmlElementStartTag(SyntaxFactory.Token(SyntaxKind.LessThanToken), name, default(SyntaxList<XmlAttributeSyntax>), SyntaxFactory.Token(SyntaxKind.GreaterThanToken));
        }

        /// <summary>Creates a new XmlElementEndTagSyntax instance.</summary>
        public static XmlElementEndTagSyntax XmlElementEndTag(SyntaxToken lessThanSlashToken, XmlNameSyntax name, SyntaxToken greaterThanToken)
        {
            switch (lessThanSlashToken.Kind())
            {
                case SyntaxKind.LessThanSlashToken:
                    break;
                default:
                    throw new ArgumentException("lessThanSlashToken");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (greaterThanToken.Kind())
            {
                case SyntaxKind.GreaterThanToken:
                    break;
                default:
                    throw new ArgumentException("greaterThanToken");
            }
            return (XmlElementEndTagSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlElementEndTag((Syntax.InternalSyntax.SyntaxToken)lessThanSlashToken.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)greaterThanToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlElementEndTagSyntax instance.</summary>
        public static XmlElementEndTagSyntax XmlElementEndTag(XmlNameSyntax name)
        {
            return SyntaxFactory.XmlElementEndTag(SyntaxFactory.Token(SyntaxKind.LessThanSlashToken), name, SyntaxFactory.Token(SyntaxKind.GreaterThanToken));
        }

        /// <summary>Creates a new XmlEmptyElementSyntax instance.</summary>
        public static XmlEmptyElementSyntax XmlEmptyElement(SyntaxToken lessThanToken, XmlNameSyntax name, SyntaxList<XmlAttributeSyntax> attributes, SyntaxToken slashGreaterThanToken)
        {
            switch (lessThanToken.Kind())
            {
                case SyntaxKind.LessThanToken:
                    break;
                default:
                    throw new ArgumentException("lessThanToken");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (slashGreaterThanToken.Kind())
            {
                case SyntaxKind.SlashGreaterThanToken:
                    break;
                default:
                    throw new ArgumentException("slashGreaterThanToken");
            }
            return (XmlEmptyElementSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlEmptyElement((Syntax.InternalSyntax.SyntaxToken)lessThanToken.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, attributes.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlAttributeSyntax>(), (Syntax.InternalSyntax.SyntaxToken)slashGreaterThanToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlEmptyElementSyntax instance.</summary>
        public static XmlEmptyElementSyntax XmlEmptyElement(XmlNameSyntax name, SyntaxList<XmlAttributeSyntax> attributes)
        {
            return SyntaxFactory.XmlEmptyElement(SyntaxFactory.Token(SyntaxKind.LessThanToken), name, attributes, SyntaxFactory.Token(SyntaxKind.SlashGreaterThanToken));
        }

        /// <summary>Creates a new XmlEmptyElementSyntax instance.</summary>
        public static XmlEmptyElementSyntax XmlEmptyElement(XmlNameSyntax name)
        {
            return SyntaxFactory.XmlEmptyElement(SyntaxFactory.Token(SyntaxKind.LessThanToken), name, default(SyntaxList<XmlAttributeSyntax>), SyntaxFactory.Token(SyntaxKind.SlashGreaterThanToken));
        }

        /// <summary>Creates a new XmlNameSyntax instance.</summary>
        public static XmlNameSyntax XmlName(XmlPrefixSyntax prefix, SyntaxToken localName)
        {
            switch (localName.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("localName");
            }
            return (XmlNameSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlName(prefix == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlPrefixSyntax)prefix.Green, (Syntax.InternalSyntax.SyntaxToken)localName.Node).CreateRed();
        }

        /// <summary>Creates a new XmlNameSyntax instance.</summary>
        public static XmlNameSyntax XmlName(SyntaxToken localName)
        {
            return SyntaxFactory.XmlName(default(XmlPrefixSyntax), localName);
        }

        /// <summary>Creates a new XmlNameSyntax instance.</summary>
        public static XmlNameSyntax XmlName(string localName)
        {
            return SyntaxFactory.XmlName(default(XmlPrefixSyntax), SyntaxFactory.Identifier(localName));
        }

        /// <summary>Creates a new XmlPrefixSyntax instance.</summary>
        public static XmlPrefixSyntax XmlPrefix(SyntaxToken prefix, SyntaxToken colonToken)
        {
            switch (prefix.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("prefix");
            }
            switch (colonToken.Kind())
            {
                case SyntaxKind.ColonToken:
                    break;
                default:
                    throw new ArgumentException("colonToken");
            }
            return (XmlPrefixSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlPrefix((Syntax.InternalSyntax.SyntaxToken)prefix.Node, (Syntax.InternalSyntax.SyntaxToken)colonToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlPrefixSyntax instance.</summary>
        public static XmlPrefixSyntax XmlPrefix(SyntaxToken prefix)
        {
            return SyntaxFactory.XmlPrefix(prefix, SyntaxFactory.Token(SyntaxKind.ColonToken));
        }

        /// <summary>Creates a new XmlPrefixSyntax instance.</summary>
        public static XmlPrefixSyntax XmlPrefix(string prefix)
        {
            return SyntaxFactory.XmlPrefix(SyntaxFactory.Identifier(prefix), SyntaxFactory.Token(SyntaxKind.ColonToken));
        }

        /// <summary>Creates a new XmlTextAttributeSyntax instance.</summary>
        public static XmlTextAttributeSyntax XmlTextAttribute(XmlNameSyntax name, SyntaxToken equalsToken, SyntaxToken startQuoteToken, SyntaxTokenList textTokens, SyntaxToken endQuoteToken)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (equalsToken.Kind())
            {
                case SyntaxKind.EqualsToken:
                    break;
                default:
                    throw new ArgumentException("equalsToken");
            }
            switch (startQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("startQuoteToken");
            }
            switch (endQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("endQuoteToken");
            }
            return (XmlTextAttributeSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlTextAttribute(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)equalsToken.Node, (Syntax.InternalSyntax.SyntaxToken)startQuoteToken.Node, textTokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)endQuoteToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlTextAttributeSyntax instance.</summary>
        public static XmlTextAttributeSyntax XmlTextAttribute(XmlNameSyntax name, SyntaxToken startQuoteToken, SyntaxTokenList textTokens, SyntaxToken endQuoteToken)
        {
            return SyntaxFactory.XmlTextAttribute(name, SyntaxFactory.Token(SyntaxKind.EqualsToken), startQuoteToken, textTokens, endQuoteToken);
        }

        /// <summary>Creates a new XmlTextAttributeSyntax instance.</summary>
        public static XmlTextAttributeSyntax XmlTextAttribute(XmlNameSyntax name, SyntaxToken startQuoteToken, SyntaxToken endQuoteToken)
        {
            return SyntaxFactory.XmlTextAttribute(name, SyntaxFactory.Token(SyntaxKind.EqualsToken), startQuoteToken, default(SyntaxTokenList), endQuoteToken);
        }

        /// <summary>Creates a new XmlCrefAttributeSyntax instance.</summary>
        public static XmlCrefAttributeSyntax XmlCrefAttribute(XmlNameSyntax name, SyntaxToken equalsToken, SyntaxToken startQuoteToken, CrefSyntax cref, SyntaxToken endQuoteToken)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (equalsToken.Kind())
            {
                case SyntaxKind.EqualsToken:
                    break;
                default:
                    throw new ArgumentException("equalsToken");
            }
            switch (startQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("startQuoteToken");
            }
            if (cref == null)
                throw new ArgumentNullException(nameof(cref));
            switch (endQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("endQuoteToken");
            }
            return (XmlCrefAttributeSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlCrefAttribute(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)equalsToken.Node, (Syntax.InternalSyntax.SyntaxToken)startQuoteToken.Node, cref == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CrefSyntax)cref.Green, (Syntax.InternalSyntax.SyntaxToken)endQuoteToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlCrefAttributeSyntax instance.</summary>
        public static XmlCrefAttributeSyntax XmlCrefAttribute(XmlNameSyntax name, SyntaxToken startQuoteToken, CrefSyntax cref, SyntaxToken endQuoteToken)
        {
            return SyntaxFactory.XmlCrefAttribute(name, SyntaxFactory.Token(SyntaxKind.EqualsToken), startQuoteToken, cref, endQuoteToken);
        }

        /// <summary>Creates a new XmlNameAttributeSyntax instance.</summary>
        public static XmlNameAttributeSyntax XmlNameAttribute(XmlNameSyntax name, SyntaxToken equalsToken, SyntaxToken startQuoteToken, IdentifierNameSyntax identifier, SyntaxToken endQuoteToken)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (equalsToken.Kind())
            {
                case SyntaxKind.EqualsToken:
                    break;
                default:
                    throw new ArgumentException("equalsToken");
            }
            switch (startQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("startQuoteToken");
            }
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));
            switch (endQuoteToken.Kind())
            {
                case SyntaxKind.SingleQuoteToken:
                case SyntaxKind.DoubleQuoteToken:
                    break;
                default:
                    throw new ArgumentException("endQuoteToken");
            }
            return (XmlNameAttributeSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlNameAttribute(name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, (Syntax.InternalSyntax.SyntaxToken)equalsToken.Node, (Syntax.InternalSyntax.SyntaxToken)startQuoteToken.Node, identifier == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.IdentifierNameSyntax)identifier.Green, (Syntax.InternalSyntax.SyntaxToken)endQuoteToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlNameAttributeSyntax instance.</summary>
        public static XmlNameAttributeSyntax XmlNameAttribute(XmlNameSyntax name, SyntaxToken startQuoteToken, IdentifierNameSyntax identifier, SyntaxToken endQuoteToken)
        {
            return SyntaxFactory.XmlNameAttribute(name, SyntaxFactory.Token(SyntaxKind.EqualsToken), startQuoteToken, identifier, endQuoteToken);
        }

        /// <summary>Creates a new XmlNameAttributeSyntax instance.</summary>
        public static XmlNameAttributeSyntax XmlNameAttribute(XmlNameSyntax name, SyntaxToken startQuoteToken, string identifier, SyntaxToken endQuoteToken)
        {
            return SyntaxFactory.XmlNameAttribute(name, SyntaxFactory.Token(SyntaxKind.EqualsToken), startQuoteToken, SyntaxFactory.IdentifierName(identifier), endQuoteToken);
        }

        /// <summary>Creates a new XmlTextSyntax instance.</summary>
        public static XmlTextSyntax XmlText(SyntaxTokenList textTokens)
        {
            return (XmlTextSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlText(textTokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>()).CreateRed();
        }

        /// <summary>Creates a new XmlTextSyntax instance.</summary>
        public static XmlTextSyntax XmlText()
        {
            return SyntaxFactory.XmlText(default(SyntaxTokenList));
        }

        /// <summary>Creates a new XmlCDataSectionSyntax instance.</summary>
        public static XmlCDataSectionSyntax XmlCDataSection(SyntaxToken startCDataToken, SyntaxTokenList textTokens, SyntaxToken endCDataToken)
        {
            switch (startCDataToken.Kind())
            {
                case SyntaxKind.XmlCDataStartToken:
                    break;
                default:
                    throw new ArgumentException("startCDataToken");
            }
            switch (endCDataToken.Kind())
            {
                case SyntaxKind.XmlCDataEndToken:
                    break;
                default:
                    throw new ArgumentException("endCDataToken");
            }
            return (XmlCDataSectionSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlCDataSection((Syntax.InternalSyntax.SyntaxToken)startCDataToken.Node, textTokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)endCDataToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlCDataSectionSyntax instance.</summary>
        public static XmlCDataSectionSyntax XmlCDataSection(SyntaxTokenList textTokens = default(SyntaxTokenList))
        {
            return SyntaxFactory.XmlCDataSection(SyntaxFactory.Token(SyntaxKind.XmlCDataStartToken), textTokens, SyntaxFactory.Token(SyntaxKind.XmlCDataEndToken));
        }

        /// <summary>Creates a new XmlProcessingInstructionSyntax instance.</summary>
        public static XmlProcessingInstructionSyntax XmlProcessingInstruction(SyntaxToken startProcessingInstructionToken, XmlNameSyntax name, SyntaxTokenList textTokens, SyntaxToken endProcessingInstructionToken)
        {
            switch (startProcessingInstructionToken.Kind())
            {
                case SyntaxKind.XmlProcessingInstructionStartToken:
                    break;
                default:
                    throw new ArgumentException("startProcessingInstructionToken");
            }
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            switch (endProcessingInstructionToken.Kind())
            {
                case SyntaxKind.XmlProcessingInstructionEndToken:
                    break;
                default:
                    throw new ArgumentException("endProcessingInstructionToken");
            }
            return (XmlProcessingInstructionSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlProcessingInstruction((Syntax.InternalSyntax.SyntaxToken)startProcessingInstructionToken.Node, name == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.XmlNameSyntax)name.Green, textTokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)endProcessingInstructionToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlProcessingInstructionSyntax instance.</summary>
        public static XmlProcessingInstructionSyntax XmlProcessingInstruction(XmlNameSyntax name, SyntaxTokenList textTokens)
        {
            return SyntaxFactory.XmlProcessingInstruction(SyntaxFactory.Token(SyntaxKind.XmlProcessingInstructionStartToken), name, textTokens, SyntaxFactory.Token(SyntaxKind.XmlProcessingInstructionEndToken));
        }

        /// <summary>Creates a new XmlProcessingInstructionSyntax instance.</summary>
        public static XmlProcessingInstructionSyntax XmlProcessingInstruction(XmlNameSyntax name)
        {
            return SyntaxFactory.XmlProcessingInstruction(SyntaxFactory.Token(SyntaxKind.XmlProcessingInstructionStartToken), name, default(SyntaxTokenList), SyntaxFactory.Token(SyntaxKind.XmlProcessingInstructionEndToken));
        }

        /// <summary>Creates a new XmlCommentSyntax instance.</summary>
        public static XmlCommentSyntax XmlComment(SyntaxToken lessThanExclamationMinusMinusToken, SyntaxTokenList textTokens, SyntaxToken minusMinusGreaterThanToken)
        {
            switch (lessThanExclamationMinusMinusToken.Kind())
            {
                case SyntaxKind.XmlCommentStartToken:
                    break;
                default:
                    throw new ArgumentException("lessThanExclamationMinusMinusToken");
            }
            switch (minusMinusGreaterThanToken.Kind())
            {
                case SyntaxKind.XmlCommentEndToken:
                    break;
                default:
                    throw new ArgumentException("minusMinusGreaterThanToken");
            }
            return (XmlCommentSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.XmlComment((Syntax.InternalSyntax.SyntaxToken)lessThanExclamationMinusMinusToken.Node, textTokens.Node.ToGreenList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.CSharpSyntaxNode>(), (Syntax.InternalSyntax.SyntaxToken)minusMinusGreaterThanToken.Node).CreateRed();
        }

        /// <summary>Creates a new XmlCommentSyntax instance.</summary>
        public static XmlCommentSyntax XmlComment(SyntaxTokenList textTokens = default(SyntaxTokenList))
        {
            return SyntaxFactory.XmlComment(SyntaxFactory.Token(SyntaxKind.XmlCommentStartToken), textTokens, SyntaxFactory.Token(SyntaxKind.XmlCommentEndToken));
        }

        /// <summary>Creates a new IfDirectiveTriviaSyntax instance.</summary>
        public static IfDirectiveTriviaSyntax IfDirectiveTrivia(SyntaxToken hashToken, SyntaxToken ifKeyword, ExpressionSyntax condition, SyntaxToken endOfDirectiveToken, bool isActive, bool branchTaken, bool conditionValue)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (ifKeyword.Kind())
            {
                case SyntaxKind.IfKeyword:
                    break;
                default:
                    throw new ArgumentException("ifKeyword");
            }
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (IfDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.IfDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)ifKeyword.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive, branchTaken, conditionValue).CreateRed();
        }

        /// <summary>Creates a new IfDirectiveTriviaSyntax instance.</summary>
        public static IfDirectiveTriviaSyntax IfDirectiveTrivia(ExpressionSyntax condition, bool isActive, bool branchTaken, bool conditionValue)
        {
            return SyntaxFactory.IfDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.IfKeyword), condition, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive, branchTaken, conditionValue);
        }

        /// <summary>Creates a new ElifDirectiveTriviaSyntax instance.</summary>
        public static ElifDirectiveTriviaSyntax ElifDirectiveTrivia(SyntaxToken hashToken, SyntaxToken elifKeyword, ExpressionSyntax condition, SyntaxToken endOfDirectiveToken, bool isActive, bool branchTaken, bool conditionValue)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (elifKeyword.Kind())
            {
                case SyntaxKind.ElifKeyword:
                    break;
                default:
                    throw new ArgumentException("elifKeyword");
            }
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (ElifDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ElifDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)elifKeyword.Node, condition == null ? null : (Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax)condition.Green, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive, branchTaken, conditionValue).CreateRed();
        }

        /// <summary>Creates a new ElifDirectiveTriviaSyntax instance.</summary>
        public static ElifDirectiveTriviaSyntax ElifDirectiveTrivia(ExpressionSyntax condition, bool isActive, bool branchTaken, bool conditionValue)
        {
            return SyntaxFactory.ElifDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.ElifKeyword), condition, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive, branchTaken, conditionValue);
        }

        /// <summary>Creates a new ElseDirectiveTriviaSyntax instance.</summary>
        public static ElseDirectiveTriviaSyntax ElseDirectiveTrivia(SyntaxToken hashToken, SyntaxToken elseKeyword, SyntaxToken endOfDirectiveToken, bool isActive, bool branchTaken)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (elseKeyword.Kind())
            {
                case SyntaxKind.ElseKeyword:
                    break;
                default:
                    throw new ArgumentException("elseKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (ElseDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ElseDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)elseKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive, branchTaken).CreateRed();
        }

        /// <summary>Creates a new ElseDirectiveTriviaSyntax instance.</summary>
        public static ElseDirectiveTriviaSyntax ElseDirectiveTrivia(bool isActive, bool branchTaken)
        {
            return SyntaxFactory.ElseDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.ElseKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive, branchTaken);
        }

        /// <summary>Creates a new EndIfDirectiveTriviaSyntax instance.</summary>
        public static EndIfDirectiveTriviaSyntax EndIfDirectiveTrivia(SyntaxToken hashToken, SyntaxToken endIfKeyword, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (endIfKeyword.Kind())
            {
                case SyntaxKind.EndIfKeyword:
                    break;
                default:
                    throw new ArgumentException("endIfKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (EndIfDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EndIfDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)endIfKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new EndIfDirectiveTriviaSyntax instance.</summary>
        public static EndIfDirectiveTriviaSyntax EndIfDirectiveTrivia(bool isActive)
        {
            return SyntaxFactory.EndIfDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.EndIfKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new RegionDirectiveTriviaSyntax instance.</summary>
        public static RegionDirectiveTriviaSyntax RegionDirectiveTrivia(SyntaxToken hashToken, SyntaxToken regionKeyword, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (regionKeyword.Kind())
            {
                case SyntaxKind.RegionKeyword:
                    break;
                default:
                    throw new ArgumentException("regionKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (RegionDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.RegionDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)regionKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new RegionDirectiveTriviaSyntax instance.</summary>
        public static RegionDirectiveTriviaSyntax RegionDirectiveTrivia(bool isActive)
        {
            return SyntaxFactory.RegionDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.RegionKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new EndRegionDirectiveTriviaSyntax instance.</summary>
        public static EndRegionDirectiveTriviaSyntax EndRegionDirectiveTrivia(SyntaxToken hashToken, SyntaxToken endRegionKeyword, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (endRegionKeyword.Kind())
            {
                case SyntaxKind.EndRegionKeyword:
                    break;
                default:
                    throw new ArgumentException("endRegionKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (EndRegionDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.EndRegionDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)endRegionKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new EndRegionDirectiveTriviaSyntax instance.</summary>
        public static EndRegionDirectiveTriviaSyntax EndRegionDirectiveTrivia(bool isActive)
        {
            return SyntaxFactory.EndRegionDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.EndRegionKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new ErrorDirectiveTriviaSyntax instance.</summary>
        public static ErrorDirectiveTriviaSyntax ErrorDirectiveTrivia(SyntaxToken hashToken, SyntaxToken errorKeyword, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (errorKeyword.Kind())
            {
                case SyntaxKind.ErrorKeyword:
                    break;
                default:
                    throw new ArgumentException("errorKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (ErrorDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ErrorDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)errorKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new ErrorDirectiveTriviaSyntax instance.</summary>
        public static ErrorDirectiveTriviaSyntax ErrorDirectiveTrivia(bool isActive)
        {
            return SyntaxFactory.ErrorDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.ErrorKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new WarningDirectiveTriviaSyntax instance.</summary>
        public static WarningDirectiveTriviaSyntax WarningDirectiveTrivia(SyntaxToken hashToken, SyntaxToken warningKeyword, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (warningKeyword.Kind())
            {
                case SyntaxKind.WarningKeyword:
                    break;
                default:
                    throw new ArgumentException("warningKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (WarningDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.WarningDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)warningKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new WarningDirectiveTriviaSyntax instance.</summary>
        public static WarningDirectiveTriviaSyntax WarningDirectiveTrivia(bool isActive)
        {
            return SyntaxFactory.WarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.WarningKeyword), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new BadDirectiveTriviaSyntax instance.</summary>
        public static BadDirectiveTriviaSyntax BadDirectiveTrivia(SyntaxToken hashToken, SyntaxToken identifier, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (BadDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.BadDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)identifier.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new BadDirectiveTriviaSyntax instance.</summary>
        public static BadDirectiveTriviaSyntax BadDirectiveTrivia(SyntaxToken identifier, bool isActive)
        {
            return SyntaxFactory.BadDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), identifier, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new DefineDirectiveTriviaSyntax instance.</summary>
        public static DefineDirectiveTriviaSyntax DefineDirectiveTrivia(SyntaxToken hashToken, SyntaxToken defineKeyword, SyntaxToken name, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (defineKeyword.Kind())
            {
                case SyntaxKind.DefineKeyword:
                    break;
                default:
                    throw new ArgumentException("defineKeyword");
            }
            switch (name.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("name");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (DefineDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.DefineDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)defineKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)name.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new DefineDirectiveTriviaSyntax instance.</summary>
        public static DefineDirectiveTriviaSyntax DefineDirectiveTrivia(SyntaxToken name, bool isActive)
        {
            return SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.DefineKeyword), name, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new DefineDirectiveTriviaSyntax instance.</summary>
        public static DefineDirectiveTriviaSyntax DefineDirectiveTrivia(string name, bool isActive)
        {
            return SyntaxFactory.DefineDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.DefineKeyword), SyntaxFactory.Identifier(name), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new UndefDirectiveTriviaSyntax instance.</summary>
        public static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(SyntaxToken hashToken, SyntaxToken undefKeyword, SyntaxToken name, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (undefKeyword.Kind())
            {
                case SyntaxKind.UndefKeyword:
                    break;
                default:
                    throw new ArgumentException("undefKeyword");
            }
            switch (name.Kind())
            {
                case SyntaxKind.IdentifierToken:
                    break;
                default:
                    throw new ArgumentException("name");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (UndefDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.UndefDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)undefKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)name.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new UndefDirectiveTriviaSyntax instance.</summary>
        public static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(SyntaxToken name, bool isActive)
        {
            return SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.UndefKeyword), name, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new UndefDirectiveTriviaSyntax instance.</summary>
        public static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(string name, bool isActive)
        {
            return SyntaxFactory.UndefDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.UndefKeyword), SyntaxFactory.Identifier(name), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new LineDirectiveTriviaSyntax instance.</summary>
        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(SyntaxToken hashToken, SyntaxToken lineKeyword, SyntaxToken line, SyntaxToken file, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (lineKeyword.Kind())
            {
                case SyntaxKind.LineKeyword:
                    break;
                default:
                    throw new ArgumentException("lineKeyword");
            }
            switch (line.Kind())
            {
                case SyntaxKind.NumericLiteralToken:
                case SyntaxKind.DefaultKeyword:
                case SyntaxKind.HiddenKeyword:
                    break;
                default:
                    throw new ArgumentException("line");
            }
            switch (file.Kind())
            {
                case SyntaxKind.StringLiteralToken:
                case SyntaxKind.None:
                    break;
                default:
                    throw new ArgumentException("file");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (LineDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.LineDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)lineKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)line.Node, (Syntax.InternalSyntax.SyntaxToken)file.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new LineDirectiveTriviaSyntax instance.</summary>
        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(SyntaxToken line, SyntaxToken file, bool isActive)
        {
            return SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.LineKeyword), line, file, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new LineDirectiveTriviaSyntax instance.</summary>
        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(SyntaxToken line, bool isActive)
        {
            return SyntaxFactory.LineDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.LineKeyword), line, default(SyntaxToken), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new PragmaWarningDirectiveTriviaSyntax instance.</summary>
        public static PragmaWarningDirectiveTriviaSyntax PragmaWarningDirectiveTrivia(SyntaxToken hashToken, SyntaxToken pragmaKeyword, SyntaxToken warningKeyword, SyntaxToken disableOrRestoreKeyword, SeparatedSyntaxList<ExpressionSyntax> errorCodes, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (pragmaKeyword.Kind())
            {
                case SyntaxKind.PragmaKeyword:
                    break;
                default:
                    throw new ArgumentException("pragmaKeyword");
            }
            switch (warningKeyword.Kind())
            {
                case SyntaxKind.WarningKeyword:
                    break;
                default:
                    throw new ArgumentException("warningKeyword");
            }
            switch (disableOrRestoreKeyword.Kind())
            {
                case SyntaxKind.DisableKeyword:
                case SyntaxKind.RestoreKeyword:
                    break;
                default:
                    throw new ArgumentException("disableOrRestoreKeyword");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (PragmaWarningDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.PragmaWarningDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)pragmaKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)warningKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)disableOrRestoreKeyword.Node, errorCodes.Node.ToGreenSeparatedList<Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.ExpressionSyntax>(), (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new PragmaWarningDirectiveTriviaSyntax instance.</summary>
        public static PragmaWarningDirectiveTriviaSyntax PragmaWarningDirectiveTrivia(SyntaxToken disableOrRestoreKeyword, SeparatedSyntaxList<ExpressionSyntax> errorCodes, bool isActive)
        {
            return SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.PragmaKeyword), SyntaxFactory.Token(SyntaxKind.WarningKeyword), disableOrRestoreKeyword, errorCodes, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new PragmaWarningDirectiveTriviaSyntax instance.</summary>
        public static PragmaWarningDirectiveTriviaSyntax PragmaWarningDirectiveTrivia(SyntaxToken disableOrRestoreKeyword, bool isActive)
        {
            return SyntaxFactory.PragmaWarningDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.PragmaKeyword), SyntaxFactory.Token(SyntaxKind.WarningKeyword), disableOrRestoreKeyword, default(SeparatedSyntaxList<ExpressionSyntax>), SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new PragmaChecksumDirectiveTriviaSyntax instance.</summary>
        public static PragmaChecksumDirectiveTriviaSyntax PragmaChecksumDirectiveTrivia(SyntaxToken hashToken, SyntaxToken pragmaKeyword, SyntaxToken checksumKeyword, SyntaxToken file, SyntaxToken guid, SyntaxToken bytes, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (pragmaKeyword.Kind())
            {
                case SyntaxKind.PragmaKeyword:
                    break;
                default:
                    throw new ArgumentException("pragmaKeyword");
            }
            switch (checksumKeyword.Kind())
            {
                case SyntaxKind.ChecksumKeyword:
                    break;
                default:
                    throw new ArgumentException("checksumKeyword");
            }
            switch (file.Kind())
            {
                case SyntaxKind.StringLiteralToken:
                    break;
                default:
                    throw new ArgumentException("file");
            }
            switch (guid.Kind())
            {
                case SyntaxKind.StringLiteralToken:
                    break;
                default:
                    throw new ArgumentException("guid");
            }
            switch (bytes.Kind())
            {
                case SyntaxKind.StringLiteralToken:
                    break;
                default:
                    throw new ArgumentException("bytes");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (PragmaChecksumDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.PragmaChecksumDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)pragmaKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)checksumKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)file.Node, (Syntax.InternalSyntax.SyntaxToken)guid.Node, (Syntax.InternalSyntax.SyntaxToken)bytes.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new PragmaChecksumDirectiveTriviaSyntax instance.</summary>
        public static PragmaChecksumDirectiveTriviaSyntax PragmaChecksumDirectiveTrivia(SyntaxToken file, SyntaxToken guid, SyntaxToken bytes, bool isActive)
        {
            return SyntaxFactory.PragmaChecksumDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.PragmaKeyword), SyntaxFactory.Token(SyntaxKind.ChecksumKeyword), file, guid, bytes, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }

        /// <summary>Creates a new ReferenceDirectiveTriviaSyntax instance.</summary>
        public static ReferenceDirectiveTriviaSyntax ReferenceDirectiveTrivia(SyntaxToken hashToken, SyntaxToken referenceKeyword, SyntaxToken file, SyntaxToken endOfDirectiveToken, bool isActive)
        {
            switch (hashToken.Kind())
            {
                case SyntaxKind.HashToken:
                    break;
                default:
                    throw new ArgumentException("hashToken");
            }
            switch (referenceKeyword.Kind())
            {
                case SyntaxKind.ReferenceKeyword:
                    break;
                default:
                    throw new ArgumentException("referenceKeyword");
            }
            switch (file.Kind())
            {
                case SyntaxKind.StringLiteralToken:
                    break;
                default:
                    throw new ArgumentException("file");
            }
            switch (endOfDirectiveToken.Kind())
            {
                case SyntaxKind.EndOfDirectiveToken:
                    break;
                default:
                    throw new ArgumentException("endOfDirectiveToken");
            }
            return (ReferenceDirectiveTriviaSyntax)Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxFactory.ReferenceDirectiveTrivia((Syntax.InternalSyntax.SyntaxToken)hashToken.Node, (Syntax.InternalSyntax.SyntaxToken)referenceKeyword.Node, (Syntax.InternalSyntax.SyntaxToken)file.Node, (Syntax.InternalSyntax.SyntaxToken)endOfDirectiveToken.Node, isActive).CreateRed();
        }

        /// <summary>Creates a new ReferenceDirectiveTriviaSyntax instance.</summary>
        public static ReferenceDirectiveTriviaSyntax ReferenceDirectiveTrivia(SyntaxToken file, bool isActive)
        {
            return SyntaxFactory.ReferenceDirectiveTrivia(SyntaxFactory.Token(SyntaxKind.HashToken), SyntaxFactory.Token(SyntaxKind.ReferenceKeyword), file, SyntaxFactory.Token(SyntaxKind.EndOfDirectiveToken), isActive);
        }*/
    }
}
