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
            //file = File.OpenText("dane.txt");
            /*
                2-4,6-8
                2-3,4-5
                5-7,7-9
                2-8,3-7
                6-6,4-6
                2-6,4-8 
             */
            string s = "";
            var linesimple = new List<string>();
            int pairs = 0;
            int pairs2 = 0;
            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);
                int a, b, c, d;
                var spl = s.Split(',');
                a = int.Parse(spl[0].Substring(0, spl[0].IndexOf('-')));
                b = int.Parse(spl[0].Substring(spl[0].IndexOf('-') + 1));
                c = int.Parse(spl[1].Substring(0, spl[1].IndexOf('-')));
                d = int.Parse(spl[1].Substring(spl[1].IndexOf('-') + 1));

                if ((a <= c && b >= d) || (a >= c && b <= d))
                {
                    pairs++;
                }

                if (
                    ((a <= c && c <= b)
                    ||
                    (c <= b && b <= d)
                    )
                    ||
                    (c <= a && a <= d)
                    ||
                    (a <= d && d <= b)
                    )
                {
                    pairs2++;
                }

            }

            Console.WriteLine("stage one " + pairs);
            Console.WriteLine("stage two " + pairs2);
            Console.ReadLine();
        }
    }
}
