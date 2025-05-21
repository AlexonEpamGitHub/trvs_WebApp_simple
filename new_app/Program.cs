using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using new_app.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Configure secure response headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("X-Powered-By"); // Remove unnecessary headers
    context.Response.Headers.Remove("Server");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff"); // Prevent MIME sniffing
    context.Response.Headers.Add("X-Frame-Options", "DENY"); // Prevent clickjacking
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block"); // Enable XSS protection
    await next();
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();