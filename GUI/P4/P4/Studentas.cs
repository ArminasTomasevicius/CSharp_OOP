using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4
{
    public sealed class Studentas
    {
        public string pv { get; set; } // studento pavardė ir vardas
        Mazgas pr; // sąrašo pradžios nuoroda
        Mazgas d; // sąsajos nuoroda
                  // Konstruktorius be parametrų
        public Studentas()
        {
            this.pr = null;
            this.d = null;
        }
        // Sąsajos metodai
        // Sąsajai priskiriama sąrašo pradžia
        public void Pradžia()
        {
            d = pr;
        }

        // Sąsajai priskiriamas sąrašo sekantis elementas
        public void Kitas()
        {
            d = d.Kitas;
        }
        // Grąžina true, jeigu sąsaja netuščia; false - priešingu atveju
        public bool Yra()
        {
            return d != null;
        }
        // Grąžina pagalbinės rodyklės rodomo elemento reikšmę
        public Mobilus ImtiDuomenis() { return d.Duomenys; }
        // Sukuriamas sąrašo elementas ir prijungiamas prie sąrašo PRADŽIOS
        // inf – naujo elemento reikšmė (duomenys)
        public void DėtiDuomenisA(Mobilus inf)
        {
            var d = new Mazgas(inf, null);
            d.Kitas = pr;
            pr = d;
            // arba
            //pr = new Mazgas(inf, pr);
        }
        // Sunaikinamas sąrašas
        public void Naikinti()
        {
            while (pr != null)
            {
                d = pr;
                // sąrašo elementų duomenų dalyje yra nuoroda į objektą,
                // ten taip pat reikėtų įrašyti reikšmę null.
                // pr.Duomenys = null;
                pr = pr.Kitas;
                d = null;
            }
            d = pr;
        }

        // Rikiavimas išrinkimo būdu
        public void Rikiuoti()
        {
            for (Mazgas d1 = pr;
                d1.Kitas != null; d1 = d1.Kitas)
            {
                Mazgas maxv = d1;
                for (Mazgas d2 = d1; d2 != null; d2 = d2.Kitas)
                    if (d2.Duomenys <= maxv.Duomenys)
                        maxv = d2;
                Mobilus St = d1.Duomenys;
                d1.Duomenys = maxv.Duomenys;
                maxv.Duomenys = St;
            }
        }

        // Suranda ir grąžina ilgiausiai veikiančio įrenginio duomenis
        public Mobilus MaxTrukmė()
        {
            Mobilus max;
            max = pr.Duomenys;
            for (Mazgas d1 = pr; d1 != null; d1 = d1.Kitas)
                if (d1.Duomenys > max)
                    max = d1.Duomenys;
            return max;
        }

        // Į sąrašo pradžią įterpia naują elementą ir įrašo į jį duom
        // duom – įrenginių sąrašas papildomas nauju objektu
        public void Papildyti(Mobilus duom)
        {
            Mazgas d1 = new Mazgas();
            d1.Duomenys = duom;
            d1.Kitas = pr;       
            pr = d1;
        }

        // Ieškoma naujo elemento įterpimo vieta.
        // Vieta objektui duom ieškoma, naudojant rikiavimui sukurtu operatoriumi
        // duom – objektas
        private Mazgas Vieta(Mobilus duom)
        {
            Mazgas dd = pr;
            while (dd != null && dd.Kitas != null && duom >= dd.Kitas.Duomenys)
                dd = dd.Kitas;
            return dd;
        }

        // Suranda vietą, kurioje reikia įterpti naują elementą ir įterpia
        // duom – objektas papildymui

        public void Įterpti(Mobilus duom)
        {
            Mazgas d = new Mazgas();
            d.Duomenys = duom;
            d.Kitas = null;
            if (pr == null) pr = d; // jei sąrašas tuščias
            else
            if (pr.Duomenys >= duom)
            { 
                // jeigu elementą reikia sukurti sąrašo pradžioje        
                d.Kitas = pr;
                pr = d;
            }
            else
            { // jeigu elementą reikia įterpti sąraše
              // randama įterpimo vieta – elementas, už kurio reikia įterpti
                Mazgas dd = Vieta(duom);
                d.Kitas = dd.Kitas; // naujas elementas įterpiamas už surasto elemento
                dd.Kitas = d;
            }
        }
    }
}
