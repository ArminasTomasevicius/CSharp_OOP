using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_2_4
{
    class Draugas
    {
        private string vardas;
        private double ugis;
        private double svoris;
        private string pozicija;

        public Draugas(string vardas, double ugis, double svoris, string pozicija)
        {
            this.vardas = vardas;
            this.ugis = ugis;
            this.svoris = svoris;
            this.pozicija = pozicija;
        }

        public string Vardas
        {
            set{ vardas = value; }
            get{ return vardas; }
        }

        public double Ugis
        {
            set { ugis = value; }
            get { return ugis; }
        }
        public double Svoris
        {
            set { svoris = value; }
            get { return svoris; }
        }
        public string Pozicija
        {
            set { pozicija = value; }
            get { return pozicija; }
        }
    }

    class Pozicija
    {
        private string name;
        private double nuo;
        private double iki;

        public Pozicija(string name, double nuo, double iki)
        {
            this.name = name;
            this.nuo = nuo;
            this.iki = iki;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double Nuo
        {
            set { nuo = value; }
            get { return nuo; }
        }

        public double Iki
        {
            set { iki = value; }
            get { return iki; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string vardas;
            double ugis;
            double svoris;

            Pozicija p1 = new Pozicija("Gynėjas", 169, 196);
            Pozicija p2 = new Pozicija("Puolėjas", 197, 220);

            List<Draugas> draugai = new List<Draugas>();
            Console.WriteLine("Įveskite 1 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d1 = new Draugas(vardas, ugis, svoris, null);
            draugai.Add(d1);

            Console.WriteLine("Įveskite 2 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d2 = new Draugas(vardas, ugis, svoris, null);
            draugai.Add(d2);

            Console.WriteLine("Įveskite 3 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d3 = new Draugas(vardas, ugis, svoris, null);
            draugai.Add(d3);

            Console.WriteLine("Įveskite 4 draugo duomenis");
            Console.Write("Vardas:");
            vardas = (string)Console.ReadLine();
            Console.Write("Ūgis:");
            ugis = double.Parse(Console.ReadLine());
            Console.Write("Svoris:");
            svoris = double.Parse(Console.ReadLine());
            Draugas d4 = new Draugas(vardas, ugis, svoris, null);
            draugai.Add(d4);

            foreach(Draugas d in draugai)
            {
                if (d.Ugis >= p1.Nuo && d.Ugis <= p1.Iki)
                {
                    d.Pozicija = p1.Name;
                }
                else if (d.Ugis >= p2.Nuo && d.Ugis <= p2.Iki)
                {
                    d.Pozicija = p2.Name;
                }
                Console.WriteLine("{0} pozicija: {1}" , d.Vardas, d.Pozicija);
            }
            
        }
    }
}
