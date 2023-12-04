using System;
using System.Collections.Generic;
using System.IO;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            { 
                lines.Add(s);
            }

            Console.WriteLine("Part1");
        }
        
        private static void Part2()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            { 
                lines.Add(s);
            }

            Console.WriteLine("Part2");
        }

    }
}