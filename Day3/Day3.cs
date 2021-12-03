using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public static class Day3
    {
        public static int Star1(string[] input)
        {
            int pow = 1;
            var gamma = 0;
            var epsilon = 0;
            for (int i = input[0].Length - 1; i >= 0; i--)
            {
                var common = input.Select(e => e[i]).OrderBy(e => e).ToList()[input.Count() / 2];
                if (common == '0')
                {
                    epsilon += pow;
                }
                else
                {
                    gamma += pow;
                }
                pow *= 2;
            }

            return epsilon * gamma;
        }
        public static int Star2(string[] input)
        {
            var size = input[0].Length;
            var o2 = 0;
            var co2 = 0;
            var inp = input;
            for (int i = 0; i < size; i++)
            {
                var common = inp.Select(e => e[i]).OrderBy(e => e).ToList()[inp.Count() / 2];
                inp = inp.Where(e => e[i] == common).ToArray();
                if (inp.Length == 1)
                {
                    o2 = Convert.ToInt32(inp[0], 2);
                    break;
                }
            }
            inp = input;
            for (int i = 0; i < size; i++)
            {
                var common = inp.Select(e => e[i]).OrderBy(e => e).ToList()[inp.Count() / 2];
                inp = inp.Where(e => e[i] == (common == '0' ? '1' : '0')).ToArray();
                if (inp.Length == 1)
                {
                    co2 = Convert.ToInt32(inp[0], 2);
                    break;
                }
            }
            return o2 * co2;
        }

    }
}
