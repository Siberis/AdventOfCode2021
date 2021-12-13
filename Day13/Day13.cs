using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public static class Day13
    {
        public static int Star1(int[][] positions, string[] folding)
        {
            int maxX = 0;
            int maxY = 0;
            for (int i = 0; i < positions.Length; i++)
            {
                maxX = Math.Max(maxX, positions[i][0]);
                maxY = Math.Max(maxY, positions[i][1]);
            }
            bool[,] array = new bool[maxX + 1, maxY + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                array[positions[i][0], positions[i][1]] = true;
            }
            var firstFold = folding[0].Substring(11).Split('=');
            var number = int.Parse(firstFold[1]);
            Fold(ref maxX, ref maxY, array, firstFold);
            int sum = 0;
            for (int i = 0; i < maxX + 1; i++)
            {
                for (int j = 0; j < maxY + 1; j++)
                {
                    if (array[i, j])
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static void Fold(ref int maxX, ref int maxY, bool[,] array, string[] firstFold)
        {
            switch (firstFold[0])
            {
                case "x":
                    for (int i = 0; i < maxX + 1; i++)
                    {
                        for (int j = 0; j < maxY + 1; j++)
                        {
                            array[i, j] = array[i, j] || array[maxX - i, j];
                        }
                    }
                    maxX /= 2;
                    break;
                case "y":
                    for (int i = 0; i < maxX + 1; i++)
                    {
                        for (int j = 0; j < maxY + 1; j++)
                        {
                            array[i, j] = array[i, j] || array[i, maxY - j];
                        }
                    }
                    maxY /= 2;
                    break;
            }
        }

        public static int Star2(int[][] positions, string[] folding)
        {
            int maxX = 0;
            int maxY = 0;
            for (int i = 0; i < positions.Length; i++)
            {
                maxX = Math.Max(maxX, positions[i][0]);
                maxY = Math.Max(maxY, positions[i][1]);
            }
            bool[,] array = new bool[maxX + 1, maxY + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                array[positions[i][0], positions[i][1]] = true;
            }
            foreach (var fold in folding)
            {
                var firstFold = fold.Substring(11).Split('=');
                Fold(ref maxX, ref maxY, array, firstFold);
            }
            Print(maxX, maxY, array);
            return 0;
        }

        private static void Print(int maxX, int maxY, bool[,] array)
        {
            for (int j = 0; j < maxY; j++)
            {
                for (int i = 0; i < maxX; i++)
                {
                    if (i % 5 == 0)
                    {
                        Console.Write(" ");
                    }
                    if (array[i, j])
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
