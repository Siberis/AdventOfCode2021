using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day2
{
    public class Day2Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => e.Split(' ')).ToArray();

            Assert.Equal(150, Day2.Star1(numbers));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1Input.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => e.Split(' ')).ToArray();

            Assert.Equal(2117664, Day2.Star1(numbers));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => e.Split(' ')).ToArray();

            Assert.Equal(900, Day2.Star2(numbers));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1Input.txt").ConfigureAwait(false);
            var numbers = lines.Select(e => e.Split(' ')).ToArray();

            Assert.Equal(2073416724, Day2.Star2(numbers));
        }
    }
}
