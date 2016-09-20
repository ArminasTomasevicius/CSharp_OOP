using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1antra_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.1415;
            double H;
            double R, r;
            double V;
            Console.WriteLine("Įveskite kūgio aukštinės reikšmę");
            H = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio viršutinio pagrindo spindulio reikšmę");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kūgio apatinio pagrindo spindulio reikšmę");
            R = double.Parse(Console.ReadLine());
            V = (1.0 / 3) * pi * H * (R * R + R * r + r * r);
            Console.WriteLine("Kūgio tūris = {0, 5:f}", V);
        }
    }
}
