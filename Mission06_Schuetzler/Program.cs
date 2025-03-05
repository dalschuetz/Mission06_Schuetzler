using Microsoft.EntityFrameworkCore; // Entity Framework
using Mission06_Schuetzler.Models; // Models

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // MVC Pattern (Controllers, Views)


// Push to SQLite database
builder.Services.AddDbContext<MovieContext>(options => // DbContext, DbSet
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"))); // Connection String, Entity Framework


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Middleware, Controllers (Error Handling)
    app.UseHsts(); // Middleware
}

app.UseHttpsRedirection(); // Middleware
app.UseStaticFiles(); // .UseStaticFiles()

app.UseRouting(); // .UseRouting()

app.UseAuthorization(); // Middleware

app.MapControllerRoute( // Navigation (Routing) in MVC
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Controllers, Actions, Routing

app.Run(); // Middleware (Starting the Application)

