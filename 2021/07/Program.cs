using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {

            var file = File.OpenText("dane.txt");
            string s = "";
            List<int> list = new List<int>();

            while ((s = file.ReadLine()) != null)
            {
                list.AddRange(s.Split(",").Select(s => int.Parse(s)));

            }

            int fuel = 0;
            int median = Median(list.ToArray());
            for (int i = 0; i < list.Count; i++)
            {
                fuel += (Math.Abs(list[i] - median));
            }

            Console.WriteLine($"Stage1 { fuel}");


            int fuel2 = int.MaxValue; ;
            int maxValue = list.Max();
            for (int i = 0; i <= maxValue; i++)
            {
                int fTemp = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    for (int f = 1; f <= (Math.Abs(list[j] - i)); f++)
                    {
                        fTemp += f;
                    }

                }
                if (fuel2 > fTemp && fTemp > 0)
                {
                    fuel2 = fTemp;
                    Console.WriteLine($"Stage tmp { fTemp } dla {list[i] }");
                }
            }
            Console.WriteLine($"Stagef { fuel2}");

            static int Median(int[] xs)
            {
                Array.Sort(xs);
                return xs[xs.Length / 2];
            }


        }
    }
}