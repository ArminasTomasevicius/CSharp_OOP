using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4
{
    public class Mobilus
    { // mobiliosios elektronikos įrenginys
        public string modelis { get; set; } // modelio pavadinimas
        public string tipas { get; set; } // įrenginio tipas
        public int baterija { get; set; } // baterijos veikimo trukmė

        // konstruktorius
        public Mobilus(string modelis = "", string tipas = "", int baterija = 0)
        {
            this.modelis = modelis;
            this.tipas = tipas;
            this.baterija = baterija;
        }
        // objekto naujos reikšmės
        // a – modelio pavadinimas
        // b – įrenginio tipas
        // c – baterijos veikimo trukmė
        public void Dėti(string a, string b, int c)
        {
            modelis = a;
            tipas = b;
            baterija = c;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0, -30}| {1, -20} | {2, 8:f} |",
            modelis, tipas, baterija);
            return eilute;
        }
        public override bool Equals(object objektas)
        {
            Mobilus telef = objektas as Mobilus;
            return telef.tipas == tipas && telef.modelis == modelis && telef.baterija == baterija;
        }

        // Užklotas metodas GetHashCode()

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Užklotas operatorius >= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę
        // ir modelio pavadinimą)

        public static bool operator >= (Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.modelis, antras.modelis, StringComparison.CurrentCulture);
            return pirmas.baterija > antras.baterija || pirmas.baterija == antras.baterija && poz > 0;
        }
        // Užklotas operatorius <= (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę
        // ir modelio pavadinimą)

        public static bool operator <=(Mobilus pirmas, Mobilus antras)
        {
            int poz = String.Compare(pirmas.modelis, antras.modelis, StringComparison.CurrentCulture);
            return pirmas.baterija < antras.baterija || pirmas.baterija == antras.baterija && poz < 0;
        }
        // Užklotas operatorius == (įrenginių tipui palyginti)
        public static bool operator ==(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.tipas == antras.tipas;
        }
        // Užklotas operatorius != (įrenginių tipui palyginti)
        public static bool operator !=(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.tipas != antras.tipas;
        }
        // Užklotas operatorius > (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)

        public static bool operator >(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.baterija > antras.baterija;
        }
        // Užklotas operatorius < (dviejų įrenginių palyginimui pagal baterijos veikimo trukmę)
        public static bool operator <(Mobilus pirmas, Mobilus antras)
        {
            return pirmas.baterija < antras.baterija;
        }
    }
}
