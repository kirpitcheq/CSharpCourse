namespace _07_linq.Tests;

using _07_linq;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        IEnumerable<int> ints = new[] { 1, 2, 4, 6};

        var result = ints.TakeOdd().ToArray();

        var mustbe = new [] {1};

        Assert.Equal(mustbe, result);

    }

    [Fact]
    public void Test2()
    {
        IEnumerable<int> ints = new[] { 1, 2, 4, 6};

        var result = ints.TakeEven().ToArray();

        var mustbe = new [] {2,4,6};

        Assert.Equal(mustbe, result);
    }
    [Fact]
    public void Test3()
    {
        IEnumerable<int> ints = new[] { -1, -2, 4, 6};

        var result = ints.TakePositive().ToArray();

        var mustbe = new [] {4,6};

        Assert.Equal(mustbe, result);
    }
    [Fact]
    public void Test4()
    {
        IEnumerable<int> ints = new[] { -1, -2, 4, 6};

        var result = ints.TakeNegative().ToArray();

        var mustbe = new [] {-1,-2};

        Assert.Equal(mustbe, result);
    }
}