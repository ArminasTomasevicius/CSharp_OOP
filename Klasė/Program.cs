using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasė
{
    class Plyta
    {
        private int ilgis,
                    plotis,
                    aukštis;

    public Plyta(int ilgis, int pločioReikšmė, int aukščioReikšmė) {
        this.ilgis = ilgis;
        plotis = pločioReikšmė;
        aukštis = aukščioReikšmė;
    }
    /** grąžina plytos ilgį */
    public int ImtiIlgį() { return ilgis; }
    /** grąžina plytos plotį */
    public int ImtiPlotį() { return plotis; }
    /** grąžina plytos aukštį */
    public int ImtiAukštį() { return aukštis; }
}

class Program
{
    static void Main(string[] args)
        {
            double sienosIlgis = 12.0, 
                   sienosPlotis = 0.23, 
                   sienosAukštis = 3.0;

            Plyta p1;
            p1 = new Plyta(250, 120, 88);
            SpausdintiPlytą(p1);
           /* Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \n"
                                + "Plytos ilgis: {2, 5:d}\n",
                                p1.ImtiAukštį(), p1.ImtiPlotį(), p1.ImtiIlgį());
                                */


            Plyta p2;
            p2 = new Plyta(240, 115, 71);
            SpausdintiPlytą(p2);
            /* Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \n"
                                 + "Plytos ilgis: {2, 5:d}\n",
                                 p2.ImtiAukštį(), p2.ImtiPlotį(), p2.ImtiIlgį());
                                 */

            Plyta p3;
            p3 = new Plyta(240, 115, 61);
            SpausdintiPlytą(p3);
            /* Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \n"
                                 + "Plytos ilgis: {2, 5:d}\n",
                                 p3.ImtiAukštį(), p3.ImtiPlotį(), p3.ImtiIlgį());
                                 */


            int k1; // Pirmo tipo plytų kiekis 
            k1 = (int)(sienosIlgis * 1000 / p1.ImtiIlgį() *
                       sienosPlotis * 1000 / p1.ImtiPlotį() *
                       sienosAukštis * 1000 / p1.ImtiAukštį());
            //Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n ", (4 * k1));


            int k2;      // Pirmo tipo plytų kiekis
            k2 = (int)(sienosIlgis * 1000 / p2.ImtiIlgį() *
                       sienosPlotis * 1000 / p2.ImtiPlotį() *
                       sienosAukštis * 1000 / p2.ImtiAukštį());
           // Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n ", (4 * k2));
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d} \n ", (4 * VienaSiena(p1, sienosPlotis, sienosIlgis, sienosAukštis)));
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d} \n ", (4 * VienaSiena(p2, sienosPlotis, sienosIlgis, sienosAukštis)));
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d} \n ", (4 * VienaSiena(p3, sienosPlotis, sienosIlgis, sienosAukštis)));
            Console.WriteLine("Programa baigė darbą!");

        }
        static int VienaSiena(Plyta p, double sienosPlotis, double sienosIlgis, double sienosAukštis)
        {
            return (int)(sienosIlgis * 1000 / p.ImtiIlgį() *
                         sienosPlotis * 1000 / p.ImtiPlotį() *
                         sienosAukštis * 1000 / p.ImtiAukštį());
        }

        static void SpausdintiPlytą(Plyta p) {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1, 4:d} \n" + "Plytos ilgis: {2, 5:d}\n", p.ImtiAukštį(), p.ImtiPlotį(), p.ImtiIlgį());
        }
    }
}
