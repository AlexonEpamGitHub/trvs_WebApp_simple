using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

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
else
{
    // Global exception handling middleware for development environment
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/html";

            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature != null)
            {
                var exception = exceptionHandlerFeature.Error;

                // Log the exception (use any logging framework or service)
                // Example: logger.LogError(exception, "An unhandled exception occurred.");

                // Display a simple error page or redirect to a custom error page
                await context.Response.WriteAsync("<html><body>\r\n");
                await context.Response.WriteAsync("We're sorry, an unexpected error occurred.<br>\r\n");

                // Display exception details in development for debugging purposes
                await context.Response.WriteAsync($"<strong>Exception: {exception.Message}</strong><br>\r\n");
                await context.Response.WriteAsync("<pre>\r\n");
                await context.Response.WriteAsync(exception.StackTrace);
                await context.Response.WriteAsync("</pre>\r\n");
                await context.Response.WriteAsync("</body></html>\r\n");
            }
        });
    });
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