using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware
app.UseRouting();
app.UseStaticFiles();

// Configure routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();