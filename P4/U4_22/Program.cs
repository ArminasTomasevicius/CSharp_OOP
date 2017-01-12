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
        private int mkiekis;

        public Destytojas(string[] mpavadinimas, int mkiekis, string dpavarde, string dvardas, double credit)
        {
            this.dpavarde = dpavarde;
            this.dvardas = dvardas;
            this.credit = credit;
            mpavadinimas = new string[100];
            for (int i = 0; i < mkiekis; i++)
            {
                this.mpavadinimas[i] = mpavadinimas[i];
            }
        }

        public string[] MPavadinimas
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
    }

    class Modulis
    {
        private string mpavadinimas, dpavarde, dvardas;
        private double credit, skiekis;

        public Modulis(string mpavadinimas, string dpavarde, string dvardas, double credit, double skiekis)
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

        public double Skiekis
        {
            set { skiekis = value; }
            get { return skiekis; }
        }

    }

    class Grupe
    {
        private string pavadinimas;
        private string s;
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
    }

    class Moduliai
    {
        private int CMaxi = 100;
        private Studentas[] studentai;
        private int n;
        private string pav;

        public Moduliai()
        {
            n = 0;
            studentai = new Studentas[CMaxi];
        }

        public Studentas Imti(int i)
        {
            return studentai[i];
        }

        public int Imti()
        {
            return n;
        }

        public void Deti(Studentas ob)
        {
            studentai[n++] = ob;
        }
    }

    class Grupes
    {
        const int CMaxi = 100;
        private Studentas[] Studentai;
        private int n;
        private string pav;

        public Grupes()
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
            const string CFd = "...\\...\\Duom.txt";
            Grupes grupele = new Grupes();
            Destytojai dest = new Destytojai();
            Moduliai mod = new Moduliai();
            Konteineris kont = new Konteineris();

            Skaityti(ref n, CFd, ref kont);
            
    }

        static void DaugiausiaiPasirinko()
        {

        }

        static void AreAll()
        {

        }

        static void IGrupes(Konteineris kont, Grupes grupele, int n)
        {
            double suma;
            int poz;
            for (int i = 0; i < n; i++)
            {
                poz = 0;
                suma = 0;

                for (int j = 0; j < kont.Imti(); j++)
                {

                    if (kont.Imti(j).Grupe == grupele.Imti(i).Grupe)
                    {

                        grupele.Deti(kont.Imti(i));
                        Console.WriteLine(kont.Imti(i).Grupe);
                        poz++;
                        Console.WriteLine("Add");
                        poz++;
                    }

                }

                if (poz == 0)
                {
                    Grupe ob = new Grupe();  //ideda ir nekeicia
                    grupele.Deti(ob);
                    Console.WriteLine("Create");

                }
            }
        }

        static void Nepasirinko()
        {

        }

        static void IModulius(Grupes grupele, Destytojai dest, )
        {
            for ()
            {

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
