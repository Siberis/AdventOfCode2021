using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class Day2
    {
        public static int Star1(string[][] input)
        {
            var forward = 0;
            var depth = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var val = int.Parse(input[i][1]);
                switch (input[i][0])
                {
                    case "forward": forward += val; break;
                    case "up": depth -= val; break;
                    case "down": depth += val; break;
                }
            }
            return forward * depth;
        }
        public static int Star2(string[][] input)
        {
            var forward = 0;
            var depth = 0;
            var aim = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var val = int.Parse(input[i][1]);
                switch (input[i][0])
                {
                    case "forward": depth += aim * val; forward += val; break;
                    case "up": aim -= val; break;
                    case "down": aim += val; break;
                }
            }
            return forward * depth;
        }

    }
}
