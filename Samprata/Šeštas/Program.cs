using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Šeštas
{
    class Program
    {
        static void Main(string[] args)

        {
            int a; // Pirmas kintamasis
            int b; // Antras kintamasis
            int suma; // Kintamasis sumai saugoti
            Console.Write("Įveskite sveikąją a reikšmę: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Įveskite sveikąją b reikšmę: ");
            b = int.Parse(Console.ReadLine());
            suma = a + b;
            Console.WriteLine("{0,3:d} + {1,3:d} = {2,4:d} \n", a, b, suma);
        }
    }
}
