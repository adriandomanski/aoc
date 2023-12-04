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
            file = File.OpenText("dane.txt");
            string s = "";
            var linesimple = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);
            }
            s = linesimple[0];
            int startingpoint = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var sub = s.Substring(i, 14);
                var dist =sub.ToCharArray().Distinct();

                if (sub.Length==dist.ToList().Count)
                {
                    startingpoint = i +14 ;
                    break;
                }
            }
            Console.WriteLine("stage one " + startingpoint);
            Console.ReadLine();
        }
    }
}
