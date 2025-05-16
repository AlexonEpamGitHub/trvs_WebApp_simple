using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create a builder for the application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container using built-in .NET Core dependency injection
builder.Services.AddControllersWithViews();

// Register services previously defined in App_Start/NinjectWebCommon.cs
// Example service registrations; update these based on actual services and lifetimes
builder.Services.AddTransient<IMyTransientService, MyTransientService>();
builder.Services.AddScoped<IMyScopedService, MyScopedService>();
builder.Services.AddSingleton<IMySingletonService, MySingletonService>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Migrate route configuration from RouteConfig.cs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();