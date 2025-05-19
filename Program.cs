using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews();

// Register global filters (equivalent to Global.asax.cs filter registration)
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters.AuthorizeFilter());
});

// Configure services and bundles (if applicable)
builder.Services.AddRazorPages();

// Add additional configurations here if needed

var app = builder.Build();

// Register middlewares and routes
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

// Register endpoint routing
app.UseEndpoints(endpoints =>
{
    // Area registration (equivalent to Global.asax.cs area registration)
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    // Default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Razor pages (if applicable)
    endpoints.MapRazorPages();
});

app.Run();