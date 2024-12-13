using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using DotNetEnv; // Import DotNetEnv namespace

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load(); // This loads variables from the .env file into environment variables.

// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<MyAppContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("DEFAULTCONNECTION")));
// Note: The above line uses the environment variable directly. 
// If you're using "DefaultConnection" from `appsettings.json`, use the builder.Configuration method instead.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // The default HSTS value is 30 days.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
