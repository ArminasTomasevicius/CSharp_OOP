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
            int suma;
            int eilute;
            
            Console.Write("Įveskite spausdinamą simbolį: ");
            simbolis = (char)Console.Read();
            Console.ReadLine();
            Console.Write("Įveskite simbolių skaičių: ");
            suma = int.Parse(Console.ReadLine());
            Console.Write("Įveskite simbolių skaičių vienoje eilutėje: ");
            eilute = int.Parse(Console.ReadLine());
            Spausdinti(simbolis, suma, eilute);

        }
        static void Spausdinti(char simbolis, int suma, int eilute) {
            int count = 0;
            while (suma > count)
            {
                
                for (int j = 1; j <= eilute && suma>count; j++)
                {
                    Console.Write(simbolis);
                    count++;
                }
                Console.WriteLine(" ");
            }
        }
    }
}
