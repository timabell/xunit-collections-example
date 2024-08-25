Test/example code for <https://timwise.co.uk/2024/08/02/running-xunit-test-setup-only-once/>

This repo demonstrates various aspects of controlling the way xUnit runs tests.

To see the output of just one type of test, `cd` into the project folder and run `dotnet test` from there.

To better observe parallel behaviour by delaying tests, run with the environment variable `GO_SLOW=true`.

e.g.

```sh
cd ClassSetupExample 
GO_SLOW=true dotnet test
```

Note that `dotnet test` runs test projects in parallel. Other test runners my operate differently, for example Rider defaults to a maximum of 1 "test runner to run in parallel", but this can be increased in the settings.
