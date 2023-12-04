using System;
using System.IO;

namespace advent_22_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("dane.txt");
            List<int> elves = new List<int>();
            int elve = 0;
            while ((s = file.ReadLine()) != null)
            {
                if (s == "")
                {
                    elves.Add(elve);
                    elve = 0;

                }
            }
            Console.Writeline(elves.Sort().First());
        }
    }
}
