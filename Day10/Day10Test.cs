using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day10
{
    public class Day10Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(26397, Day10.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(358737, Day10.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)288957, Day10.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)4329504793, Day10.Star2(parts));
        }
    }
}
