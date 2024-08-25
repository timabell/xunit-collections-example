// https://timwise.co.uk/2024/08/02/running-xunit-test-setup-only-once/

/// <summary>
/// Setup / teardown code that the tests need to work.
/// Will be run once per class in the project/assembly.
/// </summary>
public class SharedFixture : IDisposable
{
    public int CallCount { get; set; }

    public SharedFixture()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} constructor -  Setup code that runs once across all test classes.");
    }

    public void Dispose()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} dispose -  Cleanup code that runs once after all tests are done. {CallCount} calls made to this fixture instance");
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
        //_fixture.DoSomething();
        Assert.True(true);
        _fixture.CallCount++;
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        Assert.True(true);
        _fixture.CallCount++;
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
        Assert.True(true);
        _fixture.CallCount++;
    }
}
