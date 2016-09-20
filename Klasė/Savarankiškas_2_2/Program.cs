using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_2_2
{
    class Draugas
    {
        private string vardas;
        private double ūgis;
        private double svoris;

        public Draugas(string vardas, double ūgis, double svoris)
        {
            this.vardas = vardas;
            this.ūgis = ūgis;
            this.svoris = svoris;
        }
        public string Vardas
        {
            get{ return vardas; }
            set{ vardas = value; }
        }
        public double Ūgis
        {
            get { return ūgis; }
            set { ūgis = value; }
        }
        public double Svoris
        {
            get { return svoris; }
            set { svoris = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string vardas;
            double ugis;
            double svoris;
            List<Draugas> draugai = new List<Draugas>();
            Console.WriteLine("Įveskite 1 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d1 = new Draugas(vardas, ugis, svoris);
            draugai.Add(d1);

            Console.WriteLine("Įveskite 2 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d2 = new Draugas(vardas, ugis, svoris);
            draugai.Add(d2);

            Console.WriteLine("Įveskite 3 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d3 = new Draugas(vardas, ugis, svoris);
            draugai.Add(d3);

            Console.WriteLine("Įveskite 4 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d4 = new Draugas(vardas, ugis, svoris);
            draugai.Add(d4);

            double vid = (d1.Svoris + d2.Svoris + d3.Svoris + d4.Svoris) / 4;
            Console.WriteLine("Vidutinis draugų svoris: {0}", vid);

            double min_ugis = Double.MaxValue;
            foreach (Draugas d in draugai)
            {
                if (d.Ūgis <= min_ugis)
                {
                    min_ugis = d.Ūgis;
                }
            }

            foreach(Draugas d in draugai)
            {
                if (min_ugis == d.Ūgis)
                {
                    Console.WriteLine("Mažiausias draugas: {0}", d.Vardas);
                }
            }

        }
    }
}
