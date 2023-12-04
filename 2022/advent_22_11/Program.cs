using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_22_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenText("test.txt");
            //var file = File.OpenText("test.txt");
            string s = "";
            var linesimple = new List<string>();
            int[,] graph = new int[5, 8];


            int index = 0;

            while ((s = file.ReadLine()) != null)
            {
                var arr = s.ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    graph[index, i] = arr[i];

                }
                index++;



            }


            DijkstraAlgo(graph, 0, 9);
            Console.ReadKey();
        }
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = 0;
            int minIndex = 0;
            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }
        public static void DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    try
                    {
                        if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v])
            && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                            distance[v]++;
                    }
                    catch (Exception)
                    {
                        //throw;
                    }

            }
            Print(distance, verticesCount);
        }
    }
}

