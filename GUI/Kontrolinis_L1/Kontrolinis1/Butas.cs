using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrolinis1
{
    class Butas
    {
        public int nr { get; set; }
        public string sav { get; set; }
        public DateTime date { get; set; }
        public double mokestisd { get; set; }
        public double mokestisl { get; set; }


        public Butas(int nr, string sav, DateTime date, double mokestisd, double mokestisl)
        {
            nr = this.nr;
            sav = this.sav;
            date = this.date;
            mokestisd = this.mokestisd;
            mokestisl = this.mokestisl;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0}     {1}     {2}     {3}     {4}", nr, sav, date, mokestisd, mokestisl);
            return eilute;
        }

        public static bool operator >=(Butas b1, Butas b2)
        {
            if (b1.mokestisd != b2.mokestisd)
            {
                return b1.mokestisd >= b2.mokestisd;
            }else
            {
                return b1.nr <= b2.nr;
            }
        }

        public static bool operator <=(Butas b1, Butas b2)
        {
            if (b1.mokestisd != b2.mokestisd)
            {
                return b1.mokestisd <= b2.mokestisd;
            }else
            {
                return b1.nr >= b2.nr;
            }
        }
    }
}
