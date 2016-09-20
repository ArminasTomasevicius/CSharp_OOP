using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penktas
{
    class Program
    {
        static void Main(string[] args)
        {
            int k=0;
            Console.WriteLine("Skaičiai nuo 5 iki 15 jų kvadratai ir kubai:");
            for (int i = 5; i < 16; i++)
            {
                k++;
                Console.WriteLine(" {0,3:d} {1,5:d} {2,5:d}", i, i * i, i * i * i);
                Console.WriteLine("Ciklo {0,3:d} Ratas", k);
            }
        }
    }
}
