using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04
{
    class Program
    {
        static List<Pointt> pointList = new List<Pointt>();
        static void Main(string[] args)
        {
            try
            {
                var dane = File.ReadAllLines("dane.txt");
                foreach (var pairString in dane)
                {
                    Console.WriteLine(pairString);
                    var firstX = Int16.Parse(pairString.Split(" -> ")[0].Split(",")[0]);
                    var firstY = Int16.Parse(pairString.Split(" -> ")[0].Split(",")[1]);
                    var secondX = Int16.Parse(pairString.Split(" -> ")[1].Split(",")[0]);
                    var secondY = Int16.Parse(pairString.Split(" -> ")[1].Split(",")[1]);
                    if (firstX == secondX)
                    {
                        Int16 min = Math.Min(secondY, firstY);
                        Int16 max = Math.Max(secondY, firstY);

                        for (Int16 i = min; i <= max; i++)
                        {
                            AddPoint(firstX, i);
                        }

                    }
                    else if (secondY == firstY)
                    {
                        Int16 min = Math.Min(secondX, firstX);
                        Int16 max = Math.Max(secondX, firstX);

                        for (Int16 i = min; i <= max; i++)
                        {
                            AddPoint(i, firstY);
                        }

                    }
                    else
                    {
                        //x1 > x2 , y1 > y2
                        //x1 < x2 , y1 < y2 

                        //  \
                        //x1 < x2 , y1 > y2
                        //x1 > x2 , y1 < y2
                        // /
                        // Int16 miny = Math.Min(secondY, firstY);
                        // Int16 maxy = Math.Max(secondY, firstY);
                        // Int16 minx = Math.Min(secondX, firstX);
                        // Int16 maxx = Math.Max(secondX, firstX);
                        // up or down
                        Int16 XIncrementator = 0;
                        Int16 YIncrementator = 0;
                        if (firstX > secondX)
                        {
                            if (firstY > secondY)
                            {
                                XIncrementator = -1;
                                YIncrementator = -1;
                            }
                            else
                            {
                                XIncrementator = -1;
                                YIncrementator = +1;
                            }
                        }
                        else
                        {

                            if (firstY > secondY)
                            {
                                XIncrementator = +1;
                                YIncrementator = -1;
                            }
                            else
                            {

                                XIncrementator = +1;
                                YIncrementator = +1;
                            }
                        }
                        AddSeriesOfPoints(firstX, firstY, XIncrementator, YIncrementator, (short)(Math.Abs(firstY - secondY)));



                    }
                }
                Console.WriteLine(pointList.Where(p => p.C > 1).Count());

            }
            catch (System.Exception ex)
            {
                // TODO
            }
        }

        static void AddSeriesOfPoints(Int16 minx, Int16 miny, Int16 incx, Int16 incy, Int16 count)
        {
            for (var i = 0; i <= count; i++)
            {
                AddPoint(minx, miny);
                //Console.WriteLine(minx+","+miny);
                minx += incx;
                miny += incy;
            }

        }
        static void AddPoint(Int16 x, Int16 y)
        {
            var pFound = pointList.SingleOrDefault(p => p.X == x && p.Y == y);
            if (pFound == null)
            {
                pointList.Add(new Pointt { X = x, Y = y, C = 1 });
            }
            else
            {
                pFound.C++;
            }
        }
    }

    internal class Pointt
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public Int16 C { get; set; }
    }
}
