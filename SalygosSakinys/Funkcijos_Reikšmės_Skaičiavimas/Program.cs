using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funkcijos_Reikšmės_Skaičiavimas
{
    class Program
    {
        static void Main(string[] args)
        {
            double fx;
            int z;
            Console.Write("Įveskite z reikšmę:  ");
            z = int.Parse(Console.ReadLine());

            if (z - 1 >= 0)
            {
                fx = Math.Pow(z - 1, 0.5); // Matematinių funkcijų klasė, Pow – kėlimas laipsniu 
                Console.WriteLine(" z = {0}   f(x) =  {1,8:f3}", z, fx);
            }
            else
            {
                Console.WriteLine(" z = {0}  f-ja neegzistuoja", z);
            }
        }
    }
}
