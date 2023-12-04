using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("dane.txt");
            string s = "";
            var lines = new List<Tuple<string, string>>();
            var linesimple = new List<string>();

            int sum = 0;

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);
                   var tuple = new Tuple<string, string>(s.Substring(0, s.Length / 2), s.Substring(s.Length / 2));
                lines.Add(tuple);

                var comon = from e1 in tuple.Item1
                            join e2 in tuple.Item2
                            on e1 equals e2
                            select e1;
                sum += point(comon.First());
            }

            Console.WriteLine("sum "+ sum);

            int sum2 = 0;
            for (int i = 0; i < linesimple.Count; i +=3)
            {
                var comon = from e1 in linesimple[i]
                            join e2 in linesimple[i + 1]
                            on e1 equals e2

                            join e3 in linesimple[i + 2]
                            on e2 equals e3
                            select e1;

                sum2 += point(comon.First());
            }

            Console.WriteLine("sum2 " + sum2);
        }

        static int point(char c)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.IndexOf(c) + 1;
        }
    }
}
