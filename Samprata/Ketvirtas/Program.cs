using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketvirtas
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3; // Pirmas kintamasis
            int b = 5; // Antras kintamasis
            int suma = a + b;
            Console.Write(" {0,3:d} + {1,3:d} =", a, b);
            Console.WriteLine(" {0,3:d} \n", suma);
        }
    }
}
