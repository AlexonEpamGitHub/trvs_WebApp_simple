using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Global Filters
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddRazorPages();

// Register Areas
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddAreaFolderRoute("Admin", "/Admin", "Admin/{controller=Home}/{action=Index}/{id?}");
    options.Conventions.AddAreaFolderRoute("User", "/User", "User/{controller=Home}/{action=Index}/{id?}");
});

// Example dependency injection configurations
builder.Services.AddTransient<IMyService, MyService>();
builder.Services.AddScoped<IMyOtherService, MyOtherService>();
builder.Services.AddSingleton<IMySingletonService, MySingletonService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure route table
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    
    endpoints.MapRazorPages();
});

app.Run();