using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public static class Day6
    {
        public static long Star1(string[] input)
        {
            var list = input.Select(e => int.Parse(e)).ToList();
            var map = new Dictionary<int, long>();
            foreach (var l in list)
            {
                if (!map.ContainsKey(l))
                {
                    map.Add(l, 0);
                }
                map[l]++;
            }
            for (int i = 0; i < 80; i++)
            {
                var newMap = new Dictionary<int, long>();
                for (int j = 0; j < 9; j++)
                {
                    newMap[j - 1] = map.ContainsKey(j) ? map[j] : 0;
                }
                newMap.Add(8, newMap[-1]);
                newMap[6] += newMap[-1];
                map = newMap;
            }
            return Enumerable.Range(0, 9).Select(e => map[e]).Sum();
        }
        public static long Star2(string[] input)
        {
            var list = input.Select(e => int.Parse(e)).ToList();
            var map = new Dictionary<int, long>();
            foreach (var l in list)
            {
                if (!map.ContainsKey(l))
                {
                    map.Add(l, 0);
                }
                map[l]++;
            }
            for (int i = 0; i < 256; i++)
            {
                var newMap = new Dictionary<int, long>();
                for (int j = 0; j < 9; j++)
                {
                    newMap[j - 1] = map.ContainsKey(j) ? map[j] : 0;
                }
                newMap.Add(8, newMap[-1]);
                newMap[6] += newMap[-1];
                map = newMap;
            }
            return Enumerable.Range(0, 9).Select(e => map[e]).Sum();
        }
    }
}
