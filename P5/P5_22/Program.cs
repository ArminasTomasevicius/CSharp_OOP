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
        const string input = "..\\..\\input.txt";
        const string rez = "..\\..\\rez.txt";
        static void Main(string[] args)
        {
            char[] skirikliai = {'/', '!', '+'};
            int matches = 0;
            if (File.Exists(rez))
                File.Delete(rez);
            Read(input, ref matches, skirikliai);
            Console.WriteLine("Atitikimai:");
            Console.WriteLine(matches);

        }

        static void Read(string input, ref int matches, char[] skirikliai)
        {
            string[] parts = new string[1000];

            using (StreamReader reader = new StreamReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        if (match(parts[i], parts[i + 1]))
                        {
                            matches++;
                        }
                    }

                    int min = 0;
                    string trans_word = "";
                    Console.WriteLine(parts.Length);

                    for (int j = 0; j < parts.Length - 1; j++)
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
                    naujas[naujas.Length - 1] = trans_word;
                    Console.WriteLine(trans_word);

                    for (int i = 0; i < naujas.Length; i++)
                    {
                        using (var fr = File.AppendText(rez))
                        {
                            for (int j = 0; j < naujas.Length; j++)
                            {
                                fr.Write(naujas[j] + " ");
                            }
                            fr.WriteLine();
                        }
                    }
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
                return true;
            }
            else
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
