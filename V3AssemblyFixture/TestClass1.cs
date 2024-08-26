public class TestClass1
{
    private readonly AssemblyFixtureExample _fixture;

    public TestClass1(AssemblyFixtureExample fixture)
    {
        _fixture = fixture;
        Console.WriteLine($"- Running Assembly {nameof(TestClass1)} constructor");
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass1)}.{nameof(Test1)}");
        _fixture.IncrementCallCount();
        AssemblyFixtureExample.SlowDown();
        Assert.True(true);
    }
}
