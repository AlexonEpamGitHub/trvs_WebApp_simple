using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Bind configuration settings
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
var compilationSettings = builder.Configuration.GetSection("CompilationSettings").Get<CompilationSettings>();

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new HandleErrorFilter());
    options.Filters.Add(new AuthorizeFilter()); // Example: Add additional filters if needed
});

// Register areas
builder.Services.AddRazorPages();

// Register configuration settings as singleton services
builder.Services.AddSingleton(appSettings);
builder.Services.AddSingleton(compilationSettings);

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

app.UseEndpoints(endpoints =>
{
    // Configure routes
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Map Razor Pages for areas
    endpoints.MapRazorPages();
});

app.Run();

// AppSettings class
public class AppSettings
{
    public string ApplicationName { get; set; }
    public string Version { get; set; }
    // Add other properties as needed
}

// CompilationSettings class
public class CompilationSettings
{
    public bool EnableDebug { get; set; }
    public string TargetFramework { get; set; }
    // Add other properties as needed
}