using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_22
{
    class Studentas
    {
        private string mpavadinimas, dpavarde, vardas, pbank;
        private double snr, dindel;

        public Studentas(string mpavadinimas, string dpavarde, string vardas, string pbank, double snr, double dindel)
        {
            this.mpavadinimas = mpavadinimas;
            this.dpavarde = dpavarde;
            this.vardas = vardas;
            this.pbank = pbank;
            this.snr = snr;
            this.dindel = dindel;
        }

        public string MPavadinimas
        {
            set { mpavadinimas = value; }
            get { return mpavadinimas; }
        }

        public string Dpavarde
        {
            set { dpavarde = value; }
            get { return dpavarde; }
        }

        public string Vardas
        {
            set { vardas = value; }
            get { return vardas; }
        }

        public string Pbank
        {
            set { pbank = value; }
            get { return pbank; }
        }

        public double Snr
        {
            set { snr = value; }
            get { return snr; }
        }

        public double Dindel
        {
            set { dindel = value; }
            get { return dindel; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
