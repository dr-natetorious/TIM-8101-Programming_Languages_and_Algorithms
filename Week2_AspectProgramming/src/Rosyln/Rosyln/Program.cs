using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace Rosyln
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(args[0]);
            foreach (var file in directory.GetFiles("*.cs", SearchOption.AllDirectories))
            {
                Console.WriteLine($"{file.FullName}...");
                var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(file.FullName));
                var root = tree.GetCompilationUnitRoot();

                var compilation = CSharpCompilation.Create("Mastery")
                    .AddSyntaxTrees(tree);

                var model = compilation.GetSemanticModel(tree);

                var texas = new MethodWalker(root, model);
                var rewrite = texas.Visit(root);

                using (var sw = new StreamWriter(file.OpenWrite()))
                {
                    rewrite.WriteTo(sw);
                }
            }
        }
    }
}
