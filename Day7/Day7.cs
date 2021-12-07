using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public static class Day7
    {
        public static int Star1(int[] input)
        {
            var min = Enumerable.Range(input.Min(), input.Max())
            .MinBy(i => input.Select(e => Math.Abs(e - i)).Sum());
            return input.Select(e => Math.Abs(e - min)).Sum();
        }
        public static int Star2(int[] input)
        {
            var min = Enumerable.Range(input.Min(), input.Max())
            .MinBy(i =>
            {
                return input.Select(e =>
                {
                    var diff = Math.Abs(e - i);
                    return diff * (diff + 1) / 2;
                }).Sum();
            });
            return input.Select(e =>
            {
                var diff = Math.Abs(e - min);
                return diff * (diff + 1) / 2;
            }).Sum();
        }
    }
}
