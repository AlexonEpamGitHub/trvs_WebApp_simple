# New Application Migration

## Overview
This document provides an overview of the migration process for the legacy application to .NET 8 and ASP.NET Core MVC. It includes the purpose of the application and its high-level goals.

## Technology Stack
- **.NET 8**: Modern framework for building high-performance applications.
- **ASP.NET Core MVC**: For creating web applications with a Model-View-Controller pattern.
- **Entity Framework Core**: For database interaction and management.
- **Docker**: Containerization for deployment.
- **Bootstrap**: For responsive UI design.
- **jQuery**: For DOM manipulation and client-side scripting.

## Migration Strategy
The migration was carried out in the following steps:
1. **Code Analysis**: Reviewed legacy application codebase.
2. **Project Setup**: Created a new .NET 8 project.
3. **Code Refactoring**: Updated code to align with modern .NET practices.
4. **Testing**: Ensured functional parity with the legacy application.
5. **Deployment**: Containerized the application using Docker.

## Features
- Responsive web design using Bootstrap.
- RESTful APIs for data interaction.
- Improved performance with .NET 8.
- Enhanced security features.

## Getting Started
### Prerequisites
- Install .NET 8 SDK.
- Install Docker (optional).

### Steps
1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```
2. Navigate to the project directory:
    ```bash
    cd new_app
    ```
3. Build and run the application:
    ```bash
    dotnet run
    ```

## Configuration
- Application settings are stored in `appsettings.json`.
- Development-specific settings are in `appsettings.Development.json`.

## Docker Support
1. Build the Docker image:
    ```bash
    docker build -t new-app .
    ```
2. Run the Docker container:
    ```bash
    docker run -p 5000:5000 new-app
    ```

## Testing
- Unit tests are located in the `test/` directory.
- Run tests using the following command:
    ```bash
    dotnet test
    ```

## Deployment
- Deploy the application using Docker or your preferred cloud hosting platform.

## Known Issues
- No known issues at this time.

## License
- MIT License

## Contributors
- Acknowledge all contributors involved in the migration process.