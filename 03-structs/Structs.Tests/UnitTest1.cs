namespace Structs.Tests;

using Structs.Lib;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Inch in3 = new Inch(3M);
        Meter met3 = new Meter(3M);

        Meter in3plmet3met = in3 + (Inch)met3;
        Assert.Equal(3.076199999988M, in3plmet3met.Value);
    }
}