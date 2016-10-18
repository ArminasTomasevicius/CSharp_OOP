using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{

    class Dviratis
    {
        private int metai;
        private double kaina;

        public Dviratis(int metai, double kaina) { this.metai = metai; this.kaina = kaina; }
        /** grąžina metus */
        public int ImtiMetus() { return metai; }
        /** grąžina dviračio reikšmę */
        public double ImtiKainą() { return kaina; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int kiekNetinka;
            double sumaNetinka;
            int kiekTinka;
            double sumaTinka;

            const int Cn = 100;
            const string CFd = "...\\...\\Duom.txt";

                Dviratis[] D = new Dviratis[Cn];
                int n;
                int am;
                Skaityti(CFd, D, out n , out am);


            Console.WriteLine("Pagaminimo metai     Kaina");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("    {0}            {1, 7:f2}", D[i].ImtiMetus(), D[i].ImtiKainą());
                Console.WriteLine();
            }


            Console.WriteLine("Dviračių kiekis {0}\n", n);

        Dviratis d;
        d = new Dviratis(2012, 25.26);
        Console.WriteLine("{0} {1, 6:f2} \n", d.ImtiMetus(), d.ImtiKainą());

            Pinigai(D, n, 0, am, 2015, out kiekTinka, out sumaTinka);
            Console.WriteLine("Tinkami naudoti: {0,3:d}  {1,7:f2}", kiekTinka, sumaTinka);

            Pinigai(D, n, am + 1, 1000, 2015, out kiekNetinka, out sumaNetinka);
            Console.WriteLine("Netinkami naudoti: {0}  {1,7:f2}\n", kiekNetinka, sumaNetinka);

            double vidurkisTinka = Vidurkis(D, n, 2015, 0, am);

            if (vidurkisTinka > 0)
            Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius:   {0,7:f2}", vidurkisTinka);
            else
                Console.WriteLine("Tinkamų naudoti dviračių nėra");

            double vidurkisNetinka = Vidurkis(D, n, 2015, am + 1, 1000);
            if (vidurkisNetinka > 0)
                Console.WriteLine("Netinkamų naudoti dviračių vidutinis amžius: {0,7:f2}\n", vidurkisNetinka);
            else
                Console.WriteLine("Netinkamų naudoti dviračių nėra\n");

            Console.WriteLine("Programa baigė darbą!");
    }


        static void Skaityti(string fv, Dviratis[] D, out int n, out int m)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);
                }
            }
        }

        static void Pinigai(Dviratis[] D, int n, int amPr, int amPb, int metai, out int kiek, out double suma)
        {
            kiek = 0;
            suma = 0.0;
            int amžius;
            for (int i = 0; i < n; i++)
            {
                amžius = metai - D[i].ImtiMetus();
                if ((amPr <= amžius) && (amžius <= amPb))
                {
                    suma = suma + D[i].ImtiKainą();
                    kiek++;
                }
            }
        }

        static double Vidurkis(Dviratis[] D, int n, int metai, int amPr, int amPb)
        {
            int kiek = 0, suma = 0;
            int amžius;
            for (int i = 0; i < n; i++)
            {
                amžius = metai - D[i].ImtiMetus();
                if ((amPr <= amžius) && (amžius <= amPb))
                {
                    suma = suma + amžius;
                    kiek++;
                }
            }

            if (kiek > 0) return (double)suma / kiek;
            return 0.0;
        }
    }
}
