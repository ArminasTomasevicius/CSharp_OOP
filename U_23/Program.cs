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
        private double time_1;
        private double time_2;
        private double time_3;
        private double trans;

        public Kepykla(string name, double time_1, double time_2, double time_3, double trans)
        {
            this.name = name;
            this.time_1 = time_1;
            this.time_2 = time_2;
            this.time_3 = time_3;
            this.trans = trans;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public double Time_1
        {
            set { time_1 = value; }
            get { return time_1; }
        }

        public double Time_2
        {
            set { time_2 = value; }
            get { return time_2; }
        }

        public double Time_3
        {
            set { time_3 = value; }
            get { return time_3; }
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
            List<Duona> duona = new List<Duona>();

            Duona d1 = new Duona("");
            duona.Add(d1);
            Duona d2 = new Duona("");
            duona.Add(d2);
            Duona d3 = new Duona("");
            duona.Add(d3);

            Kepykla k1 = new Kepykla();

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
