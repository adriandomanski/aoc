using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            var dane = System.IO.File.ReadAllLines("dane.txt");
            foreach (var item in dane)
            {
                var vals = item.Split(",");
                points.Add(new Point(int.Parse(vals[0]), int.Parse(vals[1])));
            }

            FoldX(655);

            Console.WriteLine($"stage1 { points.Select(x => x.ToString()).Distinct().Count()}");
            FoldY(447);
            FoldX(327);
            FoldY(223);
            FoldX(163);
            FoldY(111);
            FoldX(81);
            FoldY(55);
            FoldX(40);
            FoldY(447);
            FoldY(27);
            FoldY(13);
            FoldY(6);
            
            Console.WriteLine($"stage2");
            for (var y = 0; y < 6; y++)

            {
                Console.Write($"{y}:");
                for (var x = 0; x < 41; x++)
                {
                    var val = points.Any(p => p.x == x && p.y == y) ? "X" : ".";
                    Console.Write($"{val}");
                }
                Console.Write(Environment.NewLine);
            }
        }


        private static void FoldY(int fold)
        {
            points.RemoveAll(p => p.y == fold);

            foreach (var item in points.Where(x => x.y > fold))
            {
                item.y = fold - (item.y - fold);
            }
        }
        private static void FoldX(int fold)
        {
            points.RemoveAll(p => p.x == fold);

            foreach (var item in points.Where(x => x.x > fold))
            {
                item.x = fold - (item.x - fold);
            }
        }

        public static List<Point> points = new List<Point>();

    }
    class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }
        public override string ToString()
        {
            return $"x:{x} y:{y}";
        }
    }
}
