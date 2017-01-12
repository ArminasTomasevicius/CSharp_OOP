using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "..\\..\\input.txt";

            string text = File.ReadAllText(input);
            string textrev = Reverse(text);

            string[] words = Arraying(text);
            string[] wordsrev = Arraying(textrev);

            Console.WriteLine("Polindromų kiekis {0}", Repeats(words, wordsrev));
        }

        public static string[] Arraying(string text)
        {
            string[] words = Regex.Matches(text, "\\w+")
              .OfType<Match>()
              .Select(m => m.Value)
              .ToArray();

            return words;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int Repeats(string[] words, string[] wordsrev)
        {
            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < wordsrev.Length; j++)
                {
                    if ((words[i] == wordsrev[j]) && (words[i].Length == wordsrev[j].Length))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
