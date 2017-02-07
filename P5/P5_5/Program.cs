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
        const string input = "..\\..\\input.txt";
        const string rez = "..\\..\\rez.txt";

        static void Main(string[] args)
        {
            if (File.Exists(rez))
                File.Delete(rez);

            
            Console.WriteLine("Žodis kurį norite išimti");
            string word = Console.ReadLine();

            Write(word);
            
        }

        public static string[] Remove(string[] words, string word)
        {

            string[] arr = words.Where(s => s != word).ToArray();
            return arr;
        }

        public static void Write(string word)
        {
            char[] skirikliai = { '/', '*', '#', '+' };
            string[] parts = new string[1000];
            using (StreamReader reader = new StreamReader(input))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);
                    string[] naujas = Remove(parts, word);
                    using (var fr = File.AppendText(rez))
                    {
                        for (int i = 0; i < naujas.Length; i++)
                        {
                            fr.Write(naujas[i] + " ");
                        }
                        fr.WriteLine();
                    }
                }
            }
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