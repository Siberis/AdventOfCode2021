using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day8
{
    public class Day8Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e =>
            {
                var parts = e.Split(" | ");
                return (parts[0].Split(' ', StringSplitOptions.TrimEntries), parts[1].Split(' ', StringSplitOptions.TrimEntries));
            }).ToList();

            Assert.Equal(26, Day8.Star1(parts));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e =>
            {
                var parts = e.Split(" | ");
                return (parts[0].Split(' ', StringSplitOptions.TrimEntries), parts[1].Split(' ', StringSplitOptions.TrimEntries));
            }).ToList();

            Assert.Equal(288, Day8.Star1(parts));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = new string[]{
                "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
            };
            var parts = lines.Select(e =>
            {
                var parts = e.Split(" | ");
                return (parts[0].Split(' ', StringSplitOptions.TrimEntries), parts[1].Split(' ', StringSplitOptions.TrimEntries));
            }).ToList();

            Assert.Equal(5353, Day8.Star2(parts));
        }

        [Fact]
        public async Task Test2b()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1.txt").ConfigureAwait(false);
            var parts = lines.Select(e =>
            {
                var parts = e.Split(" | ");
                return (parts[0].Split(' ', StringSplitOptions.TrimEntries), parts[1].Split(' ', StringSplitOptions.TrimEntries));
            }).ToList();

            Assert.Equal(61229, Day8.Star2(parts));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Input.txt").ConfigureAwait(false);
            var parts = lines.Select(e =>
            {
                var parts = e.Split(" | ");
                return (parts[0].Split(' ', StringSplitOptions.TrimEntries), parts[1].Split(' ', StringSplitOptions.TrimEntries));
            }).ToList();

            Assert.Equal(940724, Day8.Star2(parts));
        }
    }
}
