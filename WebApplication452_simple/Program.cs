using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews().AddMvcOptions(options =>
{
    options.Filters.Add(new HandleErrorAttribute());
});

var app = builder.Build();

// Register areas
AreaRegistration.RegisterAllAreas();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
    // Add routing logic from RouteConfig.cs
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Ensure bundles are handled through modern tools (Webpack/Gulp)
// Note: The actual setup of Webpack or Gulp is typically outside the scope of this file.
// You would configure those tools in their respective configuration files (e.g., webpack.config.js or gulpfile.js).

app.Run();