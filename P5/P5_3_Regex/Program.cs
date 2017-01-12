using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P5_3_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var PaliekamStrings = @"@(""[^""]*"")+";
            const string input = "..\\..\\input.txt";
            const string rez = "..\\..\\Rezultatai.txt";
            string lines = File.ReadAllText(input, Encoding.GetEncoding(1257));
            string resultString = Regex.Replace(lines, blockComments + "|" + lineComments + "|" + strings + "|" + PaliekamStrings, me => {
                if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                    if (me.Value.StartsWith("//"))
                        return Environment.NewLine;
                    else
                        return "";
            return me.Value;
            }, RegexOptions.Singleline);

           // string resultString1 = Regex.Replace(lines, @"\/+\*|\*+\/|\/+\/", "");
          //  resultString = resultString.Replace("\n", Environment.NewLine);
            Console.WriteLine(resultString);
            File.WriteAllText(rez, resultString);
        }
    }
}
