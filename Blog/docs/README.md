# Pre requisits

## Database setup

You can download and install ravenDB for free [Here](https://ravendb.net/docs/article-page/4.2/csharp/start/getting-started) or setup docker image in docker directory.

## Dotnet CLI

Install the dotnet CLI in order to build, run and restore project [here](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60)

run dotnet restore

```
dotnet restore ./Blog/src/Blog.Api.csproj
```
run dotnet run to execute project

```
dotnet run --project ./Blog/src/Blog.Api.csproj
```

In order to run unit tests

```
dotnet test ./Blog/tests/Blog.Api.Tests.csproj
```

# Configuration

## database connection string

You must setup the database configuration into ./Blog/src/Blog.Api/appsettings*

## CI

The CICD directory has yaml file in order create artefact in azure.