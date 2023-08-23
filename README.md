# Lord of the Rings SDK

## Installing the SDK
Currently the SDK must be installed by building the project either in Visual Studio or by running `dotnet  build` from the command line.   

Once the dll has been built, it can be manually added to any .NET project you are working on.

> **Future State:** Project should automatically build and publish a nuget package for consumption.
## Using the SDK
1. Within your `Program.cs`, call `.AddLOTR("{apiKey}")` to make the SDK classed available in your project.
1. Using .NET Core built in Dependency Injection, inject the necessary Services into you project as needed.
1. Service methods can be consumed to call into the LOTR APIs.
## Testing the SDK 
Sample Unit tests have been provided in UnitTests project.  They can be run using the `dotnet test` command from the project directory.
A Swagger based test harness has been provided to test the endpoints.