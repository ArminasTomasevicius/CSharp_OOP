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
        private string mpavadinimas, dpavarde, dvardas, grupe, svardas, spavarde;
        private double credit;

        public Destytojas(string mpavadinimas, string dpavarde, string dvardas, double credit)
        {
            this.mpavadinimas = mpavadinimas;
            this.dpavarde = dpavarde;
            this.dvardas = dvardas;
            this.credit = credit;
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

        public Destytojai Imti(int i)
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

    class Grupe
    {
        const int CMaxi = 100;
        private Studentas[] Studentai;
        private int n;
        private string pav;

        public Grupe()
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
            Grupe grupele = new Grupe();
            Destytojai dest = new Destytojai();
            Moduliai mod = new Moduliai();

            Skaityti(ref n, CFd, ref grupele, ref mod);

            double suma = 0;
            int kiekis = 1;

            for (int i = 0; i < n; i++)
            {
                int poz = 0;

                suma += grupele.Imti(i).Credit;

                for (int j = 0; j < grupele.Imti(); j++)
                {

                    if (grupele.Imti(j).Pavadinimas == grupele.Imti(i).Grupe)
                    {
                        grupele.Imti(j).Kiekis++;
                        Console.WriteLine(grupele.Imti(j).Kiekis);
                        grupele.Imti(j).Suma += suma;
                        poz++;
                    }
                }

                if (poz == 0)
                {
                    grupele ob = new grupele(grupele.Imti(i).Grupe, kiekis, suma);
                    grupele.Deti(ob);
                    Console.WriteLine("Create");
                }
            }

        }

        static void Skaityti(ref int n, string fv, ref Grupe grupele, ref Moduliai mod)
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
                    grupele.Deti(ob);
                   // mod.Deti(ob);
                }

            }
        }
    }
}
