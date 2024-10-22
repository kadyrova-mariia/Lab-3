using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Algorithms graph = new Algorithms(6);

            // a, b, c, d, e, f
            // 0, 1, 2, 3, 4, 5 

            // Додаємо ребра з вагами
            graph.AddEdge(0, 1, 5); // a -> b
            graph.AddEdge(0, 2, 5); // a -> c
            graph.AddEdge(0, 4, 12); // a -> e
            graph.AddEdge(0, 5, 10); // a -> f
            graph.AddEdge(1, 3, 5); // b -> d
            graph.AddEdge(1, 4, 3); // b -> e
            graph.AddEdge(2, 5, 3); // c -> f
            graph.AddEdge(3, 4, 5); // d -> e
            graph.AddEdge(4, 5, 5); // e -> f

            Console.WriteLine("Список ребер з вагами:");
            string[] vertexNames = { "a", "b", "c", "d", "e", "f" };
            foreach (var (from, to, weight) in graph.GetEdges())
            {
                Console.WriteLine($"{vertexNames[from]} -> {vertexNames[to]} з вагою {weight}");
            }
            Console.WriteLine();

            Console.WriteLine("Алгоритм Дейкстри:");
            graph.Dekstra(0);

            Console.WriteLine("\nАлгоритм Флойда:");
            graph.Floyd();

            Console.ReadKey();

        }
    }
}
