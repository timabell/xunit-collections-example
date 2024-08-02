public class SharedFixture : IDisposable
{
    public SharedFixture()
    {
        Console.WriteLine($"Running {nameof(SharedFixture)} constructor -  Setup code that runs once across all test classes");
    }

    public void Dispose()
    {
        Console.WriteLine($"Running {nameof(SharedFixture)} dispose -  Cleanup code that runs once after all tests are done");
    }
}

/// <summary>
/// This exists to prevent xUnit running the SharedFixture setup more than once
/// concurrently when multiple test classes are executed at once.
/// </summary>
[CollectionDefinition(nameof(SharedFixture))]
public class SharedFixtureCollection : ICollectionFixture<SharedFixture> { }

[Collection(nameof(SharedFixture))]
public class TestClass1 : IClassFixture<SharedFixture>
{
    SharedFixture _fixture;

    public TestClass1(SharedFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"Running {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        Assert.True(true);
    }
}

[Collection(nameof(SharedFixture))]
public class TestClass2 : IClassFixture<SharedFixture>
{
    SharedFixture _fixture;

    public TestClass2(SharedFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test2()
    {
        Console.Out.WriteLine($"Running {nameof(TestClass2)}.{nameof(TestClass2.Test2)}");
        Assert.True(true);
    }
}
