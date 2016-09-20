using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" Įveskite pirmąjį skaičių:  ");
            double sk1 = double.Parse(Console.ReadLine());
            Console.WriteLine(" Įveskite veiksmo simbolį (+,-,*,/):  ");
            char op = char.Parse(Console.ReadLine());
            Console.WriteLine(" Įveskite antrąjį skaičių:  ");
            double sk2 = double.Parse(Console.ReadLine());
            double ats = calcus(sk1, sk2, op);
            if (ats != 0)
            {
                Console.WriteLine("{0,8:f3} {1} {2,8:f3} = {3,8:f3}", sk1, op, sk2, ats);
            }
        }
            static double calcus(double sk1, double sk2, char op){
            double ats;
            switch (op)
            {
                case '+':
                    {
                        ats = sk1 + sk2;
                        break;
                    }
                case '-':
                    {
                        ats = sk1 - sk2;
                        break;
                    }
                case '*':
                    {
                        ats = sk1 * sk2;
                        break;
                    }
                case '/':
                    {
                        ats = sk1 / sk2;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error");
                        return 0;
                        break;
                    }
            }
            return ats;
        }
    }
}
