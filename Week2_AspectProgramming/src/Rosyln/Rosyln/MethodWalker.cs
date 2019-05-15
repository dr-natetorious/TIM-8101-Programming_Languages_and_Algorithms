using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rosyln
{
    public class MethodWalker : CSharpSyntaxRewriter
    {
        private readonly ICompilationUnitSyntax root;
        private readonly SemanticModel model;

        public MethodWalker(ICompilationUnitSyntax root, SemanticModel model)
        {
            this.root = root;
            this.model = model;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (node.Modifiers.Any(m => m.Text == "public") == false)
            {
                return node;
            }

            var checkedParameters = new List<string>();
            var blockSyntax = node.ChildNodes().OfType<BlockSyntax>().FirstOrDefault();
            if (blockSyntax == null)
            {
                return node;
            }

            // Find all the parameter checks..
            checkedParameters.AddRange(WalkMethodBody(blockSyntax));

            // Find which parameters are not checked...
            var parameters = node.ParameterList.Parameters.Select(p => p.Identifier.Text);
            var statements = new List<StatementSyntax>();

            // Get friendly text for declarer...
            string declaredBy = node.Identifier.Text;
            if (node.Parent is ClassDeclarationSyntax classDeclaration)
            {
                declaredBy = $"{classDeclaration.Identifier.Text}::{declaredBy}";
            }

            foreach (var parameterName in parameters)
            {
                if (checkedParameters.Contains(parameterName))
                {
                    continue;
                }

                var parameterInfo = node.ParameterList.Parameters.First(
                    p => p.Identifier.Text == parameterName);

                if (parameterInfo.Default != null)
                {
                    continue;
                }

                var check = SyntaxFactory.ParseStatement(
                    $@"// Check parameter...
                       if({parameterName} == null){{
                           throw new System.ArgumentNullException(
                               ""{parameterName}"",
                               ""{parameterName} was not provided to {declaredBy}."");
                       }}
                    ");

                statements.Add(check);
            }

            // If any checks are needed inject them...
            if (statements.Count == 0)
            {
                return node;
            }

            statements.AddRange(blockSyntax.Statements);
            var block = SyntaxFactory.Block(statements);

            var result = node.ReplaceNode(blockSyntax, block);
            return result;
        }

        private IReadOnlyList<string> WalkMethodBody(BlockSyntax block)
        {
            var checkedParameters = new List<string>();
            foreach (var ifStatement in block.ChildNodes().OfType<IfStatementSyntax>())
            {
                foreach(var binaryExpression in ifStatement.ChildNodes().OfType<BinaryExpressionSyntax>())
                {
                    if (binaryExpression.Left is IdentifierNameSyntax identifier)
                    {
                        checkedParameters.Add(identifier.Identifier.Text);
                    }
                }
            }

            return checkedParameters;
        }
    }
}
