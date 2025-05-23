using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure logging as needed
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var app = builder.Build();

// Middleware for handling errors globally
app.UseExceptionHandler("/Home/Error"); // Redirects to shared error view

// Middleware for serving static files
app.UseStaticFiles();

// Middleware for routing
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Application is running
app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation("Default page accessed");
});

app.Run();
