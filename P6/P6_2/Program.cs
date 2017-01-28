using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_2
{
    class Asmuo
    {
        private string vardas;            // pirkusio asmens vardas         
        private double pinigai;           // išlaidos per dieną        

        public Asmuo(string vardas, double pinigai)
        {
            this.vardas = vardas;
            this.pinigai = pinigai;
        }

        /** grąžina pirkusio asmens vardą */
        public string ImtiVarda() { return vardas; }

        /** grąžina išlaidų kiekį */
        public double ImtiPinigus() { return pinigai; }

    }

    class Matrica
    {
        const int CMaxEil = 100;    // didžiausias galimas savaičių skaičius         
        const int CMaxSt = 7;       // didžiausias galimas stulpelių (dienų) skaičius         
        private Asmuo[,] A;         // duomenų matrica                 
        public int n { get; set; }  // eilučių skaičius (savaičių skaičius)         
        public int m { get; set; }  // stulpelių skaičius (dienų skaičius) 

        public Matrica()
        {
            n = 0;
            m = 0;
            A = new Asmuo[CMaxEil, CMaxSt];
        }

        public void Deti(int i, int j, Asmuo asmuo)
        {
            A[i, j] = asmuo;
        }

        public Asmuo ImtiReiksme(int i, int j)
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
            Matrica seimosIslaidos = new Matrica();
            Skaityti(CFd, ref seimosIslaidos);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, seimosIslaidos, "Pradiniai duomenys");

            Console.WriteLine("Pradiniai duomenys išspausdinti faile: {0}", CFr);
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("Rezultatai");
                fr.WriteLine();
                fr.WriteLine("Viso išleista: {0,5:c2}.", VisosIslaidos(seimosIslaidos));
            }

        }

        static void Skaityti(string fd, ref Matrica seimosIslaidos)
        {
            int nn, mm;
            double pinigai;
            string line, vardas;
            Asmuo asmuo;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                seimosIslaidos.n = nn;
                seimosIslaidos.m = mm;
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    for (int j = 0; j < mm; j++)
                    {
                        vardas = parts[2 * j];
                        pinigai = double.Parse(parts[2 * j + 1]);
                        asmuo = new Asmuo(vardas, pinigai);
                        seimosIslaidos.Deti(i, j, asmuo);
                    }
                }
            }
        }

        static void Spausdinti(string fv, Matrica seimosIslaidos, string antraštė)
        {
            Asmuo asmuo;
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine();
                fr.WriteLine("Savaičių kiekis {0}", seimosIslaidos.n);
                fr.WriteLine("Dienų kiekis {0}", seimosIslaidos.m);
                fr.WriteLine();
                for (int j = 0; j < seimosIslaidos.m; j++)
                    fr.Write("{0}-dienis       ", j + 1);
                fr.WriteLine();

                for (int i = 0; i < seimosIslaidos.n; i++)
                {
                    for (int j = 0; j < seimosIslaidos.m; j++)
                    {
                        asmuo = seimosIslaidos.ImtiReiksme(i, j);
                        fr.Write("{0} {1,6:f2}   ", asmuo.ImtiVarda(), asmuo.ImtiPinigus());
                    }
                    fr.WriteLine();
                }
            }
        }

        static decimal VisosIslaidos(Matrica A)
        {
            Asmuo asmuo;
            double suma = 0;
            for (int i = 0; i < A.n; i++)
                for (int j = 0; j < A.m; j++)
                {
                    asmuo = A.ImtiReiksme(i, j);
                    suma = suma + asmuo.ImtiPinigus();
                }
            return (decimal)suma;
        }

        static int Neturejoislaidu()
        {
            return 0;
        }

        static void IslaidosKasdien()
        {

        }
    }
}
