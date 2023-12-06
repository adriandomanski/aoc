using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static List<long> seeds = new List<long>();
        private static List<map> maps = new List<map>();
        private static List<Tuple<List<map>, int>> mapsSub = new List<Tuple<List<map>, int>>();

        class map
        {
            public long a = 0;
            public long b = 0;
            public long range = 0;
            public int type = 0;
            public long AsubB;

            public long bPlusRange;

            public override string ToString()
            {
                return $"{a} {b} {range} t{type} ";
            }

            public long mapValue(long val)
            {
                if (val >= b && val <= b + range)
                {
                    val += a - b;
                }

                return val;
            }
        }

        static int maptype = -1;

        private static void Part1()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;

            while ((s = file.ReadLine()) != null)
            {
                if (s.StartsWith("seeds: "))
                {
                    foreach (var s1 in s.Replace("seeds: ", "").Split(" "))
                    {
                        seeds.Add(long.Parse(s1));
                    }
                }
                else if (string.IsNullOrEmpty(s))
                {
                    maptype++;
                }
                else if (s.Contains("map"))
                {
                    maps.Add(new map()
                        {
                            type = maptype
                        }
                    );
                }
                else if (!string.IsNullOrEmpty(s))
                {
                    maps.Add(new map()
                        {
                            a = long.Parse(s.Split(' ')[0]),
                            b = long.Parse(s.Split(' ')[1]),
                            range = long.Parse(s.Split(' ')[2]),
                            AsubB = long.Parse(s.Split(' ')[0]) - long.Parse(s.Split(' ')[1]),
                            bPlusRange = long.Parse(s.Split(' ')[1]) + long.Parse(s.Split(' ')[2]),
                            type = maptype
                        }
                    );
                }
            }

            maps = maps.OrderByDescending(_ => _.a).ToList();

            List<long> results = new List<long>();
            foreach (var seed in seeds)
            {
                results.Add(GetValue(seed));
            }

            List<Task> tasks = new List<Task>();

            Console.WriteLine("Part1 " + results.Min());


            foreach (var mapGroup in maps.OrderByDescending(_ => _.a).GroupBy(_ => _.type).OrderBy(_=>_.Key))
            {
                mapsSub.Add(new Tuple<List<map>, int>(mapGroup.ToList(), mapGroup.Key));
            }


            long part2val = long.MaxValue;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("start " + sw.Elapsed);
            try
            {
                
                Parallel.For(0, seeds.Count, i =>
                {
                    var res = Part2Val(i, part2val);
                    
                    if (res < part2val)
                    {
                        part2val = res;
                    }
                    Console.WriteLine("Partial res " + res);
                    Console.WriteLine("Partial value " + part2val);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Part2 " + part2val);
            Console.WriteLine("time " + sw.Elapsed);
        }

        private static long Part2Val(int i, long part2val)
        {
            try
            {
                long seedNu = seeds[i];
                long number = seeds[i + 1];

                for (long j = 0; j < number; j++)
                {
                    var res = GetValue2(seedNu + j);
                    if (res < part2val)
                    {
                        part2val = res;
                    }
                }
            }
            catch (Exception e)
            {
            }

            return part2val;
        }
        
        static long GetValue2(long mappingvalue)
        {
            // Console.Write($"{seed}->");
            for (int i = 0; i <= maptype; i++)
            {
                var subMaps = mapsSub[i].Item1;
                foreach (var maps in subMaps)
                {
                    if (mappingvalue >= maps.b &&
                        mappingvalue < maps.bPlusRange)
                    {
                        mappingvalue += maps.AsubB;
                        break;
                    }
                }
                // Console.Write($" {mappingvalue} | {foundMap} ->");
            }

            return mappingvalue;
        }

        static long GetValue(long mappingvalue)
        {
            // Console.Write($"{seed}->");
            for (int i = 0; i <= maptype; i++)
            { 
                for (var index = 0; index < maps.Count; index++)
                {
                    if (maps[index].type == i && mappingvalue >= maps[index].b &&
                        mappingvalue < maps[index].bPlusRange)
                    {
                        mappingvalue += maps[index].AsubB;
                        break;
                    }
                }
                // Console.Write($" {mappingvalue} | {foundMap} ->");
            }

            return mappingvalue;
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