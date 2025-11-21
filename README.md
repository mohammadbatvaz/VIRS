# VIRS

Short description (GitHub): Vehicle Inspection Request System (VIRS) — an example ASP.NET Core project with layered architecture and EF Core

## Overview
VIRS is an educational/example project that demonstrates a layered architecture and domain separation in an ASP.NET Core application. It follows domain-driven principles and separates responsibilities across distinct projects for domain models, application services, domain services, infrastructure (data access and storage), and a presentation layer (MVC).

The system models concepts such as car models, car owners, images, and inspection requests and provides the foundation for managing related operations.

## Key Features
- Clear layered architecture: Domain, AppServices (application layer), Services (domain services), Infrastructure (repositories, DB), and Presentation (MVC)
- Data access using Entity Framework Core and support for migrations
- Multiple database implementations: SQL Server (EF Core) and an in-memory variant for testing
- File storage example for images and file handling

## Technologies
- .NET 10 / ASP.NET Core (TargetFramework: `net10.0`)
- ASP.NET Core MVC
- Entity Framework Core (EF Core)
- SQL Server (EF Core provider)
- In-memory database implementation (for tests or quick runs)

## Project Structure (high-level)
- `VIRS.slnx` / Solution: groups the projects in the repository
- `VIRS.Domain.Core/`: domain entities and core domain logic
- `VIRS.Domain.Services/`: domain-level services and business logic
- `VIRS.Domain.AppServices/`: application services (coordinate use cases and act as a boundary for the presentation layer)
- `VIRS.Infra.DataAccess.EFCore/`: repository implementations using EF Core
- `VIRS.Infra.DataAccess.Storage/`: file and image storage utilities
- `VIRS.Infra.DataBase.EFCoreSqlServer/`: EF Core `DbContext` and migrations for SQL Server
- `VIRS.Infra.DataBase.InMemoryStaticDB/`: in-memory database implementation for testing and demos
- `VIRS.Presentation.WebApp.MVC/`: ASP.NET Core MVC web application (contains `appsettings.json` and `Program.cs`)
- `WebApplication1/`: additional/sample presentation project (may be an alternate or earlier sample)