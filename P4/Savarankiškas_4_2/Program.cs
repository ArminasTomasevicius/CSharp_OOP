using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_4_2
{
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

    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Skaityti(ref Sodas sodas, string fv)
        {
            int koef1, koef2, kiek, priaug, n;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    koef1 = int.Parse(parts[0]);
                    koef2 = int.Parse(parts[1]);
                    kiek = int.Parse(parts[2]);
                    priaug = int.Parse(parts[3]);
                    Obelis ob = new Obelis(kiek, priaug, koef1, koef2);
                    sodas.Dėti(ob);
                }
            }
        }
    }
}
