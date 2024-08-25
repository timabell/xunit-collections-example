/// <summary>
/// Setup / teardown code shared across multiple test classes.
/// xUnit will create one instance of this fixture *per test class*,
/// and inject that same instance into each test class instance that
/// it creates (one for every test in every class).
/// This allows you to share state between tests in the same class,
/// but not between test classes.
/// </summary>
public class SharedFixture : IDisposable
{
    private int _callCount;
    public int CallCount => _callCount;

    public SharedFixture()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} constructor -  Setup code that runs once across all test classes.");
    }

    public void Dispose()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} dispose -  Cleanup code that runs once after all tests are done. {CallCount} calls made to this fixture instance");
    }

    public void IncrementCallCount()
    {
        Interlocked.Increment(ref _callCount);
    }
}

public class TestClass1 : IClassFixture<SharedFixture>
{
    SharedFixture _fixture;

    public TestClass1(SharedFixture fixture)
    {
        Console.WriteLine($"- Running class-fixture {nameof(TestClass1)} constructor");
        _fixture = fixture; // this is how you get access to the fixture from the tests
    }

    [Fact]
    public void Test2()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass1)}.{nameof(TestClass1.Test2)}");
        _fixture.IncrementCallCount();
        Assert.True(true);
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        _fixture.IncrementCallCount();
        Assert.True(true);
    }
}

public class TestClass2 : IClassFixture<SharedFixture>
{
    SharedFixture _fixture;

    public TestClass2(SharedFixture fixture)
    {
        Console.WriteLine($"- Running class-fixture {nameof(TestClass2)} constructor");
        _fixture = fixture; // this is how you get access to the fixture from the tests
    }

    [Fact]
    public void Test3()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass2)}.{nameof(TestClass2.Test3)}");
        _fixture.IncrementCallCount();
        Assert.True(true);
    }
}
