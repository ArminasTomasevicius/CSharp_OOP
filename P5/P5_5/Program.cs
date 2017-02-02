﻿using System;
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
            Console.WriteLine("Žodis kurį norite išimti");
            string word = Console.ReadLine();

            /*using (StreamReader reader = new StreamReader(input))
            {
                //while (reader.ReadLine() != null)
                //{
                    string line = reader.ReadLine();
                    char[] simbols = line.ToCharArray();
                    for (int i =0; i < simbols.Length; i++)
                    {
                        Console.Write(simbols[i]);
                    }

               // }
            }
                */
                string[] wordsremoved = Remove(words, word);
            string s = string.Join(" ", wordsremoved);
            s = s.Replace("\n", Environment.NewLine);
                


                File.WriteAllText(rez, s);
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

            string[] arr = words.Where(s => s != word).ToArray();
            return arr;
            
        }
    }
}



// Notes
/*

int removeIndex = Array.IndexOf(words, word);

            if (removeIndex >= 0)
            {
                // declare and define a new array one element shorter than the old array
                string[] newStrItems = new string[words.Length - 1];

                // loop from 0 to the length of the new array, with i being the position
                // in the new array, and j being the position in the old array
                for (int i = 0, j = 0; i<newStrItems.Length; i++, j++)
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



    */