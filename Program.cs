using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container following .NET 8 Core MVC best practices.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages support if needed.
builder.Services.AddRouting(options => options.LowercaseUrls = true); // Enforce lowercase URLs for routing.
builder.Services.AddHttpContextAccessor(); // Add HTTP context accessor for dependency injection if required.

// Configure application settings if needed.
// Example: builder.Configuration["Key"] = "Value";

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure routing directly within this file, replacing RouteConfig.cs.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Add this if using Razor Pages.

app.Run();