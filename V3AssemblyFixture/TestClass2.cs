public class TestClass2
{
	private readonly AssemblyFixtureExample _fixture;
	private readonly ITestOutputHelper _output;

	public TestClass2(AssemblyFixtureExample fixture, ITestOutputHelper output)
	{
		_output = output;
		_output.WriteLine($"- Running Assembly {nameof(TestClass2)} constructor");
		_fixture = fixture;
	}

	[Fact]
	public void Test2()
	{
		_output.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test2)}");
		_fixture.IncrementCallCount();
		_fixture.SlowDown();
		Assert.True(true);
	}

	[Fact]
	public void Test3()
	{
		_output.WriteLine($"- Running Assembly {nameof(TestClass2)}.{nameof(Test3)}");
		_fixture.IncrementCallCount();
		_fixture.SlowDown();
		Assert.True(true);
	}
}
