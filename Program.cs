using Grupo4CineCartelera.Data;
using Grupo4CineCartelera.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Conexión a SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuración de Identity con soporte de Roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Servicios MVC y Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuración HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

// Inicialización de Roles y Usuarios de prueba (Fase 5)
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // 1. Crear roles Curador y Espectador si no existen
    string[] roles = { "Curador", "Espectador" };
    foreach (var rol in roles)
    {
        if (!await roleManager.RoleExistsAsync(rol))
        {
            await roleManager.CreateAsync(new IdentityRole(rol));
        }
    }

    // 2. Crear usuario Curador (Rol de gestión)
    string emailCurador = "curador@cine.com";
    var curador = await userManager.FindByEmailAsync(emailCurador);
    if (curador == null)
    {
        curador = new ApplicationUser
        {
            UserName = emailCurador,
            Email = emailCurador,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(curador, "Curador123!");
    }
    if (!await userManager.IsInRoleAsync(curador, "Curador"))
    {
        await userManager.AddToRoleAsync(curador, "Curador");
    }

    // 3. Crear usuario Espectador (Rol de consulta)
    string emailEspectador = "espectador@cine.com";
    var espectador = await userManager.FindByEmailAsync(emailEspectador);
    if (espectador == null)
    {
        espectador = new ApplicationUser
        {
            UserName = emailEspectador,
            Email = emailEspectador,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(espectador, "Espectador123!");
    }
    if (!await userManager.IsInRoleAsync(espectador, "Espectador"))
    {
        await userManager.AddToRoleAsync(espectador, "Espectador");
    }
}

app.Run();