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

To see the console output on the terminal run the tests with the `--logger` option:

```sh
dotnet test --logger "console;verbosity=detailed"
```
ref <https://stackoverflow.com/questions/61087246/when-running-dotnet-test-show-output-of-the-dotnet-vstest-output-sink/67873341#67873341>
