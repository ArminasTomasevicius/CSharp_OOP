using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "..\\..\\input.txt";
            const string rez = "..\\..\\rez.txt";

            string text = File.ReadAllText(input);
            string[] words = Arraying(text);

            string word = Console.ReadLine();
            string[] wordsremoved = Remove(words, word);

            Spausdinti(rez, wordsremoved);
        }

        public static string[] Arraying(string text)
        {
            string[] words = Regex.Matches(text, "\\w+")
              .OfType<Match>()
              .Select(m => m.Value)
              .ToArray();

            return words;
        }

        public static string[] Remove(string[] words, string word)
        {
            int removeIndex = Array.IndexOf(words, word);

            if (removeIndex >= 0)
            {
                // declare and define a new array one element shorter than the old array
                string[] newStrItems = new string[words.Length - 1];

                // loop from 0 to the length of the new array, with i being the position
                // in the new array, and j being the position in the old array
                for (int i = 0, j = 0; i < newStrItems.Length; i++, j++)
                {
                    // if the index equals the one we want to remove, bump
                    // j up by one to "skip" the value in the original array
                    if (i == removeIndex)
                    {
                        j++;
                    }

                    // assign the good element from the original array to the
                    // new array at the appropriate position
                    newStrItems[i] = words[j];
                }

                // overwrite the old array with the new one
                words = newStrItems;
            }
            return words;
        }

        static void Spausdinti(string fv, string[] words)
        {
            using (var fr = File.CreateText(fv))
            {
                for (int i = 0; i < words.Length; i++)
                {
                    fr.Write(words[i] + " ");
                }
            }
        }

    }
}
