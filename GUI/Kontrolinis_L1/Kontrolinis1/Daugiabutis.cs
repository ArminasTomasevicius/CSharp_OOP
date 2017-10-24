using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrolinis1
{
    class Daugiabutis
    {
        private Butas[] butas;
        public int Kiek { get; set; }
        public string Pav { get; set; }

        public Daugiabutis()
        {
            Kiek = 0;
            butas = new Butas[100];
        }

        public Butas ImtiButa(int i)
        {
            return butas[i];
        }

        public void DetiButa(Butas Butas)
        {
            butas[Kiek++] = Butas;
        }

        public void DetiTiksliai(Butas butas, int index)
        {
            this.butas[index] = butas;
        }

        public void ApkeistiValues(Butas butas1, Butas butas2)
        {
            int nr = butas2.nr;
            string sav = butas2.sav;
            DateTime date = butas2.date;
            double mokestisd = butas2.mokestisd;
            double mokestisl = butas2.mokestisl;

            butas1.nr = nr;
            butas1.sav = sav;
            butas1.date = date;
            butas1.mokestisd = mokestisd;
            butas1.mokestisl = mokestisl;
        }



        public void Apkeisti(int butas1, int butas2)
        {
            var tmp = butas[butas1];
            butas[butas1] = butas[butas2];
            butas[butas2] = tmp;
        }

        public void Burbulas(Butas[] Butai, int Kiek)
        {
            int i = 0;
            bool bk = true;
            while (bk)
            {
                bk = false;
                for (int j = Kiek - 1; j > i; j--)
                {
                    if (Butai[j] >= Butai[j - 1])
                    {
                        bk = true;
                        Butas but = Butai[j];
                        Butai[j] = Butai[j - 1];
                        Butai[j - 1] = but;
                    }
                    i++;
                }
            }
        }
    }
}