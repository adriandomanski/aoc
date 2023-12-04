using System;
using System.Collections.Generic;
using System.IO;

namespace _04
{
    class Program
    {
        static List<Card> cards = new List<Card>();
        static string[] listalosow;
        static void Main(string[] args)
        {
            var dane = File.ReadAllLines("dane.txt");
            listalosow = dane[0].Split(",");

            for (var i = 2; i < dane.Length; i++)
            {
                if (dane[i] != "")
                {
                    var card = new Card();
                    card.AddRow(dane[i]);
                    card.AddRow(dane[i + 1]);
                    card.AddRow(dane[i + 2]);
                    card.AddRow(dane[i + 3]);
                    card.AddRow(dane[i + 4]);
                    cards.Add(card);
                    i += 4;
                }
            }

            startGame();
        }
        static void startGame()
        {
            foreach (var item in listalosow)
            {
                foreach (var card in cards)
                {
                    card.SetNumber(item);
                    if (card.IsBingo() && !card.Won)
                    {
                        Console.WriteLine("Bingo " + cards.IndexOf(card));
                        card.Calc(int.Parse(item));
                        card.Won = true;
                    }
                }
            }
        }

        class Card
        {
            public bool Won = false;
            List<string> dane = new List<string>();
            List<int> called = new List<int>();
            string[,] liczby = new string[5, 5];
            int row = 0;
            int col = 0;
            public void AddRow(string rowData)
            {
                col = 0;
                List<string> vvv = new List<string>(rowData.Split(" "));
                vvv.RemoveAll(s => s == "" || s == " ");

                foreach (var item in vvv)
                {
                    liczby[row, col] = item;
                    col++;
                }
                row++;
            }

            public void SetNumber(string num)
            {
                for (var i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (liczby[i, j] == num)
                        {
                            liczby[i, j] = string.Empty;
                            called.Add(int.Parse(num));
                        }
                    }
                }
            }

            public void Calc(int lastNum)
            {
                int NonCalledSUm = 0;
                for (var i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int curren = 0;
                        if (int.TryParse(liczby[i, j], out curren))
                        {
                            NonCalledSUm += curren;
                        }
                    }
                }
                int calledSUm = 0;
                foreach (var item in called)
                {
                    calledSUm += item;
                }
                Console.WriteLine("lastNum :" + lastNum);
                Console.WriteLine("NonCalledSUm :" + NonCalledSUm);
                Console.WriteLine("Stage1 " + lastNum * NonCalledSUm);
            }
            public void Print()
            {

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(string.Format("{0} |", liczby[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
            }
            public bool IsBingo()
            {

                for (var i = 0; i < 5; i++)
                {
                    if (
                        liczby[1, i] == string.Empty &&
                        liczby[2, i] == string.Empty &&
                        liczby[3, i] == string.Empty &&
                        liczby[4, i] == string.Empty &&
                        liczby[0, i] == string.Empty
                     )
                    {
                        return true;
                    }
                }
                for (var i = 0; i < 5; i++)
                {
                    if (
                        liczby[i, 1] == string.Empty &&
                        liczby[i, 2] == string.Empty &&
                        liczby[i, 3] == string.Empty &&
                        liczby[i, 4] == string.Empty &&
                        liczby[i, 0] == string.Empty
                     )
                    {
                        return true;
                    }
                }

                return false;

            }
        }
    }
}
