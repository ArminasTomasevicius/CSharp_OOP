using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_užduotis
{
    class Kelias
    {
        private string pav;
        private double ilgis;
        private int lgr;

        public Kelias(string pav, double ilgis, int lgr)
        {
            this.pav = pav;
            this.ilgis = ilgis;
            this.lgr = lgr;
        }
        public void DėtiLeistGreitį(int lgr) { lgr = lgr; }
        public string ImtiPav() { return pav; }
        public double ImtiIlgį() { return ilgis; }
        public int ImtiLeistGreitį() { return lgr; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Kelias k1, k2, k3;
            k1 = new Kelias("Kaunas - Vilnius", 105.0, 110);
            k2 = new Kelias("Kaunas - Alytus", 65.6, 90);
            k3 = new Kelias("Vilnius - Panevėžys", 136.0, 120);

            double laikas = k2.ImtiIlgį() / k2.ImtiLeistGreitį() +
                            k1.ImtiIlgį() / k1.ImtiLeistGreitį() +
                            k3.ImtiIlgį() / k3.ImtiLeistGreitį();

            string maxPav = k1.ImtiPav();
            double maxIlgis = k1.ImtiIlgį();
            if(k2.ImtiIlgį() > maxIlgis)
            {
                maxPav = k2.ImtiPav();
                maxIlgis = k2.ImtiIlgį();
            }
            if (k3.ImtiIlgį() > maxIlgis)
            {
                maxPav = k3.ImtiPav();
                maxIlgis = k3.ImtiIlgį();
            }


            Console.WriteLine("Keliai (pavadinimas,\t      ilgis,\t   leistinas greitis:)");
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k1.ImtiPav(), k1.ImtiIlgį(), k1.ImtiLeistGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d}", k2.ImtiPav(), k2.ImtiIlgį(), k2.ImtiLeistGreitį());
            Console.WriteLine("{0},\t {1,10:f2}, {2,15:d} \n\n", k3.ImtiPav(), k3.ImtiIlgį(), k3.ImtiLeistGreitį());
            Console.WriteLine("Iš Alytaus į Panevėžį nuvažiuosime per {0,5:f2}  val. ", laikas);
            Console.WriteLine();
            Console.WriteLine("Ilgiausias kelias: {0}", maxPav);
            Console.WriteLine("Programa baigė darbą!");

        }
    }
}
