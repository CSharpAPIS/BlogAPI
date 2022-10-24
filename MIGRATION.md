# Database Migration for the project

## How to run migration?

- First of all, install `dotnet-ef` command if you haven't: `dotnet tool install --global dotnet-ef`
- Then do `dotnet ef migrations add MigrationName` and `dotnet ef database update`

<hr/>

## What types of databases are supported?
Currently, only `SQLite` and `Microsoft SQL Server` databases are supported.

If you want to use SQLite, change the constant defined in ./file, and then update the migration again.

If you are getting error on migration, delete `Migrations` directory once, then run `dotnet ef migrations add InitialCreate` and then update migrations again.

If you still got any error, open an issue on this repo and explain what you have done.

<hr/>

## How to pass args to the migrator?
Starting in EF Core 5.0, you can specify these arguments from the tools:

```sh
dotnet ef database update -- --environment Production
```

   - [source](https://learn.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args)

<hr/>
