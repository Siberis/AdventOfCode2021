using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day12
{
    public class Day12Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Split('-')).ToArray();

            Assert.Equal(10, Day12.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Split('-')).ToArray();

            Assert.Equal(5212, Day12.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Split('-')).ToArray();

            Assert.Equal(36, Day12.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e.Split('-')).ToArray();

            Assert.Equal(134862, Day12.Star2(parts));
        }
    }
}
