using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;

namespace Rosyln
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(args[0]);
            var workspace = new AdhocWorkspace();
            var texas = new StyleWriter();
            foreach (var file in directory.GetFiles("*.cs", SearchOption.AllDirectories))
            {
                Console.WriteLine($"{file.FullName}...");
                var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(file.FullName));
                var root = tree.GetCompilationUnitRoot();

                var compilation = CSharpCompilation.Create("Mastery")
                    .AddSyntaxTrees(tree);

                var model = compilation.GetSemanticModel(tree);
                //var rewrite = dict_rewrite.Visit(root);

                //var white = new MethodWalker(root, model);
                //var rewrite = texas.Visit(white.Visit(root));
                var rewrite = texas.Visit(root);

                using (var sw = new StreamWriter(file.FullName, append: false))
                {
                    var formatted = Formatter.Format(rewrite, workspace).ToFullString();
                    sw.Write(formatted);
                }
            }
        }
    }
}
