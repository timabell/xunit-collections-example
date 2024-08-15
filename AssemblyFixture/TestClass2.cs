public class TestClass2
{
    public TestClass2()
    {
        Console.WriteLine($"- Running Assembly {nameof(TestClass2)} constructor");
    }

    [Fact]
    public void Test2()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(TestClass2.Test2)}");
        Assert.True(true);
    }
}
