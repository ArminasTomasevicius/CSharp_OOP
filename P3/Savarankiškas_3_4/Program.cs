using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_3_4
{
    class Kelias
    {
        private string pav;
        private double ilgis, greitis;

        public Kelias(string pav, double ilgis, double greitis)
        {
            this.pav = pav;
            this.ilgis = ilgis;
            this.greitis = greitis;
        }

        public string ImtiPav
        {
            set { pav = value; }
            get { return pav; }
        }

        public double ImtiIlgi
        {
            set { ilgis = value; }
            get { return ilgis; }
        }

        public double ImtiGreiti
        {
            set { greitis = value; }
            get { return greitis; }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "...\\...\\Duom1.txt";
            const string CFrez = "...\\...\\Rez.txt";
            if (File.Exists(CFrez)) File.Delete(CFrez);
            Kelias[] K = new Kelias[100];
            int na;

            Skaityti(CFd1, K, out na);
            Spausdinti(CFrez, K, na);

        }


        static void Skaityti(string Fd, Kelias[] K, out int kiek)
        {
            using (StreamReader reader = new StreamReader(Fd, Encoding.GetEncoding(1257)))
            {
                
                string pav;
                double ilgis, greitis;
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0];
                    ilgis = double.Parse(parts[1]);
                    greitis = double.Parse(parts[2]);
                    K[i] = new Kelias(pav, ilgis, greitis);
                }
            }
        }

        static void Spausdinti(string fv, Kelias[] K, int nkiek)
        {

            const string virsus = "|------------------------------------------------|-------------|---------|\r\n" +
                                  "|                                                |             |         |\r\n" + 
                                  "|   Kelias                                       |  Atstumas   | Greitis |\r\n" +
                                  "|                                                |             |         |\r\n" +
                                  "|------------------------------------------------|-------------|---------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(virsus);
                Kelias tarp;
                for (int i = 0; i < nkiek; i++)
                {
                    tarp = K[i];
                    fr.WriteLine("| {0,-46} | {1,-11} | {2,7:f2} |", tarp.ImtiPav, tarp.ImtiIlgi, tarp.ImtiGreiti);
                }
                fr.WriteLine("--------------------------------------------------------------------------");
            }
        }

    }
}
