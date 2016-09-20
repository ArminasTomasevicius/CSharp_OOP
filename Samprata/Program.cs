using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samprata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 1; i < 11; i++)
                Console.WriteLine(" {0,3:d} {1,5:d}", i, i * i);
        }
    }
}
