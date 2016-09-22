using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_3_1
{
    class Narys
    {
        private double eu;
        private double duokle;

        public Narys(double eu, double cnt)
        {
            this.eu = eu + cnt/100;
        }

        public double Eu
        {
            set{ eu = value; }
            get{ return eu; }
        }

        public double Duokle
        {
            set { duokle = value; }
            get { return eu / 4; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double viso = 0;
            double vid = 0;
            double balance = 0;
            int eu, cnt, n;

            const string CFd = "...\\...\\Duom.txt";

            Narys[] N = new Narys[100];

            Skaityti(CFd, N, out n);
            Console.WriteLine(Calcus(N, n));


        }


        static void Skaityti(string fv, Narys[] N, out int n)
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
                    parts = line.Split(';');
                   int eu = int.Parse(parts[0]);
                   int cnt = int.Parse(parts[1]);
                    N[i] = new Narys(eu, cnt);
                }
            }
        }


        static Tuple <double, double, double> Calcus(Narys[] N, int n)
        {
            double suma = 0;
            double sumaT = 0;
            double vid = 0;
            for (int i = 0; i < n; i++)
            {
                suma += N[i].Eu;
                sumaT += N[i].Duokle;
            }
            vid = suma / n;
            return Tuple.Create(suma, vid, sumaT);
        }
    }
}
