using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStream = new StreamReader(Console.OpenStandardInput());
            var input = new AntlrInputStream(inputStream.ReadToEnd());
            var lexer = new Combined1Lexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new Combined1Parser(tokens);
            var tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));
            var visitor = new Combined1Visitor();
            Console.WriteLine(visitor.Visit(tree));

            Console.Read();
        }
    }
}
