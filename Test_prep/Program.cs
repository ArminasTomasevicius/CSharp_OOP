using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K2_117
{
    class Program
    {
        const string input = "..\\..\\Tekstas.txt";
        const string output = "..\\..\\RedTekstas.txt";


        static void Main(string[] args)
        {
            string zod = "";
            int nr = 0;
            string s = " .,;:?!";
            if (File.Exists(output))
                File.Delete(output);
            RastiZTekste(input, s, out zod, ref nr);
            PerkeltiEilute(input, output, nr);
        }


        static int NelygSkaitmenuSkaicius(string e)
        {
            char[] nskait = { '1', '3', '5', '7', '9' };
            int kiek = 0;
            for (int j = 0; j < nskait.Length; j++)
            {
                int i = e.IndexOf(nskait[j], 0, e.Length);
                if (i != -1)
                {
                    kiek++;
                }
            }
            Console.WriteLine(kiek);
            return kiek;
        }

        static void TrumpasZodis(string e, string s, out string zod)
        {
            int counter = 0;
            string min = "";
            string[] parts = new string[100];
            char[] masyvas = s.ToCharArray(0, s.Length);
            parts = e.Split(masyvas, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                if ((NelygSkaitmenuSkaicius(parts[i]) >= 2) && (parts[i][0] == '2'))
                {
                    if ((min.Length < parts[i].Length) || (min.Length == 0))
                    {
                        min = parts[i];
                        counter++;
                        Console.WriteLine("count" + counter);
                    }
                }
            }
            if (counter > 0)
            {
                zod = min;
            }
            else
            {
                zod = "";
            }
        }

        static void RastiZTekste(string fv, string s, out string zod, ref int nr)
        {
            int counter = 0;
            bool yra = false;
            using (StreamReader reader = new StreamReader(input))
            {
                string min = "kjhklhkljhlkjhkljhkjlhkjhkljhkljhkjlh";
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                    TrumpasZodis(line, s, out zod);

                    if (zod.Length < min.Length)
                    {
                        min = zod;
                        Console.WriteLine(min);
                        nr = counter;
                        yra = true;
                    }
                }

                if (yra)
                {
                    zod = min;
                }
                else
                {
                    zod = "";
                }

            }
        }

        static void PerkeltiEilute(string fv1, string fv2, int nr)
        {
            using(StreamReader reader = new StreamReader(input))
            using (var fr = File.AppendText(output))
            {
                int counter = 0;
                string line;
                string nukelta="";
                while ((line = reader.ReadLine()) != null)
                {
                    counter++;
                    if (counter != nr)
                        fr.WriteLine(line);
                    else
                        nukelta = line;
                }
                fr.WriteLine(nukelta);
            }
        }
    }
}
