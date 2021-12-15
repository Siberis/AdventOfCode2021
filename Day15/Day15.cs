using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public static class Day15
    {
        public static int Star1(string[] input)
        {
            var graph = new Dictionary<(int, int), Dictionary<(int, int), int>>();
            PrepareGraph(input, graph);
            return Dijkstra(input.Length, graph);
        }

        public static int Star2(string[] input)
        {
            var graph = new Dictionary<(int, int), Dictionary<(int, int), int>>();
            var newInput = new int[input.Length * 5, input.Length * 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int x = 0; x < input.Length; x++)
                    {
                        for (int y = 0; y < input[x].Length; y++)
                        {
                            var d = input[x][y] - '0' + i + j;
                            while (d > 9)
                            {
                                d -= 9;
                            }
                            newInput[(i * input.Length) + x, (j * input.Length) + y] = d;
                        }
                    }
                }
            }
            PrepareGraph(newInput, graph, input.Length * 5);
            return Dijkstra(input.Length * 5, graph);
        }

        private static int Dijkstra(int inputLength, Dictionary<(int, int), Dictionary<(int, int), int>> graph)
        {
            var dist = new int[graph.Count];
            var queue = new List<(int, int, int)>();
            for (int i = 0; i < graph.Count; i++)
            {
                var x = i / inputLength;
                var y = i % inputLength;
                dist[i] = int.MaxValue;
            }
            queue.Add((0, 0, 0));
            dist[0] = 0;
            while (queue.Count > 0)
            {
                var minx = queue.MinBy(e => dist[e.Item3]);
                var index = queue.IndexOf(minx);
                var min = dist[minx.Item3];
                queue.RemoveAt(index);
                var x = minx.Item3 / inputLength;
                var y = minx.Item3 % inputLength;
                foreach (var neig in graph[(x, y)])
                {
                    var dist2 = min + neig.Value;
                    int idx = (neig.Key.Item1 * inputLength) + neig.Key.Item2;
                    if (dist2 < dist[idx])
                    {
                        dist[idx] = dist2;
                        queue.Add((neig.Key.Item1, neig.Key.Item2, idx));
                        if (idx == graph.Count - 1)
                        {
                            return dist2;
                        }
                    }
                }
            }
            return dist[graph.Count - 1];
        }

        private static void PrepareGraph(string[] input, Dictionary<(int, int), Dictionary<(int, int), int>> graph)
        {
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input[x].Length; y++)
                {
                    graph[(x, y)] = new Dictionary<(int, int), int>();
                    if (x > 0)
                    {
                        graph[(x, y)][(x - 1, y)] = input[x - 1][y] - '0';
                    }
                    if (y > 0)
                    {
                        graph[(x, y)][(x, y - 1)] = input[x][y - 1] - '0';
                    }
                    if (x < input.Length - 1)
                    {
                        graph[(x, y)][(x + 1, y)] = input[x + 1][y] - '0';
                    }
                    if (y < input[x].Length - 1)
                    {
                        graph[(x, y)][(x, y + 1)] = input[x][y + 1] - '0';
                    }
                }
            }
        }


        private static void PrepareGraph(int[,] input, Dictionary<(int, int), Dictionary<(int, int), int>> graph, int length)
        {
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    graph[(x, y)] = new Dictionary<(int, int), int>();
                    if (x > 0)
                    {
                        graph[(x, y)][(x - 1, y)] = input[x - 1, y];
                    }
                    if (y > 0)
                    {
                        graph[(x, y)][(x, y - 1)] = input[x, y - 1];
                    }
                    if (x < length - 1)
                    {
                        graph[(x, y)][(x + 1, y)] = input[x + 1, y];
                    }
                    if (y < length - 1)
                    {
                        graph[(x, y)][(x, y + 1)] = input[x, y + 1];
                    }
                }
            }
        }


    }
}
