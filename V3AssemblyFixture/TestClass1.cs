public class TestClass1
{
	private readonly AssemblyFixtureExample _fixture;
	private readonly ITestOutputHelper _output;

	public TestClass1(AssemblyFixtureExample fixture, ITestOutputHelper output)
	{
		_fixture = fixture;
		_output = output;
		output.WriteLine($"- Running Assembly {nameof(TestClass1)} constructor");
	}

	[Fact]
	public void Test1()
	{
		_output.WriteLine($"- Running Assembly {nameof(TestClass1)}.{nameof(Test1)}");
		_fixture.IncrementCallCount();
		_fixture.SlowDown();
		Assert.True(true);
	}
}
