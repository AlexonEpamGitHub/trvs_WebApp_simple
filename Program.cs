using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

// Define routing configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "blog",
    pattern: "blog/{articleId}",
    defaults: new { controller = "Blog", action = "Article" });

app.MapControllerRoute(
    name: "categories",
    pattern: "categories/{categoryName}/{pageNumber?}",
    defaults: new { controller = "Category", action = "List" });

app.MapControllerRoute(
    name: "product",
    pattern: "product/{productId}/{action=Details}",
    defaults: new { controller = "Product" });

app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{action=Dashboard}/{id?}",
    defaults: new { controller = "Admin" });

app.Run();