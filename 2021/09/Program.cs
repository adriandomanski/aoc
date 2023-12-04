using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04
{
    class Program
    {
        static int max_X, max_Y;
        static List<Pointt> pointList = new List<Pointt>();
        static List<Pointt> pointList2 = new List<Pointt>();
        static void Main(string[] args)
        {
            var dane = File.ReadAllLines("dane.txt");
            max_X = dane.Length;
            max_Y = dane[0].Length;

            for (var i = 0; i < dane.Length; i++)
            {
                for (int j = 0; j < dane[0].Length; j++)
                {
                    int UP = int.MaxValue, Down = int.MaxValue, Left = int.MaxValue, Right = int.MaxValue, Center = int.MaxValue;
                    if (CoordsInTable(i, j))
                    {
                        Center = int.Parse(dane[i].Substring(j, 1));
                    }

                    if (CoordsInTable(i - 1, j))
                    {
                        UP = int.Parse(dane[i - 1].Substring(j, 1));
                    }

                    if (CoordsInTable(i, j - 1))
                    {
                        Left = int.Parse(dane[i].Substring(j - 1, 1));
                    }

                    if (CoordsInTable(i, j + 1))
                    {
                        Right = int.Parse(dane[i].Substring(j + 1, 1));
                    }

                    if (CoordsInTable(i + 1, j))
                    {
                        Down = int.Parse(dane[i + 1].Substring(j, 1));
                    }

                    pointList.Add(new Pointt(UP, Down, Left, Right, Center, i, j));
                }
            }
            pointList2.AddRange(pointList);

            Console.WriteLine($"Stage1 : {   pointList.Where(x => x.lowest != null).Sum(x => x.lowest + 1)}");

            foreach (var item in pointList.Where(x => x.lowest != null))
            {
                list2.Add(new PointtBase { COords = $"{item.X}:{item.Y}", Count = 0 });
                Method(item.X, item.Y, item.center, item);
            }

            var tmp = list2.OrderByDescending(x => x.Count).Take(3).ToList();

            Console.WriteLine($"Stage2 : {tmp[0].Count * tmp[1].Count * tmp[2].Count}");


        }
        static bool CoordsInTable(int i, int j)
        {
            return i >= 0 && j >= 0 && i < max_X && j < max_Y;
        }


        static List<PointtBase> list2 = new List<PointtBase>();
        static int ccc = 0;
        static void Method(int base_point_X, int base_point_Y, int center, Pointt base_point)
        {
            var p_0 = pointList2.FirstOrDefault(x => x.X == base_point_X && x.Y == base_point_Y);

            pointList2.Remove(p_0);
            if (center >= 9)
            {
                return;
            }
            ccc++;
            var element = list2.FirstOrDefault(x => x.COords == $"{base_point.X}:{base_point.Y}");
            if (element != null)
            {
                element.Count++;
            }
            var p_1 = pointList2.FirstOrDefault(x => x.X == base_point_X && x.Y == base_point_Y - 1 && x.center < 9);
            if (p_1 != null)
            {
                pointList2.Remove(p_1);
                Method(p_1.X, p_1.Y, p_1.center, base_point);
            }

            var p_2 = pointList2.FirstOrDefault(x => x.X == base_point_X && x.Y == base_point_Y + 1 && x.center < 9);
            if (p_2 != null)
            {
                pointList2.Remove(p_2);
                Method(p_2.X, p_2.Y, p_2.center, base_point);
            }

            var p_3 = pointList2.FirstOrDefault(x => x.X == base_point_X - 1 && x.Y == base_point_Y && x.center < 9);
            if (p_3 != null)
            {
                pointList2.Remove(p_3);
                Method(p_3.X, p_3.Y, p_3.center, base_point);
            }

            var p_4 = pointList2.FirstOrDefault(x => x.X == base_point_X + 1 && x.Y == base_point_Y && x.center < 9);
            if (p_4 != null)
            {
                pointList2.Remove(p_4);
                Method(p_4.X, p_4.Y, p_4.center, base_point);
            }
        }

    }
    internal class PointtBase
    {
        public string COords { get; set; }
        public int Count { get; set; }

    }

    internal class Pointt
    {
        public int? lowest = null;
        private readonly int up;
        private readonly int down;
        private readonly int left;
        private readonly int right;
        public readonly int center;
        public int Y { get; }
        public int X { get; }
        public Pointt(int up, int down, int left, int right, int center, int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.center = center;
            this.right = right;
            this.left = left;
            this.down = down;
            this.up = up;
            lowest = GeIfLowestPoint();
        }
        int? GeIfLowestPoint()
        {
            if (center < left && center < right && center < up && center < down)
            {
                return center;
            }
            return null;
        }
    }
}
