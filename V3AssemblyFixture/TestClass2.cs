public class TestClass2
{
    private readonly AssemblyFixtureExample _fixture;

    public TestClass2(AssemblyFixtureExample fixture)
    {
        Console.WriteLine($"- Running Assembly {nameof(TestClass2)} constructor");
        _fixture = fixture;
    }

    [Fact]
    public void Test2()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test2)}");
        _fixture.IncrementCallCount();
        AssemblyFixtureExample.SlowDown();
        Assert.True(true);
    }

    [Fact]
    public void Test3()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test3)}");
        _fixture.IncrementCallCount();
        AssemblyFixtureExample.SlowDown();
        Assert.True(true);
    }
}
