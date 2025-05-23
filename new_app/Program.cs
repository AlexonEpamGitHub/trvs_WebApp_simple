using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container with .NET 8 compatibility
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Register Razor Pages if needed
builder.Services.AddResponseCompression(); // Add middleware for better performance

var app = builder.Build();

// Ensure proper configuration for the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Enforce HTTPS usage
app.UseStaticFiles(); // Enable serving of static files
app.UseResponseCompression(); // Use response compression middleware for performance

app.UseRouting();

app.UseAuthorization(); // Setup authorization middleware

// Configure modern routing for controllers and Razor Pages
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Explicitly map Razor Pages

app.Run();