using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrolinis1
{
    class Program
    {
        const string CFd = "..\\..\\Duomenys2.txt";
        Daugiabutis D;

        static void Main(string[] args)
        {
            Skaityti(CFd, out D);
            Spausdinti(D);
            D.Burbulas(D, D.Kiek);
            Spausdinti(D);
            Pasalinti(D);
            Spausdinti(D);
            Iterpti(D);
            Spausdinti(D);
        }

        static void Skaityti(string fv, out Daugiabutis D)
        {
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1224)))
            {
                D = new Daugiabutis();
                string eilute;
                int k = Int32.Parse(srautas.ReadLine());
                for (int i = 0; i < k; i++)
                {
                    eilute = srautas.ReadLine();
                    string[] eilDalis = eilute.Split(' ');
                    int nr = Int32.Parse(eilDalis[0]);
                    string pav = eilDalis[1];
                    DateTime date = DateTime.Parse(eilDalis[2]);
                    double mokd = double.Parse(eilDalis[3]);
                    double mokl = double.Parse(eilDalis[4]);

                    Butas butas = new Butas(nr, pav, date, mokd, mokl);
                    D.DetiButa(butas);
                }
            }
        }

        private void Iterpti(Daugiabutis daugiabutis)
        {
            int nr = int.Parse(Console.ReadLine());
            string pav = Console.ReadLine();
            DateTime date = DateTime.Parse(Console.ReadLine());
            double mokd = double.Parse(Console.ReadLine());
            double mokl = double.Parse(Console.ReadLine());
            Butas butas = new Butas(nr, pav, date, mokd, mokl);

            bool iterpe = false;
            for (int i = 0; i < daugiabutis.Kiek; i++)
            {
                if (butas >= daugiabutis.ImtiButa(i) && iterpe == false)
                {
                    daugiabutis.Kiek = daugiabutis.Kiek + 1;
                    for (int j = daugiabutis.Kiek - 1; j > i; j--)
                    {
                        daugiabutis.Apkeisti(j, j - 1);
                    }
                    iterpe = true;
                    daugiabutis.DetiTiksliai(butas, i);
                }
                else if (butas.date <= daugiabutis.ImtiButa(i).date && iterpe == false)
                {
                    daugiabutis.Kiek = daugiabutis.Kiek + 1;
                }
            }
        }


        private void Pasalinti(Daugiabutis daugiabutis)
        {
            DateTime nuo = DateTime.Parse(Console.ReadLine());

            for (int i = 0; i < daugiabutis.Kiek; i++)
            {
                if (nuo < daugiabutis.ImtiButa(i).date)
                {
                    for (int j = i; j < daugiabutis.Kiek - 1; j++)
                    {
                        daugiabutis.ApkeistiValues(daugiabutis.ImtiButa(j), daugiabutis.ImtiButa(j + 1));
                    }
                    i--;
                    daugiabutis.Kiek = daugiabutis.Kiek - 1;
                }
            }
        }

        static void Spausdinti(Daugiabutis daugiabutis)
        {
            string v = "---------------------------------------------\r\n" + " Nr.   Savininkas       Data     Mokestis uz dujas   Mokestis uz lifta \r\n" + "---------------------------------------------";
                Console.WriteLine("\n " + " Butai ");
                Console.WriteLine(v);
                for (int i = 0; i < daugiabutis.Kiek; i++)
                {
                    Butas butas = daugiabutis.ImtiButa(i);
                    Console.WriteLine("{0, 3}   |{1}       |{2}     |{3}   |{4}", i + 1, daugiabutis.ImtiButa(i).sav, daugiabutis.ImtiButa(i).date, daugiabutis.ImtiButa(i).mokestisd, daugiabutis.ImtiButa(i).mokestisl);
                }
                Console.WriteLine("---------------------------------------------\n");
            }
        }
    }
