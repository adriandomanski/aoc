using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("test.txt");
            //var file = File.OpenText("test.txt");
            string s = "";
            var linesimple = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);
                Console.WriteLine(s);

            }
            Console.ReadLine();
        }
    }
}
