using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day14
{
    public class Day14Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)1588, Day14.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)2947, Day14.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)2188189693529, Day14.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal((ulong)3232426226464, Day14.Star2(parts));
        }
    }
}
