using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L
{
    class Moneta
    {
            public string Salis { get; set; }
            public int Nominalas { get; set; }
            public int Svoris { get; set;  }

            public Moneta(string salis, int nominalas, int svoris)
            {
                Salis = salis;
                Nominalas = nominalas;
                Svoris = svoris;
            }

            public override string ToString()
            {
                string eilute;
                eilute = string.Format("{0, -20}     {1, 2}     {2, 2}", Salis, Nominalas, Svoris);
                return eilute;
            }
    }
}
