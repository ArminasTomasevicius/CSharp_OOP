using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Savarankiskas
{
    class Pazymys
    {
        /// <summary>
        /// Klasė vieno studento duomenims saugoti
        /// </summary>
        public int Pazym { get; set; } // savybė: pažymys (skaičius: 1..10)
        public string PazZodR { get; set; } // savybė: pažymio žodinė reikšmė
                                            /// Klasės konstruktorius: savybėms suteikia reikšmes.
                                            /// </summary>
                                            /// <param name="paz"> pažymys </param>
                                            /// <param name="pazR"> pažymio žodinė reikšmė </param>
        public Pazymys(int paz, string pazR)
        {
            Pazym = paz;
            PazZodR = pazR;
        }
        /// <summary>
        /// Užklotas metodas ToString()
        /// </summary>
        /// <returns> grąžina suformatuotą eilutę </returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, 2:d} {1, -15}", Pazym, PazZodR);
            return eilute;
        }
    }
}
