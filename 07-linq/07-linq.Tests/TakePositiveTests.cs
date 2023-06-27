using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace _07_linq.Tests
{
    public class TakePositiveTests
    {
        [Fact]
        public void TakePositiveTestSimple()
        {
            IEnumerable<int> ints = new[] { -1, -2, 4, 6 };

            var result = ints.TakePositive().ToArray();

            var mustbe = new[] { 4, 6 };

            Assert.Equal(mustbe, result);
        }
    }
}