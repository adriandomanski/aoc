using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _14
{
    class Program
    {
        static List<char> valueList;
        static List<char> tmplist;
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");

            string start = lines[0];
            valueList = start.ToList();

            Dictionary<string, char> dic = new Dictionary<string, char>();
            for (var i = 2; i < lines.Length; i++)
            {
                var lin = lines[i].Split(" -> ");
                dic.Add(lin[0], lin[1].ToCharArray()[0]);
            }
            for (int i = 0; i <10; i++)
            {
                tmplist = new List<char>();
                var sw = new Stopwatch();
                sw.Start();
                // for (int index = 0; index < start.Length; index += 2)
                // {
                // try
                // {
                //     start = start.Insert(index + 1, dic[start.Substring(index, 2)]);

                // }
                // catch (System.Exception ex)
                // {
                //     // TODO
                // }
                char lastAdded;

                lastAdded = valueList[0];
                tmplist.Add(lastAdded);

                for (int index = 1; index < valueList.Count; index++)
                {

                    //1
                    char second = valueList[index];
                    string key = string.Empty + tmplist.Last() + second;
                    lastAdded = dic[key];
                    tmplist.Add(lastAdded);
                    tmplist.Add(second);
                    //2
                }

                //end
                valueList = tmplist;
                sw.Stop();
                Console.WriteLine($"stet {i} end { sw.Elapsed.TotalSeconds}");

            }
            List<char> datalist = new List<char>();
            datalist.AddRange(start);
            var counts = valueList.GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());
            Console.WriteLine($" stage 1 : {counts.Values.Max() - counts.Values.Min()}");

        }
    }
}
