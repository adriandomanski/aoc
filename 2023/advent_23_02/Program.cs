using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static List<game> games = new List<game>();

        class game
        {
            public game(string line)
            {
                line = line.Replace("Game ", "");
                number = int.Parse(line.Split(":".Replace(" ", ""))[0]);
                var gamess = line.Split(":")[1];
                foreach (var l1 in gamess.Split(";"))
                {
                    foreach (var l2 in l1.Split(","))
                    {
                        Console.WriteLine("'" + l2 + "'");

                        if (l2.Contains("blue"))
                        {
                            blues.Add(ReplaceNumNumbers(l2));
                        }
                        else if (l2.Contains("red"))
                        {
                            reds.Add(ReplaceNumNumbers(l2));
                        }
                        else if (l2.Contains("green"))
                        {
                            greens.Add(ReplaceNumNumbers(l2));
                        }
                    }
                }

                maxReds = reds.Max();
                maxBlues = blues.Max();
                maxGreens = greens.Max();
            }

            int ReplaceNumNumbers(string phone)
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                return int.Parse(digitsOnly.Replace(phone, ""));
            }

            public int number;
            public List<int> reds = new List<int>();
            public List<int> blues = new List<int>();
            public List<int> greens = new List<int>();
            public int maxReds;
            public int maxBlues;
            public int maxGreens;
        }

        private static void Part1()
        {
            StreamReader file;
            //  file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                lines.Add(s);
                games.Add(new game(s));
            }

            var result = games.Where(_ =>
                _.maxBlues <= 14
                && _.maxGreens <= 13
                && _.maxReds <= 12);

            var answer = result.Sum(_ => _.number);
            Console.WriteLine("Part1 " + answer);
        }

        private static void Part2()
        {
            StreamReader file;
            //file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                lines.Add(s);
                games.Add(new game(s));
            }

            var answer = games.Sum(_ => _.maxBlues * _.maxGreens * _.maxReds);

            Console.WriteLine("Part2 " + answer);
        }
    }
}