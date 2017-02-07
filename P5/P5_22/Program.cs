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

        static void Read(string input, ref int matches, char[] skirikliai)
        {
            string[] parts = new string[10];

            using (StreamReader reader = new StreamReader(input))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length; i=i+2)
                    {
                        if (match(parts[i],parts[i+1]))
                        {
                            matches++;
                        }
                    }

                    int min = 0;
                    string trans_word="";
                    Console.WriteLine(parts.Length);

                    for (int j = 0; j < parts.Length-1; j++)
                    {
                        int length = parts[j].Length + parts[j + 1].Length;
                        if (min < length)
                        {
                            trans_word = parts[j];
                            min = trans_word.Length;
                            int index = j;
                        }
                    }
                    string[] naujas = parts.Where(str => str != trans_word).ToArray();
                    naujas[naujas.Length-1] = trans_word;
                    Console.WriteLine(trans_word);
   
                   /* for (int i = 0; i < naujas.Length; i++)
                    {
                        Console.WriteLine(naujas[i]);
                    }*/
                }
            }
        }

        static void move()
        {

        }

        static bool match(string text1, string text2)
        {
            if (text1[text1.Length-1] == text2[0])
            {
                Console.WriteLine("t");
                return true;
            }
            else
                Console.WriteLine("f");
            return false;
        }


        public static string Arraying(string text)
        {
            string word = Regex.Matches(text, "\\w+")
              .OfType<Match>()
              .Select(m => m.Value)
              .ToString();

            return word;
        }

    }
            
    }






//char_masyvas = Eil.ToCharArray(pr_nr, simb_kiek) – eilutės simbolius surašo (konvertuoja) į char_masyvą;
//Eil1.IndexOf(simbolis, pr, kiekis) – randa simbolio pirmą vietą eilutėje, pradedant nuo simbolio, kurio numeris pr, ir tikrinant simbolių kiekį kiekis;

//Eil.Insert(vieta, kint) – įterpimas į eilutę.kint - bool, char, int, double, string tipo kintamasis arba char tipo masyvas; 
//Eil.Remove(pr, kiek) – šalina iš eilutės simbolius.pr – pradinis adresas; kiek – kiekis;
