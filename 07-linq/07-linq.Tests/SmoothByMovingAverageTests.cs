using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace _07_linq.Tests
{
    public class SmoothByMovingAverageTests
    {
        [Theory]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -1, 0, 1 }, 4)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -1, 0, 1 }, 3)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -1, 1, 2 }, 2)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -2, 4, 6 }, 1)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -2, 4, 6 }, 0)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -2, 4, 6 }, -1)]
        [InlineData(new[] { -1, -2, 4, 6 }, new[] { -1, -2, 4, 6 }, -10)]
        [InlineData(new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256 }, new[] { 1, 1, 2, 3, 5, 9, 17, 33, 65 }, 4)]
        [InlineData(new[] { 1, -2, 3, -5, 8, -13, 21, -34, 55 }, new[] { 1, 0, 0, 0, 1, -1, 1, -2, 8 }, 8)]
        public void SmoothByMovingAverageComplexTest(int[] ints_in, int[] ints_exp, int width)
        {
            IEnumerable<int> ints = ints_in;

            var result = ints.SmoothByMovingAverage(width).ToArray();

            var mustbe = ints_exp;

            Assert.Equal(mustbe, result);
        }
    }
}