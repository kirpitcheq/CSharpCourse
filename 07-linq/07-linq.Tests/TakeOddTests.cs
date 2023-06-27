using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace _07_linq.Tests
{
    public class TakeOddTests
    {
        [Fact]
        public void TakeOddTestSimple()
        {
            IEnumerable<int> ints = new[] { 1, 2, 4, 6 };

            var result = ints.TakeOdd().ToArray();

            var mustbe = new[] { 1 };

            Assert.Equal(mustbe, result);

        }
    }
}