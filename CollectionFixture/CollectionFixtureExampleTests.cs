/// <summary>
/// Setup / teardown code shared across classes with the named
/// collection fixture. This is one of the design weaknesses
/// of xUnit - that the tests and fixture are connected by string matches.
/// The addition of the named collection forces the tests to run in series.
/// </summary>
public class SharedCollectionFixture : IDisposable
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

    public SharedCollectionFixture()
    {
        Console.WriteLine($"Running {nameof(SharedCollectionFixture)} constructor -  Setup code that runs once across all test classes.");
    }

    public void Dispose()
    {
        Console.WriteLine($"Running {nameof(SharedCollectionFixture)} dispose -  Cleanup code that runs once after all tests are done. {CallCount} calls made to this fixture instance");
    }

    public void IncrementCallCount()
    {
        Interlocked.Increment(ref _callCount);
    }
}

/// <summary>
/// This exists to prevent xUnit running the SharedFixture setup more than once
/// concurrently when multiple test classes are executed at once,
/// and as a middle point in connecting the fixture to the test classes.
/// </summary>
[CollectionDefinition(nameof(SharedFixtureCollection))]
public class SharedFixtureCollection : ICollectionFixture<SharedCollectionFixture> { }

/// <summary>
/// The `CollectionAttribute` decoration does two things:
/// 1. Prevent tests with the same collection running in parallel
/// 2. Connect the test class to the matching shared fixture
/// </summary>
[Collection(nameof(SharedFixtureCollection))]
public class TestClass1 : IClassFixture<SharedCollectionFixture>
{
    private readonly SharedCollectionFixture _fixture;

    public TestClass1(SharedCollectionFixture fixture)
    {
        Console.WriteLine($"- Running {nameof(TestClass1)} constructor");
        _fixture = fixture; // this is how you get access to the fixture from the tests
    }

    [Fact]
    public void Test2()
    {
        Console.Out.WriteLine($"- Running {nameof(TestClass1)}.{nameof(TestClass1.Test2)}");
        _fixture.IncrementCallCount();
        SharedCollectionFixture.SlowDown();
        Assert.True(true);
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        _fixture.IncrementCallCount();
        SharedCollectionFixture.SlowDown();
        Assert.True(true);
    }
}

[Collection(nameof(SharedFixtureCollection))]
public class TestClass2 : IClassFixture<SharedCollectionFixture>
{
    private readonly SharedCollectionFixture _fixture;

    public TestClass2(SharedCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test3()
    {
        Console.Out.WriteLine($"- Running {nameof(TestClass2)}.{nameof(TestClass2.Test3)}");
        _fixture.IncrementCallCount();
        SharedCollectionFixture.SlowDown();
        Assert.True(true);
    }
}
