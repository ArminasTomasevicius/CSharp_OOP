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

        public void Apkeisti(Moneta moneta1, Moneta moneta2)
        {
            string salis = moneta2.Salis;
            int nominalas = moneta2.Nominalas;
            int svoris = moneta2.Svoris;

            moneta1.Salis = salis;
            moneta1.Nominalas = nominalas;
            moneta1.Svoris = svoris;
        }

        public void Apkeisti(int moneta1, int moneta2) {
            var tmp = moneta[moneta1];
            moneta[moneta1] = moneta[moneta2];
            moneta[moneta2] = tmp;
        }
    }
}
