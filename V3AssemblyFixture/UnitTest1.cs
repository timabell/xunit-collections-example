namespace V3AssemblyFixture;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

        Console.Out.WriteLine($"- Running {nameof(UnitTest1)}.{nameof(Test1)}");
        // SlowDown();
        Assert.True(true);
        Console.Out.WriteLine($"- Done {nameof(UnitTest1)}.{nameof(Test1)}");
    }
}
