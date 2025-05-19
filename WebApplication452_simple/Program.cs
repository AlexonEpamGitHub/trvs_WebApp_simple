using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register MVC services and configure global filters.
builder.Services.AddControllersWithViews(options =>
{
    // Create an instance of MvcOptions to configure filters.
    var mvcOptions = new MvcOptions();
    
    // Add global filters here, such as HandleErrorAttribute or others.
    mvcOptions.Filters.Add(new Microsoft.AspNetCore.Mvc.Filters.HandleErrorAttribute());
    
    // Apply MvcOptions to the options.Filters collection.
    foreach (var filter in mvcOptions.Filters)
    {
        options.Filters.Add(filter);
    }
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