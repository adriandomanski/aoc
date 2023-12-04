using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _14
{
    class Program
    {
        //public static Dictionary<string, char> dic = new Dictionary<string, char>();

        public static List<Pair> pairList = new List<Pair>();
        static List<char> valueList;
        static List<char> tmplist;
        static void Main(string[] args)
        {
            // impl1();
            impl2();

        }
        private static void impl2()
        {
            Dictionary<string, char> dic = new Dictionary<string, char>();
            var lines = File.ReadAllLines("data.txt");
            string start = lines[0];

            LinkedList<char> startStack = new LinkedList<char>();

            for (var i = 0; i < start.Length - 1; i++)
            {
                pairList.Add(new Pair { left = start[i], right = start[i + 1] });
            }
            for (int i = 0; i < start.Length; i++)
            {
                startStack.AddLast(start[i]);
            }

            for (var i = 2; i < lines.Length; i++)
            {
                var lin = lines[i].Split(" -> ");
                dic.Add(lin[0], lin[1].ToCharArray()[0]);
            }

            for (int i = 0; i < 40; i++)
            {
                if (i < 6)
                {

                    Console.WriteLine(String.Concat(startStack.Select(s => s)));

                }
                long count = pairList.Count;
                LinkedListNode<char> current = startStack.First;
                string pairstring = "";
                var newsign = ' ';
                LinkedListNode<char> next;
                LinkedListNode<char> neewItem;
                System.Diagnostics.Stopwatch sw = new Stopwatch();
                int cn = 0;
                sw.Start();
                while (current.Next != null)
                {
                    next = current.Next;
                    pairstring = "" + current.Value + next.Value; ;
                    newsign = dic[pairstring];
                    neewItem = new LinkedListNode<char>(newsign);
                    startStack.AddAfter(current, neewItem);
                    current = neewItem.Next;
                }
                var ss = startStack;


                cn++;
                if (cn == 10000000)
                {
                    sw.Stop();
                    Console.WriteLine($"stopwatch per {cn} :  { sw.ElapsedMilliseconds} ");
                    sw.Reset();
                    sw.Start();
                    cn = 0;

                }


                //startStack = newStart;


                Console.WriteLine($" stage 1 iteration {i} :  queue count  {startStack.Count}  { DateTime.Now}");
            }

            var counts = startStack.GroupBy(x => x)
                     .ToDictionary(g => g.Key, g => g.Count());
            Console.WriteLine($" stage 1 iteration  last : {counts.Values.Max() - counts.Values.Min()}");

        }
        //private static void impl1()
        //{
        //    var lines = File.ReadAllLines("data.txt");
        //    string start = lines[0];

        //    for (var i = 0; i < start.Length - 1; i++)
        //    {
        //        pairList.Add(new Pair { left = start[i], right = start[i + 1] });
        //    }

        //    for (var i = 2; i < lines.Length; i++)
        //    {
        //        var lin = lines[i].Split(" -> ");
        //        dic.Add(lin[0], lin[1].ToCharArray()[0]);
        //    }

        //    for (int i = 0; i < 40; i++)
        //    {
        //        long count = pairList.Count;
        //        for (int item = 0; item < count; item++)
        //        {
        //            pairList[item].Clone();
        //        }
        //        var counts = pairList.GroupBy(x => x)
        //       .ToDictionary(g => g.Key, g => g.Count());
        //        Console.WriteLine($" stage 1 impl1 iterationa {i} : {counts.Values.Max() - counts.Values.Min()}");

        //    }

        //}
    }
    class Pair
    {
        public string value { get { return string.Empty + left + right; } }

        public char left { get; set; }
        public char right { get; set; }
        public int count { get; set; }
        public void Clone()
        {
            //var valu = Program.dic[value];
            //Program.pairList.Add(new Pair() { left = valu, right = right });
            //right = valu;
        }

    }
}
