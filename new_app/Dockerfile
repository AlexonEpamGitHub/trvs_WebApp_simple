# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY *.sln .
COPY new_app/*.csproj ./new_app/
RUN dotnet restore

# Copy the entire application and build it
COPY new_app/. ./new_app/
WORKDIR /src/new_app
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the build output
COPY --from=build /app/publish .

# Expose the HTTP port
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "new_app.dll"]