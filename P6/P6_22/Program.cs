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
        private int nr, skaicius;

        public Bankas()
        {
            nr = 0;
            pav = "";
            salis = "";
            skaicius = 0;
        }

        public void Dėti(int nr, string pav, string salis, int skaicius)
        {
            this.nr = nr;
            this.pav = pav;
            this.salis = salis;
            this.skaicius = skaicius;
        }

        public int ImtiNr() { return nr; }

        public string ImtiPav() { return pav; }

        public string ImtiSalis() { return salis; }

        public int ImtiSkaicius() { return skaicius; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -15} {1, -10}   {2,2:d}", pav, salis, skaicius);
            return eilute;
        }
        
       public static bool operator >=(Bankas b1, Bankas b2)
        {
 
            int p = string.Compare(b1.ImtiPav(), b2.ImtiPav(), StringComparison.CurrentCulture);
            return (p>0);
        }

        public static bool operator <=(Bankas b1, Bankas b2)
        {
            int p = string.Compare(b1.ImtiPav(), b2.ImtiPav(), StringComparison.CurrentCulture);
            return (p < 0);
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

        public override string ToString()
        {
            string eilute = "";
            return eilute;
        }

        public void Rikiuoti()
        {
            int temp = 0;
            for (int write = 0; write < n; write++)
            {
                for (int sort = 0; sort < n - 1; sort++)
                {

                    int b1 = ImtiMatrica(Banku[sort].ImtiNr(), 3);
                    int b2 = ImtiMatrica(Banku[sort+1].ImtiNr(), 3);

                    if (b1 > b2)
                    {
                        temp = b2;
                        b2 = b1;
                        b1 = temp;
                    }

                    if (b1 == b2)
                    {
                        Console.WriteLine("A");
                        if (Banku[sort] >= Banku[sort+1])
                        {
                            temp = b2;
                            b2 = b1;
                            b1 = temp;
                        }
                    }
                }
            }

        }

    }


    class Program
    {
        const string input = "...\\...\\input.txt";
        const string output = "...\\...\\output.txt";

        static void Main(string[] args)
        {
            if (File.Exists(output))
                File.Delete(output);

            Bankai bankai = new Bankai();
            SkaitytiMok(input, ref bankai);
            PradiniaiDuomenys(bankai);
            KiekValstybiu(bankai);
            Apsimoka(bankai, 0);
            Apsimoka(bankai, 1);
            Apsimoka(bankai, 2);
            Apsimoka(bankai, 3);
            Apsimoka(bankai, 4);
            Apsimoka(bankai, 5);
            Apsimoka(bankai, 6);
            RikiuotoSpausdinimas(ref bankai);
            
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
                    ban.Dėti(i, pav, salis, skaicius);
                    bankai.Dėti(ban);
                }

                for (int i = 0; i < bankai.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    Console.WriteLine(line);
                    for (int j = 0; j < 7; j++)
                    {
                        prc = int.Parse(parts[j]);
                        bankai.DėtiMatrica(i, j, prc);
                    }
                }
            }
        }

        static void KiekValstybiu(Bankai bankai)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < bankai.n; i++)
            {
                if (list.Contains(bankai.Imti(i).ImtiSalis()) == false || list.Count == 0)
                {
                    list.Add(bankai.Imti(i).ImtiSalis());
                }
            }
            using (var fr = File.AppendText(output))
            {
                fr.WriteLine();
                fr.WriteLine("Lietuvoje veikia {0} kitų valstybių bankai", list.Count);
            }
        }

        static void Apsimoka(Bankai bankai, int laik)
        {
            int max = 0;
            for (int i = 0; i < bankai.n; i++)
            {
                int current = bankai.ImtiMatrica(i, laik);
                if (current > max)
                {
                    max = current;
                }
            }

            for (int i = 0; i < bankai.n; i++)
            {
                int current = bankai.ImtiMatrica(i, laik);
                if (max == current)
                {
                    using (var fr = File.AppendText(output))
                        fr.WriteLine("{0} laikotarpį labiausiai apsimoka laikyti {1} banke", laik+1, bankai.Imti(i).ImtiPav());
                }
            }
        }

        static void PradiniaiDuomenys(Bankai bankai)
        {
            using (var fr = File.AppendText(output))
            {
                fr.WriteLine("Pradiniai duomenys: ");
                fr.WriteLine();

                for (int i = 0; i < bankai.n; i++)
                {
                    fr.WriteLine(bankai.Imti(i).ToString());
                }

                fr.WriteLine();

                for (int i = 0; i < bankai.n; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        fr.Write("{0}; ", bankai.ImtiMatrica(i, j));
                    }
                    fr.WriteLine();
                }
            }
        }

        static void RikiuotoSpausdinimas(ref Bankai bankai)
        {
            bankai.Rikiuoti();

            for (int i = 0; i < bankai.n; i++)
            {
                Console.WriteLine(bankai.Imti(i).ToString());
            }
        }
    }
}
