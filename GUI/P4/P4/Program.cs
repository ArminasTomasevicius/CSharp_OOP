using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4
{
    class Program
    {
        const string CFd1 = "..\\..\\Mikas.txt";
        const string CFd2 = "..\\..\\Darius.txt";
        const string CFd3 = "..\\..\\Rimas.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Studentas A, // pirmojo studento duomenys
            B; // antrojo studento duomenys
            A = SkaitytiAtv(CFd1);
            B = SkaitytiAtv(CFd2);
            if (File.Exists(CFr))
                File.Delete(CFr);
            Spausdinti(CFr, A, A.pv);
            Spausdinti(CFr, B, B.pv);

            using (var failas = new StreamWriter(CFr, true))
            {
                Mobilus max;
                max = A.MaxTrukmė();
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n modelis: " +
                "{1}, tipas: {2}, trukmė: {3}.",

                A.pv, max.modelis, max.tipas, max.baterija);

                failas.WriteLine();
                max = B.MaxTrukmė();
                failas.WriteLine("Studentas: {0}, ilgiausiai veikianti baterija \r\n modelis: " +
                " {1}, tipas: {2}, trukmė: {3}.",

                B.pv, max.modelis, max.tipas, max.baterija);

            }

            // --- Nurodyto tipo įrenginių atrinkimas ---
            Studentas Naujas = new Studentas(); // atrinkti duomenys
            Console.WriteLine("Įveskite norimą įrenginio tipą:");
            string tipas = Console.ReadLine(); // Įvedamas norimas įrenginio tipas
            Atrinkti(A, tipas, Naujas);
            Atrinkti(B, tipas, Naujas);
            // --- Suformuoto sąrašo spausdinimas ir rikiavimas ---
            Naujas.Pradžia();
            if (Naujas.Yra())
            {
                Spausdinti(CFr, Naujas, "Atrinkti nerikiuoti");
                Naujas.Rikiuoti();
                Spausdinti(CFr, Naujas, "Atrinkti surikiuoti");
            }
            else
            {
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas nesudarytas.");
                }
            }

            Studentas C; // trečio studento duomenys
            C = SkaitytiAtv(CFd3);
            Spausdinti(CFr, C, C.pv);
            Atrinkti_Į_Rikiuotą(C, tipas, Naujas);
            Naujas.Pradžia();
            if (Naujas.Yra())
                Spausdinti(CFr, Naujas, "Rikiuotas po papildymo");
            else
                using (var failas = new StreamWriter(CFr, true))
                {
                    failas.WriteLine("Naujas sąrašas liko nesudarytas.");
                }
        }

        // Iš sąrašo senas kopijuoja objektus į sąrašą naujas
        // senas įrenginių sąrašas
        // tipas atrenkamų įrenginių tipas
        // naujas naujo objektų sąrašo adresas
        static void Atrinkti_Į_Rikiuotą(Studentas senas, string tipas, Studentas naujas)
        {
            for (senas.Pradžia(); senas.Yra(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.tipas == tipas)
                    naujas.Įterpti(duom);
            }
        }

        // Skaitomi duomenys iš failo ir sudedami į sąrašą ATVIRKŠTINE tvarka

        // fv – duomenų failo vardas

        static Studentas SkaitytiAtv(string fv)
        {
            var A = new Studentas();
            using (var failas = new StreamReader(fv))
            {
                string eilute;
                A.pv = eilute = failas.ReadLine();
                while ((eilute = failas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string modelis = eilDalis[0];
                    string tipas = eilDalis[1];
                    int baterija = int.Parse(eilDalis[2]);
                    Mobilus elem = new Mobilus(modelis, tipas, baterija);
                    A.DėtiDuomenisA(elem);
                }
            }
            return A;
        }

        // Sąrašo duomenys spausdinami faile
        // fv – duomenų failo vardas
        // A - sąrašo objekto nuoroda
        // koment - komentaras

        static void Spausdinti(string fv, Studentas A, string koment)
        {
            using (var failas = new StreamWriter(fv, true))
            {
                failas.WriteLine(koment);
                failas.WriteLine("+------------------------------+---------------" +
                "-------+--------------+");
                failas.WriteLine("| Modelis | Tipas " +
                " | Veik. trukmė |");
                failas.WriteLine("+------------------------------+---------------" +
                "-------+--------------+");
                // Sąrašo peržiūra, panaudojant sąsajos metodus
                for (A.Pradžia(); A.Yra(); A.Kitas())
                {
                    failas.WriteLine("{0}", A.ImtiDuomenis().ToString());
                }
                failas.WriteLine("+------------------------------+---------------" +
                "-------+--------------+");
                failas.WriteLine();
            }
        }

        // Iš sąrašo senas kopijuoja objektus į sąrašą naujas
        // senas įrenginių sąrašas
        // tipas atrenkamų įrenginių tipas
        // naujas naujo objektų sąrašo adresas
        static void Atrinkti(Studentas senas, string tipas, Studentas naujas)
        {
            for (senas.Pradžia(); senas.Yra(); senas.Kitas())
            {
                Mobilus duom = senas.ImtiDuomenis();
                if (duom.tipas == tipas)
                    naujas.Papildyti(duom);
            }
        }

    }
}
