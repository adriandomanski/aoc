using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent
{
    class Program
    {
        static void Main(string[] args)
        {
            //100101001101

            var file = File.OpenText("dane.txt");
            int[] values = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string s = "";
            List<string> list = new List<string>();

            while ((s = file.ReadLine()) != null)
            {
                string kierunek = s;
                int i = 0;
                list.Add(s);
                foreach (var item in s)
                {
                    if (item == '0')
                    {
                        values[i]--;
                    }
                    else
                    {
                        values[i]++;
                    }
                    i++;
                }
            }

            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 0)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            int gammaInt = Convert.ToInt32(gamma, 2);
            int epsilonInt = Convert.ToInt32(epsilon, 2);
            Console.WriteLine("gammaInt " + gammaInt);

            Console.WriteLine("epsilonInt " + epsilonInt);
            Console.WriteLine(gammaInt * epsilonInt);
            var oxygen = new List<string>();
            oxygen.AddRange(list);
            var co2 = new List<string>();
            co2.AddRange(list);

            var oxygenValue = "";
            var co2Value = "";

            for (int i = 0; i < 12; i++)
            {
                if (oxygen.Count == 1)
                {
                    oxygenValue = oxygen[0];
                    return;
                }
                if (oxygen.Count(s => s[i] == '0') > oxygen.Count / 2)
                {
                    oxygen = oxygen.Where(s => s[i] == '0').ToList();
                }
                else if (oxygen.Count(s => s[i] == '1') > oxygen.Count / 2)
                {
                    oxygen = oxygen.Where(s => s[i] == '1').ToList();
                }
                else
                {
                    oxygen = oxygen.Where(s => s[i] == '1').ToList();
                }
            }
            oxygenValue = oxygen[0];
            for (int i = 0; i < 12; i++)
            {
                if (co2.Count == 1)
                {
                    co2Value = co2[0];
                    break;
                }
                if (co2.Count(s => s[i] == '0') > co2.Count / 2)
                {
                    co2 = co2.Where(s => s[i] == '1').ToList();
                }
                else if (co2.Count(s => s[i] == '1') > co2.Count / 2)
                {
                    co2 = co2.Where(s => s[i] == '0').ToList();
                }
                else
                {
                    co2 = co2.Where(s => s[i] == '0').ToList();
                }
            }
            co2Value = co2[0];



            int oxygenInt = Convert.ToInt32(oxygenValue, 2);
            int co2Int = Convert.ToInt32(co2Value, 2);

            Console.WriteLine("oxygenInt " + oxygenInt);

            Console.WriteLine("co2Int " + co2Int);
            Console.WriteLine(oxygenInt * co2Int);

        }
    }
}