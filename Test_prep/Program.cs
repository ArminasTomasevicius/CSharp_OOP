using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test_prep
{
    class Program
    {
        const string input = "..\\..\\input.txt";
        const string output = "..\\..\\output.txt";


        static void Main(string[] args)
        {
            string sk = "/+|";
            using (StreamReader reader = new StreamReader(input))
            {
                while (reader.ReadLine() != null)
                {
                    string line = reader.ReadLine();
                    RastiZodiEil(line, sk, zod);
                }
            }
        }

        static int EilutesBSkaicius(string e)
        {
            char[] balsiai = { 'a', 'e', 'i', 'y', 'u', 'o' };
            int kiek = 0;
            for (int j = 0; j < balsiai.Length-1; j++)
            {
                int i = e.IndexOf(balsiai[j], 0, e.Length - 1);
                if (i != -1)
                {
                    kiek++;
                }
            }
            return kiek;
        }

        static void RastiZodiEil(string e, string sk, out string zod)
        {
            string min = "";
            string[] words = Wording(e);
            for (int i = 0; i < words.Length-1; i++)
            {
                if (EilutesBSkaicius(words[i]) >= 2)
                {
                    if (min.Length-1 < words[i].Length-1)
                    {
                        min = words[i];
                    }
                }
            }
            zod = min;
        }

        static void RastiZTekste(string input, string sk, out string zod, ref int nr)
        {
            string text = File.ReadAllText(input);
                    string[] words = Wording(text);
                    for (int i = 0; i < words.Length-1; i++)
                    {
                        if (SkirtBalsiuSkaicius(words[i]) >= 3)
                        {

                        }
                        SkirtBalsiuSkaicius(words[i]);
                    }
                }

        static void PerkeltiEilute(string input, string output, int n)
        {

        }

        public static string[] Wording(string text)
        {
            string[] words = Regex.Matches(text, "\\w+")
              .OfType<Match>()
              .Select(m => m.Value)
              .ToArray();

            return words;
        }
    }
}

/* Notes
 * 
 * string[] arr = words.Where(s => s != word).ToArray();
 * using (StreamReader reader = new StreamReader(input))
            {
                while (reader.ReadLine() != null)
                {
                    string line = reader.ReadLine();
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);

//char_masyvas = Eil.ToCharArray(pr_nr, simb_kiek) – eilutės simbolius surašo (konvertuoja) į char_masyvą;
//Eil1.IndexOf(simbolis, pr, kiekis) – randa simbolio pirmą vietą eilutėje, pradedant nuo simbolio, kurio numeris pr, ir tikrinant simbolių kiekį kiekis;

//Eil.Insert(vieta, kint) – įterpimas į eilutę.kint - bool, char, int, double, string tipo kintamasis arba char tipo masyvas; 
//Eil.Remove(pr, kiek) – šalina iš eilutės simbolius.pr – pradinis adresas; kiek – kiekis;

    using (var fr = File.AppendText(CFr))
            {
            fr.WriteLine();

 */
