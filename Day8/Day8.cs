using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public static class Day8
    {
        private static readonly Dictionary<int, char[]> LETTERS = new()
        {
            [0] = new char[] { 'a', 'b', 'c', 'e', 'f', 'g' },
            [1] = new char[] { 'c', 'f' },
            [2] = new char[] { 'a', 'c', 'd', 'e', 'g' },
            [3] = new char[] { 'a', 'c', 'd', 'f', 'g' },
            [4] = new char[] { 'b', 'c', 'd', 'f' },
            [5] = new char[] { 'a', 'b', 'd', 'f', 'g' },
            [6] = new char[] { 'a', 'b', 'd', 'e', 'f', 'g' },
            [7] = new char[] { 'a', 'c', 'f' },
            [8] = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' },
            [9] = new char[] { 'a', 'b', 'c', 'd', 'f', 'g' },
        };
        public static int Star1(List<(string[], string[])> input)
        {
            var res = 0;
            foreach (var example in input)
            {
                var learning = example.Item1;
                var mapping = new Dictionary<char, char>();
                GenerateMapping(learning, mapping, 8);

                foreach (var c in example.Item2)
                {
                    var x = "";
                    for (int j = 0; j < c.Length; j++)
                    {
                        x += mapping[c[j]];
                    }
                    var r = string.Join(',', x.OrderBy(e => e).ToArray());
                    Console.WriteLine(r);
                    if (x.Length == LETTERS[1].Length ||
                    x.Length == LETTERS[4].Length ||
                    x.Length == LETTERS[7].Length ||
                    x.Length == LETTERS[8].Length)
                    {
                        res++;
                    }
                }
            }
            return res;
        }

        private static void GenerateMapping(string[] learning, Dictionary<char, char> mapping, int letter)
        {
            var letters = learning.First(e => e.Length == LETTERS[letter].Length);
            for (int i = 0; i < letters.Length; i++)
            {
                mapping[letters[i]] = LETTERS[letter][i];
            }
        }

        public static int Star2(List<(string[], string[])> input)
        {
            var res = 0;
            var ALL_CHARS = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            foreach (var example in input)
            {
                var learning = example.Item1;
                var mapping = new Dictionary<char, char>();
                GenerateMapping(learning, mapping, 8);

                var check = example.Item2;
                var temp = 0;
                var list = new List<List<char>>();
                foreach (var perm in DoPermute(ALL_CHARS, 0, ALL_CHARS.Length - 1, list))
                {
                    for (int i = 0; i < ALL_CHARS.Length; i++)
                    {
                        mapping[perm[i]] = ALL_CHARS[i];
                    }
                    try
                    {
                        foreach (var c in learning)
                        {
                            CheckMapping(mapping, c);
                        }
                        temp = 0;
                        foreach (var c in check)
                        {
                            var num = CheckMapping(mapping, c);
                            temp *= 10;
                            temp += num;
                        }
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
                }

                res += temp;
            }
            return res;
        }

        private static int CheckMapping(Dictionary<char, char> mapping, string c)
        {
            var x = "";
            for (int j = 0; j < c.Length; j++)
            {
                x += mapping[c[j]];
            }
            var r = string.Join(',', x.OrderBy(e => e).ToArray());
            return Enumerable.Range(0, 10).First(i => r == string.Join(',', LETTERS[i]
                .OrderBy(e => e)
                .ToArray()));
        }

        private static List<List<char>> DoPermute(char[] nums, int start, int end, List<List<char>> list)
        {
            if (start == end)
            {
                list.Add(new List<char>(nums));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    DoPermute(nums, start + 1, end, list);
                    Swap(ref nums[start], ref nums[i]);
                }
            }

            return list;
        }
        static void Swap(ref char a, ref char b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
