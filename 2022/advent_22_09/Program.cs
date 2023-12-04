using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_04
{
    class Program_1
    {
        static Head head = new Head();
        static Tail tail = new Tail() { Parent = head };
        static List<string> tailPoints = new List<string>();
        static void Main_stage(string[] args)
        {
            var file = File.OpenText("test.txt");
            //file = File.OpenText("dane.txt");
            string s = "";

            tailPoints.Add("0.0");
            var linesimple = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                linesimple.Add(s);

                MoveHead(s);

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

                switch (values[0])
                {
                    case "U":

                        head.X++;
                        tail.CheckShouldFollow();
                        break;
                    case "D":
                        head.X--;
                        tail.CheckShouldFollow();

                        break;
                    case "L":
                        head.Y--;
                        tail.CheckShouldFollow();

                        break;
                    case "R":
                        head.Y++;
                        tail.CheckShouldFollow();

                        break;
                    default:
                        break;
                }
            }

        }
        class Head
        {

            private int x = 0;

            public int X
            {
                get { return x; }
                set
                {
                    setPrev();


                    x = value;
                }
            }

            private int y = 0;

            public int Y
            {
                get { return y; }
                set
                {
                    setPrev();

                    y = value;
                }
            }
            private void setPrev()
            {

                prev_x = x;
                prev_y = y;
            }


            public int prev_x = 0, prev_y = 0;

        }
        class Tail

        {
            public Head Parent { get; set; }

            public int x = 0, y = 0;

            internal void CheckShouldFollow()
            {
                if (!doesTouchParent())
                {
                    x = Parent.prev_x;
                    y = Parent.prev_y;

                    tailPoints.Add($"{x}.{y}");
                }
            }

            bool doesTouchParent()
            {
                if (
                    (x == Parent.X && y == Parent.Y) ||
                    (x == Parent.X + 1 && y == Parent.Y) ||
                    (x == Parent.X && y == Parent.Y + 1) ||
                    (x == Parent.X + 1 && y == Parent.Y + 1) ||
                    (x == Parent.X - 1 && y == Parent.Y - 1) ||
                    (x == Parent.X - 1 && y == Parent.Y + 1) ||
                    (x == Parent.X + 1 && y == Parent.Y - 1) ||
                    (x == Parent.X - 1 && y == Parent.Y) ||
                    (x == Parent.X && y == Parent.Y - 1)



                    )
                {
                    return true;


                }
                return false;

            }
        }
    }
}
