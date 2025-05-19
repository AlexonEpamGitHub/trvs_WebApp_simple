using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register MVC services and configure global filters.
builder.Services.AddControllersWithViews(options =>
{
    // Add global filters here.
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters.AllowAnonymousFilter()); // Example filter, replace with actual filters as needed.
    // Add more filters as necessary.
});

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

// Map routes (from RouteConfig).
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();