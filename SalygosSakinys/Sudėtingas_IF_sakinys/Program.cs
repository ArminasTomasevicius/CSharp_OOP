using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudėtingas_IF_sakinys
{
    class Program
    {
        static void Main(string[] args)
        {
            double fx;
            int a;
            double x;
            Console.Write(" Įveskite a reikšmę (tik sveikas skaičius):  ");
            a = int.Parse(Console.ReadLine());
            Console.Write(" Įveskite x reikšmę:  ");
            x = double.Parse(Console.ReadLine());
            Console.Clear();                      // Išvalo langą 
            Console.SetCursorPosition(5, 6);      // Nustato pradinę žymeklio padėtį
            if (x <= 0) fx = a * Math.Exp(-x);
            else if (x < 1) fx = 5 * a * x - 7;
            else fx = Math.Pow(x + 1, 0.5);
            Console.WriteLine(" Reikšmė a = {0,3:d}, reikšmė x = {1,6:f2}, fx = {2,8:f3}", a, x, fx);

        }
    }
}
