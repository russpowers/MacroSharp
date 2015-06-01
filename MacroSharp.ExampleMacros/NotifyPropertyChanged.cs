using MacroSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.CSharp;

namespace MacroSharp.ExampleMacros
{
    /// <summary>
    /// This is the attribute that will be used on a class
    /// </summary>
    public class NotifyPropertyChangedAttribute : TypeMacroAttribute
    {
    }

    /// <summary>
    /// This was hacked together very quickly as an demo, please don't use it as
    /// as an example of good Roslyn syntax... I will improve it later
    /// </summary>
    class NotifyPropertyChanged : MacroTransform<NotifyPropertyChangedAttribute>
    {
        private class MyRewriter : MacroCSharpSyntaxRewriter
        {
            public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
            {
                if (node.AccessorList.Accessors.Count == 2 &&
                    node.AccessorList.Accessors[0].Body == null &&
                    node.AccessorList.Accessors[1].Body == null)
                {

                    var propertyName = node.Identifier.Text;
                    var privateVarName = "_" + Char.ToLower(propertyName[0]) + propertyName.Substring(1);
                    var privateVar = F.ParseName(privateVarName);

                    AddBeforeCurrentNode(
                        F.FieldDeclaration(
                            F.VariableDeclaration(node.Type)
                                .AddVariables(F.VariableDeclarator(privateVarName))));

                    var getter = F.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration,
                        F.Block(F.ReturnStatement(privateVar)));

                    var setter = F.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration,
                        F.Block(
                            F.ExpressionStatement(F.ParseExpression(privateVarName + " = value")),
                            F.IfStatement(
                                F.ParseExpression("PropertyChanged != null"),
                                F.ExpressionStatement(
                                    F.InvocationExpression(
                                        F.ParseName("PropertyChanged"),
                                        F.ParseArgumentList("(this, new System.ComponentModel.PropertyChangedEventArgs(\"" + propertyName + "\"))"))))));

                    return F.PropertyDeclaration(node.Type, propertyName)
                        .AddAccessorListAccessors(getter, setter)
                        .AddModifiers(F.Token(SyntaxKind.PublicKeyword));
                }
                else
                    return base.VisitPropertyDeclaration(node);
            }

            public override SyntaxNode VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
            {
                if (node.Declaration.Variables.Any(x => x.Identifier.Text == "PropertyChanged"))
                {
                    // This is just a sample of how to create a warning... normally you wouldn't have one here
                    Context.Diagnostics.Add(Diagnostic.Create(diagDesc, node.GetLocation()));
                    foundPCEH = true;
                }

                return base.VisitEventFieldDeclaration(node);
            }

            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                var transformed = (ClassDeclarationSyntax)base.VisitClassDeclaration(node);
                if (!foundPCEH)
                    return transformed
                        .AddMembers(
                            F.EventFieldDeclaration(
                                F.VariableDeclaration(pceh)
                                    .AddVariables(F.VariableDeclarator("PropertyChanged")))
                            .WithModifiers(SyntaxTokenList.Create(F.Token(SyntaxKind.PublicKeyword))));
                else
                    return transformed;
            }

            TypeSyntax pceh = F.ParseTypeName("System.ComponentModel.PropertyChangedEventHandler");
            private bool foundPCEH;
            private DiagnosticDescriptor diagDesc = 
                new DiagnosticDescriptor("INPC001", "PropertyChanged already created (just testing, everything's ok)", "PropertyChanged already created (just testing, everything's ok)", 
                    "Macro", DiagnosticSeverity.Warning, true);
        }

        public override SyntaxNode Transform(TransformContext context)
        {
            // Uncomment the below line to launch a debugger
            //System.Diagnostics.Debugger.Launch();
            var t = new MyRewriter().Run(context);
            return t;
        }
    }
}
