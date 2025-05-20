using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services and configuration logic migrated from Global.asax.cs
builder.Services.AddControllersWithViews(options =>
{
    // Register filters globally (migrated from Global.asax)
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Area registration logic
builder.Services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AddAreaPageRoute("Admin", "/Dashboard", "Admin/Dashboard");
    });

var app = builder.Build();

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Endpoint routing configuration
app.UseEndpoints(endpoints =>
{
    // Map default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Explicitly register area routes
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.Run();