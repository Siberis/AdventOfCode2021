using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day13
{
    public class Day13Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();
            var positions = parts.TakeWhile(e => e.Length > 0).Select(e => e.Split(',').Select(x => int.Parse(x)).ToArray()).ToArray();
            var folding = parts.Skip(positions.Length + 1).ToArray();

            Assert.Equal(17, Day13.Star1(positions, folding));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray(); var positions = parts.TakeWhile(e => e.Length > 0).Select(e => e.Split(',').Select(x => int.Parse(x)).ToArray()).ToArray();
            var folding = parts.Skip(positions.Length + 1).ToArray();

            Assert.Equal(751, Day13.Star1(positions, folding));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();
            var positions = parts.TakeWhile(e => e.Length > 0).Select(e => e.Split(',').Select(x => int.Parse(x)).ToArray()).ToArray();
            var folding = parts.Skip(positions.Length + 1).ToArray();

            Assert.Equal(0, Day13.Star2(positions, folding));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e => e).ToArray();
            var positions = parts.TakeWhile(e => e.Length > 0).Select(e => e.Split(',').Select(x => int.Parse(x)).ToArray()).ToArray();
            var folding = parts.Skip(positions.Length + 1).ToArray();

            Assert.Equal(0, Day13.Star2(positions, folding));
        }
    }
}
