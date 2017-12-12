using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Program
    {
        const string CFd = "..\\..\\Biblioteka.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            List<Knyga> Knygos = new List<Knyga>();
            Skaityti(CFd, Knygos);
            RastiSeniausias(Knygos);

        }

        static void Skaityti(string fv, List<Knyga> Knygos)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line; while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    int isbn = int.Parse(parts[0]);
                    string pav = parts[1].Trim();
                    string autor = parts[2].Trim();
                    string type = parts[3].Trim();
                    string leidykla = parts[4].Trim();
                    DateTime isleidimas = DateTime.Parse(parts[5]);
                    int psl = int.Parse(parts[6]);
                    Knyga kn = new Knyga(isbn, pav, autor, type, leidykla, isleidimas, psl);
                    Knygos.Add(kn);
                }
            }
        }

        static void Rasyti()
        {

        }

        static void RastiSeniausias(List<Knyga> Knygos)
        {
            DateTime min = DateTime.MinValue;
            for (int i = 0; i < Knygos.Count; i++)
            {
                if (Knygos[i])
                {

                }
            }

            for (int i = 0; i < Knygos.Count; i++)
            {
                if ()
                {

                }
            }
        }

        static void LeidykosSarasas()
        {

        }

        //rikiuoti pgl pasirinktus bruozus (2)

        static void SudarytiAutoriuSarasa()
        {

        }
    }
}
