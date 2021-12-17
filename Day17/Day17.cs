using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public static class Day17
    {
        public static int Star1(string[] input)
        {
            var (targetX, targetY) = GetParams(input);
            var (_, maxY) = CalculateParams(targetX, targetY);
            return maxY;
        }

        public static int Star2(string[] input)
        {
            var (targetX, targetY) = GetParams(input);
            var (counter, _) = CalculateParams(targetX, targetY);
            return counter;
        }

        private static (int[], int[]) GetParams(string[] input)
        {
            var parse = input[0].Split("=");
            var targetX = string.Concat(parse[1].SkipLast(3).ToArray()).Split("..").Select(i => int.Parse(i)).ToArray();
            var targetY = string.Concat(parse[2].ToArray()).Split("..").Select(i => int.Parse(i)).ToArray();
            return (targetX, targetY);
        }

        private static (int, int) CalculateParams(int[] targetX, int[] targetY)
        {
            var pos = (0, 0);
            var speed = (0, 0);
            var maxY = 0;
            var counter = 0;

            for (int x = 1; x < 1000; x++)
            {
                for (int y = -200; y < 1000; y++)
                {
                    pos = (0, 0);
                    speed = (x, y);
                    var tmpMax = 0;

                    do
                    {
                        PerformStep(ref pos, ref speed);
                        tmpMax = Math.Max(tmpMax, pos.Item2);

                        if (
                            pos.Item1 >= targetX[0] && pos.Item1 <= targetX[1] &&
                            pos.Item2 >= targetY[0] && pos.Item2 <= targetY[1]
                        )
                        {
                            counter++;
                            maxY = Math.Max(maxY, tmpMax);
                            break;
                        }
                    }
                    while (pos.Item1 <= targetX[1] && pos.Item2 >= targetY[0]);
                }
            }

            return (counter, maxY);
        }

        private static void PerformStep(ref (int, int) pos, ref (int, int) speed)
        {
            pos = (pos.Item1 + speed.Item1, pos.Item2 + speed.Item2);
            if (speed.Item1 > 0)
            {
                speed = (speed.Item1 - 1, speed.Item2 - 1);
            }
            else if (speed.Item1 < 0)
            {
                speed = (speed.Item1 + 1, speed.Item2 - 1);
            }
            else
            {
                speed = (speed.Item1, speed.Item2 - 1);
            }
        }
    }
}
