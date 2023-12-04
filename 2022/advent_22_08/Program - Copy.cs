//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace advent_22_04
//{
//    class Program
//    {
//        static List<Pointt> points = new List<Pointt>();

//        static void Main(string[] args)
//        {
//            var file = File.OpenText("test.txt");
//            file = File.OpenText("dane.txt");
//            string s = "";
//            int row = 0;
//            int dim = 0;
//            List<string> lines = new List<string>();

//            while ((s = file.ReadLine()) != null)
//            {
//                lines.Add(s);
//                if (dim == 0)
//                {
//                    dim = s.Length - 1;
//                }
//                int max = -1;
//                for (int col = 0; col < s.Length; col++)
//                {
//                    var hei = int.Parse(s[col].ToString());
//                    if (row == 0 || row == dim)
//                    {
//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        pointsAdd(row, col, hei);
//                    }
//                    else
//                    if (s[col] == '9')
//                    {
//                        pointsAdd(row, col, hei);
//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        break;
//                    }
//                    else
//                        if (hei > max)
//                    {
//                        max = hei;
//                        pointsAdd(row, col, hei);
//                    }
//                }
//                max = -1;
//                for (int col = dim; col >= 0; col--)
//                {
//                    var hei = int.Parse(s[col].ToString());
//                    if (row == 0 || row == dim)
//                    {
//                        pointsAdd(row, col, hei);

//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                    }
//                    else
//                    if (s[col] == '9')
//                    {
//                        pointsAdd(row, col, hei);

//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        break;
//                    }
//                    else
//                        if (hei > max)
//                    {
//                        max = hei;
//                        pointsAdd(row, col, hei);
//                    }
//                }

//                row++;

//            }

//            var cols = TransposeRowsToColumns(lines);
//            row = 0;
//            foreach (var item in cols)
//            {
//                int max = -1;
//                for (int col = 0; col < item.Length; col++)
//                {
//                    var hei = int.Parse(item[col].ToString());
//                    if (row == 0 || row == dim)
//                    {
//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        pointsAdd(col, row, hei);
//                    }
//                    else
//                    if (item[col] == '9')
//                    {
//                        pointsAdd(col, row, hei);
//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        break;
//                    }
//                    else
//                        if (hei > max)
//                    {
//                        max = hei;
//                        pointsAdd(col, row, hei);
//                    }
//                }
//                max = -1;
//                for (int col = dim; col >= 0; col--)
//                {
//                    var hei = int.Parse(item[col].ToString());
//                    if (row == 0 || row == dim)
//                    {
//                        pointsAdd(col, row, hei);

//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                    }
//                    else
//                    if (item[col] == '9')
//                    {
//                        pointsAdd(col, row, hei);

//                        //points.Add(new Pointt { row = row, col = col, hei = int.Parse(s[col].ToString()) });
//                        break;
//                    }
//                    else
//                        if (hei > max)
//                    {
//                        max = hei;
//                        pointsAdd(col, row, hei);
//                    }
//                }
//                row++;
//            }
//            static void pointsAdd(int row, int col, int hei)
//            {

//                var p = points.FirstOrDefault(p => p.row == row && p.col == col);
//                if (p == null)
//                {
//                    points.Add(new Pointt { row = row, col = col, hei = hei });
//                }
//                else
//                {


//                }

//            }
//            static List<string> TransposeRowsToColumns(List<string> rows)
//            {
//                List<string> result = new List<string>();

//                StringBuilder columnBuilder = new StringBuilder();

//                for (int columnIndex = 0; columnIndex < rows[0].Length; columnIndex++)
//                {
//                    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
//                    {
//                        columnBuilder.Append(rows[rowIndex][columnIndex]);
//                    }
//                    string ro = columnBuilder.ToString();

//                    if (ro != string.Empty)
//                    {
//                        result.Add(ro);
//                    }

//                    columnBuilder.Clear();
//                }

//                return result;
//            }

//            Console.ReadLine();
//        }
//        class Pointt
//        {
//            public int row, col, beenUsed, hei;
//            public override string ToString()
//            {
//                return $"{row}.{col} | {hei}";
//            }

//        }
//    }
//}
