using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace advent_22_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            string s = "";
            List<string> rows = new List<string>();
            var moves = new List<string>();
            int mode = 0;
            /*
             move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
             */
            while ((s = file.ReadLine()) != null)
            {
                if (mode == 0)
                {
                    if (s == string.Empty)
                    {
                        mode = 1;
                        continue;
                    }
                    rows.Add(s);
                }
                else
                {
                    moves.Add(s);

                }

            }


            List<Stack<char>> stacks = new List<Stack<char>>();
            stacks.Add(new Stack<char>());
            var res = TransposeRowsToColumns(rows);
            foreach (var item in res)
            {
                Stack<char> q1 = new Stack<char>();
                var new1 = item.Reverse<char>().ToArray();
                for (int i = 1; i < new1.Length; i++)
                {
                    q1.Push(new1[i]);
                }
                stacks.Add(q1);
            }
            
            //foreach (var move in moves)
            //{
            //    var spl = move.Split(' ');
            //    int _howmuch = int.Parse(spl[1]);
            //    int _from = int.Parse(spl[3]);
            //    int _to = int.Parse(spl[5]);
            //    for (int i = 0; i < _howmuch; i++)
            //    {
            //        stacks[_to].Push(stacks[_from].Pop());
            //    }

            //}
            //foreach (var item in stacks)
            //{
            //    if (item.Count == 0)
            //    {
            //        continue;
            //    }
            //    Console.Write(item.Pop());
            //}
            
            foreach (var move in moves)
            {
                var spl = move.Split(' ');
                int _howmuch = int.Parse(spl[1]);
                int _from = int.Parse(spl[3]);
                int _to = int.Parse(spl[5]);

                Stack<char> temp = new Stack<char>();

                for (int i = 0; i < _howmuch; i++)
                {
                    temp.Push(stacks[_from].Pop());
                }
                for (int i = 0; i < _howmuch; i++)
                {
                    stacks[_to].Push(temp.Pop());
                }

            }
            foreach (var item in stacks)
            {
                if (item.Count == 0)
                {
                    continue;
                }
                Console.Write(item.Pop());
            }

            Console.ReadLine();
        }


        static List<string> TransposeRowsToColumns(List<string> rows)
        {
            List<string> result = new List<string>();

            StringBuilder columnBuilder = new StringBuilder();

            for (int columnIndex = 0; columnIndex < rows[0].Length; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    columnBuilder.Append(rows[rowIndex][columnIndex]);
                }
                string ro = columnBuilder.ToString().Replace(" ", "").Replace("[", "").Replace("]", "");

                if (ro != string.Empty)
                {
                    result.Add(ro);
                }

                columnBuilder.Clear();
            }

            return result;
        }
    }



}
    