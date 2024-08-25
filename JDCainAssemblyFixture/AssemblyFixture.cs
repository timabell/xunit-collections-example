using Xunit.Extensions.AssemblyFixture;

[assembly: TestFramework(AssemblyFixtureFramework.TypeName, AssemblyFixtureFramework.AssemblyName)]

public class AssemblyFixture : IDisposable
{
    private int _callCount;
    private int CallCount => _callCount;

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
