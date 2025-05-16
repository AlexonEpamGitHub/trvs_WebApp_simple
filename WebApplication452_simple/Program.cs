using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Migrate Application_Start functionality from Global.asax.cs
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc(options =>
{
    // Add filters or any additional setup if needed
});

// Register areas support if required
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure middleware
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

// Configure routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Run the application
app.Run();