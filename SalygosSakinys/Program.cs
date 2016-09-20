using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalygosSakinys
{
    class Program
    {
        static void Main(string[] args)
        {
            char simbolis;
            int suma =0;
            int eilute = 0;
            Console.Write("Įveskite spausdinamą simbolį: ");
            simbolis = (char)Console.Read();
            Console.ReadLine();
            Console.Write("Įveskite simbolių skaičių: ");
            suma = int.Parse(Console.ReadLine());
            Console.Write("Įveskite simbolių skaičių vienoje eilutėje: ");
            eilute = int.Parse(Console.ReadLine());
            Console.WriteLine("{0} {1}", suma, eilute);
            for (int i = 1; i <= suma; i++)
                if (i % eilute == 0)
                    Console.WriteLine(simbolis);
                else
                    Console.Write(simbolis);
                    Console.WriteLine("");
        }
    }
}
