using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("dane.txt");
            string s = "";
            List<string> list = new List<string>();
            List<string> listInput = new List<string>();
            List<string> listOutput = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                list.AddRange(s.Split("|").Last().Split(" "));
                listInput.Add(s.Split("|").First());

                listOutput.Add(s.Split("|").Last());
            }

            Console.WriteLine("Stage1 " + list.Count(x => x.Length == 2 | x.Length == 3 || x.Length == 4 || x.Length == 7));

            List<int> mappingsList = new List<int>();

            for (int i = 0; i < listInput.Count; i++)
            {
                var input = listInput[i];
                var res = new ResolverDigit(input.Split(" ").ToList());

                Dictionary<string, int> mappings = new Dictionary<string, int>();
                mappings.Add("abcdefg", 8);    //acedgfb: 8  
                mappings.Add(String.Concat((res.seg1 + res.seg2 + res.seg4 + res.seg6 + res.seg7).OrderBy(c => c)), 5);  //cdfbe: 5    
                mappings.Add(String.Concat((res.seg1 + res.seg3 + res.seg4 + res.seg5 + res.seg7).OrderBy(c => c)), 2);  //gcdfa: 2    
                mappings.Add(String.Concat((res.seg1 + res.seg3 + res.seg4 + res.seg6 + res.seg7).OrderBy(c => c)), 3);  //fbcad: 3    
                mappings.Add(String.Concat((res.seg1 + res.seg3 + res.seg6).OrderBy(c => c)), 7);   //dab: 7      
                mappings.Add(String.Concat((res.seg1 + res.seg2 + res.seg3 + res.seg4 + res.seg6 + res.seg7).OrderBy(c => c)), 9);  //cefabd: 9   
                mappings.Add(String.Concat((res.seg1 + res.seg2 + res.seg4 + res.seg5 + res.seg6 + res.seg7).OrderBy(c => c)), 6);  //cdfgeb: 6   
                mappings.Add(String.Concat((res.seg2 + res.seg3 + res.seg4 + res.seg6).OrderBy(c => c)), 4);//eafb: 4     
                mappings.Add(String.Concat((res.seg1 + res.seg2 + res.seg3 + res.seg5 + res.seg6 + res.seg7).OrderBy(c => c)), 0);  //cagedb: 0   
                mappings.Add(String.Concat((res.seg3 + res.seg6).OrderBy(c => c)), 1);  //ab: 1    
       
                string newNumber = "";
                foreach (var number in listOutput[i].Split(" "))
                {
                    if (string.IsNullOrEmpty(number))
                    {
                        continue;
                    }
                    newNumber += mappings[String.Concat(number.OrderBy(c => c))];
                }
                mappingsList.Add(int.Parse(newNumber));
            }

            Console.WriteLine("Stage2 " + mappingsList.Sum());
        }
        class ResolverDigit
        {
            public string seg1 = "", seg2, seg3, seg4 = "", seg5, seg6, seg7 = "";

            List<string> values = new List<string>();
            public ResolverDigit(List<string> val)
            {
                values.AddRange(val.Where(x => x != string.Empty));
                var valueof1 = (values.First(x => x.Length == 2));
                seg1 = values.Where(x => x.Length == 3).First().Replace(valueof1[0].ToString(), "").Replace(valueof1[1].ToString(), "");

                //seg7
                foreach (var word in values.Where(x => x.Length == 6 && doSth(x) == 1))
                {
                    string newWord = word;
                    foreach (var item in GetLetters(3).Union(GetLetters(2)).Union(GetLetters(4)).ToList())
                    {
                        newWord = newWord.Replace(item.ToString(), "");
                    }
                    seg7 = newWord;
                }
                // seg 4
                seg4 = values.First(
                        x => x.Length == 5
                        && x.Contains(seg7)
                        && x.Contains(seg1)
                        && x.Contains(valueof1[0])
                        && x.Contains(valueof1[1])
                    )
                    .Replace(seg1, "")
                    .Replace(seg7, "")
                    .Replace(valueof1[0].ToString(), "")
                    .Replace(valueof1[1].ToString(), "");


                // seg2 "eafb"
                seg2 = values.Where(x => x.Length == 4).First()
                    .Replace(seg4, "")
                    .Replace(valueof1[0].ToString(), "")
                    .Replace(valueof1[1].ToString(), "");
                //seg5
                seg5 = values.Where(x => x.Length == 6 && !x.Contains(seg4)).First()
                    .Replace(seg2, "")
                    .Replace(seg1, "")
                    .Replace(seg7, "")
                    .Replace(valueof1[0].ToString(), "")
                    .Replace(valueof1[1].ToString(), "");


                //seg6
                seg6 = values.Where(x => x.Length == 6 && x.Contains(seg4) && x.Contains(seg5)).First()
                    .Replace(seg2, "")
                    .Replace(seg1, "")
                    .Replace(seg7, "")
                    .Replace(seg4, "")
                    .Replace(seg5, "");
                    
                //seg3
                seg3 = values.Where(x => x.Length == 2).First().Replace(seg6, "");
            }

            int doSth(string word)
            {
                int count = 0;
                foreach (var letter in word)
                {
                    if (!GetLetters(3).Union(GetLetters(2)).Union(GetLetters(4)).ToList().Contains(letter))
                    {
                        count++;
                    }
                }
                return count++;
            }

            char[] GetLetters(int len)
            {
                return values.First(x => x.Length == len).ToArray();
            }

        }
    }
}