using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_04
{
    class Program_2
    {
        private const string tailendcons = "tailEnd";
        static Part tailEnd = new Part() { name = tailendcons };

        static Part tail_8 = new Part() { next = tailEnd, name = "tail_8" };
        static Part tail_7 = new Part() { next = tail_8, name = "tail_7" };
        static Part tail_6 = new Part() { next = tail_7, name = "tail_6" };
        static Part tail_5 = new Part() { next = tail_6, name = "tail_5" };
        static Part tail_4 = new Part() { next = tail_5, name = "tail_4" };
        static Part tail_3 = new Part() { next = tail_4, name = "tail_3" };
        static Part tail_2 = new Part() { next = tail_3, name = "tail_2" };
        static Part tail_1 = new Part() { next = tail_2, name = "tail_1" };
        static Part head = new Part() { name = "head", next = tail_1 };


        static List<string> CurrentPooints()
        {
            List<string> l = new List<string>();
            l.Add(head.getCurrentPoint());
            l.Add(tail_1.getCurrentPoint());
            l.Add(tail_2.getCurrentPoint());
            l.Add(tail_3.getCurrentPoint());
            l.Add(tail_4.getCurrentPoint());
            l.Add(tail_5.getCurrentPoint());
            l.Add(tail_6.getCurrentPoint());
            l.Add(tail_7.getCurrentPoint());
            l.Add(tail_8.getCurrentPoint());
            l.Add(tailEnd.getCurrentPoint());

            return l;
        }

        static List<string> tailPoints = new List<string>();
        static void Main(string[] args)
        {
            var file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            string s = "";

            tailPoints.Add("0.0");
            var linesimple = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);

                MoveHead(s);
                Console.WriteLine(s);
            }

            Console.WriteLine($"stage one : {tailPoints.Distinct().Count()}");

            Console.ReadLine();
        }

        private static void MoveHead(string s)
        {
            var values = s.Split(' ');
            int moves = int.Parse(values[1]);
            for (int i = 0; i < moves; i++)
            {
                string way = values[0];
                string wway = "";
                switch (way)
                {
                    case "U":
                        wway = "y";
                        head.Y++;
                        break;
                    case "D":
                        head.Y--;
                        wway = "y";

                        break;
                    case "L":
                        head.X--;
                        wway = "x";
                        break;
                    case "R":
                        head.X++;
                        wway = "x";
                        break;
                    default:
                        break;
                }
                head.AdjustNext(wway);
            }

        }
        class Part

        {
            public string getCurrentPoint()
            {
                return $"{X}.{Y}";
            }
            public string name = "";

            public int X { get; set; } = 0;

            public int Y { get; set; } = 0;

            public Part next { get; set; }


            internal void AdjustNext(string way)
            {
                if (this.name == tailendcons)
                {
                    tailPoints.Add(getCurrentPoint());
                }
                if (next == null)
                {
                    return;
                }
                if (!doesTouchNext())
                {
                    {
                        if (next.Y + 2 == this.Y && next.X + 2 == this.X)
                        {
                            next.Y = this.Y - 1;
                            next.X = this.X - 1;
                        }
                        else
                        if (next.Y - 2 == this.Y && next.X - 2 == this.X)
                        {
                            next.Y = this.Y + 1;
                            next.X = this.X + 1;
                        }
                        else

                        if (next.Y - 2 == this.Y && next.X + 2 == this.X)
                        {
                            next.Y = this.Y + 1;
                            next.X = this.X - 1;
                        }
                        else

                        if (next.Y + 2 == this.Y && next.X - 2 == this.X)
                        {
                            next.Y = this.Y - 1;
                            next.X = this.X + 1;
                        }
                        else

                        if (next.Y + 2 == this.Y)
                        {
                            next.Y = this.Y - 1;
                            next.X = this.X;
                        }
                        else
                        if (next.Y - 2 == this.Y)
                        {
                            next.X = this.X;
                            next.Y = this.Y + 1;
                        }
                        else

                        if (next.X + 2 == this.X)
                        {
                            next.Y = this.Y;
                            next.X = this.X - 1;
                        }
                        else
                        if (next.X - 2 == this.X)
                        {
                            next.Y = this.Y;
                            next.X = this.X + 1;
                        }
                    }
                }
                next?.AdjustNext(way);

            }

            bool doesTouchNext()
            {
                if (
                    (this.X == next.X && this.Y == next.Y) ||
                    (this.X == next.X + 1 && this.Y == next.Y) ||
                    (this.X == next.X && this.Y == next.Y + 1) ||
                    (this.X == next.X + 1 && this.Y == next.Y + 1) ||
                    (this.X == next.X - 1 && this.Y == next.Y - 1) ||
                    (this.X == next.X - 1 && this.Y == next.Y + 1) ||
                    (this.X == next.X + 1 && this.Y == next.Y - 1) ||
                    (this.X == next.X - 1 && this.Y == next.Y) ||
                    (this.X == next.X && this.Y == next.Y - 1)
                )
                {
                    return true;
                }
                return false;
            }

            public override string ToString()
            {
                return name + " " + getCurrentPoint();// + next?.ToString();
            }
        }

        public static void Printtt()
        {
            var xes = tailPoints.Select(s => int.Parse(s.Split('.')[0])).ToList();
            var minx = xes.Min();
            var maxx = xes.Max();

            var yes = tailPoints.Select(s => int.Parse(s.Split('.')[1])).ToList();
            var miny = yes.Min();
            var maxy = yes.Max();
            Print2DArrayFOrTAil(minx, miny, maxx + 1, maxy + 1, tailPoints);
        }


        public static void PrinCurrentPoint()
        {
            var l = CurrentPooints();
            var xes = l.Select(s => int.Parse(s.Split('.')[0])).ToList();
            var minx = -10;
            var maxx = 10;

            var yes = l.Select(s => int.Parse(s.Split('.')[1])).ToList();
            var miny = -10;
            var maxy = 10;
            Print2DArray(minx, miny, maxx + 1, maxy + 1, l);
        }

        public static void Print2DArray(int minx, int miny, int maxx, int maxy, List<string> listtopront)
        {
            for (int j = maxy; j > miny; j--)
            {
                for (int i = minx; i < maxx; i++)

                {

                    if (i == 0 && j == 0)
                    {
                        Console.Write("S" + "");
                    }
                    else
                    if (listtopront.Contains($"{i}.{j}"))
                    {
                        Console.Write(listtopront.IndexOf($"{i}.{j}"));
                    }
                    else
                    {
                        Console.Write("." + "");

                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        public static void Print2DArrayFOrTAil(int minx, int miny, int maxx, int maxy, List<string> listtopront)
        {
            for (int j = maxy; j > miny; j--)
            {
                for (int i = minx; i < maxx; i++)

                {

                    if (i == 0 && j == 0)
                    {
                        Console.Write("S" + "");
                    }
                    else
                    if (listtopront.Contains($"{i}.{j}"))
                    {
                        Console.Write("X" + "");

                    }
                    else
                    {
                        Console.Write("." + "");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }
    }

}
