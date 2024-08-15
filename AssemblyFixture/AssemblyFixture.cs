public class AssemblyFixture : IDisposable
{
    public AssemblyFixture()
    {
        Console.WriteLine("Running AssemblyFixture constructor - Setup code that runs once for the entire assembly.");
    }

    public void Dispose()
    {
        Console.WriteLine("Running AssemblyFixture dispose - Cleanup code that runs once after all tests in the assembly are done.");
    }
}
