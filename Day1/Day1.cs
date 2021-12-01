using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class Day1
    {
        public static int Star1(int[] input)
        {
            var current = input[0];
            var dec = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > current) dec++;
                current = input[i];
            }
            return dec;
        }
        public static int Star2(int[] input)
        {
            var currentA = input[0];
            var currentB = input[1];
            var currentC = input[2];
            var dec = 0;
            for (int i = 1; i < input.Length - 2; i++)
            {
                if ((input[i] + input[i + 1] + input[i + 2]) > (currentA + currentB + currentC)) dec++;
                currentA = input[i];
                currentB = input[i + 1];
                currentC = input[i + 2];
            }
            return dec;
        }
    }
}
