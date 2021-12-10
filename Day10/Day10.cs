using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public static class Day10
    {
        private static readonly Dictionary<char, char> pairs = new()
        {
            ['('] = ')',
            ['{'] = '}',
            ['['] = ']',
            ['<'] = '>',
        };
        public static int Star1(string[] input)
        {
            var mapping = new Dictionary<char, int>()
            {
                [')'] = 3,
                [']'] = 57,
                ['}'] = 1197,
                ['>'] = 25137,
            };
            var res = new List<char>();
            foreach (var line in input)
            {
                var stack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (pairs.ContainsKey(line[i]))
                    {
                        stack.Push(pairs[line[i]]);
                    }
                    else
                    {
                        if (stack.Peek() != line[i])
                        {
                            res.Add(line[i]);
                            break;
                        }
                        stack.Pop();
                    }
                }
            }
            return mapping.Select(m => res.Count(e => e == m.Key) * m.Value).Sum();
        }
        public static ulong Star2(string[] input)
        {
            var mapping = new Dictionary<char, ulong>()
            {
                [')'] = 1,
                [']'] = 2,
                ['}'] = 3,
                ['>'] = 4,
            };
            var scores = new List<ulong>();
            foreach (var line in input)
            {
                var skip = false;
                var stack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (pairs.ContainsKey(line[i]))
                    {
                        stack.Push(pairs[line[i]]);
                    }
                    else
                    {
                        if (stack.Peek() != line[i])
                        {
                            skip = true;
                            break;
                        }
                        stack.Pop();
                    }
                }
                if (skip)
                {
                    continue;
                }
                ulong sum = 0;
                foreach (var s in stack)
                {
                    sum *= 5;
                    sum += mapping[s];
                }
                scores.Add(sum);
            }
            scores.Sort();
            return scores[scores.Count / 2];
        }
    }
}
