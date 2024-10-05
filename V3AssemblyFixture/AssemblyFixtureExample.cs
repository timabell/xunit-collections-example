[assembly: AssemblyFixture(typeof(AssemblyFixtureExample))]

/// <summary>
/// This is using the pre-release v3 of xUnit.
/// Note that Rider needs to be at least version 2024.2 for it to be able to run these.
/// This does not affect the default xUnit parallelism, so the classes will be run
/// in parallel, and the tests within each class will be run in series.
/// </summary>
public class AssemblyFixtureExample : IDisposable
{
	private int _callCount;
	private int CallCount => _callCount;
	private static bool SlowMode => Environment.GetEnvironmentVariable("GO_SLOW") == "true";

	public AssemblyFixtureExample()
	{
		TestContext.Current.SendDiagnosticMessage("Running AssemblyFixture constructor - Setup code that runs once for the entire assembly.");
	}

	/// <summary>Helper to slow down tests to make it easier to see what's being run in parallel</summary>
	public void SlowDown()
	{
		if (SlowMode)
		{
			Console.Out.WriteLine("zzz");
			TestContext.Current.SendDiagnosticMessage("diag ZZZ");
			Thread.Sleep(2000);
		}
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
