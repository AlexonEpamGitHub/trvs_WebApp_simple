# Application Documentation

## Purpose
This application serves as a platform for managing and showcasing the capabilities of migrating .NET Framework to .NET 8 with ASP.NET Core MVC. It highlights the modernization of legacy systems and demonstrates the benefits of adopting the latest tech stack.

## Usage
The application provides functionalities for user management, data visualization, and responsive design, leveraging the features of ASP.NET Core MVC and Razor Pages.

## Migration Summary
The application has been migrated from .NET Framework 4.5.2 to .NET 8, transitioning from ASP.NET MVC 5 to ASP.NET Core MVC. This migration includes the following updates:

- Adoption of .NET 8 and ASP.NET Core MVC
- Implementation of Razor Pages for enhanced UI development
- Modernization of routing, configuration, and dependency injection mechanisms

## Setup Instructions

### Prerequisites
- Install .NET 8 SDK
- Ensure database requirements are met
- Configure external dependencies as specified in `appsettings.json`

### Local Setup
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Switch to the migration branch:
   ```bash
   git checkout mason-net-migration
   ```
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
4. Run database migrations:
   ```bash
   dotnet ef database update
   ```
5. Start the application:
   ```bash
   dotnet run
   ```

### Deployment
Follow the deployment guidelines provided in the `docs/deployment.md` file to publish and host the application in a production environment.