using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_22
{
    class Kaliausė
    {
        private string type;
        private int count;
        private double mass;
        private double cost;

        public Kaliausė(string type, int count, double mass, double cost)
        {
            this.type = type;
            this.count = count;
            this.mass = mass;
            this.cost = cost;
        }

        public string Type
        {
            set { type = value; }
            get { return type; }
        }

        public int Count
        {
            set { count = value; }
            get { return count; }
        }

        public double Mass
        {
            set { mass = value; }
            get { return mass; }
        }

        public double Cost
        {
            set { cost = value; }
            get { return cost; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string name1, name2;
            int kiek1, kiek2;
            const string CFd1 = "...\\...\\Duom1.txt";
            const string CFd2 = "...\\...\\Duom2.txt";
            const string Rez = "...\\...\\Rez.txt";
            Kaliausė[] K1 = new Kaliausė[100];
            Kaliausė[] K2 = new Kaliausė[100];
            Kaliausė[] R = new Kaliausė[100];
            int[] count1 = new int[100];
            int[] count2 = new int[100];
            if (File.Exists(Rez)) File.Delete(Rez);

            Skaityti(CFd1, K1, out kiek1, out name1);
            SpausdintiPradiniusDuomenis(Rez, K1, kiek1, name1);
            Skaityti(CFd2, K2, out kiek2, out name2);
            SpausdintiPradiniusDuomenis(Rez, K2, kiek2, name2);
            Count_HighestMass(K1, kiek1, name1);
            Count_HighestMass(K2, kiek2, name2);
            SpausdintiDuomenis(Rez, Vid_Cost(K1, kiek1), name1);
            SpausdintiDuomenis(Rez, Vid_Cost(K2, kiek2), name2);
            count1 = Count_HighestMass_Compare(K1, kiek1, count1);
            count2 = Count_HighestMass_Compare(K2, kiek2, count2);
            SpausdintiMax(Rez, count1, count2, name1, name2);
            Vid_Cost_Lowest(K1, K2, kiek1, kiek2, name1, name2);
            Console.WriteLine("Įveskite kaliausių rinkinio tipą");
            string x = Console.ReadLine();
            int check = 0;
            check = Make_Type_List(K1, R, kiek1, x, check);
            Make_Type_List(K2, R, kiek2, x, check);
            SpausdintiRinki(Rez, R, check);

        }

        static void Count_HighestMass(Kaliausė[] K, int kiek, string name)
        {
            using (StreamWriter writer = new StreamWriter("...\\...\\Rez.txt", true))
            {
                writer.WriteLine("Ūkininko {0} sunkiausios kaliausės aprėdų skaičius:", name);
                double Max_mass = 0;
                for (int i = 0; i < kiek; i++)
                {
                    if (K[i].Mass > Max_mass)
                    {
                        Max_mass = K[i].Mass;
                    }
                }

                for (int i = 0; i < kiek; i++)
                {
                    if (K[i].Mass == Max_mass)
                    {

                        writer.WriteLine("Kaliausės tipas {0}, aprėdų skaičius {1}, masė {2}, kaina {3}", K[i].Type, K[i].Count, K[i].Mass, K[i].Cost);
                    }
                }
            }
        }

        static double Vid_Cost(Kaliausė[] K, int kiek)
        {
            double sum = 0;

            for (int i = 0; i < kiek; i++)
            {
                sum += K[i].Cost;
            }

            double vid_cost = sum / kiek;
            return vid_cost;
        }

        static int[] Count_HighestMass_Compare(Kaliausė[] K, int kiek, int[] count)
        {
            double Max_mass = 0;

            for (int i = 0; i < kiek; i++)
            {
                if (K[i].Mass > Max_mass)
                {
                    Max_mass = K[i].Mass;
                }
            }

            for (int i = 0; i < kiek; i++)
            {
                if (K[i].Mass == Max_mass)
                {
                    count[i] = K[i].Count;
                }
            }
            return count;
        }


        static void Vid_Cost_Lowest(Kaliausė[] K1, Kaliausė[] K2, int kiek1, int kiek2, string name1, string name2)
        {
            using (StreamWriter writer = new StreamWriter("...\\...\\Rez.txt", true))
            {

                if (Vid_Cost(K1, kiek1) < Vid_Cost(K2, kiek2))
                {
                    writer.WriteLine("Ūkininko {0} vidutinė kaliausės kaina mažesnė:  {1:f2}", name1, Vid_Cost(K1, kiek1));
                }
                else if (Vid_Cost(K1, kiek1) > Vid_Cost(K2, kiek2))
                {
                    writer.WriteLine("Ūkininko {0} vidutinė kaliausės kaina mažesnė:  {1:f2}", name2, Vid_Cost(K2, kiek2));
                }
                else
                {
                    writer.WriteLine("Abiejų ūkininkų vidutinės kaliausių kainos lygios: {0:f2}", Vid_Cost(K1, kiek1));
                }

            }
        }

        static int Make_Type_List(Kaliausė[] K, Kaliausė[] R, int kiek, string x, int check0)
        {
            int check = check0;
            for (int i = 0; i < kiek; i++)
            {
                if (x == K[i].Type)
                {
                    R[check] = new Kaliausė(K[i].Type, K[i].Count, K[i].Mass, K[i].Cost);
                    check++;
                }
            }
            return check;
        }

        static void Skaityti(string CFd, Kaliausė[] K, out int kiek, out string name)
        {
            using (StreamReader reader = new StreamReader(CFd, Encoding.GetEncoding(1257)))
            {
                string type;
                int count;
                double mass, cost;
                string line;
                line = reader.ReadLine();
                string[] parts;
                name = (line);
                line = reader.ReadLine();
                kiek = int.Parse(line);
                for (int i = 0; i < kiek; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    type = parts[0];
                    count = int.Parse(parts[1]);
                    mass = double.Parse(parts[2]);
                    cost = double.Parse(parts[3]);
                    K[i] = new Kaliausė(type, count, mass, cost);
                }
            }
        }

        static void SpausdintiDuomenis(string fv, double vid_cost, string name)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Vidutinė {0} kaliausės kaina: {1:f2}", name, vid_cost);
            }
        }


        static void SpausdintiPradiniusDuomenis(string fv, Kaliausė[] K, int kiek, string name)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(name);
                fr.WriteLine();
                const string virsus = "|------------------------------------------------|-------------|---------|--------|\r\n" +
                                      "|                                                |             |         |        |\r\n" +
                                      "|   Tipas                                        |    Kiekis   |   Masė  |  Kaina |\r\n" +
                                      "|                                                |             |         |        |\r\n" +
                                      "|------------------------------------------------|-------------|---------|--------|";
                fr.WriteLine(virsus);
                for (int i = 0; i < kiek; i++)
                {
                    fr.WriteLine("|{0,-48}|{1,13}|{2,9}|{3,8}|", K[i].Type, K[i].Count, K[i].Mass, K[i].Cost);
                }
                fr.WriteLine();
                fr.WriteLine();
            }
        }

        static void SpausdintiRinki(string fv, Kaliausė[] R, int check)
        {

            using (StreamWriter fr = new StreamWriter(fv, true))
            {
                if (check == 0)
                {
                    Console.WriteLine("Nurodyto tipo kaliausių nėra");
                    fr.WriteLine("Nurodyto tipo kaliausių nėra");
                }
                else
                {
                    fr.WriteLine();
                    const string virsus = "|------------------------------------------------|-------------|---------|--------|\r\n" +
                                          "|                                                |             |         |        |\r\n" +
                                          "|   Tipas                                        |    Kiekis   |   Masė  |  Kaina |\r\n" +
                                          "|                                                |             |         |        |\r\n" +
                                          "|------------------------------------------------|-------------|---------|--------|";
                    fr.WriteLine(virsus);
                    for (int i = 0; i <= check; i++)
                    {
                        fr.WriteLine("|{0,-48}|{1,13}|{2,9}|{3,8}|", R[i].Type, R[i].Count, R[i].Mass, R[i].Cost);
                    }
                }
            }

        }

        static void SpausdintiMax(string fv, int[] count1, int[] count2, string name1, string name2)
        {

            using (StreamWriter fr = new StreamWriter(fv, true))
            {
                if (count1.Max() == count2.Max())
                {
                    fr.WriteLine("Abiejų ūkininkų sunkiausios kaliausės yra vienodai aprėdytos: {0}", count1.Max());
                }
                else if (count1.Max() < count2.Max())
                {
                    fr.WriteLine("Ūkininko {0} sunkiausia kaliausė yra daugiausiai aprėdyta: {1}", name2, count2.Max());
                }
                else
                {
                    fr.WriteLine("Ūkininko {0} sunkiausia kaliausė yra daugiausiai aprėdyta: {1}", name1, count1.Max());
                }

            }
        }
    }
}
