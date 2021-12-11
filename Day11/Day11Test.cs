using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day11
{
    public class Day11Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Select(x => x - '0').ToArray()).ToArray();

            Assert.Equal(1656, Day11.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Select(x => x - '0').ToArray()).ToArray();

            Assert.Equal(1642, Day11.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Select(x => x - '0').ToArray()).ToArray();

            Assert.Equal(195, Day11.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Select(x => x - '0').ToArray()).ToArray();

            Assert.Equal(320, Day11.Star2(parts));
        }
    }
}
