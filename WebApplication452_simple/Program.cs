using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Register HandleErrorAttribute as a global filter
    options.Filters.Add(new HandleErrorAttribute());

    // Enable legacy compatibility options
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

    // Register global filters (equivalent to FilterConfig.RegisterGlobalFilters)
    options.Filters.Add(new AuthorizeFilter());
});

// Register areas (equivalent to AreaRegistration.RegisterAllAreas)
builder.Services.AddRazorPages();

// Configure bundling (static files middleware for client-side bundling tools)
builder.Services.AddStaticFiles();

builder.Services.Configure<MvcOptions>(options =>
{
    // Enable detailed error messages in debug mode
    options.AllowInputFormatterExceptionMessages = true;
});

var app = builder.Build();

builder.Services.Configure<MvcOptions>(options =>
{
    // Enable detailed error messages in debug mode (equivalent to debug=true in Web.config)
    options.AllowInputFormatterExceptionMessages = true;
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Middleware for handling exceptions (equivalent to <customErrors> in Web.config)
    app.UseExceptionHandler("/Home/Error");

    // Enable HSTS for production environments
    app.UseHsts();
}

AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Configure routing to match legacy ASP.NET MVC setup
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
