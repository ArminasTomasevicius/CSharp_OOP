using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System;

namespace P5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "..\\..\\input.txt";
            const string rez = "..\\..\\Rezultatai.txt";
            string lines = File.ReadAllText(input);
            string output = Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
            Console.WriteLine(output);
            output = output.Replace("\n", Environment.NewLine);
            File.WriteAllText(rez, output);
        }
    }
}