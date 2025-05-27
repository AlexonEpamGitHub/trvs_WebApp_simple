using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using new_app.Data;
using new_app.Models;

// In .NET 8, we use top-level statements for the Program.cs file
// This is a file-scoped namespace declaration (C# 10 feature)
namespace new_app;

// Create a WebApplicationBuilder with command-line arguments
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Configure database context with SQL Server using connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MVC services with compatibility features for migrated app
builder.Services.AddControllersWithViews(options => 
{
    // Add automatic CSRF protection (similar to ValidateAntiForgeryToken attribute)
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute());
});

// Add Razor pages support (optional, but useful for some ASP.NET Core features)
builder.Services.AddRazorPages();

// Configure localization (if needed)
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Configure application
var app = builder.Build();

// Configure the HTTP request pipeline (middleware)
if (app.Environment.IsDevelopment())
{
    // In development, show detailed error pages
    app.UseDeveloperExceptionPage();
}
else
{
    // In production, use custom error page and HSTS
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Serve static files from wwwroot folder (CSS, JS, images)
app.UseStaticFiles();

// Enable routing middleware
app.UseRouting();

// Add authentication and authorization middleware (if needed)
app.UseAuthentication();
app.UseAuthorization();

// Configure routing patterns using endpoint routing
// Define custom routes first, then the default route
// This preserves the "otel/{id}" route from the original app
app.MapControllerRoute(
    name: "Otel",
    pattern: "otel/{id}",
    defaults: new { controller = "Hotels", action = "Details" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Run the application
app.Run();