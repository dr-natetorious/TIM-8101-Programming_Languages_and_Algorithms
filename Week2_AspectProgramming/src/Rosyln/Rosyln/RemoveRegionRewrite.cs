using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rosyln
{
    public sealed class RemoveRegionRewrite : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            return node.Parent.RemoveNode(node, SyntaxRemoveOptions.KeepNoTrivia);
        }

        public override SyntaxNode VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            return node.Parent.RemoveNode(node, SyntaxRemoveOptions.KeepNoTrivia);
        }
    }
}
