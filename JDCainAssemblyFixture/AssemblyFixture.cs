using Xunit.Extensions.AssemblyFixture;

[assembly: TestFramework(AssemblyFixtureFramework.TypeName, AssemblyFixtureFramework.AssemblyName)]

/// <summary>
/// This 3rd-party library is used to run setup code once for the entire assembly.
/// This does not affect the default xUnit parallelism, so the classes will be run
/// in parallel, and the tests within each class will be run in series.
/// </summary>
public class AssemblyFixture : IDisposable
{
	private int _callCount;
	private int CallCount => _callCount;
	private static bool SlowMode => Environment.GetEnvironmentVariable("GO_SLOW") == "true";
	/// <summary>Helper to slow down tests to make it easier to see what's being run in parallel</summary>
	public static void SlowDown()
	{
		if (SlowMode)
		{
			Console.Out.WriteLine("zzz");
			Thread.Sleep(2000);
		}
	}

	public AssemblyFixture()
	{
		Console.WriteLine("Running AssemblyFixture constructor - Setup code that runs once for the entire assembly.");
	}

	public void IncrementCallCount()
	{
		Interlocked.Increment(ref _callCount);
	}

	public void Dispose()
	{
		Console.WriteLine($"Running AssemblyFixture dispose - Cleanup code that runs once after all tests in the assembly are done. {CallCount} calls made to this fixture instance");
	}
}
