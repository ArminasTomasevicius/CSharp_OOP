using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_Savarankiskas
{
    class Studentas
    {
            public string PavVrd { get; set; } // savybė: studento pavardė ir vardas
            public int Pazym { get; set; } // savybė: pažymys (įvertinimas)
                                           /// <summary>
                                           /// Klasės konstruktorius: savybėms suteikia reikšmes
                                           /// </summary>
                                           /// <param name="pavv"> pavardė ir vardas </param>
                                           /// <param name="pazym"> pažymys </param>
            public Studentas(string pavv, int pazym)
            {
                PavVrd = pavv;
                Pazym = pazym;
            }
            /// <summary>
            /// Užklotas metodas ToString()
            /// </summary>
            /// <returns> grąžina suformatuotą eilutę </returns>
            public override string ToString()
            {
                string eilute;
                eilute = string.Format("{0, -20} {1, 2}", PavVrd, Pazym);

                return eilute;
            }
        }
    }
