using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public static class Day16
    {
        public static int Star1(string[] input)
        {
            var message = input[0];
            var binaryBuilder = new StringBuilder(message.Length * 4);
            foreach (var c in message)
            {
                binaryBuilder.Append(MAPPING[c]);
            }
            var binary = binaryBuilder.ToString();
            int res = 0;
            ParseMessage(binary, 0, ref res);
            return res;
        }

        private static int ParseMessage(string binary, int startIndex, ref int sumVersion)
        {
            var version = string.Concat(binary.Skip(startIndex).Take(3).ToArray());
            sumVersion += Convert.ToInt32(version, 2);
            switch (string.Concat(binary.Skip(startIndex + 3).Take(3).ToArray()))
            {
                case "100":
                    var start = startIndex + 6;
                    var val = binary.Skip(start).Take(5).ToArray();
                    var num = 1;
                    while (val[0] != '0')
                    {
                        start += 5;
                        val = binary.Skip(start).Take(5).ToArray();
                        num++;
                    }
                    var size = (6 + (num * 5)) % 4;
                    return startIndex + 6 + (num * 5);
                default:
                    var i = binary.Skip(startIndex + 6).Take(1).ToArray()[0];
                    switch (i)
                    {
                        case '0':
                            var lenght = Convert.ToInt32(string.Concat(binary.Skip(startIndex + 7).Take(15).ToArray()), 2);
                            var next2 = startIndex + 22;
                            while (next2 < (startIndex + 22 + lenght) - 3)
                            {
                                next2 = ParseMessage(binary, next2, ref sumVersion);
                            }
                            return startIndex + 22 + lenght;
                        case '1':
                            var number = Convert.ToInt32(string.Concat(binary.Skip(startIndex + 7).Take(11).ToArray()), 2);
                            var next = startIndex + 18;
                            for (int x = 0; x < number; x++)
                            {
                                next = ParseMessage(binary, next, ref sumVersion);
                            }
                            return next;
                    }
                    break;
            }
            return startIndex;
        }

        public static long Star2(string[] input)
        {
            var message = input[0];
            var binaryBuilder = new StringBuilder(message.Length * 4);
            foreach (var c in message)
            {
                binaryBuilder.Append(MAPPING[c]);
            }
            var binary = binaryBuilder.ToString();
            long res;
            ParseMessage2(binary, 0, out res);
            return res;
        }


        private static int ParseMessage2(string binary, int startIndex, out long sumVersion)
        {
            _ = string.Concat(binary.Skip(startIndex).Take(3).ToArray());
            var type = string.Concat(binary.Skip(startIndex + 3).Take(3).ToArray());
            switch (type)
            {
                case "100":
                    var start = startIndex + 6;
                    var val = binary.Skip(start).Take(5).ToArray();
                    var num = 1;
                    var text = string.Concat(val.Skip(1).ToArray());
                    while (val[0] != '0')
                    {
                        start += 5;
                        val = binary.Skip(start).Take(5).ToArray();
                        text += string.Concat(val.Skip(1).ToArray());
                        num++;
                    }
                    sumVersion = Convert.ToInt64(text, 2);
                    return startIndex + 6 + (num * 5);
                default:
                    var i = binary.Skip(startIndex + 6).Take(1).ToArray()[0];
                    var list = new List<long>();
                    switch (i)
                    {
                        case '0':
                            var lenght = Convert.ToInt32(string.Concat(binary.Skip(startIndex + 7).Take(15).ToArray()), 2);
                            var next2 = startIndex + 22;
                            while (next2 < startIndex + 22 + lenght - 3)
                            {
                                next2 = ParseMessage2(binary, next2, out var xx);
                                list.Add(xx);
                            }
                            sumVersion = Calculateval(type, list);
                            return startIndex + 22 + lenght;
                        case '1':
                            var number = Convert.ToInt32(string.Concat(binary.Skip(startIndex + 7).Take(11).ToArray()), 2);
                            var next = startIndex + 18;
                            for (int x = 0; x < number; x++)
                            {
                                next = ParseMessage2(binary, next, out var xx);
                                list.Add(xx);
                            }
                            sumVersion = Calculateval(type, list);
                            return next;
                    }
                    break;
            }
            sumVersion = 0;
            return startIndex;
        }

        private static long Calculateval(string type, List<long> list)
        {
            return type switch
            {
                "000" => list.Sum(),
                "001" => list.Aggregate(1l, (acc, a) => acc * a),
                "010" => list.Min(),
                "011" => list.Max(),
                "101" => list[0] > list[1] ? 1 : 0,
                "110" => list[0] < list[1] ? 1 : 0,
                "111" => list[0] == list[1] ? 1 : 0,
                _ => 0,
            };
        }

        private static readonly Dictionary<char, string> MAPPING = new()
        {
            ['0'] = "0000",
            ['1'] = "0001",
            ['2'] = "0010",
            ['3'] = "0011",
            ['4'] = "0100",
            ['5'] = "0101",
            ['6'] = "0110",
            ['7'] = "0111",
            ['8'] = "1000",
            ['9'] = "1001",
            ['A'] = "1010",
            ['B'] = "1011",
            ['C'] = "1100",
            ['D'] = "1101",
            ['E'] = "1110",
            ['F'] = "1111",
        };
    }
}
