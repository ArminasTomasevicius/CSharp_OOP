using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_3_3
{
    class Dviratis
    {

        private int metai;
        private double kaina;
        private string eil;
        private int kiek;

        public Dviratis(string eil, int metai, int kiek, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
            this.eil = eil;
            this.kiek = kiek;
        }

        public double ImtiKainą
        {
            set { kaina = value; }
            get { return kaina; }
        }


        public int ImtiMetus
        {
            set { metai = value; }
            get { return metai; }
        }

        public string ImtiPavadinimą
        {
            set { eil = value; }
            get { return eil; }
        }

        public int ImtiKiekį
        {
            set { kiek = value; }
            get { return kiek; }
        }

        public void PapildytiKiekį(int k)
        {
            kiek = kiek + k;

        }
    }
    class Program
    {
        const string CFd1 = "...\\...\\Duom1.txt";
        const string CFd2 = "...\\...\\Duom2.txt";
        const string CFrez = "...\\...\\Rez.txt";

        static void Main(string[] args)
        {
            Dviratis[] D1 = new Dviratis[100];
            Dviratis[] D2 = new Dviratis[100];
            int n1;
            string pav1;
            int n2;
            string pav2;

            Skaityti(CFd1, D1, out n1, out pav1);
            Skaityti(CFd2, D2, out n2, out pav2);

            int ind1 = Seniausias(D1, n1);
            int ind2 = Seniausias(D2, n2);

            Console.WriteLine("Pirmas nuomos punktas:  {0}", pav1);
            Console.WriteLine("Dviračių kiekis {0}\n", n1);
            Console.WriteLine("Pavadinimas   Kiekis    Pagaminimo metai     Kaina");
            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine("{0,-12}  {1,4:d}           {2,3:d}          {3, 7:f2}", D1[i].ImtiPavadinimą, D1[i].ImtiKiekį, D1[i].ImtiMetus, D1[i].ImtiKainą);
            }

            if (File.Exists(CFrez)) File.Delete(CFrez);
            SpausdintiDuomenis(CFrez, D1, n1, pav1);
            SpausdintiDuomenis(CFrez, D2, n2, pav2);


            using (var fr = File.AppendText(CFrez))
            {
                if (D1[ind1].ImtiMetus == D2[ind2].ImtiMetus)
                {
                    fr.WriteLine("Seniausias dviratis yra nuomos punktuose: {0}  {1} ", pav1, pav2);
                }
                else if (D1[ind1].ImtiMetus > D2[ind2].ImtiMetus)
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0} ", pav1);
                else
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte {0} ", pav2);
            }

            Dviratis[] Dr = new Dviratis[100];
            int nr;
            nr = 0;
            Formuoti(D1, n1, Dr, ref nr);
            Formuoti(D2, n2, Dr, ref nr);
            SpausdintiDuomenis(CFrez, Dr, nr, "Modelių sąrašas");

        }



        static void Skaityti(string Fd, Dviratis[] D, out int n1, out string pav1)
        {
            using (StreamReader reader = new StreamReader(Fd))
            {
                string eil;
                int kiek;
                int metai;
                double kaina;
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav1 = line;
                line = reader.ReadLine();
                n1 = int.Parse(line);
                for (int i = 0; i < n1; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    eil = parts[0];
                    kiek = int.Parse(parts[1]);
                    metai = int.Parse(parts[2]);
                    kaina = double.Parse(parts[3]);
                    D[i] = new Dviratis(eil, metai, kiek, kaina);
                }
            }
        }

        static void SpausdintiDuomenis(string fv, Dviratis[] D, int kiek, string pav)
        {
            const string virsus = "|-----------------|------------|---------------|---------|\r\n" + "|   Pavadinimas   |   Kiekis   |  Pagaminimo   |  Kaina  | \r\n" + "|                 |            |     metai     |  (eurų) | \r\n" + "|-----------------|------------|---------------|---------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Nuomos firma: {0}", pav);
                fr.WriteLine(virsus);
                Dviratis tarp;
                kiek = 5;
                for (int i = 0; i < kiek; i++)
                {
                    tarp = D[i];
                    fr.WriteLine("| {0,-15} | {1,8}   |    {2,5:d}      | {3,7:F2} |", tarp.ImtiPavadinimą, tarp.ImtiKiekį, tarp.ImtiMetus, tarp.ImtiKainą);
                }
                fr.WriteLine("----------------------------------------------------------");
            }
        }

        static int Seniausias(Dviratis[] D, int n)
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (D[i].ImtiMetus < D[k].ImtiMetus)
                {
                    k = i;
                    return k;
                }
            }
            return 0;
        }


        static int YraModelis(Dviratis[] D, int n, string pav, int metai)
        {
            for (int i = 0; i < n; i++)
                if (D[i].ImtiPavadinimą == pav && D[i].ImtiMetus == metai)
                    return i;
            return -1;
        }

        static void Formuoti(Dviratis[] D, int n, Dviratis[] Dr, ref int nr)
        {
            int k;
            for (int i = 0; i < n; i++)
            {
                k = YraModelis(Dr, nr, D[i].ImtiPavadinimą, D[i].ImtiMetus);
                if (k >= 0) Dr[k].PapildytiKiekį(D[i].ImtiKiekį);
                else
                    Dr[nr] = D[i];
                    nr++;
            }
        }


        static string Brangiausias(Dviratis[] D, int n)
        {
            double j = 0;
            for(int i = 0; i < n; i++ )
            {
                if (D[i].ImtiKainą > j)
                {
                    j = D[i].ImtiKainą;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (D[i].ImtiKainą == j)
                {
                    return D[i].ImtiPavadinimą;
                }
            }
            return "";
        }
    }
}
