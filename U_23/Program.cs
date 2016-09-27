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
            int[] kiekis = new int[100];

            List<Duona> duona = new List<Duona>();

            Console.WriteLine("Įveskite 1 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 1 duonos masę(g): ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos plotą(cm2): ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 1 duonos kepaliukų kiekį gaminamą kepyklos per 1 d: ");
            kiekis_1 = int.Parse(Console.ReadLine());
            Duona d1 = new Duona(name, mass, cost, area);
            duona.Add(d1);
            kiekis[0] = kiekis_1;

            Console.WriteLine("Įveskite 2 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 2 duonos masę(g): ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos plotą(cm2): ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 2 duonos kepaliukų kiekį gaminamą kepyklos per 1 d: ");
            kiekis_2 = int.Parse(Console.ReadLine());
            Duona d2 = new Duona(name, mass, cost, area);
            duona.Add(d2);
            kiekis[1] = kiekis_2;

            Console.WriteLine("Įveskite 3 duonos miltų pavadinimą: ");
            name = (string)Console.ReadLine();
            Console.WriteLine("Įveskite 3 duonos masę(g): ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos kainą: ");
            cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos plotą(cm2): ");
            area = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite 3 duonos kepaliukų kiekį gaminamą kepyklos per 1 d: ");
            kiekis_3 = int.Parse(Console.ReadLine());
            Duona d3 = new Duona(name, mass, cost, area);
            duona.Add(d3);
            kiekis[2] = kiekis_3;


            Console.WriteLine("Įveskite kepyklos pavadinimą: ");
            kname = (string)Console.ReadLine();

            Console.WriteLine("Įveskite kepyklos transporto galimą vežti kepaliukų kiekį: ");
            trans = int.Parse(Console.ReadLine());



            Kepykla k1 = new Kepykla(kname, kiekis_1, kiekis_2, kiekis_3, trans);


            Min_mass(duona);
            Max_cost(duona);
            Area(duona, kiekis);
            Transportation(k1);
            Vid_mass(duona);


        }

        public static void Min_mass(List<Duona> duona)
        {

            double min_mass = Double.MaxValue;
            foreach (Duona d in duona)
            {
                if (min_mass >= d.Mass)
                {
                    min_mass = d.Mass;
                }
            }

            foreach (Duona d in duona)
            {
                if (min_mass == d.Mass)
                {
                    Console.WriteLine("Mažiausiai sveria: {0} {1} g", d.Name, d.Mass);
                }
            }
        }



        public static void Max_cost(List<Duona> duona)
        {

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
                    Console.WriteLine("Didžiausia kaina: {0} {1}", d.Name, d.Cost);
                }
            }
        }

        public static void Area(List<Duona> duona, int[] kiekis)
        {
            int i = 0;
            double sum_area = 0;
            foreach (Duona d in duona)
            {
                double area = 0;
                area += d.Area * kiekis[i];
                i++;
                Console.WriteLine("{0} rūšies: {1} cm2", i, area);
                sum_area += area;
            }
            Console.WriteLine("Visi duonos kepaliukai užims: {0} cm2", sum_area);
        }

        public static void Transportation(Kepykla k)
        {
            int times = 0;
            if ((k.Kiekis_1 + k.Kiekis_2 + k.Kiekis_3) % k.Trans > 0)
            {
                times = (int)((k.Kiekis_1 + k.Kiekis_2 + k.Kiekis_3) / k.Trans + 1);
            }
            else
            {
                times = (int)((k.Kiekis_1 + k.Kiekis_2 + k.Kiekis_3) / k.Trans);
            }


            Console.WriteLine("Kepyklos automobiliui reikės važiuoti: {0} kartus", times);
        }

        public static void Vid_mass(List<Duona>duona)
        {
            double vid_mass = 0;
            double sum = 0;
            foreach(Duona d in duona)
            {
                sum += d.Mass;
            }
            vid_mass = sum / duona.Count;
            Console.WriteLine("Vidutinis kepaliuko svoris: {0}", vid_mass);
        }
    }
}
