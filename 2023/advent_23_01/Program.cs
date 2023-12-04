using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_01
{
    class Program
    {
        static string[] numbs = new string[]
        {
            " ", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine"
        }.ToArray();

        static void Main(string[] args)
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var numbers = new List<long>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                var s1 = s;

                var st = ReplaceFirstOccurrence(s);
                var ed = ReplaceLastOccurrence(s);
                var val = st.Where(c => char.IsDigit(c)).ToArray();
                var val2 = ed.Where(c => char.IsDigit(c)).ToArray();
                var vaInt = $"{val[0]}{val2[val2.Length - 1]}";
 
                numbers.Add(int.Parse(vaInt));
            }

            Console.WriteLine(numbers.Sum());
        }

        private static string ReplaceLastOccurrence(string source)
        {
            string value = "";
            int place1 = -1;
            foreach (var str in numbs)
            {
                if (source.LastIndexOf(str) > place1)
                {
                    place1 = source.LastIndexOf(str);
                    value = str;
                }
            }

            if (place1 == -1)
                return source;

            return source.Remove(place1, value.Length).Insert(place1, Array.IndexOf(numbs, value).ToString());
        }

        private static string ReplaceFirstOccurrence(string source)
        {
            string value = "";
            int place1 = int.MaxValue;
            foreach (var str in numbs)
            {
                if (source.IndexOf(str) > -1 && source.IndexOf(str) < place1)
                {
                    place1 = source.IndexOf(str);
                    value = str;
                }
            }

            if (place1 == int.MaxValue)
                return source;

            return source.Remove(place1, value.Length).Insert(place1, Array.IndexOf(numbs, value).ToString());
        }
    }
}using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_01
{
    class Program
    {
        static string[] numbs = new string[]
        {
            " ", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine"
        }.ToArray();

        static void Main(string[] args)
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var numbers = new List<long>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                var s1 = s;

                var st = ReplaceFirstOccurrence(s);
                var ed = ReplaceLastOccurrence(s);
                var val = st.Where(c => char.IsDigit(c)).ToArray();
                var val2 = ed.Where(c => char.IsDigit(c)).ToArray();
                var vaInt = $"{val[0]}{val2[val2.Length - 1]}";
 
                numbers.Add(int.Parse(vaInt));
            }

            Console.WriteLine(numbers.Sum());
        }

        private static string ReplaceLastOccurrence(string source)
        {
            string value = "";
            int place1 = -1;
            foreach (var str in numbs)
            {
                if (source.LastIndexOf(str) > place1)
                {
                    place1 = source.LastIndexOf(str);
                    value = str;
                }
            }

            if (place1 == -1)
                return source;

            return source.Remove(place1, value.Length).Insert(place1, Array.IndexOf(numbs, value).ToString());
        }

        private static string ReplaceFirstOccurrence(string source)
        {
            string value = "";
            int place1 = int.MaxValue;
            foreach (var str in numbs)
            {
                if (source.IndexOf(str) > -1 && source.IndexOf(str) < place1)
                {
                    place1 = source.IndexOf(str);
                    value = str;
                }
            }

            if (place1 == int.MaxValue)
                return source;

            return source.Remove(place1, value.Length).Insert(place1, Array.IndexOf(numbs, value).ToString());
        }
    }
}