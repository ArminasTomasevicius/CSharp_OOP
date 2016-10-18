using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_4_1
{
    class Butas
    {
        private int nr, k_count, tel_nr;
        private double area, price;
        private Butas[] Rightbutai;

        public Butas(int nr, int k_count, int tel_nr, double area, double price)
        {
            this.nr = nr;
            this.k_count = k_count;
            this.tel_nr = tel_nr;
            this.area = area;
            this.price = price;
        }

        public TinkamiButai(int n, Namas namas)
        {
            Rightbutai = new Butas[100];
            Console.WriteLine("Įveskite norimą kambarių skaičių:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite didžiausią buto kainą:");
            double y = double.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
               if(x == namas.Imti(i).k_count)
                {
                    if (y >= namas.Imti(i).price)
                    {
                     Rightbutai[i] = namas.Imti(i);
                    }
                }
            }
        }
    }

    class Namas
    {

        const int CMaxi = 100;
        private Butas[] Butai;
        private int n;

        public Namas()
        {
            n = 0;
            Butai = new Butas[CMaxi];
        }

        public Butas Imti(int i) { return Butai[i]; }

        public int Imti()
        {
            return n;
        }

        public void Dėti(Butas ob)
        {
            Butai[n++] = ob;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Skaityti();
            Butas.TinkamiButai();
        }

        static void Skaityti(ref Namas namas, string fv)
        {
            int nr, k_count, tel_nr, n;
            double area, price;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    nr = int.Parse(parts[0]);
                    area = double.Parse(parts[1]);
                    k_count = int.Parse(parts[2]);
                    price = double.Parse(parts[3]);
                    tel_nr = int.Parse(parts[4]);
                    Butas ob = new Butas(nr, k_count, tel_nr, area, price);
                    namas.Dėti(ob);
                }
            }
        }
    }
}
