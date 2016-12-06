using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Func());
        }

        static int Func()
        {
            int i = 0, y = 2, a = 3;

            if (i<y)
            {
                return i;
            }else
            {
                i++;
            }
            if (i < y)
            {
                return y;
            }else
            {
                return i;
            }
             
        }
    }
}
