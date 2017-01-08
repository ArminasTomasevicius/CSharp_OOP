using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Apdoroti(string fv, string fvr, string fa)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            using (var fr = File.CreateText(fvr))
            {
                using (var far = File.CreateText(fa))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string nauja = line;
                            if (BeKomentaru(line, out nauja))
                            {
                                far.WriteLine(line);
                            }
                            if (nauja.Length > 0)
                            {
                                fr.WriteLine(nauja);
                            }
                        }else{
                            fr.WriteLine(line);
                        }
                }
            }
        }
    }

