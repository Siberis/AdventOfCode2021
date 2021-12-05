using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day5
{
    public class Day5Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day5Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(5, Day5.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day5Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(7644, Day5.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day5Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(12, Day5.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day5Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();

            Assert.Equal(18627, Day5.Star2(parts));
        }
    }
}
