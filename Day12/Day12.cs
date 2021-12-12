using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public static class Day12
    {
        public static int Star1(string[][] input)
        {
            var map = new Dictionary<string, List<string>>();
            var smallCaves = input.Select(e => e[0].ToLower()).ToHashSet();
            foreach (var v in input.Select(e => e[1].ToLower()).ToHashSet())
            {
                smallCaves.Add(v);
            }
            SetupMap(input, map);
            var result = new List<List<string>>();
            var start = "start";
            var queue = new Queue<(string, List<string>, HashSet<string>)>();
            queue.Enqueue((start, new List<string>() { "start" }, new HashSet<string>() { "start" }));
            while (queue.Count > 0)
            {
                var last = queue.Dequeue();
                var next = map[last.Item1];
                var visited = last.Item3;
                foreach (var n in next)
                {
                    if (n == "end")
                    {
                        var newList = last.Item2.ConvertAll(e => e);
                        newList.Add(n);
                        result.Add(newList);
                        continue;
                    }
                    if (!smallCaves.Contains(n) || (smallCaves.Contains(n) && !visited.Contains(n)))
                    {
                        var newList = last.Item2.ConvertAll(e => e);
                        newList.Add(n);
                        var newVisited = visited.Select(e => e).ToHashSet();
                        newVisited.Add(n);
                        queue.Enqueue((n, newList, newVisited));
                    }
                }
            }
            return result.Count;
        }

        private static void SetupMap(string[][] input, Dictionary<string, List<string>> map)
        {
            foreach (var i in input)
            {
                if (!map.ContainsKey(i[0]))
                {
                    map[i[0]] = new List<string>();
                }
                if (!map.ContainsKey(i[1]))
                {
                    map[i[1]] = new List<string>();
                }
                map[i[0]].Add(i[1]);
                map[i[1]].Add(i[0]);
            }
        }

        public static int Star2(string[][] input)
        {
            var map = new Dictionary<string, List<string>>();
            var smallCaves = input.Select(e => e[0].ToLower()).ToHashSet();
            foreach (var v in input.Select(e => e[1].ToLower()).ToHashSet())
            {
                smallCaves.Add(v);
            }
            SetupMap(input, map);
            var result = new List<List<string>>();
            var start = "start";
            var queue = new Queue<(string, List<string>, HashSet<string>, HashSet<string>, bool)>();
            queue.Enqueue((
                start,
                new List<string>() { "start" },
                new HashSet<string>() { "start" },
                new HashSet<string>() { "start" },
                false
              ));
            while (queue.Count > 0)
            {
                var last = queue.Dequeue();
                var next = map[last.Item1];
                var visited = last.Item3;
                var visited2 = last.Item4;
                var flag = last.Item5;
                foreach (var n in next)
                {
                    if (n == "start")
                    {
                        continue;
                    }
                    if (n == "end")
                    {
                        var newList = last.Item2.ConvertAll(e => e);
                        newList.Add(n);
                        result.Add(newList);
                        continue;
                    }
                    if (
                        !smallCaves.Contains(n)
                        || (!flag && smallCaves.Contains(n) && !visited2.Contains(n))
                        || (flag && smallCaves.Contains(n) && !visited.Contains(n))
                    )
                    {
                        var newList = last.Item2.ConvertAll(e => e);
                        newList.Add(n);
                        var newVisited = visited.Select(e => e).ToHashSet();
                        newVisited.Add(n);
                        var newVisited2 = visited2.Select(e => e).ToHashSet();
                        var newFlag = flag;
                        if (visited.Contains(n) && smallCaves.Contains(n))
                        {
                            newFlag = true;
                            newVisited2.Add(n);
                        }
                        queue.Enqueue((n, newList, newVisited, newVisited2, newFlag));
                    }
                }
            }
            return result.Count;
        }
    }
}
