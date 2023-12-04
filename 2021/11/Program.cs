using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int runs = 10000;
            var dane = System.IO.File.ReadAllLines("dane.txt");
            for (int x = 0; x < dane[0].Length; x++)
            {
                for (int y = 0; y < dane[x].Length; y++)
                {
                    points.Add(new Point(x, y, int.Parse(dane[x].Substring(y, 1))));
                }
            }

            for (int i = 1; i <= runs; i++)
            {
                foreach (var item in points)
                {
                    item.Increment();
                }
                CountFlashesAndClear();
                if (i == 100)
                {
                    Console.WriteLine($"Stage 1 @ {i} flashes {flashes}");
                }
                if (points.All(x => x.value == 0))
                {
                    Console.WriteLine($"Stage 2 @ {i}");

                    break;
                }
            }
        }

        private static void CountFlashesAndClear()
        {
            flashes += points.Where(x => x.value > 9).Count();
            foreach (var item in points.Where(x => x.value > 9))
            {
                item.value = 0;
            }
            flashedPointsInStep.Clear();
        }

        public static int flashes = 0;
        public static List<Point> points = new List<Point>();
        public static List<Point> flashedPointsInStep = new List<Point>();
    }
    class Point
    {
        public Point(int x, int y, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }

        public int x { get; set; }
        public int y { get; set; }
        private int _val;
        public int value
        {
            get { return _val; }
            set
            {
                _val = value;
                if (_val == 10)
                {
                    Flash();
                }
            }
        }

        public void Flash()
        {
            if (value > 9)
            {
                Program.flashedPointsInStep.Add(this);
                var points = Program.points.Where(p =>
                     ((p.x == x && p.y == y - 1)
                    || (p.x == x && p.y == y + 1)
                    || (p.x == x + 1 && p.y == y)
                    || (p.x == x - 1 && p.y == y)
                    || (p.x == x - 1 && p.y == y - 1)
                    || (p.x == x - 1 && p.y == y + 1)
                    || (p.x == x + 1 && p.y == y + 1)
                    || (p.x == x + 1 && p.y == y - 1)
                     ) && !Program.flashedPointsInStep.Contains(p)).ToList();
                foreach (var item in points)
                {
                    item.Increment();
                }
            }
        }
        public void Increment()
        {
            value++;
        }
        public override string ToString()
        {
            return $"x:{x} y:{y} v: {value}";
        }
    }
}
