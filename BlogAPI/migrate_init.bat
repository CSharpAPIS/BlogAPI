@echo off
dotnet ef migrations add InitialCreate
dotnet ef database update

