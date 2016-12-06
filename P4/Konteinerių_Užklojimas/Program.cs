using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorių_Užklojimas_Konteineryje
{
    class Studentas
    {
        private string pavardė,
                        vardas,
                         grupė;
        private ArrayList paž;


        public Studentas()
        {
            pavardė = "";
            vardas = "";
            grupė = "";
            paž = new ArrayList();
        }

        public void Dėti(string pav, string vard, string grup, ArrayList pž)
        {
            pavardė = pav;
            vardas = vard;
            grupė = grup;
            foreach (int sk in pž)
                paž.Add(sk);
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7}", pavardė, vardas, grupė);
            foreach (int sk in paž)
                eilute = eilute + string.Format("{0, 3:d}", sk);
            return eilute;
        }

        public static bool operator !(Studentas c1)
        {
            foreach (int sk in c1.paž)
            {
                if (sk < 9)
                    return true;
            }
            return false;
        }

        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }

        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int p = String.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }
    }

    class Fakultetas
    {
        const int CMax = 100;
        private Studentas[] St;
        private int n;
        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }
        public int Imti() { return n; }

        public Studentas Imti(int i) { return St[i]; }

        public void Dėti(Studentas ob) { St[n++] = ob; }

        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    {
                        min = St[j];
                        im = j;
                    }
                St[im] = St[i];
                St[i] = min;
            }
        }
    }

    class Program
    {
        const string CFd = "..\\..\\U1.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Fakultetas grupes = new Fakultetas();
            Fakultetas grupes1 = new Fakultetas();
            if (File.Exists(CFr)) File.Delete(CFr);
            Skaityti(ref grupes, CFd);
            Spausdinti(grupes, CFr, " Pradinis studentų sąrašas");
            Formuoti(grupes, ref grupes1);
            if (grupes1.Imti() > 0)
                Spausdinti(grupes1, CFr, " Naujas studentų sąrašas");
            else
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Tokių studentų nėra");
                }
        }

        static void Skaityti(ref Fakultetas grupe, string fv)
        {
            string pv, vrd, grp;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pv = parts[0].Trim();
                vrd = parts[1].Trim();
                grp = parts[2].Trim();
                string[] eil = parts[3].Trim().Split(new[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries);
                pz.Clear();
                foreach (string eilute in eil)
                {
                    int aa = int.Parse(eilute);
                    pz.Add(aa);

                }
                Studentas stud = new Studentas();
                stud.Dėti(pv, vrd, grp, pz);
                grupe.Dėti(stud);
            }
        }

        static void Spausdinti(Fakultetas grupe, string fv, string antraštė)
        {
            string virsus = "------------------------------------------\r\n" + " Pavardė    Vardas     Grupė    Pažymiai  \r\n" + "------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraštė);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0}", grupe.Imti(i).ToString());
                fr.WriteLine("------------------------------------------\r\n");
            }
        }

        static void Formuoti(Fakultetas D, ref Fakultetas R)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Dėti(D.Imti(i));
        }
    }
}
