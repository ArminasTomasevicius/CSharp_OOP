using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Įveskite x reikšmę (tik sveikas skaičius):  ");
            int x = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("fx = {0}", calcus(x));
        }
        static double calcus(int x) {
            double fx;
            if (x >= -5 && x <= 0)
            {
                fx = x + 2 * Math.Pow(x, 2);
            } else if (x > 0 && x < 3)
            {
                fx = Math.Pow(x, 2) + 4;
            }else
            {
                fx = Math.Pow(2 * Math.Pow(x, 2)+3, 0.5);
            }
            return fx;
        }
    }
}
