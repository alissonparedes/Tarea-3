using Clientes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Proveedor Pomelo para MySQL. Reemplaza al proveedor Oracle MySql.EntityFrameworkCore.
var cn = builder.Configuration.GetConnectionString("cn")
    ?? throw new InvalidOperationException("Falta ConnectionStrings:cn en appsettings.json");

builder.Services.AddDbContext<ClientesDbContext>(opciones =>
    opciones.UseMySql(cn, ServerVersion.AutoDetect(cn)));

builder.Services.AddControllersWithViews();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}");

// La base de datos se crea/aplica solo desde migraciones (NO EnsureCreated).
app.Run();
