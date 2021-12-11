using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public static class Day11
    {
        public static int Star1(int[][] input)
        {
            int sum = 0;
            for (int s = 0; s < 100; s++)
            {
                var flashed = new HashSet<(int, int)>();
                Increment(input);
                var flag = true;
                while (flag)
                {
                    flag = false;
                    for (int i = 0; i < input.Length; i++)
                    {
                        for (int j = 0; j < input[0].Length; j++)
                        {
                            if (input[i][j] > 9)
                            {
                                flag = Flash(input, flashed, i, j);
                            }
                        }
                    }
                }
                sum += flashed.Count;
            }
            return sum;
        }


        public static int Star2(int[][] input)
        {

            int s = 0;
            while (true)
            {
                s++;
                var flashed = new HashSet<(int, int)>();
                Increment(input);
                var flag = true;
                while (flag)
                {
                    flag = false;
                    for (int i = 0; i < input.Length; i++)
                    {
                        for (int j = 0; j < input[0].Length; j++)
                        {
                            if (input[i][j] > 9)
                            {
                                flag = Flash(input, flashed, i, j);
                            }
                        }
                    }
                }
                if (flashed.Count == 100)
                {
                    return s;
                }
            }
        }


        private static bool Flash(int[][] input, HashSet<(int, int)> flashed, int i, int j)
        {
            input[i][j] = 0;
            flashed.Add((i, j));

            if (i > 0 && j > 0 && !flashed.Contains((i - 1, j - 1))) input[i - 1][j - 1]++;
            if (i > 0 && !flashed.Contains((i - 1, j))) input[i - 1][j]++;
            if (i > 0 && j < 9 && !flashed.Contains((i - 1, j + 1))) input[i - 1][j + 1]++;

            if (j > 0 && !flashed.Contains((i, j - 1))) input[i][j - 1]++;
            if (j < 9 && !flashed.Contains((i, j + 1))) input[i][j + 1]++;

            if (i < 9 && j > 0 && !flashed.Contains((i + 1, j - 1))) input[i + 1][j - 1]++;
            if (i < 9 && !flashed.Contains((i + 1, j))) input[i + 1][j]++;
            if (i < 9 && j < 9 && !flashed.Contains((i + 1, j + 1))) input[i + 1][j + 1]++;
            return true;
        }

        private static void Increment(int[][] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    input[i][j]++;
                }
            }
        }
    }
}
