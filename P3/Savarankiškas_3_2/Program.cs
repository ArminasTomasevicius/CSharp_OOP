using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_3_2
{
    class Pinigai
    {
        private double eu;
        private double cnt;
        private double rate;

        public Pinigai(double eu, double cnt, double rate)
        {
            this.eu = (eu + cnt / 100) * rate;
        }

        public double Eu
        {
            set { eu = value; }
            get { return eu; }
        }
        public double Rate
        {
            set { rate = value; }
            get { return rate; }
        }
        public double Cnt
        {
            set { cnt = value; }
            get { return cnt; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "...\\...\\A.txt";
            const string CFd2 = "...\\...\\B.txt";
            int n = 0, m = 0;

            Pinigai[] P1 = new Pinigai[100];
            Pinigai[] P2 = new Pinigai[100];

            Skaityti(CFd1, P1, out n);
            Skaityti(CFd2, P2, out m);

            Console.WriteLine("Anupro pinigai: {0}", Calcus(P1, n));
            Console.WriteLine("Barboros pinigai: {0}", Calcus(P2, m));
            Console.WriteLine("Bendrai: {0}", Calcus(P1, n) + Calcus(P2, m));

        }

        static void Skaityti(string fv, Pinigai[] P, out int n)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    double eu = double.Parse(parts[0]);
                    double cnt = double.Parse(parts[1]);
                    double rate = double.Parse(parts[2]);
                    P[i] = new Pinigai(eu, cnt, rate);
                }
            }
        }
        static double Calcus(Pinigai[] P, int n)
        {
            double suma = 0;

            for (int i = 0; i < n; i++)
            {
                suma += P[i].Eu;
            }
            return suma;
        }
    }
}
