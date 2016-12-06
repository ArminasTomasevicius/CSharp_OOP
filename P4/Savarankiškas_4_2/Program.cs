using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_4_2
{
    //reikia studentu ir grupiu ir kiekvienam po konteineri
    class Studentas
    {
        private string pavarde;
        private string vardas;
        private string grupe;
        private int pkiekis;
        private int[] pazymiai;

        public Studentas(string pavarde, string vardas, string grupe, int pkiekis, int[] pazymiai)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.pkiekis = pkiekis;
            this.pazymiai = pazymiai;
        }

        public string Pavarde
        {
            set{ value = pavarde; }
            get{ return pavarde; }
        }

        public string Vardas
        {
            set { value = vardas; }
            get { return vardas; }
        }

        public string Grupe
        {
            set { value = grupe; }
            get { return grupe; }
        }

        public int Pkiekis
        {
            set { value = pkiekis; }
            get { return pkiekis; }
        }

        public int[] Pazymiai
        {
            set { value = pazymiai; }
            get { return pazymiai; }
        }
    }

    class Facult
    {
        private string pavadinimas;
        private int kiekis;
        private double suma;

        public Facult(string pavadinimas, int kiekis, double suma)
        {
            this.pavadinimas = pavadinimas;
            this.kiekis = kiekis;
            this.suma = suma;
        }

        public string Pavadinimas
        {
            set { value = pavadinimas; }
            get { return pavadinimas; }
        }

        public int Kiekis
        {
            set { value = kiekis; }
            get { return kiekis; }
        }

        public double Suma
        {
            set { value = suma; }
            get { return suma; }
        }

        public double Vid()
        {
            double vid = suma / kiekis;
            return vid;
        }

        public static bool operator <= (Facult f1, Facult f2)
        {
            int p = String.Compare(f1.pavadinimas, f2.pavadinimas, StringComparison.CurrentCulture);

            return ((f1.Vid()<f2.Vid()) || (f1.Vid() == f2.Vid()) && (p > 0));
        }

        public static bool operator >= (Facult f1, Facult f2)
        {
            int p = String.Compare(f1.pavadinimas, f2.pavadinimas, StringComparison.CurrentCulture);

            return ((f1.Vid() > f2.Vid()) || (f1.Vid() == f2.Vid()) && (p > 0));
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7} {3}", pavadinimas, kiekis, suma, Vid());
            return eilute;
        }
    }

    class Grupe //abc sortas
    {
        const int CMaxi = 100;
        private Studentas[] Studentai;
        private int n;
        private string pav;

        public Grupe()
        {
            n = 0;
            Studentai = new Studentas[CMaxi];
        }

        public Studentas Imti(int i) {
            return Studentai[i];
        }

        public int Imti()
        {
            return n;
        }

        public void Deti(Studentas ob)
        {
            Studentai[n++] = ob;
        }
    }

    class Facult_Konteineris
    {
        const int CMaxi = 100;
        private Facult[] Facults;
        private int n;

        public Facult_Konteineris()
        {
            n = 0;
            Facults = new Facult[CMaxi];
        }

        public Facult Imti(int i) { return Facults[i]; }

        public int Imti()
        {
            return n;
        }

        public void Deti(Facult ob)
        {
            Facults[n++] = ob;
        }

     /*   public void RikiuotiVid()
        {
            for (int i = 0; i < n - 1; i++)
            {
                double min = Facults[i].Vid();
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Facults[j].Vid() < min)
                    {
                        min = Facults[j].Vid();
                        im = j;
                    }
                Facults[im] = Facults[i];
            }
        }
        */
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Facult min = Facults[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Facults[j] <= min)
                    {
                        min = Facults[j];
                        im = j;
                    }
                Facults[im] = Facults[i];
                Facults[i] = min;
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            double suma;
            int poz;
            int n = 0;
            Grupe grupele = new Grupe();
            Facult_Konteineris facult = new Facult_Konteineris();
            const string CFd = "...\\...\\Duom.txt";
            Skaityti(ref n, CFd,ref grupele);

            for (int i = 0; i < n; i++)
            {
                poz = 0;
                suma = 0;
                int kiekis = 1;
                for (int a = 0; a < grupele.Imti(i).Pkiekis; a++) {
                    suma += grupele.Imti(i).Pazymiai[a];
            }


                for(int j = 0; j < facult.Imti(); j++)
                {
                    
                    if (facult.Imti(j).Pavadinimas == grupele.Imti(i).Grupe)
                    {
                        facult.Imti(j).Kiekis++;
                        Console.WriteLine(facult.Imti(j).Kiekis);
                        facult.Imti(j).Suma += suma;
                        poz++;
                    }
                }

                if (poz==0)
                {
                    Facult ob = new Facult(grupele.Imti(i).Grupe, kiekis, suma);  //ideda ir nekeicia
                    facult.Deti(ob);
                    Console.WriteLine("Create");

                }
            }
            Spausdinti(facult);

        }

        static void Skaityti(ref int n, string fv, ref Grupe grupele)
        {
            int pkiekis;
            int[] paz = new int[100];
            string pavadinimas, pavarde, vardas, grupe;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                pavadinimas = reader.ReadLine();
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    vardas = parts[0];
                    pavarde = parts[1];
                    grupe = parts[2];
                    pkiekis = int.Parse(parts[3]);

                    for (int j = 0; j < pkiekis; j++)
                    {
                        paz[j] = int.Parse(parts[j+3]);
                    }
                    Studentas ob = new Studentas(vardas, pavarde, grupe, pkiekis, paz);
                    grupele.Deti(ob);
                }

            }
        }
        
        static void Spausdinti(Facult_Konteineris facult)
        {
            double sum = 0;
            for (int i = 0; i < facult.Imti(); i++)
            {
                sum = 0;
                double vid = facult.Imti(i).Suma/facult.Imti(i).Kiekis;
                sum += facult.Imti(i).Suma;
               Console.WriteLine(facult.Imti(i).Suma);
               Console.WriteLine(vid);
                Console.WriteLine(i);
            }
            
            for(int i = 0; i < facult.Imti(); i++)
            {
                Console.WriteLine("{0}", facult.Imti(i).ToString());
            }
        }
    }
}
