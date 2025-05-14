## XUnit fixture/setup minimal examples

Test/example code for <https://timwise.co.uk/2024/08/02/running-xunit-test-setup-only-once/>

This repo demonstrates various aspects of controlling the way xUnit runs tests.

## Running

To see the output of just one type of test, `cd` into the project folder and run `dotnet test` from there.

To better observe parallel behaviour by delaying tests, run with the environment variable `GO_SLOW=true`.

e.g.

```sh
cd ClassSetupExample 
GO_SLOW=true dotnet test
```

## Configuring parallel running

Note that `dotnet test` runs test projects in parallel. Other test runners my operate differently.

For example Rider defaults to a maximum of 1 "test runner to run in parallel", but this can be increased in the settings.

By default xUnit runs test projects in parallel. This can be disabled by adding the following to the `xunit.runner.json` file in the relevant project folder.

```json
{
	"parallelizeTestCollections": true
}
```

## Solution structure

Note that code is duplicated between projects rather than using a shared project for things such as `SlowDown()` so that there is no risk of the test behaviours cross-contaminating. Each project is a self-contained example of a particular approach to xunit setup.
