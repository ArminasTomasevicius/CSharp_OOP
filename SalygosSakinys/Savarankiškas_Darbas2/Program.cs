using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_Darbas2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Įveskite x reikšmę:  ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Įveskite y reikšmę:  ");
            double y = double.Parse(Console.ReadLine());
            
            Console.WriteLine("x = {0,8:f3} y = {1,8:f3}", x, y);
            Console.WriteLine("fx = {0,8:f3}", calcus(x, y));
        }

        static double calcus(double x, double y)
        {
            double fx1;
            double fx2;
            double fx = 0;
            if ((fx2 = Math.Pow(x, 3) - y) != 0)
            {
                fx1 = Math.Pow(y, 2) - 2 * y * x + Math.Pow(x, 2);
                fx = fx1 / fx2;
                return fx;
            }else
            {
                return 0;
            }
        }
    }
}
