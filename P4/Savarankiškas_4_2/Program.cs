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

        public Studentas(string pavarde, string vardas, string grupe, int pkiekis, int[] pazymiai1)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.pkiekis = pkiekis;
            pazymiai = new int[100];
            for (int i = 0; i < pkiekis; i++)
            {
                this.pazymiai[i] = pazymiai1[i];
            }
            //this.pazymiai = pazymiai;
        }

        public string Pavarde
        {
            set { value = pavarde; }
            get { return pavarde; }
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
        private int pkiekis;
        private double suma;

        public Facult(string pavadinimas, int pkiekis, double suma)
        {
            this.pavadinimas = pavadinimas;
            this.pkiekis = pkiekis;
            this.suma = suma;
        }

        public string Pavadinimas
        {
            set { value = pavadinimas; }
            get { return pavadinimas; }
        }

        public int Pkiekis
        {
            set { value = pkiekis; }
            get { return pkiekis; }
        }

        public double Suma
        {
            set { value = suma; }
            get { return suma; }
        }

        public void DetiSuma(double sum)
        {
            suma = sum;
        }

        public void DetiKiek(int kiek)
        {
            pkiekis = kiek;
        }

        public double Vid
        {
            set { value = Vid; }
            get { return suma / pkiekis; }
        }

        public static bool operator <=(Facult f1, Facult f2)
        {
            int p = String.Compare(f1.pavadinimas, f2.pavadinimas, StringComparison.CurrentCulture);

            return ((f1.Vid < f2.Vid) || (f1.Vid == f2.Vid) && (p > 0));
        }

        public static bool operator >=(Facult f1, Facult f2)
        {
            int p = String.Compare(f1.pavadinimas, f2.pavadinimas, StringComparison.CurrentCulture);

            return ((f1.Vid > f2.Vid) || (f1.Vid == f2.Vid) && (p < 0));
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7} {3}", pavadinimas, pkiekis, suma, Vid);
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

        public Studentas Imti(int i)
        {
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

        public void DetiSuma(double sum, int i)
        {
            /* double s1;
             s1 = Imti(i).Suma;
             s1 += sum;
             */
            Facults[i].DetiSuma(sum);
        }

        public void DetiKiek(int kiek, int j)
        {
            Facults[j].DetiKiek(kiek);
        }

        public void Deti(Facult ob)
        {
            Facults[n++] = ob;
        }

        /*  public void RikiuotiVid()
          {
              for (int i = 0; i < n - 1; i++)
              {
                  double min = Facults[i].Vid;
                  int im = i;
                  for (int j = i + 1; j < n; j++)
                      if (Facults[j].Vid < min)
                      {
                          min = Facults[j].Vid;
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
                    if (Facults[j] >= min)
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


        const string CFd = "...\\...\\Duom1.txt";

        static void Main(string[] args)
        {
            int n = 0;
            Grupe grupele = new Grupe();
            Facult_Konteineris facult = new Facult_Konteineris();
            Skaityti(ref n, CFd, ref grupele);
            Magija(facult, grupele, n);
            facult.Rikiuoti();
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
                        paz[j] = int.Parse(parts[j + 4]);
                        Console.WriteLine(" * " + j);
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
                double vid = facult.Imti(i).Suma / facult.Imti(i).Pkiekis;
                sum += facult.Imti(i).Suma;
                Console.WriteLine(facult.Imti(i).Suma);
                Console.WriteLine(vid);
                Console.WriteLine(i);
            }

            for (int i = 0; i < facult.Imti(); i++)
            {
                Console.WriteLine("{0}", facult.Imti(i).ToString());
            }
        }

        static void Magija(Facult_Konteineris facult, Grupe grupele, int n)
        {
            double suma;
            int poz;
            for (int i = 0; i < n; i++)
            {
                poz = 0;
                suma = 0;
                for (int a = 0; a < grupele.Imti(i).Pkiekis; a++)
                {
                    suma += grupele.Imti(i).Pazymiai[a];
                    Console.WriteLine(" / " + grupele.Imti(i).Pazymiai[a]);
                }


                for (int j = 0; j < facult.Imti(); j++)
                {

                    if (facult.Imti(j).Pavadinimas == grupele.Imti(i).Grupe)
                    {

                        Console.WriteLine(facult.Imti(j).Pkiekis);

                        double s1 = 0;
                        int v = 0;
                        s1 = facult.Imti(j).Suma;
                        s1 = s1 + suma;

                        v = facult.Imti(j).Pkiekis;
                        v = v + grupele.Imti(i).Pkiekis;

                        facult.DetiKiek(v, j);
                        Console.WriteLine(s1 + "  " + suma + "  " + facult.Imti(j).Pavadinimas);
                        facult.DetiSuma(s1, j);

                        Console.WriteLine(facult.Imti(j).Suma);
                        poz++;
                    }
                }

                if (poz == 0)
                {
                    Facult ob = new Facult(grupele.Imti(i).Grupe, grupele.Imti(i).Pkiekis, suma);  //ideda ir nekeicia
                    facult.Deti(ob);
                    Console.WriteLine("Create");

                }
            }
        }
    }
}
