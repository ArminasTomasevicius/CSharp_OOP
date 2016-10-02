using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firmos_Automobiliai
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
            Auto[] A = new Auto[100];
            int na;

            Skaityti(CFd1, A, out na);
            Spausdinti(CFrez, A, na);

        }


        static void Skaityti(string Fd, Auto[] A, out int kiek)
        {
            using (StreamReader reader = new StreamReader(Fd))
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
