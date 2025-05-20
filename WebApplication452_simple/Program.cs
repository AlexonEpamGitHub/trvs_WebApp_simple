using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add support for areas.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configure application lifecycle settings from Global.asax.cs
// Register areas
app.Use(async (context, next) =>
{
    var routeData = context.GetRouteData();
    if (routeData.Values.ContainsKey("area"))
    {
        // Logic for handling areas if needed
    }
    await next.Invoke();
});

// Add and configure filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters.ValidateAntiForgeryTokenAttribute());
});

// Register routes
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Register static bundles
// Note: ASP.NET Core does not have direct support for BundleConfig like ASP.NET MVC.
// Instead, consider using tools like Webpack, Gulp, or similar for bundling/minifying.
// Here, we assume static file serving is configured.

app.Run();