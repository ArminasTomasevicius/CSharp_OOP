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
            if (File.Exists(CFr))
                File.Delete(CFr);

            List<Knygos> Knyg = new List<Knygos>();
            List<Knygos> KnygosPglLeidykla = new List<Knygos>();
            List<string> Autoriai = new List<string>();

            Skaityti(CFd, Knyg);
            Rasyti(Knyg, "Pradiniai Duomenys");
            RastiSeniausias(Knyg);

            Console.Write("Sarasas Leidyklos: ");
            string leidykla = Console.ReadLine();
            LeidykosSarasas(Knyg, KnygosPglLeidykla, leidykla);
            Rasyti(KnygosPglLeidykla, "Pasirinktos Leidyklos Knygos");

            Rikiuoti(KnygosPglLeidykla);
            Rasyti(KnygosPglLeidykla, "Surikiuotos Knygos");

            SudarytiAutoriuSarasa(Knyg, Autoriai);
            Rasyti_Autorius(Autoriai);
        }

        static void Skaityti(string fv, List<Knygos> Knygos)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    int isbn = int.Parse(parts[0]);
                    string pav = parts[1].Trim();
                    string autor = parts[2].Trim();
                    string type = parts[3].Trim();
                    string leidykla = parts[4].Trim();
                    double isleidimas = double.Parse(parts[5]);
                    int psl = int.Parse(parts[6]);
                    Knygos kn = new Knygos(isbn, pav, autor, type, leidykla, isleidimas, psl);
                    Knygos.Add(kn);
                }
            }
        }

        static void Rasyti(List<Knygos> kn, string antrast)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine(antrast);
                fr.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                fr.WriteLine("| ISBN |            Pavadinimas            |            Autorius            | Metai | Puslapiu sk. |      Tipas      |      Leidykla      |");
                fr.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

                for (int i = 0; i < kn.Count; i++)
                {
                    fr.WriteLine("{0}", kn[i].ToString());
                }
                fr.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                fr.WriteLine();
            }
        }

        static void Rasyti_Autorius(List<string> Autoriai)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("Autoriu sarasas");
                for (int i = 0; i < Autoriai.Count; i++)
                {
                    fr.WriteLine("{0}", Autoriai[i]);
                }
            }
        }

        static void RastiSeniausias(List<Knygos> Knygos)
        {
            int counter = 0;
            double max = double.MaxValue;
            for (int i = 0; i < Knygos.Count; i++)
            {
                if (Knygos[i].metai<max)
                {
                    max = Knygos[i].metai;
                }
            }

            for (int i = 0; i < Knygos.Count; i++)
            {
                if (max == Knygos[i].metai && counter < 2)
                {
                    using (var fr = File.AppendText(CFr))
                    {
                        fr.WriteLine("Seniausia knyga: {0}", Knygos[i].ToString());
                    }
                    counter++;
                }
            }
        }

        static void LeidykosSarasas(List<Knygos> Knygos, List<Knygos> KnygosPglLeidykla, string leidykla)
        {
            for (int i = 0; i < Knygos.Count; i++)
            {
                if (leidykla == Knygos[i].Leidykla)
                {
                    KnygosPglLeidykla.Add(Knygos[i]);
                }
            }
        }

        static void Rikiuoti(List<Knygos> Knygos)
        {
            Knygos.Sort();
        }

        static void SudarytiAutoriuSarasa(List<Knygos> Knygos, List<string> Autoriai)
        {
            for(int i = 0; i < Knygos.Count; i++)
            {
                if (!Autoriai.Contains(Knygos[i].autor))
                    Autoriai.Add(Knygos[i].autor);
            }
        }
    }
}
