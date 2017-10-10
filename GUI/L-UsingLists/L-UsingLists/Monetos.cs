using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L
{
    class Monetos
    {
        const int Cn = 500;
        private Moneta[] moneta;
        public int Kiek { get; set; }
        public string Pav { get; set; }

        public Monetos()
        {
            Kiek = 0;
            moneta = new Moneta[Cn];
        }

        public Moneta ImtiMoneta(int i)
        {
            return moneta[i];
        }

        public void DetiMoneta(Moneta Moneta)
        {
            moneta[Kiek++] = Moneta;
        }

        public void DetiTiksliai(Moneta moneta, int index)
        {
            this.moneta[index] = moneta;
        }
    }
}
