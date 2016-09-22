using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_2_3
{
    class Plyta
    {
        private double ilgis,
                   plotis,
                   aukštis;

        public Plyta(double ilgis, double plotis, double aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }
        /** grąžina plytos ilgį */
        public double ImtiIlgį() { return ilgis; }
        /** grąžina plytos plotį */
        public double ImtiPlotį() { return plotis; }
        /** grąžina plytos aukštį */
        public double ImtiAukštį() { return aukštis; }

    }


    class Siena
    {
        private double ilgis,
                   plotis,
                   aukštis;

        public Siena(double ilgis, double plotis, double aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }

        /** grąžina plytos ilgį */
        public double ImtiIlgį() { return ilgis; }
        /** grąžina plytos plotį */
        public double ImtiPlotį() { return plotis; }
        /** grąžina plytos aukštį */
        public double ImtiAukštį() { return aukštis; }
    }

    class Bokstas
    {
        private double skersmuo,
                  storis,
                  aukštis;

        public Bokstas(double skersmuo, double storis, double aukštis)
        {
            this.skersmuo = skersmuo;
            this.storis = storis;
            this.aukštis = aukštis;
        }

        /** grąžina plytos ilgį */
        public double ImtiSkersmenį() { return skersmuo; }
        /** grąžina plytos plotį */
        public double ImtiStorį() { return storis; }
        /** grąžina plytos aukštį */
        public double ImtiAukštį() { return aukštis; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Plyta p1 = new Plyta(250, 120, 90);
            Siena s1 = new Siena(26.5, 0.7, 5.2);
            Siena s2 = new Siena(50.5, 0.5, 5.2);
            Bokstas b1 = new Bokstas(5.2, 0.5, 2.5);

            int sum1 = 0;
            int sum2 = 0;

            sum1 += 2*VienaSiena(p1,s1);
            sum1 += 2*VienaSiena(p1,s2);
            sum2 += 4*Bokstas(p1,b1);
            Console.WriteLine("Plytos sienoms: {0}", sum1);
            Console.WriteLine("Plytos bokštams: {0}", sum2);
            Console.WriteLine("Sunaudota plytų: {0}", sum1+sum2);
        }




        static int VienaSiena(Plyta p, Siena s)
        {
            return (int)(s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
                         s.ImtiPlotį() * 1000 / p.ImtiPlotį() *
                         s.ImtiAukštį() * 1000 / p.ImtiAukštį());
        }

        static int Bokstas(Plyta p, Bokstas b)
        {
            return (int)(b.ImtiSkersmenį() * 1000 * Math.PI / p.ImtiPlotį() *
                         b.ImtiStorį() * 1000 / p.ImtiIlgį() *
                         b.ImtiAukštį() * 1000 / p.ImtiAukštį());
        }

    }
}
