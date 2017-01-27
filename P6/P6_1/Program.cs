using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_1
{
    class Matrica
    {
        const int CMaxEil = 10;     // didžiausias galimas eilučių (kasų) skaičius
        const int CMaxSt = 100;     // didžiausias galimas stulpelių (pirkėjų) skaičius
        private int[,] A;           // duomenų matrica
        public int n { get; set; }  // eilučių skaičius (kasų skaičius)
        public int m { get; set; }  // stulpelių skaičius (dienų skaičius) 

        // Pradinių matricos duomenų nustatymas
        public Matrica()
        {
            n = 0;
            m = 0;
            A = new int[CMaxEil, CMaxSt];
        }

        //Priskiria klasės matricos kintamajam reikšmę
        public void Deti(int i, int j, int pirk)
        {
            A[i, j] = pirk;
        }

        // Grąžina pirkėjų kiekį.
        public int ImtiReiksme(int i, int j)
        {
            return A[i, j];
        }
    }

    class Program
    {
        const string CFd = "..\\..\\input.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Matrica prekybosBaze = new Matrica();
            Skaityti(CFd, ref prekybosBaze);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, prekybosBaze, " Pradiniai duomenys");
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("1)");
                fr.WriteLine(" Vidutiniškai viena kasa per dieną aptarnavo {0} klientus", VidPirkeju(prekybosBaze));
                KiekNedirbo(prekybosBaze, CFr);
                fr.WriteLine("2)");
                KiekvienaKasaAptarnavo(CFr, prekybosBaze);
                KiekvienaDienaAptarnauta(CFr, prekybosBaze);
            }
        }

        static void Skaityti(string fd, ref Matrica prekybosBaze)
        {
            int nn, mm, skaic; string line; using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine(); string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                prekybosBaze.n = nn;
                prekybosBaze.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        skaic = int.Parse(parts[j]);
                        prekybosBaze.Deti(i, j, skaic);
                    }
                }
            }
        }

        static void Spausdinti(string fv, Matrica prekybosBaze, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine(" Kasų kiekis {0}", prekybosBaze.n);
                fr.WriteLine(" Darbo dienų kiekis {0}", prekybosBaze.m);
                fr.WriteLine(" Aptarnautų klientų kiekiai");
                for (int i = 0; i < prekybosBaze.n; i++)
                {
                    for (int j = 0; j < prekybosBaze.m; j++)
                        fr.Write("{0,4:d}", prekybosBaze.ImtiReiksme(i, j));
                    fr.WriteLine();
                }

                fr.WriteLine();
                fr.WriteLine(" Rezultatai");
                fr.WriteLine();
                fr.WriteLine(" Viso aptarnauta: {0} klientų.", VisoAptarnauta(prekybosBaze));
                fr.WriteLine();
                fr.WriteLine(" Daugiausia pirkėjų aptarnavo (kasa): {0}", KasosNumerisMaxPirkėjų(prekybosBaze));
            }
        }

        static int VisoAptarnauta(Matrica A)
        {
            int suma = 0;
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    suma = suma + A.ImtiReiksme(i, j);
                }
            }
            return suma;
        }

        static double VidPirkeju(Matrica A)
        {
            int vid = 0, sum = 0, kiek = 0;
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    sum += A.ImtiReiksme(i, j);
                    kiek++;
                }
            }
            vid = sum / kiek;
            return vid;
        }

        static void KiekNedirbo(Matrica A, string fv)
        {
            for (int i = 0; i < A.n; i++)
            {
                int days = 0;
                for (int j = 0; j < A.m; j++)
                {
                    if (A.ImtiReiksme(i, j) == 0)
                    {
                        days++;
                    }
                }
                if (days != 0)
                {
                    using (var fr = File.AppendText(fv))
                    {
                        fr.WriteLine(" {0} kasa nedirbo {1} dienų(as) ", i++, days);
                    }
                }
            }
        }

        static void KiekvienaKasaAptarnavo(string CFr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                for (int i = 0; i < A.n; i++)
                {
                    int suma = 0;
                    for (int j = 0; j < A.m; j++)
                        suma = suma + A.ImtiReiksme(i, j);
                    fr.WriteLine(" Kasa nr. {0} aptarnavo {1} klientų.", i + 1, suma);
                }
            }
        }

        static void KiekvienaDienaAptarnauta(string CFr, Matrica A)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                for (int j = 0; j < A.m; j++)
                {
                    int suma = 0;
                    for (int i = 0; i < A.n; i++)
                        suma = suma + A.ImtiReiksme(i, j);
                    fr.WriteLine(" Diena nr. {0}: aptarnauta klientų - {1}.", j + 1, suma);
                }
            }
        }

        static int KasosNumerisMaxPirkėjų(Matrica A)
        {
            int max = 0;
            int nr = 0;
            for (int i = 0; i < A.n; i++)
            {
                int suma = 0;
                for (int j = 0; j < A.m; j++)
                    suma = suma + A.ImtiReiksme(i, j);
                if (suma > max)
                {
                    max = suma;
                    nr = i + 1;
                }
            }
            return nr;
        }
    }
}