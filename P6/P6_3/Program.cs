using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_3
{
    class Mokinys
    {
        private string pav, vard;
        private int klas, laikas;
        private double vid;

        public Mokinys()
        {
            pav = "";
            vard = "";
            klas = 0;
            laikas = 0;
            vid = 0.0;
        }

        public void Dėti(string pav, string vard, int klas, double vid)
        {
            this.pav = pav;
            this.vard = vard;
            this.klas = klas;
            this.vid = vid;
        }

        /** įrašo laiką */
        public void DėtiLaiką(int laik) { laikas = laik; }

        /** Grąžina mokinio pavardę */
        public string ImtiPav() { return pav; }

        /** Grąžina mokinio vardą */
        public string ImtiVard() { return vard; }

        /** Grąžina mokinio klasę */
        public int ImtiKlas() { return klas; }

        /** Grąžina mokinio vidurkį */
        public double ImtiVid() { return vid; }

        /** Grąžina mokinio laiką, praleistą internete */
        public int ImtiLaiką() { return laikas; }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -15} {1, -10}   {2,2:d}    {3, 6:f2}", pav, vard, klas, laikas);
            return eilute;
        }

        /** Operatorius grąžina         //  true, jeigu klasė yra mažesnė už kitą klasę, arba klasės yra lygios,         //  o laikas yra mažesnis už kitą laiką;         //  false - kitais atvejais. */
        public static bool operator <=(Mokinys pirmas, Mokinys antras)
        {
            return pirmas.klas < antras.klas || pirmas.klas == antras.klas && pirmas.laikas < antras.laikas;
        }

        /** Operatorius grąžina         //  true, jeigu klasė yra didesnė už kitą klasę, arba klasės yra lygios,         //  o laikas yra didesnis už kitą laiką;         //  false - kitais atvejais. */
        public static bool operator >=(Mokinys pirmas, Mokinys antras)
        {
            return pirmas.klas > antras.klas || pirmas.klas == antras.klas && pirmas.laikas > antras.laikas;
        }
    }
    class Mokykla
    {
        const int CMaxMk = 1000;      // didžiausias galimas mokinių skaičius         
        const int CMaxDn = 30;        // didžiausias galimas dienų skaičius         
        private Mokinys[] Mokiniai;   // mokinių duomenys         
        public int n { get; set; }    // mokinių skaičius         
        private int[,] WWW;           // laikas, praleistas internete         
        public int m { get; set; }    // dienų skaičius

        public Mokykla()
        {
            n = 0;
            Mokiniai = new Mokinys[CMaxMk];

            m = 0;
            WWW = new int[CMaxMk, CMaxDn];
        }

        /** Grąžina nurodyto indekso mokinio objektą */
        public Mokinys Imti(int nr) { return Mokiniai[nr]; }

        /** Padeda į mokinių objektų masyvą naują mokinį ir masyvo dydį padidina vienetu */
        public void Dėti(Mokinys ob) { Mokiniai[n++] = ob; }

        /** Pakeičia mokinių objektų masyvo mokinį, kurio numeris nr - keičiamo mokinio numeris mok - mokinių objekto masyvas */
        public void PakeistiMokinį(int nr, Mokinys mok) { Mokiniai[nr] = mok; }

        /** Pakeičia laikų matricos elementą                 @param i - mokinio numeris         @param j - dienos numeris         @param r - naujas laikas */
        public void DėtiWWW(int i, int j, int r) { WWW[i, j] = r; }

        /** Grąžina laikų matricos elementą                @param i - mokinio numeris         @param j - dienos numeris */
        public int ImtiWWW(int i, int j) { return WWW[i, j]; }

        //------------------------------------------------------------         /** Sukeičia dvi eilutes vietomis dvimačiame masyve WWW(n,m)         @param nr1 – pirmos eilutės numeris         @param nr2 – antros eilutės numeris */         //------------------------------------------------------------         
        public void SukeistiEilutesWWW(int nr1, int nr2)
        {
            for (int j = 0; j < m; j++)
            {
                int d = WWW[nr1, j];
                WWW[nr1, j] = WWW[nr2, j];
                WWW[nr2, j] = d;
            }
        }

        public void PapildytiMokiniųDuomenis()
        {
            int suma;
            Mokinys mok;
            for (int i = 0; i < n; i++)
            {
                suma = 0;
                for (int j = 0; j < m; j++)
                    suma = suma + WWW[i, j];
                mok = Imti(i);
                mok.DėtiLaiką(suma);
                PakeistiMokinį(i, mok);
            }
        }


        public void RikiuotiMinMax()
        {
            Mokinys mok; for (int i = 0; i < n - 1; i++)
            {
                int minnr = i;
                for (int j = i + 1; j < n; j++)
                    if (Imti(j) <= Imti(minnr))
                        minnr = j; mok = Imti(i);                 // pakeitimai masyvuose Mokiniai ir WWW                 
                PakeistiMokinį(i, Imti(minnr));
                PakeistiMokinį(minnr, mok);
                SukeistiEilutesWWW(i, minnr);
            }
        }
    }

    class Program
    {
        const string CFd = "...\\...\\Duomenys.txt";
        const string CFd1 = "...\\...\\Duomenys1.txt";
        const string CFr = "...\\...\\Atsakymai.txt";

        static void Main(string[] args)
        {
            // Baigta pries Programos patikrinimas
            Mokykla mokykl = new Mokykla();
            SkaitytiMok(CFd, ref mokykl);
            SkaitytiLaik(CFd1, ref mokykl);
            using (var fr = File.CreateText(CFr))
            {
                fr.WriteLine("       Pradiniai duomenys");
                fr.WriteLine();
                fr.WriteLine("Mokinių kiekis {0}", mokykl.n);
                fr.WriteLine("Dienų kiekis {0}", mokykl.m);
                fr.WriteLine();
            }
            Spausdinti(CFr, mokykl, "      Mokyklos mokiniai (laikai = 0)");
            SpausdintiLaik(CFr, mokykl, "Mokinių laikai, praleisti internete");

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine();
                fr.WriteLine("       Rezultatai");
                fr.WriteLine();
            }
            mokykl.PapildytiMokiniųDuomenis();
            Spausdinti(CFr, mokykl, "      Mokyklos mokiniai (papildyta, laikai != 0)");

            mokykl.RikiuotiMinMax();
            Spausdinti(CFr, mokykl, "      Mokyklos mokiniai (surikiuoti)");
            SpausdintiLaik(CFr, mokykl, "Mokinių laikai, praleisti internete (po rikiavimo)");


            Console.WriteLine("Pradiniai duomenys išspausdinti faile: {0}", CFr);

            using (var fr = File.AppendText(CFr))
            {
                int klasė;
                Console.WriteLine("Užrašykite klasę (1-12): ");
                klasė = int.Parse(Console.ReadLine());
                fr.WriteLine();
                if (VidLaikasKl(mokykl, klasė) != 0)
                    fr.WriteLine("{0} klasės mokiniai internete vidutiniškai praleido " + "{1,6:f2} minučių.", klasė, VidLaikasKl(mokykl, klasė));
                else
                    fr.WriteLine("{0} klasės mokinių sąraše nėra.", klasė);
            }
        }

        static void SkaitytiMok(string fd, ref Mokykla mokykl)
        {
            string pav, vard;
            int klas, nn;
            double vid;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                for (int i = 0; i < nn; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    pav = parts[0]; vard = parts[1];
                    klas = int.Parse(parts[2]);
                    vid = double.Parse(parts[3]);
                    Mokinys mok;
                    mok = new Mokinys();
                    mok.Dėti(pav, vard, klas, vid);
                    mokykl.Dėti(mok);
                }
            }
        }

        static void SkaitytiLaik(string fd, ref Mokykla mokykl)
        {
            int laikas, nn, mm;
            string line;
            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                nn = int.Parse(line);
                line = reader.ReadLine();
                mm = int.Parse(line);
                mokykl.m = mm;
                for (int i = 0; i < mokykl.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ', ';');
                    for (int j = 0; j < mokykl.m; j++)
                    {
                        laikas = int.Parse(parts[j]);
                        mokykl.DėtiWWW(i, j, laikas);
                    }
                }
            }
        }

        static void Spausdinti(string fv, Mokykla mokykl, string antraštė)
        {
            using (var fr = File.AppendText(fv))
            {
                string bruksnys = new string('-', 46);
                fr.WriteLine(antraštė); fr.WriteLine();

                fr.WriteLine(bruksnys);
                fr.WriteLine(" Nr. Pavardė         Vardas     Klasė   Laikas  ");
                fr.WriteLine(bruksnys);
                for (int i = 0; i < mokykl.n; i++)
                    fr.WriteLine("  {0}. {1}   ", i + 1, mokykl.Imti(i).ToString());
                fr.WriteLine(bruksnys);
                fr.WriteLine();
            }
        }

        static void SpausdintiLaik(string fv, Mokykla mokykl, string koment)
        {
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("{0} per {1} dienas.", koment, mokykl.m);
                fr.WriteLine();
                for (int i = 0; i < mokykl.n; i++)
                {
                    fr.Write("{0,4:d}.  ", i + 1);
                    for (int j = 0; j < mokykl.m; j++)
                        fr.Write("{0,3:d} ", mokykl.ImtiWWW(i, j));
                    fr.WriteLine();
                }
            }
        }

        static double VidLaikasKl(Mokykla mokykl, int klasė)
        {
            double suma = 0;
            int kiek = 0;
            for (int i = 0; i < mokykl.n; i++)
                if (mokykl.Imti(i).ImtiKlas() == klasė)
                {
                    kiek++;
                    suma = suma + mokykl.Imti(i).ImtiLaiką();
                }
            if (kiek != 0)
                return suma / kiek;
            else return 0;
        }
    }
}
