public class TestClass1 : IAssemblyFixture<AssemblyFixture>
{
    public TestClass1()
    {
        Console.WriteLine($"- Running Assembly {nameof(TestClass1)} constructor");
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        Assert.True(true);
    }
}
