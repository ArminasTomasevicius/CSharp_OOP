using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{

    class RaidziuDazniai
    {
        private const int CMax = 2560;
        private int[] Rn;  // raidžių pasikartojimai
        private int[] Rnlt;
        public char[] lt = {'ą', 'č', 'ę', 'ė', 'į', 'š', 'ų', 'ū', 'ž'};
        public char[] ltd = { 'Ą', 'Č', 'Ę', 'Ė', 'Į', 'Š', 'Ų', 'Ū', 'Ž'};
        public string eil { get; set; }
        public RaidziuDazniai()
        {
            eil = "";
            
            Rn = new int[CMax];
            for (int i = 0; i < CMax; i++)
                Rn[i] = 0;

            Rnlt = new int[CMax];
            for (int i = 0; i < CMax; i++)
                Rnlt[i] = 0;
        }

        public int Imti(char sim)
        {
            return Rn[sim];
        }               
        
        public int ImtiLt(char sim)
        {
            return Rnlt[sim];
        } 
         
        public void kiek()
        {
            for (int i = 0; i < eil.Length; i++)
            {
                if (('a' <= eil[i] && eil[i] <= 'z') || ('A' <= eil[i] && eil[i] <= 'Z'))
                {
                    Rn[eil[i]]++;
                }else
                {
                    for (int j = 0; j < lt.Length; j++)
                    {
                        if (eil[i] == lt[j] || eil[i] == ltd[j])
                        {
                            Rnlt[eil[i]]++;
                        }
                    }
                }

            }
        }
    }


    class Program
    {
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            char[] lt = {'ą', 'č', 'ę', 'ė', 'į', 'š', 'ų', 'ū', 'ž' };
            RaidziuDazniai eil = new RaidziuDazniai();
            Console.WriteLine("Įveskite eilutę iš mažųjų ir didžiųjų raidžių");
            string line = Console.ReadLine();
            eil.eil = line;
            eil.kiek();
            Spausdinti(CFr, eil, lt);
        }

        static void Spausdinti(string fv, RaidziuDazniai eil, char[] lt)
        {
            using (var fr = File.CreateText(fv))
            {
                for (char sim = 'a'; sim <= 'z'; sim++)
                    fr.WriteLine("{0, 3:c} {1, 4:d}  |{2, 3:c} {3, 4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim)));

                for (char sim = 'ą'; sim < 'ž'; sim++)
                {
                    if (lt.Contains(sim))
                    {
                         fr.WriteLine("{0, 3:c} {1, 4:d}  |{2, 3:c} {3, 4:d}", sim, eil.ImtiLt(sim), Char.ToUpper(sim), eil.ImtiLt(Char.ToUpper(sim)));
                        }
                    }
                }
            }
        }
    }