using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Load settings from appsettings.json
var runtimeSettings = builder.Configuration.GetSection("RuntimeSettings").Get<RuntimeSettings>();
builder.Services.AddSingleton(runtimeSettings);

// Configure runtime settings
if (runtimeSettings != null)
{
    if (!string.IsNullOrEmpty(runtimeSettings.TargetFramework))
    {
        // Log or handle target framework settings if needed
    }

    if (!string.IsNullOrEmpty(runtimeSettings.Platform))
    {
        // Log or handle platform settings if needed
    }
}

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
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

public class RuntimeSettings
{
    public string TargetFramework { get; set; }
    public string Platform { get; set; }
}