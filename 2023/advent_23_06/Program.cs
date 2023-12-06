using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        class pair
        {
            public long timeHold, race;
        }

        class race
        {
            public long time { get; } = 0;
            public long record { get; } = 0;
            public List<pair> racesPossible = new List<pair>();
            public int countMoreThanRecord =0;

            public race(long time, long record)
            {
                this.time=time  ;
                this.record = record;

                for (int i = 0; i <= time; i++)
                {
                    
                        long timehold = i;
                        long lenght = (time - timehold) * timehold;
                        
                        racesPossible.Add(new pair(){timeHold = timehold, race = lenght});
                        if (lenght>record)
                        {
                            countMoreThanRecord++;
                        }
                   
                    
                }
            }
        }

        private static void Part1()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            List<long> times = new List<long>();
            List<long> records = new List<long>();
            List<race> races = new List<race>();
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                lines.Add(s.Split(':')[1]);
            }

            times.AddRange(lines[0].Split(" ").Where(_ => !string.IsNullOrEmpty(_)).Select(_ => long.Parse(_))
                .ToList());
            
            records.AddRange(lines[1].Split(" ").Where(_ => !string.IsNullOrEmpty(_)).Select(_ => long.Parse(_))
                .ToList());

            long stage1 = 1;
            for (int i = 0; i < times.Count; i++)
            {
                var r = new race(times[i], records[i]);
                races.Add(r);
                stage1 *= r.countMoreThanRecord;
            }

            Console.WriteLine("Part1 "+ stage1);
            times = new List<long>();
            records = new List<long>();
            times.Add(long.Parse(lines[0].Replace(" ", "")));
            records.Add(long.Parse(lines[1].Replace(" ", "")));
           

            long stage2 = 1;
            for (int i = 0; i < times.Count; i++)
            {
                var r = new race(times[i], records[i]);
                races.Add(r);
                stage2 *= r.countMoreThanRecord;

            }
            Console.WriteLine("Part2 "+ stage2);
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