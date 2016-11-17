using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_4_2
{
    //reikia studentu ir grupiu ir kiekvienam po konteineri
    class Studentas
    {
        private string pavarde;
        private string vardas;
        private string grupe;
        private int pkiekis;
        private int[] pazymiai;

        public Studentas(string pavarde, string vardas, string grupe, int pkiekis, int[] pazymiai)
        {
            this.pavarde = pavarde;
            this.vardas = vardas;
            this.grupe = grupe;
            this.pkiekis = pkiekis;
            this.pazymiai = pazymiai;
        }

        public string Pavarde
        {
            set{ value = pavarde; }
            get{ return pavarde; }
        }

        public string Vardas
        {
            set { value = vardas; }
            get { return vardas; }
        }

        public string Grupe
        {
            set { value = grupe; }
            get { return grupe; }
        }

        public int Pkiekis
        {
            set { value = pkiekis; }
            get { return pkiekis; }
        }

        public int[] Pazymiai
        {
            set { value = pazymiai; }
            get { return pazymiai; }
        }
    }

    class Grupe
    {
        const int CMaxi = 100;
        private Studentas[] Studentai;
        private int n;

        public Grupe()
        {
            n = 0;
            Studentai = new Studentas[CMaxi];
        }

        public Studentas Imti(int i) { return Studentai[i]; }

        public int Imti()
        {
            return n;
        }

        public void Deti(Studentas ob)
        {
            Studentai[n++] = ob;
        }
}

    class Facult
    {
        const int CMaxi = 100;
        private Grupe[] Grupes;
        private int n;

        public Facult()
        {
            n = 0;
            Grupes = new Grupe[CMaxi];
        }

        public Grupe Imti(int i) { return Grupes[i]; }

        public int Imti()
        {
            return n;
        }

        public void Deti(Grupe ob)
        {
            Grupes[n++] = ob;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Grupe grupele = new Grupe();
            const string CFd = "...\\...\\Duom.txt";
            Skaityti(ref n, CFd,ref grupele);

            for (int i = 0; i < n; i++)
            {
                int poz = 0;
                for(int j = 0; j < grupele.Imti(); j++)
                {
                    if (grupele.Imti())
                    {

                    }poz = 1;
                    break;
                }
            }
        }

        static void Skaityti(ref int n, string fv, ref Grupe grupele)
        {
            int pkiekis;
            int[] paz = new int[100];
            string pavadinimas, pavarde, vardas, grupe;
            string line;
            using (StreamReader reader = new StreamReader(fv))
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
                        paz[j] = int.Parse(parts[j+3]);
                    }
                    Studentas ob = new Studentas(vardas, pavarde, grupe, pkiekis, paz);
                    grupele.Deti(ob);
                }

            }
        }
    }
}
