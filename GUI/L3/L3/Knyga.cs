using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Knyga:IComparable<Knyga>
    {
        private int isbn, psl;
        private string pav, autor, type, leidykla;
        private DateTime metai;

        public Knyga(int isbn, string pav, string autor, string type, string leidykla, DateTime metai, int psl)
        {
            this.isbn = isbn;
            this.pav = pav;
            this.autor = autor;
            this.type = type;
            this.leidykla = leidykla;
            this.metai = metai;
            this.psl = psl;
        }

        public int CompareTo(Knyga kita)
        {
            return 0;
        }
    }
}
