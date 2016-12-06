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

    class Destytojai
    {
        private int CMaxi = 100;
        private Modulis[] moduliai;
        private int n;
        private string pav;

        public Destytojai()
        {
            n = 0;
            moduliai = new Modulis[CMaxi];
        }

        public Studentas Imti(int i)
        {
            return moduliai[i];
        }

        public int Imti()
        {
            return n;
        }

        public void Deti(Studentas ob)
        {
            moduliai[n++] = ob;
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
            modulia = new Modulis[CMaxi];
        }

        public Studentas Imti(int i)
        {
            return moduliai[i];
        }

        public int Imti()
        {
            return n;
        }

        public void Deti(Studentas ob)
        {
            moduliai[n++] = ob;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Skaityti(ref int n, string fv, ref Grupe grupele)
        {
           string mpavadinimas, dpavarde, dvardas, grupe, svardas, spavarde;
           double credit;

        string line;
        /*    using (StreamReader reader = new StreamReader(fv))
            { */
                while ((line = File.ReadLine()) != null)
                {
                    pavadinimas = reader.ReadLine();
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    vardas = parts[0];
                    pavarde = parts[1];
                    grupe = parts[2];
                    pkiekis = int.Parse(parts[3]);

                    for (int j = 0; j < pkiekis; j++)
                    {
                        paz[j] = int.Parse(parts[j + 3]);
                    }
                    Studentas ob = new Studentas(mpavadinimas, dpavarde, dvardas, credit, spavarde, svardas, grupe);
                    grupele.Deti(ob);
                }

            }
        }
    }
}
