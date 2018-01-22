using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Knyga:IComparable<Knyga>
    {
        public int isbn { set; get; }
        public int psl { set; get; }
        public string pav { set; get; }
        public string autor { set; get; }
        public double metai { set; get; }

        public Knyga() { }

        public Knyga(int isbn, string pav, string autor, double metai, int psl)
        {
            this.isbn = isbn;
            this.pav = pav;
            this.autor = autor;
            this.metai = metai;
            this.psl = psl;
        }

        public int CompareTo(Knyga kita)
        {
            if ((this.psl > kita.psl) || ((this.psl == kita.psl) && (this.metai > kita.metai) || (this.metai == kita.metai)))
                return 1;
            else
                return -1;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("| {0, -5}|{1, -35}|{2, -32}| {3, 5} |{4, 11}   |", isbn, pav, autor, metai, psl);
            return eilute;
        }
    }
}
