using System;
using System.Collections.Generic;
using System.IO;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("dane.txt");
           
            string s = "";
            List<Tuple<string, int>> listInt = new List<Tuple<string, int>>();

            while ((s = file.ReadLine()) != null)
            {
                string kierunek = s.Split(" ")[0];
                int no = int.Parse(s.Split(" ")[1]);

                listInt.Add(new Tuple<string, int>(kierunek, no));
            }
            int forw = 0;
            int dep = 0;
            int aim = 0;

            foreach (var item in listInt)
            {
                if (item.Item1 == "forward")
                {
                    forw += item.Item2;
                    dep +=(item.Item2 * aim );
                }
                if (item.Item1 == "down")
                {
                    aim += item.Item2;

                }
                if (item.Item1 == "up")
                {
                    aim -= item.Item2;
                }
            }
            Console.WriteLine("forw:" + forw);
            Console.WriteLine("dep:" + dep);
            Console.WriteLine("aim:" + aim);
            Console.WriteLine("multiply:" + dep * forw);
        }
    }
}