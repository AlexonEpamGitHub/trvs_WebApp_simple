using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews(); // Adding MVC services

// Register additional services for areas, filters, routes, and bundles
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Register areas, filters, routes, and bundles
AreaRegistration.RegisterAllAreas();
RouteConfig.RegisterRoutes(app);
BundleConfig.RegisterBundles();

// Configure routes using UseEndpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
