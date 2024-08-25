using Xunit.Extensions.AssemblyFixture;

public class TestClass1 : IAssemblyFixture<AssemblyFixture>
{
    private readonly AssemblyFixture _fixture;

    public TestClass1(AssemblyFixture fixture)
    {
        _fixture = fixture;
        Console.WriteLine($"- Running Assembly {nameof(TestClass1)} constructor");
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running Assembly {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        Assert.True(true);
        _fixture.IncrementCallCount();
    }
}
