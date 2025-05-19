using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

using Microsoft.AspNetCore.Mvc;

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.Filters.Add(new HandleErrorAttribute()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable serving static files from wwwroot
app.UseStaticFiles();

/*
 * Static file bundling and minification:
 * Note that bundling and minification of static files (like CSS and JavaScript) is typically performed
 * using external tools such as Webpack, Gulp, or other task runners. These tools are not included
 * in the ASP.NET Core framework and need to be added to your development workflow as required.
 */

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();