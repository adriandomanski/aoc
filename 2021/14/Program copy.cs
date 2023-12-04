// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.IO;
// using System.Linq;

// namespace _14
// {
//     class Program12
//     {
//         public static Dictionary<string, char> dic = new Dictionary<string, char>();

//         public static List<Pair> pairList = new List<Pair>();
//         public static List<Pair> pairList2 = new List<Pair>();
//         static List<char> valueList;
//         static List<char> tmplist;
//         static void Main(string[] args)
//         {
//             var lines = File.ReadAllLines("data.txt");
//             string start = lines[0];

//             for (var i = 0; i < start.Length - 1; i++)
//             {
//                 pairList.Add(new Pair { left = start[i].ToString(), right = start[i + 1].ToString(), count = 1 });
//             }

//             for (var i = 2; i < lines.Length; i++)
//             {
//                 var lin = lines[i].Split(" -> ");
//                 dic.Add(lin[0], lin[1].ToCharArray()[0]);
//             }

//             for (int i = 0; i < 40; i++)
//             {
//                 Stopwatch sw = new Stopwatch();
//                 sw.Start();
//                 long count = pairList.Count;
//                 for (int item = 0; item < count; item++)
//                 {
//                     pairList[item].Clone();
//                 }
//                 pairList.Clear();
//                 pairList.AddRange(pairList2.GroupBy(p => p.value).Select(p => new Pair { left = p.Key[0].ToString(), right = p.Key[1].ToString(), count = p.Sum(x => x.count) }));
//                 pairList2.Clear();
//                 sw.Stop();
//                 Console.WriteLine($"{i}: {sw.Elapsed.TotalSeconds}");
//             }
//             long count2 = pairList.Count;
//             for (int item = 0; item < count2; item++)
//             {
//                 pairList[item].Split();
//             }

//             var listt = pairList2.GroupBy(p => p.value).Select(p => new Pair { left = p.Key[0].ToString(), count = p.Sum(x => x.count) }).ToList();


//             Console.WriteLine($" stage 1 : {listt.Max(p => p.count) - listt.Min(p => p.count) }");
 

//         }

//     }
//     class Pair12
//     {
//         public string value
//         {
//             get { return left + right; }
//         }

//         public string left { get; set; }
//         public string right { get; set; }
//         public decimal count { get; set; }
//         public void Clone()
//         {
//             var dictionaryValue = Program.dic[value];
//             string one = string.Empty + dictionaryValue + right;
//             string two = string.Empty + left + dictionaryValue;
//             decimal tmpcount = count;

//             Program.pairList2.Add(new Pair { left = dictionaryValue.ToString(), right = right, count = tmpcount });

//             Program.pairList2.Add(new Pair { left = left, right = dictionaryValue.ToString(), count = tmpcount });

//         }

//         public void Split()
//         {
//             Program.pairList2.Add(new Pair { left = right, count = count });

//             Program.pairList2.Add(new Pair { left = left, count = count });
//         }
//         public override string ToString()
//         {
//             return $"{value} : {count}";
//         }
//     }
// }
