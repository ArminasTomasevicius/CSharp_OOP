using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class Program
    {
        const string CFd1 = "..\\..\\Prekes.txt";
        const string CFd2 = "..\\..\\Prekes1.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            if (File.Exists(CFr))
                File.Delete(CFr);
            List<Prekes> PrekiuList = new List<Prekes>();
            Skaityti(CFd1, PrekiuList);
            Spausdinti(CFr, PrekiuList, "Pradinis sąrašas");

            List<Prekes> NaujasPrekiuList = new List<Prekes>();
            Perrasyti(PrekiuList, NaujasPrekiuList);
            Console.WriteLine("Ivesti prekes tipa");
            string prekesTipas = Console.ReadLine();
            NaujasPrekiuList.RemoveAll(item => item.tipas == prekesTipas);
            if (NaujasPrekiuList.Count() > 0)
            {
                Spausdinti(CFr, NaujasPrekiuList, "Suformuotas sarasas");
                NaujasPrekiuList.Sort();
                Spausdinti(CFr, NaujasPrekiuList, "Rikiuotas suformuotas sarasas");
                using (var fr = File.AppendText(CFr))
                {
                    double vid = NaujasPrekiuList.Average(item => item.kiek);
                    fr.WriteLine("Kiekio vidurkis = {0, 5:f}", vid);
                }
            }
            else
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Naujas sarasas tuscias");
                }

            List<Prekes> Papildomas = new List<Prekes>();
            Skaityti(CFd2, Papildomas);
            Papildomas.RemoveAll(item => item.tipas == prekesTipas);
            if (Papildomas.Count() > 0)
            {
                Spausdinti(CFr, Papildomas, "Papildomas sarasas");
                Iterpti(NaujasPrekiuList, Papildomas);
                Spausdinti(CFr, NaujasPrekiuList, "Iterptas sarasas");

            }
            else
            {
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Papildomas sarasas tuscias");
                }
            }


            if (PrekiuList.Count>0)
            {
                Padidinti(PrekiuList);
                Spausdinti(CFr, PrekiuList, "Padidintas pradinių prekiu sarasas");
            }
            else
            {
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Padidintas pradiniu prekiu sarasas tuscias");
                }
            }

            if (NaujasPrekiuList.Count>0)
            {
                Padidinti(NaujasPrekiuList);
                Spausdinti(CFr, NaujasPrekiuList, "Padidintas surikiuotu prekiu sarasas");
            }
            else
            {
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Padidintas surikiuotu prekiu sarasas tuscias");
                }
            }

            if (Papildomas.Count>0)
            {
                Padidinti(Papildomas);
                Spausdinti(CFr, Papildomas, "Padidintas papildomas sarasas");
            }
            else
            {
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Padidintas papildomu prekiu sarasas tuscias");
                }
            }

        }


        static void Perrasyti(List<Prekes> PrekiuList, List<Prekes> NaujasPrekiuList)
        {
            for (int i = 0; i < PrekiuList.Count; i++)
            {
                Prekes p = new Prekes(PrekiuList[i].pavadinimas, PrekiuList[i].tipas, PrekiuList[i].kaina, PrekiuList[i].kiek);
                NaujasPrekiuList.Add(p);
            }
        }

        static void Skaityti(string fv, List<Prekes> PrekiuList)
        {
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line; while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string pav = parts[0].Trim();
                    string tema = parts[1].Trim();
                    double kaina = double.Parse(parts[2]);
                    int kiek = int.Parse(parts[3]);
                    Prekes pr = new Prekes(pav, tema, kaina, kiek);
                    PrekiuList.Add(pr);
                }
            }
        }

        static void Spausdinti(string fv, List<Prekes> PrekiuList, string info)
        {
            const string virsus = "----------------------------------------------------------\r\n" + " Pavadinimas           Tipas                Kaina   Kiekis \r\n" + "----------------------------------------------------------"; using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(info); fr.WriteLine(virsus); for (int i = 0; i < PrekiuList.Count; i++)
                { Prekes pr = PrekiuList[i]; fr.WriteLine("{0}", pr); }
                fr.WriteLine("--------------------------------------------------" + "--------\r\n");
            }
        }

        static double Sum(List<Prekes> PrekiuList)
        {
            double su = 0;
            for (int i = 0; i < PrekiuList.Count; i++)
                su = su + PrekiuList[i].Suma();
            return su;
        }

        static void Iterpti(List<Prekes> NaujasPrekiuList, List<Prekes> Papildomas)
        {
            for (int i = 0; NaujasPrekiuList.Count() > i; i++)
            {
                for (int j = i; Papildomas.Count() > j; j++)
                {
                    if (NaujasPrekiuList[i].CompareTo(Papildomas[j]) == 1)
                    {
                        NaujasPrekiuList.Insert(i, Papildomas[j]);
                    }
                }
            }
        }

        static void Padidinti(List<Prekes> Prekes)
        {
            for (int i = 0; i < Prekes.Count; i++)
            {
                Prekes[i].Padidinti();
            }
        }
    }
}
