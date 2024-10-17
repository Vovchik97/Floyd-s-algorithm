using System;
using System.Collections.Generic;

namespace AiSD_Lab_6
{
    class Program
    {
        const int INF = 99999;

        static void Main(string[] args)
        {
            int V = 7;
            int[,] graph = {
                { 0, 5, 3, INF, INF, INF, INF },         //1
                      { 5, 0, 1, 5, 2, INF, INF },       //2
                      { 3, 1, 0, 7, INF, INF, 12 },      //3
                      { INF, 5, 7, 0, 3, 1, 3 },         //4
                      { INF, 2, INF, 3, 0, 1, INF },     //5
                      { INF, INF, INF, 1, 1, 0, 4 },     //6
                      { INF, INF, 12, 3, INF, 4, 0 }     // 7
            };

            int[,] dist = new int[V, V];
            int[,] next = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                    next[i, j] = j;
                }
            }

            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            Console.WriteLine("Матрица кратчайших путей:");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Наикратчайшие пути:");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (i != j)
                    {
                        Console.Write("Из вершины " + (i + 1) + " в вершину " + (j + 1) + ": ");
                        PrintPath(next, i, j);
                        Console.WriteLine();
                    }
                }
            }
        }

        static void PrintPath(int[,] next, int u, int v)
        {
            int[] path = new int[1] { u };
            while (u != v)
            {
                u = next[u, v];
                Array.Resize(ref path, path.Length + 1);
                path[path.Length - 1] = u;
            }

            for (int i = 0; i < path.Length; i++)
            {
                if (i == path.Length - 1)
                {
                    Console.Write((path[i] + 1));
                }
                else
                {
                    Console.Write((path[i] + 1) + " -> ");
                }
            }
        }
    }
}