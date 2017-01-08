using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Darbininkas
    {
        private string vardas, pavarde;
        private int metai, stazas, detales;

        public Darbininkas()
        {
            vardas = "";
            pavarde = "";
            metai = 0;
            stazas = 0;
            detales = 0;
        }

        public Darbininkas(string vardas, string pavarde, int metai, int stazas, int detales)
        {
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.metai = metai;
            this.stazas = stazas;
            this.detales = detales;
        }

        public string Vardas
        {
            set { value = vardas; }
            get { return vardas; }
        }

        public string Pavarde
        {
            set { value = pavarde; }
            get { return pavarde; }
        }

        public int Metai
        {
            set { value = metai; }
            get { return metai; }
        }

        public int Stazas
        {
            set { value = stazas; }
            get { return stazas; }
        }

        public int Detales
        {
            set { value = detales; }
            get { return detales; }
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7} {3, -7} {4, -7}", vardas, pavarde, metai, stazas, detales);
            return eilute;
        }

        public static bool operator !=(Darbininkas dr1, Darbininkas dr2)
        {
            int p = String.Compare(dr1.pavarde, dr2.pavarde, StringComparison.CurrentCulture);
            int v = String.Compare(dr1.vardas, dr2.vardas, StringComparison.CurrentCulture);
            if (dr1.Metai > dr2.Metai)
            {
                return false;
            }
            else
            {
                return (p < 0 || (p == 0 && v < 0));
            }

        }

        public static bool operator ==(Darbininkas dr1, Darbininkas dr2)
        {
            int p = String.Compare(dr1.pavarde, dr2.pavarde, StringComparison.CurrentCulture);
            int v = String.Compare(dr1.vardas, dr2.vardas, StringComparison.CurrentCulture);
            if (dr1.Metai > dr2.Metai)
            {
                return true;
            }
            else
            {
                return (p > 0 || (p == 0 && v > 0));
            }

        }
    }

    class Brigada
    {
        const int CMax = 100;
        private Darbininkas[] Darb;
        private int n;

        public Brigada()
        {
            n = 0;
            Darb = new Darbininkas[CMax];
        }
        public int Imti() { return n; }

        public Darbininkas Imti(int i) { return Darb[i]; }

        public void Deti(Darbininkas ob) { Darb[n++] = ob; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            double vid = 0;
            string inp = "...\\...\\Brigada.txt";
            string spaus = "...\\...\\Rez.txt";
            Brigada Darb = new Brigada();
            Brigada R = new Brigada();
            Skaityti(ref Darb, inp);
            if (File.Exists(spaus)) File.Delete(spaus);
            Spausdinti(Darb, spaus);
            Formuoti(Darb, ref R);
            if (R.Imti() >= 0) {
                Spausdinti(Darb, spaus);
            }
            else{
                Console.WriteLine("Konteineris tuscias");
            }

            VidStazas(Darb, ref vid);
            Console.WriteLine("{0}", vid);

            if (R.Imti() >= 0)
            {
                VidStazas(R, ref vid);
                Console.WriteLine("{0}", vid);
            }
        }

        static void Skaityti(ref Brigada Darb, string inp)
        {
            string vardas, pavarde;
            int metai, stazas, detales;
            string[] lines = File.ReadAllLines(inp);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                vardas = parts[0];
                pavarde = parts[1];//.Trim();
                metai = int.Parse(parts[2]);
                stazas = int.Parse(parts[3]);
                detales = int.Parse(parts[4]);

                Darbininkas ob = new Darbininkas(vardas, pavarde, metai, stazas, detales);
                Darb.Deti(ob);
            }
        }

        static void Spausdinti(Brigada Darb, string spaus)
        {
            using (var sp = File.AppendText(spaus))
            {

                for (int i = 0; i < Darb.Imti(); i++)
                    sp.WriteLine("{0}", Darb.Imti(i).ToString());
            }
        }

        static void Formuoti(Brigada darb, ref Brigada R)
        {
            Console.WriteLine("Įveskite x detaliu skaiciu: ");
            double x = double.Parse(Console.ReadLine());
            for (int i = 0; i < darb.Imti(); i++)
                if (darb.Imti(i).Detales > x)
                {
                    R.Deti(darb.Imti(i));
                }
                else
                {
                    ;
                }
        }

        static void VidStazas(Brigada darb, ref double vid)
        {
            double sum = 0;
            int kiek = 0;
            for (int i = 0; i < darb.Imti(); i++)
            {
                sum += darb.Imti(i).Stazas;
                kiek++;
            }
            vid = sum / kiek;
        }

        static void Ismesti(Brigada darb)
        {
            Console.WriteLine("Ismetimo darbuotojo duomenys: ");
            string vardas = Console.ReadLine();
            string pavarde = Console.ReadLine();
            int metai = int.Parse(Console.ReadLine());
            int stazas = int.Parse(Console.ReadLine());
            int detal = int.Parse(Console.ReadLine());

            for (int i = 0; i < darb.Imti(); i++)
            {
                if ((vardas == darb.Imti(i).Vardas)&&(pavarde == darb.Imti(i).Pavarde)&&(metai == darb.Imti(i).Metai)&&(stazas == darb.Imti(i).Stazas)&&(detal == darb.Imti(i).Detales))
                {
                    int n = darb.Imti();
                    for (int j = 0; j < n - 1; i++)
                    {
                        n = n + 1;
                        n = n - 1;
                    }
            }
            }
        }
    }
}