using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U_23
{
    class Duona
    {
        private string name;
        private double mass;
        private double cost;
        private double area;

        public Duona(string name, double mass, double cost, double area)
        {
            this.name = name;
            this.mass = mass;
            this.cost = cost;
            this.area = area;
        }
        
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double Mass
        {
            set { mass = value; }
            get { return mass; }
        }

        public double Cost
        {
            set { cost = value; }
            get { return cost; }
        }

        public double Area
        {
            set { area = value; }
            get { return area; }
        }
    }



    class Kepykla
    {
        private string name;
        private double kiekis_1;
        private double kiekis_2;
        private double kiekis_3;
        private double trans;

        public Kepykla(string name, double kiekis_1, double kiekis_2, double kiekis_3, double trans)
        {
            this.name = name;
            this.kiekis_1 = kiekis_1;
            this.kiekis_2 = kiekis_2;
            this.kiekis_3 = kiekis_3;
            this.trans = trans;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double Kiekis_1
        {
            set { kiekis_1 = value; }
            get { return kiekis_1; }
        }

        public double Kiekis_2
        {
            set { kiekis_2 = value; }
            get { return kiekis_2; }
        }

        public double Kiekis_3
        {
            set { kiekis_3 = value; }
            get { return kiekis_3; }
        }
        public double Trans
        {
            set { trans = value; }
            get { return trans; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string kname;
            double mass, cost, area;
            int kiekis_1;
            int kiekis_2;
            int kiekis_3;
            int trans;

            List<Duona> duona = new List<Duona>();

            Console.WriteLine("Įveskite 1 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 1 duonos masę: ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos plotą: ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos kepaliukų kiekį: ");
            kiekis_1 = int.Parse(Console.ReadLine());
            Duona d1 = new Duona(name, mass, cost, area);
            duona.Add(d1);

            Console.WriteLine("Įveskite 2 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 2 duonos masę: ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos plotą: ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos kepaliukų kiekį: ");
            kiekis_2 = int.Parse(Console.ReadLine());
            Duona d2 = new Duona(name, mass, cost, area);
            duona.Add(d2);


            Console.WriteLine("Įveskite 3 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 3 duonos masę: ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos plotą: ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos kepaliukų kiekį: ");
            kiekis_3 = int.Parse(Console.ReadLine());
            Duona d3 = new Duona(name, mass, cost, area);
            duona.Add(d3);

            Console.WriteLine("Įveskite kepyklos pavadinimą: ");
            kname = (string)Console.ReadLine();

            Console.WriteLine("Įveskite kepyklos transporto galimą vežti svorį: ");
            trans = int.Parse(Console.ReadLine());

            Kepykla k1 = new Kepykla(kname, kiekis_1, kiekis_2, kiekis_3, trans);

            double min_mass = Double.MaxValue;
            foreach (Duona d in duona)
            {
                if(min_mass <= d.Mass)
                {
                    min_mass = d.Mass;
                }
            }

            foreach (Duona d in duona)
            {
                if (min_mass == d.Mass)
                {
                    Console.WriteLine("Mažiausiai sveria: {0}", d.Name);
                }
            }


            double max_cost = Double.MinValue;
            foreach (Duona d in duona)
            {
                if (max_cost <= d.Cost)
                {
                    max_cost = d.Cost;
                }
            }

            foreach (Duona d in duona)
            {
                if (max_cost == d.Cost)
                {
                    Console.WriteLine("Didžiausia kaina: {0}", d.Cost);
                }
            }
        }
    }
}
