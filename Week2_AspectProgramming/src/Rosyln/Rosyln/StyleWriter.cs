using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rosyln
{
    class StyleWriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            return InsertCurlyBraces(node);
        }

        public override SyntaxNode VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            return InsertCurlyBraces(node);
        }

        public override SyntaxNode VisitElseClause(ElseClauseSyntax node)
        {
            return InsertCurlyBraces(node);
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            return InsertCurlyBraces(node);
        }

        private static SyntaxNode InsertCurlyBraces(SyntaxNode node)
        { 
            var children = node.ChildNodes();
            var expression = children.OfType<ExpressionStatementSyntax>().FirstOrDefault();
            if (expression == null)
            {
                return node;
            }

            var rewrite = node.ReplaceNode(expression, SyntaxFactory.Block(expression));
            return rewrite;
        }
    }
}
