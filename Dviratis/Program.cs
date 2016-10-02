using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dviratis
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

            const int Cn = 100;
            const string CFd1 = "...\\...\\Duom1.txt";
            const string CFd2 = "...\\...\\Duom2.txt";

            Dviratis[] D1 = new Dviratis[Cn];
            int n1;
            int am1;
            int kiekNetinka1;
            double sumaNetinka1;
            int kiekTinka1;
            double sumaTinka1;
            string pav1;
            Skaityti(CFd1, D1, out n1, out am1, out pav1);


            Dviratis[] D2 = new Dviratis[Cn];
            int n2;
            int am2;
            int kiekNetinka2;
            double sumaNetinka2;
            int kiekTinka2;
            double sumaTinka2;
            string pav2;
            Skaityti(CFd2, D2, out n2, out am2, out pav2);

            Console.WriteLine("Pagaminimo metai     Kaina");
            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine("    {0}            {1, 7:f2}", D1[i].ImtiMetus(), D1[i].ImtiKainą());
                Console.WriteLine();
            }


            Console.WriteLine("Dviračių kiekis {0}\n", n1);

            Dviratis d;
            d = new Dviratis(2012, 25.26);
            Console.WriteLine("{0} {1, 6:f2} \n", d.ImtiMetus(), d.ImtiKainą());

            Pinigai(D1, n1, 0, am1, 2015, out kiekTinka1, out sumaTinka1);
            Console.WriteLine("Tinkami naudoti: {0,3:d}  {1,7:f2}", kiekTinka1, sumaTinka1);

            Pinigai(D2, n2, am2 + 1, 1000, 2015, out kiekNetinka2, out sumaNetinka2);
            Console.WriteLine("Netinkami naudoti: {0}  {1,7:f2}\n", kiekNetinka2, sumaNetinka2);

            double vidurkisTinka = Vidurkis(D1, n1, 2015, 0, am1);

            if (vidurkisTinka > 0)
                Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius:   {0,7:f2}", vidurkisTinka);
            else
                Console.WriteLine("Tinkamų naudoti dviračių nėra");

            double vidurkisNetinka = Vidurkis(D1, n1, 2015, am1 + 1, 1000);
            if (vidurkisNetinka > 0)
                Console.WriteLine("Netinkamų naudoti dviračių vidutinis amžius: {0,7:f2}\n", vidurkisNetinka);
            else
                Console.WriteLine("Netinkamų naudoti dviračių nėra\n");

            Console.WriteLine("Programa baigė darbą!");
        }


        static void Skaityti(string fv, Dviratis[] D, out int n, out int m, out string pav)
        {
            int metai; double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                pav = line;
                line = reader.ReadLine();
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++) {
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
