using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebOptimizer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add WebOptimizer for bundling and minification
builder.Services.AddWebOptimizer(pipeline =>
{
    // Add JavaScript bundling
    pipeline.AddJavaScriptBundle("/js/bundle.js", "wwwroot/Scripts/*.js");

    // Add CSS bundling
    pipeline.AddCssBundle("/css/bundle.css", "wwwroot/Styles/*.css");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Configure static file serving from the wwwroot folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = string.Empty
});

// Enable WebOptimizer middleware for bundling and minification
app.UseWebOptimizer();

app.UseRouting();

app.UseAuthorization();

using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection.Extensions;

// Register areas
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Register global filters
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
