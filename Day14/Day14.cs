using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public static class Day14
    {
        public static ulong Star1(string[] input)
        {
            return Calculate(input, 10);
        }
        public static ulong Star2(string[] input)
        {
            return Calculate(input, 40);
        }

        private static ulong Calculate(string[] input, int steps)
        {
            var pattern = input[0];
            var rules = input.Skip(2).Select(e => e.Split(" -> ")).ToDictionary(e => e[0], e => e[1]);
            var pattern2 = new Dictionary<string, ulong>();
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                var search = $"{pattern[i]}{pattern[i + 1]}";
                if (!pattern2.ContainsKey(search))
                {
                    pattern2[search] = 0;
                }
                pattern2[search]++;
            }
            for (int x = 0; x < steps; x++)
            {
                var xx = new Dictionary<string, ulong>();
                foreach (var pair in pattern2)
                {
                    if (rules.ContainsKey(pair.Key))
                    {
                        var c = rules[pair.Key];
                        string firstKey = $"{pair.Key[0]}{c}";
                        string seconKey = $"{c}{pair.Key[1]}";
                        if (!xx.ContainsKey(firstKey))
                        {
                            xx[firstKey] = 0;
                        }
                        xx[firstKey] += pair.Value;
                        if (!xx.ContainsKey(seconKey))
                        {
                            xx[seconKey] = 0;
                        }
                        xx[seconKey] += pair.Value;
                    }
                    else
                    {
                        if (!xx.ContainsKey(pair.Key))
                        {
                            xx[pair.Key] = 0;
                        }
                        xx[pair.Key] += pair.Value;
                    }
                }
                pattern2 = xx;
            }

            var res = new Dictionary<char, ulong>();
            foreach (var c in pattern2)
            {
                if (!res.ContainsKey(c.Key[0]))
                {
                    res[c.Key[0]] = 0;
                }
                res[c.Key[0]] += c.Value;
                if (!res.ContainsKey(c.Key[1]))
                {
                    res[c.Key[1]] = 0;
                }
                res[c.Key[1]] += c.Value;
            }
            return ((res.Values.Max() - 1) / 2) - ((res.Values.Min() - 1) / 2);
        }
    }
}
