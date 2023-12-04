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
            //100101001101

            var file = File.OpenText("dane.txt");
            string s = "";
            List<int> list = new List<int>();
            List<int> listBase = new List<int>();

            while ((s = file.ReadLine()) != null)
            {
                list.AddRange(s.Split(",").Select(s => int.Parse(s)));
                listBase.AddRange(s.Split(",").Select(s => int.Parse(s)));
            }
            int rep = 0;
            int maxday = 80;
            for (int i = 0; i < maxday; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    list[j] -= 1;
                    if (list[j] == -1)
                    {
                        list[j] = 6;

                    }
                    if (list[j] == 0)
                    {
                        rep++;
                    }

                }
                Console.WriteLine($"day {i} :  {list.Count}");
                if (i < maxday - 1)
                {
                    for (int r = 0; r < rep; r++)
                    {
                        list.Add(9);
                    }
                }

                rep = 0;

            }
            Console.WriteLine("stage 1 " + list.Count());
            Stage2(listBase);

        }
        class Pair
        {
            public Pair(int key, long value)
            {
                Key = key;
                Value = value;
            }

            public int Key { get; set; }
            public long Value { get; set; }
        }
        static void Stage2(List<int> list)
        {



            int maxday = 256;

            var listnE = list.GroupBy(s => s).Select(c => new Pair(c.Key, c.Count())).ToList();
            var zero = new Pair(0, listnE.FirstOrDefault(s => s.Key == 0) != null ? listnE.FirstOrDefault(s => s.Key == 1).Value : 0);
            var one = new Pair(1, listnE.FirstOrDefault(s => s.Key == 1) != null ? listnE.FirstOrDefault(s => s.Key == 1).Value : 0);
            var two = new Pair(2, listnE.FirstOrDefault(s => s.Key == 2) != null ? listnE.FirstOrDefault(s => s.Key == 2).Value : 0);
            var tre = new Pair(3, listnE.FirstOrDefault(s => s.Key == 3) != null ? listnE.FirstOrDefault(s => s.Key == 3).Value : 0);
            var four = new Pair(4, listnE.FirstOrDefault(s => s.Key == 4) != null ? listnE.FirstOrDefault(s => s.Key == 4).Value : 0);
            var five = new Pair(5, listnE.FirstOrDefault(s => s.Key == 5) != null ? listnE.FirstOrDefault(s => s.Key == 5).Value : 0);
            var six = new Pair(6, listnE.FirstOrDefault(s => s.Key == 6) != null ? listnE.FirstOrDefault(s => s.Key == 6).Value : 0);
            var seven = new Pair(7, listnE.FirstOrDefault(s => s.Key == 7) != null ? listnE.FirstOrDefault(s => s.Key == 7).Value : 0);
            var eigth = new Pair(8, listnE.FirstOrDefault(s => s.Key == 8) != null ? listnE.FirstOrDefault(s => s.Key == 8).Value : 0);

            long rep = 0;
            long helper = 0;
            for (int i = 0; i < maxday; i++)
            {
                helper = zero.Value;
                zero.Value = one.Value;
                one.Value = two.Value;
                two.Value = tre.Value;
                tre.Value = four.Value;
                four.Value = five.Value;
                five.Value = six.Value;
                six.Value = seven.Value + helper;
                seven.Value = eigth.Value;
                eigth.Value = helper;


            }
            string result = (BigInteger.Parse(zero.Value.ToString()  ) +
                            BigInteger.Parse(one.Value  .ToString() )+
                            BigInteger.Parse(two.Value  .ToString() )+
                            BigInteger.Parse(tre.Value  .ToString() )+
                            BigInteger.Parse(four.Value .ToString() )+
                            BigInteger.Parse(five.Value .ToString() )+
                            BigInteger.Parse(six.Value  .ToString() ) +
                            BigInteger.Parse(seven.Value.ToString() ) +
                            BigInteger.Parse(eigth.Value.ToString() ) ).ToString();

            Console.WriteLine("stage 2 " + result);
        }
    }
}