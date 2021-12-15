using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day15
{
    public class Day15Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day15Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(40, Day15.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day15Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(366, Day15.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day15Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(315, Day15.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day15Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(2829, Day15.Star2(parts));
        }
    }
}
