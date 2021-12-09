using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public static class Day9
    {
        public static int Star1(string[] input)
        {
            int res = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (
                        (j == 0 || input[i][j] < input[i][j - 1]) &&
                        (i == 0 || input[i][j] < input[i - 1][j]) &&
                        (j == input[0].Length - 1 || input[i][j] < input[i][j + 1]) &&
                        (i == input.Length - 1 || input[i][j] < input[i + 1][j])
                    )
                    {
                        res += input[i][j] - '0' + 1;
                    }
                }
            }
            return res;
        }
        public static int Star2(string[] input)
        {
            var basins = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (
                        (j == 0 || input[i][j] < input[i][j - 1]) &&
                        (i == 0 || input[i][j] < input[i - 1][j]) &&
                        (j == input[0].Length - 1 || input[i][j] < input[i][j + 1]) &&
                        (i == input.Length - 1 || input[i][j] < input[i + 1][j])
                    )
                    {
                        var temp = FindBasin(input.Select(e => e.ToArray()).ToArray(), i, j);
                        basins.Add(temp);
                    }
                }
            }
            var res = basins.OrderByDescending(e => e).Take(3).ToArray();
            return res[0] * res[1] * res[2];
        }

        private static int FindBasin(char[][] input, int x, int y)
        {
            if (input[x][y] == '9')
            {
                return 0;
            }
            input[x][y] = 'x';
            int res = 0;
            if (x > 0 && input[x - 1][y] != 'x')
            {
                res += FindBasin(input, x - 1, y);
            }
            if (x < input.Length - 1 && input[x + 1][y] != 'x')
            {
                res += FindBasin(input, x + 1, y);
            }
            if (y > 0 && input[x][y - 1] != 'x')
            {
                res += FindBasin(input, x, y - 1);
            }
            if (y < input[0].Length - 1 && input[x][y + 1] != 'x')
            {
                res += FindBasin(input, x, y + 1);
            }
            return res + 1;
        }
    }
}
