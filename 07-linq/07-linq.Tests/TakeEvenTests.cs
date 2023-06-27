using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace _07_linq.Tests
{
    public class TakeEvenTests
    {
        [Fact]
        public void TakeEvenTestSimple()
        {
            IEnumerable<int> ints = new[] { 1, 2, 4, 6 };

            var result = ints.TakeEven().ToArray();

            var mustbe = new[] { 2, 4, 6 };

            Assert.Equal(mustbe, result);
        }
    }
}