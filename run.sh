#!/bin/sh -v
# A reminder of the method for seeing the full output and parallelism in action

# Run this from the project folder of interest, as the output from the entire sln is a not very useful jumble of different examples.

# e.g.
# cd ClassFixtureExample 
# ../run.sh 

GO_SLOW=true dotnet test -l "console;verbosity=detailed"
