using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day16
{
    public class Day16Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(20, Day16.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(913, Day16.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(1, Day16.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(1510977819698, Day16.Star2(parts));
        }
    }
}
