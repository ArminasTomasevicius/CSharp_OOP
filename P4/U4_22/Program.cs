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
        private string dpavarde, dvardas, grupe, svardas, spavarde;
        private string[] mpavadinimas;
        private double credit;
        private int mokkiekis, modsk;

        public Destytojas(int modsk, string[] mpavadinimas, int mokkiekis, string dpavarde, string dvardas, double credit)
        {
            this.dpavarde = dpavarde;
            this.dvardas = dvardas;
            this.credit = credit;
            this.modsk = modsk;
            mpavadinimas = new string[100];
            for (int i = 1; i < modsk; i++)
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

            public static bool operator >=(Facult m1, Facult m2)
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

            public void Rikiuoti()
            {
                for (int i = 0; i < n - 1; i++)
                {
                    Destytojas min = destytojai[i];
                    int im = i;
                    for (int j = i + 1; j < n; j++)
                        if (destytojai[j] >= min)
                        {
                            min = destytojai[j];
                            im = j;
                        }
                    destytojai[im] = destytojai[i];
                    destytojai[i] = min;
                }
            }
        }

        class Moduliai
        {
            private int CMaxi = 100;
            private Modulis[] moduliai;
            private int n;
            private string pav;

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
                int[] BestD = new int[100];
                const string CFd = "...\\...\\Duom.txt";
                Grupes grupele = new Grupes();
                Destytojai dest = new Destytojai();
                Moduliai mod = new Moduliai();
                Konteineris kont = new Konteineris();

                Skaityti(ref n, CFd, ref kont);
                IGrupes(kont, grupele, n);
                IModulius(kont, dest, mod);
                IDestytojus(dest, mod);
                BestD = DaugiausiaiPasirinko(dest);
                Rikiuoju(dest, BestD);
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

            static void Rikiuoju(Destytojai dest, int[] BestD)
            {

            }

            static void AreAll()
            {

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
                            Console.WriteLine(kont.Imti(j).Grupe);
                            poz++;
                            Console.WriteLine("Add");
                        }

                    }

                    if (poz == 0)
                    {
                        Grupe ob = new Grupe(kont.Imti(i).Grupe, 0);
                        grupele.Deti(ob);
                        Console.WriteLine("Create");

                    }
                }
            }

            static void Nepasirinko()
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
                            Console.WriteLine(mod.Imti(j).MPavadinimas);
                            poz++;
                            Console.WriteLine("MAdd");
                        }

                    }

                    if (poz == 0)
                    {
                        Modulis ob = new Modulis(kont.Imti(i).MPavadinimas, kont.Imti(i).Dpavarde, kont.Imti(i).Dpavarde, kont.Imti(i).Credit, 1);
                        mod.Deti(ob);
                        Console.WriteLine("MCreate");

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

                        if ((mod.Imti(i).DVardas == dest.Imti(j).Dvardas) && (mod.Imti(i).DPavarde == dest.Imti(j).Dpavarde))
                        {
                            dest.Imti(j).Credit += mod.Imti(i).Credit;
                            dest.Imti(j).Mokkiekis += mod.Imti(j).Skiekis;
                            dest.Imti(j).Modsk++;
                            Console.WriteLine(dest.Imti(j).MPavadinimas[0]);
                            poz++;
                            Console.WriteLine("DAdd");
                        }

                    }

                    if (poz == 0)
                    {
                        string[] name = new string[100];
                        name[1] = mod.Imti(i).MPavadinimas;
      
                        Destytojas ob = new Destytojas(1, name, mod.Imti(i).Skiekis, mod.Imti(i).DVardas, mod.Imti(i).DPavarde, mod.Imti(i).Credit);
                        dest.Deti(ob);
                        Console.WriteLine("DCreate");

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
}
