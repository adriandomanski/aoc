//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace advent_01
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Day one");
//            var file = File.OpenText("dane.txt");
//            List<long> elves = new List<long>();
//            long elve = 0;
//            string s;

//            while ((s = file.ReadLine()) != null)
//            {
//                long food = 0;
//                long.TryParse(s, out food);
//                elve += food;
//                if (s == "")
//                {
//                    elves.Add(elve);
//                    elve = 0;

//                }
//            }
//            Console.WriteLine("stage one: " + elves.Max());
//            var sorted = elves.OrderByDescending(i => i);
//            var sub = sorted.Take(3);
//            Console.WriteLine("stage two: " + sub.Sum());
//        }
//    }
//}
