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
            set{ eu = value; }
            get{return eu;}
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

            Pinigai P1, P2;

            P1 = Skaityti(CFd1);
            P2 = Skaityti(CFd2);

            double sum = P1.Eu + P2.Eu;

            Console.WriteLine("Anupro pinigai: {0}", P1.Eu);
            Console.WriteLine("Barboros pinigai: {0}", P2.Eu);
            Console.WriteLine("Bendrai: {0}", sum);

        }

        static Pinigai Skaityti(string fv)
        {
            double rate, eu, cnt;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                    parts = line.Split(';');
                    eu = double.Parse(parts[0]);
                    cnt = double.Parse(parts[1]);
                    rate = double.Parse(parts[2]);
                Pinigai P = new Pinigai(eu, cnt, rate);
                return P;
                }
            }

        }
    }
