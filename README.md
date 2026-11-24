# MVCProject

A .NET 9 ASP.NET Core MVC gym management application using Entity Framework Core and SQL Server.

## Requirements

- .NET 9 SDK
- SQL Server or SQL Server Express
- Visual Studio 2026 or another .NET-compatible development environment

## Run locally

1. Open `MVCProject.slnx` in Visual Studio.
2. Restore NuGet packages.
3. Ensure SQL Server is running and the `GymDb` database is available.
4. Apply the existing Entity Framework Core migration if the database has not been created.
5. Run the `MVCProject` project.

The default development URLs are configured in `MVCProject/Properties/launchSettings.json`.

## Project structure

- `MVCProject/Controllers` — MVC controllers
- `MVCProject/Entities` — domain entities
- `MVCProject/Contexts` — Entity Framework Core database context
- `MVCProject/Configurations` — entity configurations
- `MVCProject/Views` — Razor views
- `MVCProject/wwwroot` — CSS, JavaScript, and static assets
- `MVCProject/Migrations` — Entity Framework Core migrations

## Database configuration

The local SQL Server connection is currently configured in `MVCProject/Contexts/GymDbContext.cs`. Before deploying or sharing outside local development, move the connection string to user secrets or an environment-specific configuration file.
