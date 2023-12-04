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
            Puzzle(); 
        }

        private static List<Card> cards = new List<Card>();

        private static List<Card> cards2part = new List<Card>();

        class Card
        {
            public Card(string line)
            {
                line = line.Replace("Card ", "");
                cardNo = int.Parse(line.Split(":".Replace(" ", ""))[0]);
                var gamess = line.Split(":")[1];

                foreach (var number in gamess.Split('|')[0].Split(" "))
                {
                    var tmp = number.Replace(" ", "");
                    if (int.TryParse(tmp, out int value))
                    {
                        winning.Add(value);
                    }
                }

                foreach (var number in gamess.Split('|')[1].Split(" "))
                {
                    var tmp = number.Replace(" ", "");
                    if (int.TryParse(tmp, out int value))
                    {
                        numbers.Add(value);
                    }
                }

                var pointss =
                    (from wi in winning
                        select wi)
                    .Intersect
                    (from nu in numbers
                        select nu).ToList();
                
                int pointsValue = 0;
                
                if (pointss.Any())
                {
                    pointsValue = 1;
                    for (int i = 1; i < pointss.Count(); i++)
                    {
                        pointsValue *= 2;
                    }

                    winningNumber = pointss.Count();
                }

                points = pointsValue;

                Console.WriteLine($"cardno: {cardNo} points{pointsValue}");
            }

            public long points;
            public long winningNumber;

            public int cardNo;
            public List<int> winning = new List<int>();
            public List<int> numbers = new List<int>();

            public override string ToString()
            {
                return "" + cardNo;
            }
        }


        private static void Puzzle()
        {
            StreamReader file;
            file = File.OpenText("test.txt");
            file = File.OpenText("dane.txt");
            var lines = new List<string>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                cards.Add(new Card(s));
                lines.Add(s);
            }

            foreach (var card in cards)
            {
                if (card.points > 0)
                {
                    GetWinningCards(card);
                }
            }


            cards2part = cards2part.OrderBy(_ => _.cardNo).ToList();

            Console.WriteLine("Part1 " + cards.Sum(_ => _.points));
            Console.WriteLine("Part2 " + (cards2part.Count() + cards.Count()));
        }

        private static void GetWinningCards(Card card)
        {
            if (card.points > 0)
            {
                for (int i = 1; i <= card.winningNumber; i++)
                {
                    var c = cards.Single(_ => _.cardNo == card.cardNo + i);
                    cards2part.Add(c);
                    GetWinningCards(c);
                }
            }
        }
 
    }
}