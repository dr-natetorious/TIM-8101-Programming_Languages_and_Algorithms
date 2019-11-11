using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace Rosyln
{
    class UseCaseInsensitiveDictionaryRewrite : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (node.Type is GenericNameSyntax typeName)
            {
                // Check if this is a Dictionary<T,K>
                if (string.Equals(typeName.Identifier.Text, "Dictionary", StringComparison.Ordinal) == false)
                {
                    Console.WriteLine($"Skipping {typeName}...");
                    return node;
                }

                // Check if this is a Dictionary<string, K>
                var keyType = typeName.TypeArgumentList.Arguments[0];
                if (keyType is PredefinedTypeSyntax predefinedType)
                {
                    if (string.Equals(predefinedType.Keyword.Text, "string", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        Console.WriteLine($"Skipping {typeName}...");
                        return node;
                    }
                }

                // Confirm the first argument is OrdinalIgnoreCase
                var found = false;
                foreach(var argument in node.ArgumentList.Arguments)
                {
                    if (argument.Expression is MemberAccessExpressionSyntax expression)
                    {
                        var desired = "StringComparer.OrdinalIgnoreCase";
                        if (string.Equals(Convert.ToString(expression.GetText()), desired))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                //if (found == false)
                //{
                //    node.AddArgumentListArguments(
                //        kines: SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                //        SyntaxFactory.ParseExpression("System.StringComparer.OrdinalIgnoreCase"));
                //}
            }

            return node;
        }
    }
}
