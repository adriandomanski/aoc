//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace advent_01
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Day one");
//            var file = File.OpenText("dane.txt");
//            List<long> elves = new List<long>();
//            long point = 0;
//            string s;
//            while ((s = file.ReadLine()) != null)
//            {
//                //A for Rock, B for Paper, and C for Scissors
//                //X for Rock, Y for Paper, and Z for Scissors
//                if (s == "A X") { point += 3 + 1; continue; }
//                if (s == "A Y") { point += 6 + 2; continue; }
//                if (s == "A Z") { point += 0 + 3; continue; }
//                if (s == "B X") { point += 0 + 1; continue; }
//                if (s == "B Y") { point += 3 + 2; continue; }
//                if (s == "B Z") { point += 6 + 3; continue; }
//                if (s == "C X") { point += 6 + 1; continue; }
//                if (s == "C Y") { point += 0 + 2; continue; }
//                if (s == "C Z") { point += 3 + 3; continue; }
//            }
//            Console.WriteLine("stage one: " + point);


//            var file1 = File.OpenText("dane.txt");
//            long point1 = 0;
//            while ((s = file1.ReadLine()) != null)
//            {
//                //A for Rock, B for Paper, and C for Scissors
//                //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win
//                //1 for Rock, 2 for Paper, and 3 for Scissors)
//                if (s.EndsWith("X")) { point1 += 0; }
//                if (s.EndsWith("Y")) { point1 += 3; }
//                if (s.EndsWith("Z")) { point1 += 6; }
//                //rock
//                if (s == "A X") { point1 += 3 /*for Scissors*/; continue; }
//                if (s == "A Y") { point1 += 1 /*for Rock*/; continue; }
//                if (s == "A Z") { point1 += 2 /*for Paper*/; continue; }


//                //paper
//                if (s == "B X") { point1 += 1 /*for Rock*/    ; continue; }
//                if (s == "B Y") { point1 += 2 /*for Paper*/    ; continue; }
//                if (s == "B Z") { point1 += 3 /*for Scissors*/     ; continue; }

//                //scisors
//                if (s == "C X") { point1 += 2 /*for Paper*/    ; continue; }
//                if (s == "C Y") { point1 += 3 /*for Scissors*/    ; continue; }
//                if (s == "C Z") { point1 += 1 /*for Rock*/      ; continue; }




//            }
//            Console.WriteLine("stage two: " + point1);
//        }
//    }
//}
