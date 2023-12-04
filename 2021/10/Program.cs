using System;
using System.Collections.Generic;
using System.IO;

namespace advent
{
    class Program
    {

        static List<long> scores = new List<long>();
        static void Main(string[] args)
        {
            var dane = File.ReadAllLines("dane.txt");
            string badSign = "";
            foreach (var item in dane)
            {
                var itt =  BadGuy(item);
                badSign +=itt;
                if (itt == string.Empty)
                {
                    MissingSigns(item);
                }
            }
            Console.WriteLine("Stage1: " + Score(badSign));

            scores.Sort();
            Console.WriteLine("Stage2: " + scores[(int)scores.Count / 2]);

        }

        private static void MissingSigns(string item)
        {
            string missing = "";
            Dictionary<char, char> pair = new Dictionary<char, char>();
            pair.Add('[', ']');
            pair.Add('{', '}');
            pair.Add('<', '>');
            pair.Add('(', ')');

            item = BadGuyRemoved(item);
            foreach (var left in item)
            {
                missing = pair[left] + missing;
            }
            Console.WriteLine(missing);

            /*
                Start with a total score of 0.
                Multiply the total score by 5 to get 0, then add the value of ] (2) to get a new total score of 2.
                Multiply the total score by 5 to get 10, then add the value of ) (1) to get a new total score of 11.
                Multiply the total score by 5 to get 55, then add the value of } (3) to get a new total score of 58.
                Multiply the total score by 5 to get 290, then add the value of > (4) to get a new total score of 294.
            */
            long score = 0;
            foreach (var right in missing)
            {
                if (right == ']')
                {
                    score *= 5; score += 2;
                }
                if (right == ')')
                {
                    score *= 5; score += 1;
                }
                if (right == '}')
                {
                    score *= 5; score += 3;
                }
                if (right == '>')
                {
                    score *= 5; score += 4;
                }
            }
            scores.Add(score);
        }

        private static int Score(string badSign)
        {
            int score = 0;
            foreach (var item in badSign)
            {
                /*
                    ): 3 points.
                    ]: 57 points.
                    }: 1197 points.
                    >: 25137 points.
                */
                if (item == ')')
                {
                    score += 3;
                }
                if (item == ']')
                {
                    score += 57;
                }
                if (item == '}')
                {
                    score += 1197;
                }
                if (item == '>')
                {
                    score += 25137;
                }
            }
            return score;
        }

        private static string BadGuy(string item)
        {
            bool removed = false;
            do
            {
                item = ReplaceCorrect(item, out removed);
            } while (removed);

            int index = int.MaxValue;
            foreach (var right in "}]>)")
            {
                int rIndex = item.IndexOf(right);
                if (rIndex < index && rIndex > -1)
                {
                    index = rIndex;
                }
            }
            var result = index < item.Length ? item[index].ToString() : string.Empty;

            return result;
        }

        private static string BadGuyRemoved(string item)
        {
            bool removed = false;
            do
            {
                item = ReplaceCorrect(item, out removed);
            } while (removed);

            return item;
        }

        private static string ReplaceCorrect(string item, out bool removed)
        {
            int l1 = item.Length;
            string cleaned = item.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");
            removed = l1 != cleaned.Length;
            return cleaned;
        }
    }
}
