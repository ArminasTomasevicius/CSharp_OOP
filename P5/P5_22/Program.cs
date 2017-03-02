using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P5_22
{
    class Program
    {
        const string input = "..\\..\\input.txt";
        const string rez = "..\\..\\rez.txt";
        static void Main(string[] args)
        {
            char[] skirikliai = {'/', '+', ' ', ';', '!', '?'};
            int matches = 0;
            if (File.Exists(rez))
                File.Delete(rez);
            Read(input, ref matches, skirikliai);
            Console.WriteLine("Atitikimai:");
            Console.WriteLine(matches);

        }

        static void Read(string input, ref int matches, char[] skirikliai)
        {
            string[] parts = new string[1000];
            string pradzia = "";

            using (StreamReader reader = new StreamReader(input))
            {
                string line;
                int index = 0;
                bool match = false;

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(skirikliai, StringSplitOptions.RemoveEmptyEntries);

                    if (line.Length != 0)
                    {
                        if (parts.Length != 1)
                        {
                            int min = 0;
                            string trans_word = "";
                            int k = 0;
                            if ((k = line.IndexOf(parts[0])) != 0)
                            {
                                pradzia = line.Substring(0, k);
                            }
                            
                            for (int i = 0; i < parts.Length-1; i++)
                            {
                                if (Match(parts[i], parts[i + 1]))
                                {
                                    matches++;
                                    match = true;
                                    for (int j = 0; j < parts.Length - 1; j++)
                                    {
                                        int length = parts[j].Length + parts[j + 1].Length;

                                        if (min < length && Match(parts[j], parts[j+1])==true)
                                        {
                                            trans_word = parts[j];
                                            min = length;
                                            index = j;
                                        }
                                    }
                                }
                                else
                                {
                                    match = false;
                                }
                            }

                            string[] naujas = parts.Where((source, indexas) => indexas != index).ToArray();
                            using (var fr = File.AppendText(rez))
                            {
                                string intarpas;
                                for (int i = 0; i < naujas.Length; i++)
                                {
                         
                                    if (i != naujas.Length-1)
                                    {
                                            intarpas = Tarpas(line, naujas[i], naujas[i + 1], trans_word);
                                            fr.Write(pradzia + naujas[i] + intarpas);
                                    }
                                    else
                                    {
                                        intarpas = line.Substring((line.IndexOf(naujas[i]) + naujas[i].Length), line.Length - (line.IndexOf(naujas[i]) + naujas[i].Length));
                                        fr.Write(naujas[i] + intarpas);
                                    }
                                }


                                intarpas = Tarpas(line, trans_word, parts[index+1], trans_word);

                                fr.Write(trans_word + intarpas);
                                fr.WriteLine();

                            }
                        }
                        else
                        {
                            using (var fr = File.AppendText(rez))
                                fr.WriteLine(parts[0]);
                        }
                    }
                    else
                    {
                        using (var fr = File.AppendText(rez))
                            fr.Write(Environment.NewLine);
                    }
                }
            }
        }

       
        static bool Match(string text1, string text2)
        {
            if (text1[text1.Length-1] == text2[0])
            {
                return true;
            }
            else
            return false;
        }

        static string Tarpas(string text, string nuo, string iki, string trans)
        {
            int start, end;
            if (text.Contains(nuo) && text.Contains(iki))
            {
                start = text.IndexOf(nuo, 0) + nuo.Length;
                end = text.IndexOf(iki, start);

                string check = text.Substring(start, end - start);

                if (check.Contains(trans))
                {
                    if (end - start > 0)
                    {
                        start = text.IndexOf(nuo, 0) + nuo.Length;
                        end = text.IndexOf(trans, start);
                        return text.Substring(start, end - start);
                    }
                    else
                    {
                        return " ";
                    }
                }
                else
                {
                start = text.IndexOf(nuo, 0) + nuo.Length;
                end = text.IndexOf(iki, start);
                if (end - start > 0)
                {
                    return text.Substring(start, end - start);
                }
                else
                {
                    return " ";
                }
            }
            }
            else
            {
                return " ";
            }
        }
    }   
    }
