using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day6
{
    public class Day6Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1.txt").ConfigureAwait(false);
            var parts = lines.SelectMany(e => e.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToArray();

            Assert.Equal(5934, Day6.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Input.txt").ConfigureAwait(false);
            var parts = lines.SelectMany(e => e.Split(',')).ToArray();

            Assert.Equal(346063, Day6.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1.txt").ConfigureAwait(false);
            var parts = lines.SelectMany(e => e.Split(',')).ToArray();

            Assert.Equal(26984457539, Day6.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Input.txt").ConfigureAwait(false);
            var parts = lines.SelectMany(e => e.Split(',')).ToArray();

            Assert.Equal(1572358335990, Day6.Star2(parts));
        }
    }
}
