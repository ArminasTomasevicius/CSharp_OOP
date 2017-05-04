using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausimas2
{
    class Program
    {
        class Matrica
        {
            public const int Cn = 50;     // maksimalus eilučių, stulpelių skaičius           

            private int[,] DMas;          // dvimatis sveikų skaičių masyvas
            public int N { get; set; }    // savybė N: eilučių, stulpelių skaičius            

            public Matrica()
            {
                DMas = new int[Cn, Cn];
                N = 0;               
            }

            public void Deti(int i, int j, int sk)
            {
                DMas[i, j] = sk;
            }

            public int Imti(int i, int j)
            {
                return DMas[i, j];
            }

            // Užrašykite metodą, kuris suskaičiuoja kvadratinės matricos I srities
            // maksimalų neigiamą elementą.
            public void Skaiciuotimax(Matrica matrica, out int ats)
            {
                int max = int.MinValue;
                for (int j = matrica.N / 2 + 1; j < matrica.N; j++)
                {
                    for (int i = matrica.N - j - 1; i <= j; i++)
                    {
                        Console.WriteLine(matrica.Imti(i, j) + "  " + max);
                        if  (max == int.MinValue && matrica.Imti(i, j) < 0)
                             max = matrica.Imti(i, j);
                            if ((matrica.Imti(i, j) > max && matrica.Imti(i, j) < 0))
                        {
                            max = matrica.Imti(i, j);
                        }
                    }
                }
                ats = max;
                Console.WriteLine(ats + " a");
            }




        }

            const string CFd = "..\\..\\Matrica1.txt";
            const string CFd1 = "..\\..\\Matrica2.txt";
            const string CFr= "..\\..\\Rez.txt";

           

        static void Main(string[] args)
        {
            if (File.Exists(CFr))
                File.Delete(CFr);

            Matrica Mtr = new Matrica();  // Ikonteineris su dvimačiu masyvu
            Skaityti(CFd, Mtr);
            Spausdinti(CFr, Mtr," Pirma matrica" );

            Matrica Mtr1 = new Matrica();  // II konteineris su dvimačiu masyvu
            Skaityti(CFd, Mtr1);
            Spausdinti(CFr, Mtr1, " Antra matrica");

            int [] B = new int[Mtr.N];
            int [] B1 = new int[Mtr1.N];

            // Atlikite visus nurodytus skaičiavimus.
            int ats, ats1;
            Mtr.Skaiciuotimax(Mtr, out ats);
            Mtr1.Skaiciuotimax(Mtr1, out ats1);

            if (ats < 0)
            {
                Console.WriteLine("Didžiausia neigiama vertė: {0}", ats);
            }
            else
            {
                Console.WriteLine("Didžiausia neigiama vertė neegzistuoja");
            }

            if (ats1 < 0)
            {
                Console.WriteLine("Didžiausia neigiama vertė: {0}", ats1);
            }
            else
            {
                Console.WriteLine("Didžiausia neigiama vertė neegzistuoja");
            }

            Naujas(Mtr, B);
            Naujas(Mtr1, B1);

            Spausdinti1(CFd, B, Mtr.N, "tekstas");
            Spausdinti1(CFd, B1, Mtr.N, "tekstas");
        }

        static void Skaityti(string fv, Matrica A)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                int skaicius;
                string line = reader.ReadLine();
                char[] skyr = { ' ' };
                string[] skaiciai = line.Split(skyr,
                                      StringSplitOptions.RemoveEmptyEntries);
                A.N = int.Parse(skaiciai[0]);               
                for (int i = 0; i < A.N; i++)
                {
                    line = reader.ReadLine();
                    skaiciai = line.Split(skyr,
                                      StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < A.N; j++)
                    {
                        skaicius = int.Parse(skaiciai[j]);
                        A.Deti(i, j, skaicius);
                    }
                }
            }
        }


        // Matricos konteinerio duomenų spausdinimas faile fv
        static void Spausdinti(string fv, Matrica A, string tekstas)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("      " + tekstas);
                
                for (int i = 0; i < A.N; i++)
                {
                    for (int j = 0; j < A.N; j++)
                    {
                        fr.Write("{0, 4:d}", A.Imti(i, j));
                    }
                    fr.WriteLine();
                }
            }
        }

        // Masyvo duomenų spausdinimas faile fv
        static void Spausdinti1(string fv, int [] B, int n, string tekstas)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine();
                fr.WriteLine("      " + tekstas);

                for (int i = 0; i < n; i++)
                {                 
                    fr.Write("{0, 4:d}", B[i]);                    
                }
                fr.WriteLine();
            }
        }


        // Užrašykite metodą, kuris randa kiekvieno stulpelio antrą didžiausią elementą
        // ir jį įrašo į naują rinkinį.

        static void Naujas(Matrica matrica, int[] B)
        {
            int min = int.MinValue;
            int min2 = int.MinValue;
            for (int i = 0; i < matrica.N; i++)
            {
                int index =0;
                for (int j = 0; j < matrica.N; j++)
                {
                    if (min < matrica.Imti(i, j))
                    {
                        min = matrica.Imti(i, j);
                        index = j;
                    }
                }
                min = int.MinValue;

                for (int j = 0; j < matrica.N; j++)
                {
                    if (j != index && min < matrica.Imti(i, j))
                    {
                        min2 = matrica.Imti(i, j);
                    }
                }

                B[i] = min2;
            }
        }

    }
}
