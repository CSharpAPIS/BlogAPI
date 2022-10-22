# How to run migration?

- First of all, install `dotnet-ef` command if you haven't: `dotnet tool install --global dotnet-ef`
- Then do `dotnet ef database update`

<hr/>

If you want to use SQLite, change the constant defined in ./file, and then update the migration again.

If you are getting error on migration, delete `Migrations` directory once, then run `dotnet ef migrations add InitialCreate` and then update migrations again.

If you still got any error, open an issue on this repo and explain what you have done.
