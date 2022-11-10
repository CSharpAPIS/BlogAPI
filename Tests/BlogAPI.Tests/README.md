# How to add Tests to a csharp project.


* Create the BlogAPI.Tests project by running the following command:

```sh
dotnet new xunit -o BlogAPI.Tests
```

* Add the test project to the solution file by running the following command:
```sh
dotnet sln add ./BlogAPI.Tests/BlogAPI.Tests.csproj
```

* Add the BlogAPI project as a dependency to the BlogAPI.Tests project:
```sh
dotnet add ./Tests/BlogAPI.Tests/BlogAPI.Tests.csproj reference ./BlogAPI/BlogAPI.csproj
```



