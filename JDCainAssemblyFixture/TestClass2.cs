using Xunit.Extensions.AssemblyFixture;

public class TestClass2 : IAssemblyFixture<AssemblyFixture>
{
	private readonly AssemblyFixture _fixture;

	public TestClass2(AssemblyFixture fixture)
	{
		Console.WriteLine($"- Running Assembly {nameof(TestClass2)} constructor");
		_fixture = fixture;
	}

	[Fact]
	public void Test2()
	{
		Console.Out.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test2)}");
		_fixture.IncrementCallCount();
		AssemblyFixture.SlowDown();
		Assert.True(true);
	}

	[Fact]
	public void Test3()
	{
		Console.Out.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test3)}");
		_fixture.IncrementCallCount();
		AssemblyFixture.SlowDown();
		Assert.True(true);
	}
}
