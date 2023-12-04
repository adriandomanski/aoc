using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        private static void Part1()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            int line = 0;
            while ((s = file.ReadLine()) != null)
            {
                lines.Add(s);
                bool call = false;
                Sth item = null;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!char.IsDigit(s[i]) && s[i] != '.')
                    {
                        item = new Sth();
                        item.row = line;
                        item.cols.Add(i);
                        if (char.IsDigit(s[i]))
                        {
                            item.value += s[i];
                            call = true;
                            SthListNumbers.Add(item);
                        }
                        else
                        {
                            item.nondigit += s[i];
                            SthListSymbols.Add(item);
                            item = new Sth();
                            call = false;
                        }
                    }
                    else if (s[i] != '.' && call)
                    {
                        item.cols.Add(i);
                        if (char.IsDigit(s[i]))
                        {
                            item.value += s[i];
                        }
                    }
                    else if (s[i] != '.')
                    {
                        item = new Sth();
                        item.row = line;
                        item.cols.Add(i);
                        if (char.IsDigit(s[i]))
                        {
                            item.value += s[i];
                            call = true;
                            SthListNumbers.Add(item);
                        }
                        else
                        {
                            item.nondigit += s[i];
                            SthListSymbols.Add(item);
                            item = new Sth();
                            call = false;
                        }
                    }
                    else
                    {
                        call = false;
                    }
                }

                line++;
            }

            foreach (var numberItem in SthListNumbers)
            {
                numberItem.CheckIsAdjacenctPart1();
                numberItem.CheckIsAdjacenct();
            }

            var lsitOfParts = SthListNumbers.Where(_ => _.IsPartNo).ToList();

            Console.WriteLine("Part1 " + lsitOfParts.Sum(_ => int.Parse(_.value)));

            var touched = SthListSymbols.Where(_ => _.touchingParts.Count > 1);

            Console.WriteLine("Part2 " +
                              touched.Sum(
                                  _ => int.Parse(_.touchingParts[0].value) * int.Parse(_.touchingParts[1].value)));
        }

        static private List<Sth> SthListSymbols = new List<Sth>();
        static private List<Sth> SthListNumbers = new List<Sth>();

        class Sth
        {
            public Guid id = Guid.NewGuid();
            public string value;
            public string nondigit;
            public int row;
            public List<int> cols = new List<int>();
            public bool IsPartNo = false;


            public void touchingPartsAdd(Sth item)
            {
                if (!touchingParts.Any(_ => _.id == item.id))
                {
                    touchingParts.Add(item);
                }
            }

            public List<Sth> touchingParts = new List<Sth>();

            public override string ToString()
            {
                return "Partno:" + value + " " + Cooridnates + " " + nondigit;
            }

            public Point Cooridnates => new Point() { X = row, Y = cols[0] };

            public void CheckIsAdjacenct()
            {
                foreach (var pitem in SthListSymbols)
                {
                    foreach (var col in cols)
                    {
                        bool added = false;
                        var myPoint = new Point() { X = row, Y = col };
                        if (IsAdjacent(myPoint, pitem.Cooridnates))
                        {
                            if (!added)
                            {
                                pitem.touchingPartsAdd(this);
                                added = true;
                            }
                        }
                    }
                }
            }

            public void CheckIsAdjacenctPart1()
            {
                foreach (var pitem in SthListSymbols)
                {
                    foreach (var col in cols)
                    {
                        var myPoint = new Point() { X = row, Y = col };
                        if (IsAdjacent(myPoint, pitem.Cooridnates))
                        {
                            IsPartNo = true;
                            break;
                        }
                    }
                }
            }
        }

        static bool IsAdjacent(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1;

            return p1.X == p2.X + 1 && p1.Y == p2.Y
                   ||
                   p1.X == p2.X && p1.Y == p2.Y + 1
                   ||
                   p1.X == p2.X + 1 && p1.Y == p2.Y + 1
                   ||
                   p1.X == p2.X - 1 && p1.Y == p2.Y
                   ||
                   p1.X == p2.X && p1.Y == p2.Y - 1
                   ||
                   p1.X == p2.X - 1 && p1.Y == p2.Y - 1
                   ||
                   p1.X == p2.X + 1 && p1.Y == p2.Y - 1
                   ||
                   p1.X == p2.X - 1 && p1.Y == p2.Y + 1
                ;


            ;
        }
    }
}