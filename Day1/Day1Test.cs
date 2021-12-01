using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day1
{
    public class Day1Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(7, Day1.Star1(numbers));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1Input.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(1195, Day1.Star1(numbers));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(5, Day1.Star2(numbers));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1Input.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(1235, Day1.Star2(numbers));
        }
    }
}
