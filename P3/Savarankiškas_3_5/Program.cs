using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_3_5
{
    class Auto
    {
        private string pav, degalai;
        private double sąnaudos;

        public Auto(string pav, string degalai, double sąnaudos)
        {
            this.pav = pav;
            this.degalai = degalai;
            this.sąnaudos = sąnaudos;
        }

        public string ImtiPav
        {
            set { pav = value; }
            get { return pav; }
        }

        public string ImtiDegalus
        {
            set { degalai = value; }
            get { return degalai; }
        }

        public double ImtiSąnaudas
        {
            set { sąnaudos = value; }
            get { return sąnaudos; }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "...\\...\\Duom1.txt";
            const string CFrez = "...\\...\\Rez.txt";
            if (File.Exists(CFrez)) File.Delete(CFrez);
            Auto[] A = new Auto[100];
            int na;

            Skaityti(CFd1, A, out na);
            Spausdinti(CFrez, A, na);

            using (var fr = File.AppendText(CFrez))
            {
                fr.WriteLine("Vidutinės degalų sąnaudos: {0,7:f2} litro/100 km", VidSąnaudos(A, na));
                fr.WriteLine("Dyzelinių automobilių kiekis: {0}", DyzKiek(A, na));
                if (VidSanaudosBenz(A, na) == 0)
                {
                    fr.WriteLine("Nėra benzininių automobilių");
                }
                else
                {
                    fr.WriteLine("Vidutinės benzininių automobilių sąnaudos: {0} litro/100 km", VidSanaudosBenz(A, na));
                }
                }
        }

        static double VidSąnaudos(Auto[] A, int kiek)
        {
            double sum = 0;
            for (int i = 0; i < kiek; i++)
            {
                sum = sum + A[i].ImtiSąnaudas;
            }

            return sum / kiek;
        }


        static int DyzKiek(Auto[] A, int kiek)
        {
            int dyzkiek = 0;
            for (int i = 0; i<kiek; i++)
            {
                if (A[i].ImtiDegalus == "dyzelinas")
                {
                    dyzkiek++;
                }
            }
            return dyzkiek;
        }

        static double VidSanaudosBenz(Auto[] A, int kiek)
        {
            int benz = 0;
            double benz_sum = 0;
            for (int i = 0; i < kiek; i++)
            {
                if (A[i].ImtiDegalus == "benzinas")
                {
                    benz++;
                    benz_sum += A[i].ImtiSąnaudas;
                }
            }
            if (benz!=0) {
                double vid = benz_sum / benz;
                return vid;
            }
            else
            {
                return 0;
            }
        }

        static void Skaityti(string Fd, Auto[] A, out int kiek)
        {
            using (StreamReader reader = new StreamReader(Fd, Encoding.GetEncoding(1257)))
            {
                string pav, degalai;
                double sąnaudos;
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    degalai = parts[1];
                    sąnaudos = double.Parse(parts[2]);
                    A[i] = new Auto(pav, degalai, sąnaudos);
                }
            }
        }

        static void Spausdinti(string fv, Auto[] A, int nkiek)
        {
            const string virsus = "|-----------------|------------|--------------------|\r\n" + "|                 |            |                    |\r\n" + "|   Pavadinimas   |  Degalai   | Sąnaudos (l/100 km)|\r\n" + "|                 |            |                    |\r\n" + "|-----------------|------------|--------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Automobilių kiekis {0}", nkiek);
                fr.WriteLine("Automobilių sąrašas:");
                fr.WriteLine(virsus);
                Auto tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = A[i];
                    fr.WriteLine("| {0,-15} | {1,-9}  |    {2,8:f2}        |", tarp.ImtiPav, tarp.ImtiDegalus, tarp.ImtiSąnaudas);
                }
                fr.WriteLine("-----------------------------------------------------");
            }
        }

    }
}

