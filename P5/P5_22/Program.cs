using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P5_22
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "..\\..\\input.txt";
            char[] skirikliai = {'/', '!', '+'};
            int matches = 0;
            Read(input, ref matches, skirikliai);
            Console.WriteLine(matches);

        }

        public static string Arraying(string text)
        {
            string word = Regex.Matches(text, "\\w+")
              .OfType<Match>()
              .Select(m => m.Value)
              .ToString();

            return word;
        }

        static void Read(string input, ref int matches, char[] skirikliai)
        {
            string[] parts = new string[1000];

            using (StreamReader reader = new StreamReader(input))
            {
                while (reader.ReadLine() != null)
                {
                    string line = reader.ReadLine();
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length-1; i++)
                    {
                        if (match(parts[i],parts[i+1]))
                        {
                            matches++;
                        }
                    }

                    int min = 0;
                    string trans_word="";
                    for (int j = 0; j < parts.Length; j=j+2)
                    {
                        int length = parts[j].Length + parts[j + 1].Length;
                        if (min < length)
                        {
                            trans_word = parts[j];
                            int index = j;
                        }
                    }
                    string[] naujas = parts.Where(str => str != trans_word).ToArray();
                    naujas[naujas.Length-1] = trans_word;

                    for (int i = 0; i < naujas.Length-1; i++)
                    {
                        Console.WriteLine(naujas[i]);
                    }
                }
            }
        }

        static void move()
        {

        }

        static bool match(string text1, string text2)
        {
            string word1 = Arraying(text1);
            string word2 = Arraying(text2);

            if (word1[word1.Length-1] == word2[0])
            {
                Console.WriteLine("t");
                return true;
            }
            else
                Console.WriteLine("f");
            return false;
        }

            }
            
        }


/* for (int i = 0; i<words.Length; i++)
 {
     for (int j = 0; j<words.Length; j++)
     {
     */




//char_masyvas = Eil.ToCharArray(pr_nr, simb_kiek) – eilutės simbolius surašo (konvertuoja) į char_masyvą;
//Eil1.IndexOf(simbolis, pr, kiekis) – randa simbolio pirmą vietą eilutėje, pradedant nuo simbolio, kurio numeris pr, ir tikrinant simbolių kiekį kiekis;

//Eil.Insert(vieta, kint) – įterpimas į eilutę.kint - bool, char, int, double, string tipo kintamasis arba char tipo masyvas; 
//Eil.Remove(pr, kiek) – šalina iš eilutės simbolius.pr – pradinis adresas; kiek – kiekis;
