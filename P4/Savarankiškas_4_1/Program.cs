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

        public Butas(int nr, int k_count, int tel_nr, double area, double price)
        {
            this.nr = nr;
            this.k_count = k_count;
            this.tel_nr = tel_nr;
            this.area = area;
            this.price = price;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, 5:d} {1, 6:d}  {2, 5:d}  {3, 7:f}  {4, 7:f}", nr, k_count, tel_nr, area, price);
            return eilute;
        }

        public int ImtiNr
        {
            set { nr = value; }
            get { return nr; }
        }

        public int Imtik_count
        {
            set { k_count = value; }
            get { return k_count; }
        }

        public int Imtitel_nr
        {
            set { tel_nr = value; }
            get { return tel_nr; }
        }

        public double Imtiarea
        {
            set { area = value; }
            get { return area; }
        }

        public double ImtiPrice
        {
            set { price = value; }
            get { return price; }
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

    class Tinkami
    {
        const int CMaxi = 100;
        private Butas[] Rightbutai;
        private int m;

        public Tinkami()
        {
            m = 0;
            Rightbutai = new Butas[CMaxi];
        }

        public Butas Imti(int i) { return Rightbutai[i]; }

        public int Imti()
        {
            return m;
        }

        public void Dėti(Butas ob)
        {
            Rightbutai[m++] = ob;
        }
    }

    class Program
    {
        const string CFd = "...\\...\\Duom.txt";
        static void Main(string[] args)
        {
            int m = 0;
            int n = 0;
            Namas namas = new Namas();
            Tinkami tinkami = new Tinkami();
            Skaityti(ref namas, ref n, CFd);
            Console.WriteLine();
            Console.WriteLine("Įveskite norimą kambarių skaičių:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite didžiausią buto kainą:");
            double y = double.Parse(Console.ReadLine());
            Atrinkti(namas,ref tinkami, n, ref m, x, y);
            Spausdinti(tinkami, m);
            //int x = namas.Imti(2).Imtik_count;

            //Butas[] butai = TinkamiButai(n, namas);
        }

        static void Skaityti(ref Namas namas, ref int n, string fv)
        {
            int nr, k_count, tel_nr;
            double area, price;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
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

        static void Atrinkti(Namas namas, ref Tinkami tinkami, int n, ref int m, int x, double y)
        {

                for (int i = 0; i < n; i++)
                {
                    if (x == namas.Imti(i).Imtik_count)
                    {
                        if (y >= namas.Imti(i).ImtiPrice)
                        {
                            tinkami.Dėti(namas.Imti(i));
                            m++;
                        }
                    }
                }
            }

        static void Spausdinti(Tinkami tinkami, int m)
        {
            if (m > 0)
            {
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine(tinkami.Imti(i).ToString());
                }
            }
            else
            {
                Console.WriteLine("Nerasta butų");
            }
        }
    }
}
