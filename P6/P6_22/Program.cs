using System;
using System.Collections.Generic;
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


        class Program
        {
            static void Main(string[] args)
            {


            }

            static void SkaitytiMok(string fd, ref Bankai bankai)
            {
                string pav, vard;
                int klas, nn;
                double vid;
                string line;
                using (StreamReader reader = new StreamReader(fd))
                {
                    line = reader.ReadLine();
                    string[] parts;
                    nn = int.Parse(line);
                    for (int i = 0; i < nn; i++)
                    {
                        line = reader.ReadLine();
                        parts = line.Split(';');
                        pav = parts[0]; vard = parts[1];
                        klas = int.Parse(parts[2]);
                        vid = double.Parse(parts[3]);
                        Mokinys mok;
                        mok = new Mokinys();
                        mok.Dėti(pav, vard, klas, vid);
                        mokykl.Dėti(mok);
                    }
                }
            }
        }
    }
}
