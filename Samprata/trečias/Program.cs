using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trečias
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 5 iki 15 jų kvadratai ir kubai:");
            for (int i = 5; i < 16; i++)
                Console.WriteLine(" {0,3:d} {1,5:d} {2,5:d}", i, i * i, i*i*i);
        }
    }
}
