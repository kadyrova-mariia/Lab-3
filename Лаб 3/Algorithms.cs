using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_3
{
    internal class Algorithms
    {
        private int vertices;
        private List<(int, int, int)> edges; // Список ребер (from, to, weight)
        private string[] vertexNames = { "a", "b", "c", "d", "e", "f" }; // Назви вершин

        public Algorithms(int v)
        {
            vertices = v;
            edges = new List<(int, int, int)>();
        }
        public List<(int, int, int)> GetEdges()
        {
            return edges;
        }

        public void AddEdge(int from, int to, int weight)
        {
            edges.Add((from, to, weight));
        }

        public void Dekstra(int source)
        {
            int[] dist = new int[vertices];
            bool[] visited = new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[source] = 0;
            for (int i = 0; i < vertices - 1; i++)
            {
                int u = MinDistance(dist, visited);
                visited[u] = true;
                foreach (var (from, to, weight) in edges)
                {
                    if (from == u && !visited[to] && dist[u] != int.MaxValue && dist[u] + weight < dist[to])
                    {
                        dist[to] = dist[u] + weight;
                    }
                }
            }
            PrintDekstra(dist);
        }

        private int MinDistance(int[] dist, bool[] visited)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < vertices; v++)
            {
                if (!visited[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void PrintDekstra(int[] dist)
        {
            Console.WriteLine("Найкоротші відстані від вершини a:");
            for (int i = 0; i < dist.Length; i++)
                Console.WriteLine($"До вершини {vertexNames[i]}: {dist[i]}");
        }

        public void Floyd()
        {
            int[,] dist = new int[vertices, vertices];

            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    dist[i, j] = i == j ? 0 : int.MaxValue;
                }
            }
            foreach (var (from, to, weight) in edges)
            {
                dist[from, to] = weight;
            }
            for (int k = 0; k < vertices; k++)
            {
                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue 
                            && dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }
            PrintFloyd(dist);
        }

        private void PrintFloyd(int[,] dist)
        {
            Console.WriteLine("Матриця найкоротших відстаней:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (dist[i, j] == int.MaxValue)
                    {
                        Console.Write("INF".PadLeft(5));
                    }
                    else
                    {
                        Console.Write(dist[i, j].ToString().PadLeft(5));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
