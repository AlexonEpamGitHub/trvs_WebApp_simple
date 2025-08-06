# .NET Framework to .NET Core 8 Migration Plan

## Overview
This document outlines the plan for migrating the WebApplication452_simple project from .NET Framework 4.5.2 to .NET Core 8.

## Application Analysis
- **Current Application**: ASP.NET MVC 5 (.NET Framework 4.5.2)
- **Database Access**: Entity Framework 6.5.1 (Code First)
- **Frontend**: Bootstrap 5.2.3, jQuery 3.7.0
- **Authentication**: None identified

## Migration Strategy
We will follow the side-by-side migration approach, creating a new .NET Core 8 application and porting components over incrementally.

## Migration Steps

### 1. Project Setup
- Create a new ASP.NET Core 8 MVC project
- Update solution file to include both projects
- Configure shared properties and settings

### 2. Model Migration
- Port model classes (Country, Customer, Hotel, Order)
- Migrate DbContext to Entity Framework Core
- Update data annotations and configurations
- Setup Entity Framework Core migrations

### 3. Controllers Migration
- Convert controllers to use ASP.NET Core patterns
- Update action methods for dependency injection
- Adapt routing attributes and conventions

### 4. Views Migration
- Port Razor views to be compatible with ASP.NET Core
- Update HTML helpers to Tag Helpers where appropriate
- Migrate layout and shared views

### 5. Static Content
- Move and update CSS files
- Update JavaScript references
- Configure static file middleware

### 6. Dependency Injection
- Setup services in Program.cs
- Configure DbContext service
- Add required services for MVC, static files, etc.

### 7. Configuration
- Migrate connection strings to appsettings.json
- Setup configuration providers
- Move app settings to appropriate locations

### 8. Testing and Refinement
- Test all functionality
- Address compatibility issues
- Optimize for performance

## Technologies to Use
- .NET Core 8
- Entity Framework Core 8
- ASP.NET Core MVC
- Bootstrap 5.2.3 (or newer)
- jQuery 3.7.0 (or consider modern alternatives)

## Resources
- [ASP.NET Core Migration Guide](https://learn.microsoft.com/en-us/aspnet/core/migration/inc/start?view=aspnetcore-8.0)
- [Entity Framework Core Migration](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [ASP.NET Core MVC Fundamentals](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-8.0)