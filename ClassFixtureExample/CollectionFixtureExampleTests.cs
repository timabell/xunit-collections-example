// https://timwise.co.uk/2024/08/02/running-xunit-test-setup-only-once/

/// <summary>
/// Setup / teardown code that the tests need to work.
/// </summary>
public class SharedFixture : IDisposable
{
    public SharedFixture()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} constructor -  Setup code that runs once across all test classes.");
    }

    public void Dispose()
    {
        Console.WriteLine($"Running class-fixture {nameof(SharedFixture)} dispose -  Cleanup code that runs once after all tests are done");
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
    }

    [Fact]
    public void Test1()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass1)}.{nameof(TestClass1.Test1)}");
        Assert.True(true);
    }
}

public class TestClass2 : IClassFixture<SharedFixture>
{
    [Fact]
    public void Test3()
    {
        Console.Out.WriteLine($"- Running class-fixture {nameof(TestClass2)}.{nameof(TestClass2.Test3)}");
        Assert.True(true);
    }
}
