using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public static class Day5
    {
        public static int Star1(string[] input)
        {
            var map = new int[1000, 1000];
            foreach (var line in input)
            {
                var coords = line.Split(" -> ");
                var from = coords[0].Split(',').Select(e => int.Parse(e)).ToArray();
                var to = coords[1].Split(',').Select(e => int.Parse(e)).ToArray();
                if (from[0] != to[0] && from[1] != to[1])
                {
                    continue;
                }
                if (from[0] == to[0])
                {
                    int min = Math.Min(from[1], to[1]);
                    int max = Math.Max(from[1], to[1]);
                    for (int i = min; i <= max; i++)
                    {
                        map[from[0], i]++;
                    }
                }
                else
                {
                    int min = Math.Min(from[0], to[0]);
                    int max = Math.Max(from[0], to[0]);
                    for (int i = min; i <= max; i++)
                    {
                        map[i, from[1]]++;
                    }
                }
            }
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (map[i, j] > 1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        public static int Star2(string[] input)
        {

            var map = new int[1000, 1000];
            foreach (var line in input)
            {
                var coords = line.Split(" -> ");
                var from = coords[0].Split(',').Select(e => int.Parse(e)).ToArray();
                var to = coords[1].Split(',').Select(e => int.Parse(e)).ToArray();
                if (from[0] == to[0])
                {
                    int min = Math.Min(from[1], to[1]);
                    int max = Math.Max(from[1], to[1]);
                    for (int i = min; i <= max; i++)
                    {
                        map[from[0], i]++;
                    }
                }
                else if (from[1] == to[1])
                {
                    int min = Math.Min(from[0], to[0]);
                    int max = Math.Max(from[0], to[0]);
                    for (int i = min; i <= max; i++)
                    {
                        map[i, from[1]]++;
                    }
                }
                else
                {
                    if (Math.Abs(from[0] - to[0]) != Math.Abs(from[1] - to[1]))
                    {
                        continue;
                    }
                    var diffX = from[0] - to[0];
                    var diffY = from[1] - to[1];
                    for (int i = 0, j = 0; i <= Math.Abs(diffX); i++, j++)
                    {
                        var x = diffX > 0 ? (from[0] - i) : (from[0] + i);
                        var y = diffY > 0 ? (from[1] - j) : (from[1] + j);
                        map[x, y]++;
                    }
                }
            }
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (map[i, j] > 1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}
