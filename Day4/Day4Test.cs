using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day4
{
    public class Day4Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1.txt").ConfigureAwait(false);
            var inputs = lines.Take(1).SelectMany(e => e.Split(',')).ToArray();
            var boards = lines.Skip(2).Select(e => e.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();

            Assert.Equal(4512, Day4.Star1(inputs, boards));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1Input.txt").ConfigureAwait(false);
            var inputs = lines.Take(1).SelectMany(e => e.Split(',')).ToArray();
            var boards = lines.Skip(2).Select(e => e.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();


            Assert.Equal(29440, Day4.Star1(inputs, boards));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1.txt").ConfigureAwait(false);
            var inputs = lines.Take(1).SelectMany(e => e.Split(',')).ToArray();
            var boards = lines.Skip(2).Select(e => e.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();


            Assert.Equal(1924, Day4.Star2(inputs, boards));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1Input.txt").ConfigureAwait(false);
            var inputs = lines.Take(1).SelectMany(e => e.Split(',')).ToArray();
            var boards = lines.Skip(2).Select(e => e.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();


            Assert.Equal(13884, Day4.Star2(inputs, boards));
        }
    }
}
