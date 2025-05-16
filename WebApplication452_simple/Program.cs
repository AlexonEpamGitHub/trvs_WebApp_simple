using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Area Registration (Equivalent to AreaRegistration.RegisterAllAreas())
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new HandleErrorAttribute()); // Global Filters Configuration
}).AddMvcOptions(options => options.Filters.Add(new HandleErrorAttribute()));

var app = builder.Build();

// Configure middleware
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
    // Routing Setup
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Note: Bundle registration (BundleConfig.RegisterBundles) is excluded as it's not applicable in .NET Core.

app.Run();