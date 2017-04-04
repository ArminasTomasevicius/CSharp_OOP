using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_22
{
    class Bankas
    {
        private string pav, salis;
        private int skaicius;

        public Bankas()
        {
            pav = "";
            salis = "";
            skaicius = 0;
        }

        public void Dėti(string pav, string salis, int skaicius)
        {
            this.pav = pav;
            this.salis = salis;
            this.skaicius = skaicius;
        }

        public string ImtiPav() { return pav; }

        public string ImtiSalis() { return salis; }

        public int ImtiSkaicius() { return skaicius; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -15} {1, -10}   {2,2:d}", pav, salis, skaicius);
            return eilute;
        }

    }

    class Bankai
    {
        private Bankas[] Banku;
        const int CMaxMk = 1000;
        const int CMaxDn = 30;
        public int n { get; set; }
        private int[,] Matrica;

        public Bankai()
        {
            n = 0;
            Banku = new Bankas[CMaxMk];
            Matrica = new int[CMaxMk, CMaxDn];
        }

        public Bankas Imti(int nr) { return Banku[nr]; }

        public void Dėti(Bankas ob) { Banku[n++] = ob; }

        public void PakeistiBanka(int nr, Bankas mok) { Banku[nr] = mok; }

        public void DėtiMatrica(int i, int j, int r) { Matrica[i, j] = r; }

        public int ImtiMatrica(int i, int j) { return Matrica[i, j]; }

        public void Rikiuoti()
        {

        }

    }


    class Program
    {
        const string input = "...\\...\\input.txt";
        const string output = "...\\...\\output.txt";

        static void Main(string[] args)
        {
            Bankai bankai = new Bankai();
            SkaitytiMok(input, ref bankai);

        }

        static void SkaitytiMok(string fd, ref Bankai bankai)
        {
            string pav, salis;
            int skaicius, n, prc;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    salis = parts[1];
                    skaicius = int.Parse(parts[2]);
                    Bankas ban;
                    ban = new Bankas();
                    ban.Dėti(pav, salis, skaicius);
                    bankai.Dėti(ban);
                    Console.WriteLine(bankai.n);
                }

                for (int i = 0; i < bankai.n; i++)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                    parts = line.Split(';');
                    for (int j = 0; j < 6; j++)
                    {
                        prc = int.Parse(parts[j]);
                        bankai.DėtiMatrica(i, j, prc);
                    }
                }
            }
        }

        static void KiekValstybiu(Bankai bankai)
        {
            for (int i = 0; i < bankai.n; i++)
            {
                = bankai.Imti(i).ImtiSalis;
            }

        }
    

}
    }
