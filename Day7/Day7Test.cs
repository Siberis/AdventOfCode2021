using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day7
{
    public class Day7Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1.txt").ConfigureAwait(false);
            var parts = lines.Take(1).SelectMany(e => e.Split(',')).Select(e => int.Parse(e)).ToArray();

            Assert.Equal(37, Day7.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Take(1).SelectMany(e => e.Split(',')).Select(e => int.Parse(e)).ToArray();

            Assert.Equal(344138, Day7.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1.txt").ConfigureAwait(false);
            var parts = lines.Take(1).SelectMany(e => e.Split(',')).Select(e => int.Parse(e)).ToArray();

            Assert.Equal(168, Day7.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Take(1).SelectMany(e => e.Split(',')).Select(e => int.Parse(e)).ToArray();

            Assert.Equal(94862124, Day7.Star2(parts));
        }
    }
}
