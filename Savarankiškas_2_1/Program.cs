using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_2_1
{
    class Plyta
    {
        private double ilgis,
                   plotis,
                   aukštis;

        public Plyta(double ilgis, double pločioReikšmė, double aukščioReikšmė)
        {
            this.ilgis = ilgis;
            plotis = pločioReikšmė;
            aukštis = aukščioReikšmė;
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

        public Siena(double ilgis, double aukščioReikšmė)
        {
            this.ilgis = ilgis;
            plotis = 1;
            aukštis = aukščioReikšmė;
        }

        /** grąžina plytos ilgį */
        public double ImtiIlgį() { return ilgis; }
        /** grąžina plytos plotį */
        public double ImtiPlotį() { return plotis; }
        /** grąžina plytos aukštį */
        public double ImtiAukštį() { return aukštis; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            double x=0, y=0;
            Plyta p1;
            p1 = new Plyta(250, 120, 88);

            Plyta p2;
            p2 = new Plyta(200, 115, 71);


            Console.WriteLine("Įveskite 1 sienos parametrus:");
            Console.Write("Ilgis:");
            x = double.Parse(Console.ReadLine());
            Console.Write("Aukštis:");
            y = double.Parse(Console.ReadLine());
            Siena s1;
            s1 = new Siena(x, y);
            Console.WriteLine("Įveskite 2 sienos parametrus:");
            Console.Write("Ilgis:");
            x = double.Parse(Console.ReadLine());
            Console.Write("Aukštis:");
            y = double.Parse(Console.ReadLine());
            Siena s2;
            s2 = new Siena(x, y);
            Console.WriteLine("Įveskite 3 sienos parametrus:");
            Console.Write("Ilgis:");
            x = double.Parse(Console.ReadLine());
            Console.Write("Aukštis:");
            y = double.Parse(Console.ReadLine());
            Siena s3;
            s3 = new Siena(x, y);
            Console.WriteLine("Įveskite 4 sienos parametrus:");
            Console.Write("Ilgis:");
            x = double.Parse(Console.ReadLine());
            Console.Write("Aukštis:");
            y = double.Parse(Console.ReadLine());
            Siena s4;
            s4 = new Siena(x, y);

            int sum1 = 0, sum2 = 0;
            sum1 =+ calcus(p1, s1);
            sum2 =+ calcus(p2, s1);
            sum1 += calcus(p1, s2);
            sum2 += calcus(p2, s2);
            sum1 += calcus(p1, s3);
            sum2 += calcus(p2, s3);
            sum1 += calcus(p1, s4);
            sum2 += calcus(p2, s4);
            Console.WriteLine("Sunaudota pirmo tipo plytų: {0}", sum1);
            Console.WriteLine("Sunaudota antro tipo plytų: {0}", sum2);
            Console.WriteLine("Iš viso plytų: {0}", sum1+sum2);
        }


         public static int calcus(Plyta p, Siena s){
            return (int) (s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
                         s.ImtiAukštį() * 1000 / p.ImtiAukštį());

        }
    }
}
