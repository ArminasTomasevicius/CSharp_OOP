using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    abstract public class Preke:IComparable<Preke>
    {
        public string pavadinimas { get; set; }
        public string tipas { get; set; }
        public double kaina { get; set; }
        public Preke() { }

        public Preke(string pavadinimas = "", string tipas = "", double kaina = 0.0)
        {
            this.pavadinimas = pavadinimas;
            this.tipas = tipas;
            this.kaina = kaina;
        }

        abstract public double Suma();

        abstract public void Padidinti();

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("  {0, -16}     {1, -20} {2, 5:f}", pavadinimas, tipas, kaina);
            return eilute;
        }

        public int CompareTo(Preke kita)
        {
            int poz = String.Compare(this.pavadinimas, kita.pavadinimas, StringComparison.CurrentCulture);
            if ((this.kaina < kita.kaina) || ((this.kaina == kita.kaina) && (poz > 0)))
                return 1;
            else
                return -1;
        }
    }
}
