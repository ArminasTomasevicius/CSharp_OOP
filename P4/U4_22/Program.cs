using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_22
{
    class Studentas
    {
        private string mpavadinimas, dpavarde, dvardas, grupe, svardas, spavarde;
        private double credit;

        public Studentas(string mpavadinimas, string dpavarde, string dvardas, double credit, string spavarde, string svardas, string grupe)
        {
            this.mpavadinimas = mpavadinimas;
            this.dpavarde = dpavarde;
            this.dvardas = dvardas;
            this.credit = credit;
            this.spavarde = spavarde;
            this.svardas = svardas;
            this.grupe = grupe;
        }

        public string MPavadinimas
        {
            set { mpavadinimas = value; }
            get { return mpavadinimas; }
        }

        public string Dpavarde
        {
            set { dpavarde = value; }
            get { return dpavarde; }
        }

        public string Dvardas
        {
            set { dvardas = value; }
            get { return dvardas; }
        }

        public double Credit
        {
            set { credit = value; }
            get { return credit; }
        }

        public string Spavarde
        {
            set { spavarde = value; }
            get { return spavarde; }
        }

        public string Svardas
        {
            set { svardas = value; }
            get { return svardas; }
        }

        public string Grupe
        {
            set { value = grupe; }
            get { return grupe; }
        }
    }

    class Destytojas
    {
        private string dpavarde, dvardas;
        private string[] mpavadinimas = new string[100];
        private double credit;
        private int mokkiekis, modsk;

        public Destytojas(int modsk, string[] mpavadinimas, int mokkiekis, string dpavarde, string dvardas, double credit)
        {
            this.dpavarde = dpavarde;
            this.dvardas = dvardas;
            this.credit = credit;
            this.modsk = modsk;
            for (int i = 0; i < modsk; i++)
            {
                this.mpavadinimas[i] = mpavadinimas[i];
            }
        }

        public string[] MPavadinimas
        {
            set { mpavadinimas = value; }
            get { return mpavadinimas; }
        }

        public int Mokkiekis
        {
            set { mokkiekis = value; }
            get { return mokkiekis; }
        }
        public string Dpavarde
        {
            set { dpavarde = value; }
            get { return dpavarde; }
        }

        public string Dvardas
        {
            set { dvardas = value; }
            get { return dvardas; }
        }

        public double Credit
        {
            set { credit = value; }
            get { return credit; }
        }

        public int Modsk
        {
            set { modsk = value; }
            get { return modsk; }
        }

        public static bool operator <=(Destytojas d1, Destytojas d2)
        {
            return (d1.Mokkiekis < d2.Mokkiekis);
        }

        public static bool operator >=(Destytojas d1, Destytojas d2)
        {
            return (d1.Mokkiekis > d2.Mokkiekis);
        }

        public void DetiM(int nr, string value)
        {
            mpavadinimas[nr] = value;
        }
    }

        class Modulis
        {
            private string mpavadinimas, dpavarde, dvardas;
            private double credit;
            private int skiekis;

            public Modulis(string mpavadinimas, string dpavarde, string dvardas, double credit, int skiekis)
            {
                this.mpavadinimas = mpavadinimas;
                this.dpavarde = dpavarde;
                this.dvardas = dvardas;
                this.credit = credit;
                this.skiekis = skiekis;
            }

            public string MPavadinimas
            {
                set { mpavadinimas = value; }
                get { return mpavadinimas; }
            }

            public string DPavarde
            {
                set { dpavarde = value; }
                get { return dpavarde; }
            }

            public string DVardas
            {
                set { dvardas = value; }
                get { return dvardas; }
            }

            public double Credit
            {
                set { credit = value; }
                get { return credit; }
            }

            public int Skiekis
            {
                set { skiekis = value; }
                get { return skiekis; }
            }

            public static bool operator >=(Modulis m1, Modulis m2)
            {
                int p = String.Compare(m1.mpavadinimas, m2.mpavadinimas, StringComparison.CurrentCulture);

                return ((m1.Credit > m2.Credit) || (m1.Credit == m2.Credit) && (p < 0));
            }

            public static bool operator <=(Modulis m1, Modulis m2)
            {
                int p = String.Compare(m1.mpavadinimas, m2.mpavadinimas, StringComparison.CurrentCulture);

                return ((m1.Credit < m2.Credit) || (m1.Credit == m2.Credit) && (p > 0));
            }
        }

        class Grupe
        {
            private string pavadinimas;
            private int kiekis;

            public Grupe(string pavadinimas, int kiekis)
            {
                this.pavadinimas = pavadinimas;
                this.kiekis = kiekis;
            }

            public string Pavadinimas
            {
                set { pavadinimas = value; }
                get { return pavadinimas; }
            }

            public int Kiekis
            {
                set { kiekis = value; }
                get { return kiekis; }
            }
        }

    class Destytojai
    {
        private int CMaxi = 100;
        private Destytojas[] destytojai;
        private int n;
        private string pav;

        public Destytojai()
        {
            n = 0;
            destytojai = new Destytojas[CMaxi];
        }

        public Destytojas Imti(int i)
        {
            return destytojai[i];
        }

        public int Imti()
        {
            return n;
        }

        public void Deti(Destytojas ob)
        {
            destytojai[n++] = ob;
        }

        public Destytojai Rikiuoti()
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (destytojai[i].Mokkiekis >= max)
                {
                    max = destytojai[i].Mokkiekis;
                }
            }

            Destytojai Bdest = new Destytojai();
            for (int i = 0; i < n; i++)
            {
                if (max == destytojai[i].Mokkiekis)
                {
                    Bdest.Deti(destytojai[i]);
                }
            }

            for (int g = 0; g < Bdest.Imti(); g++)
            {
                for (int k = 0; k < Bdest.Imti(g).Modsk; k++)
                {
                    Bdest.Imti(g).MPavadinimas[k] = Bdest.Imti(g).MPavadinimas[k];
                }
            }
            return Bdest;
        }

        public Moduliai Rikiuotimod(Destytojai Bdest, int index, Moduliai mod)
        {
            Moduliai BMod = new Moduliai();
            for (int i = 0; i < Bdest.Imti(index).Modsk; i++) {
                for (int j = 0; j < mod.Imti(); j++)
                {
                    if (Bdest.Imti(index).MPavadinimas[i] == mod.Imti(j).MPavadinimas)
                    {
                        BMod.Deti(mod.Imti(j));
                    }
                }
                BMod.Rikiuoti();
            }
            return BMod;
        }
    }

        class Moduliai
        {
            private int CMaxi = 100;
            private Modulis[] moduliai;
            private int n;

            public Moduliai()
            {
                n = 0;
                moduliai = new Modulis[CMaxi];
            }

            public Modulis Imti(int i)
            {
                return moduliai[i];
            }

            public int Imti()
            {
                return n;
            }

            public void Deti(Modulis ob)
            {
                moduliai[n++] = ob;
            }

        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Modulis min = moduliai[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (moduliai[j] >= min)
                    {
                        min = moduliai[j];
                        im = j;
                    }
                moduliai[im] = moduliai[i];
                moduliai[i] = min;
            }
        }
    }

        class Grupes
        {
            const int CMaxi = 100;
            private Grupe[] grupe;
            private int n;

            public Grupes()
            {
                n = 0;
                grupe = new Grupe[CMaxi];
            }

            public Grupe Imti(int i)
            {
                return grupe[i];
            }

            public int Imti()
            {
                return n;
            }

            public void Deti(Grupe ob)
            {
                grupe[n++] = ob;
            }
        }

        class Konteineris
        {
            const int CMaxi = 100;
            private Studentas[] Studentai;
            private int n;
            private string pav;

            public Konteineris()
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


        class Program
        {
            static void Main(string[] args)
            {
                int n = 0;
            Destytojai BestD = new Destytojai();
                const string CFd = "...\\...\\Duom.txt";
                Grupes grupele = new Grupes();
                Destytojai dest = new Destytojai();
                Moduliai mod = new Moduliai();
                Konteineris kont = new Konteineris();

                Skaityti(ref n, CFd, ref kont);
                IGrupes(kont, grupele, n);
                IModulius(kont, dest, mod);
                IDestytojus(dest, mod);
                mod.Rikiuoti();
                BestD = dest.Rikiuoti();
                Spausdinu(dest, BestD, mod);
                
                
            }

            static int[] DaugiausiaiPasirinko(Destytojai dest)
            {
                int[] index = new int[100];
                int min = 0;
                int n = 0;
                for (int i = 0; i < dest.Imti(); i++)
                {
                    if (dest.Imti(i).Mokkiekis > min)
                    {
                        min = dest.Imti(i).Mokkiekis;
                    }
                }

                for (int i = 0; i < dest.Imti(); i++)
                {
                    if(min == dest.Imti(i).Mokkiekis)
                    {
                        index[n] = i;
                        n++;
                    }
                }
                return index;
            }

        static void Spausdinu(Destytojai dest, Destytojai BestD, Moduliai mod)
        {
            for (int i = 0; i < BestD.Imti(); i++)
            {
                Moduliai Bmod = new Moduliai();
                Bmod = BestD.Rikiuotimod(BestD, i, mod);
              Console.WriteLine(BestD.Imti(i).Dpavarde);
                for (int j = 0; j < BestD.Imti(i).Modsk; j++) {
                Console.WriteLine(BestD.Imti(i).Modsk);
                Console.WriteLine(Bmod.Imti(j).MPavadinimas);
                }
                }
            }
            static void AreAll(Destytojai BestD, Grupes grupele)
            {
            for (int j = 0; j < BestD.Imti(); j++)
            {

                for(int i = 0; i < grupele.Imti(); i++)
            {
                  /*  if ()
                    {

                    }*/
            }
            }
        }

            static void IGrupes(Konteineris kont, Grupes grupele, int n)
            {
                int poz;
                for (int i = 0; i < n; i++)
                {
                    poz = 0;

                    for (int j = 0; j < grupele.Imti(); j++)
                    {

                        if (kont.Imti(i).Grupe == grupele.Imti(j).Pavadinimas)
                        {
                            grupele.Imti(j).Kiekis++;
                            poz++;
                        }

                    }

                    if (poz == 0)
                    {
                        Grupe ob = new Grupe(kont.Imti(i).Grupe, 1);
                        grupele.Deti(ob);

                    }
                }
            }

            static void Nepasirinko(Destytojai Bdest)
            {
                
            }

            static void IModulius(Konteineris kont, Destytojai dest, Moduliai mod)
            {
                int poz;
                for (int i = 0; i < kont.Imti(); i++)
                {
                    poz = 0;
                    for (int j = 0; j < mod.Imti(); j++)
                    {

                        if (kont.Imti(i).MPavadinimas == mod.Imti(j).MPavadinimas)
                        {
                            mod.Imti(j).Credit += kont.Imti(i).Credit;
                            mod.Imti(j).Skiekis++;
                            poz++;
                        }

                    }

                    if (poz == 0)
                    {
                        Modulis ob = new Modulis(kont.Imti(i).MPavadinimas, kont.Imti(i).Dpavarde, kont.Imti(i).Dvardas, kont.Imti(i).Credit, 1);
                        mod.Deti(ob);
                    }
                }

            }

            static void IDestytojus(Destytojai dest, Moduliai mod)
            {
                int poz;
                for (int i = 0; i < mod.Imti(); i++)
                {
                    poz = 0;
                    for (int j = 0; j < dest.Imti(); j++)
                    {
                        if (mod.Imti(i).DPavarde == dest.Imti(j).Dpavarde)
                        {
                        dest.Imti(j).Modsk += 1;
                        dest.Imti(j).DetiM(dest.Imti(j).Modsk-1, mod.Imti(i).MPavadinimas);
                            dest.Imti(j).Credit += mod.Imti(i).Credit;
                            dest.Imti(j).Mokkiekis += mod.Imti(i).Skiekis;
                            poz++;
                        }

                    }


                    if (poz == 0)
                    {
                        string[] name = new string[100];
                        name[0] = mod.Imti(i).MPavadinimas;
                        int modsk = 1;
                        Destytojas ob = new Destytojas(modsk, name, mod.Imti(i).Skiekis, mod.Imti(i).DPavarde, mod.Imti(i).DVardas, mod.Imti(i).Credit);
                        dest.Deti(ob);

                    }
                }
        }

            static void Skaityti(ref int n, string fv, ref Konteineris kont)
            {
                string mpavadinimas, dpavarde, dvardas, grupe, svardas, spavarde;
                double credit;

                string line;
                using (StreamReader reader = new StreamReader(fv))
                {
                    n = int.Parse(reader.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        line = reader.ReadLine();
                        string[] parts = line.Split(' ');
                        mpavadinimas = parts[0];
                        dpavarde = parts[1];
                        dvardas = parts[2];
                        credit = double.Parse(parts[3]);
                        spavarde = parts[4];
                        svardas = parts[5];
                        grupe = parts[6];

                        Studentas ob = new Studentas(mpavadinimas, dpavarde, dvardas, credit, spavarde, svardas, grupe);
                        kont.Deti(ob);
                    }
                }

            }
        }
    }
