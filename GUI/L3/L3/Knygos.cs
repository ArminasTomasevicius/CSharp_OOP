using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Knygos : Knyga
    {
        public string Leidykla { set; get; }
        public string Type { set; get; }

        public Knygos(){}

        public Knygos(int isbn = 0, string pav = "", string autor = "", string Type = "", string Leidykla = "", double metai = 0, int psl = 0)
            : base(isbn, pav, autor, metai, psl)
        {
            this.Leidykla = Leidykla;
            this.Type = Type;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1, 16}| {2, 19}|", base.ToString(), Type, Leidykla);
            return eilute;
        }
    }
}
