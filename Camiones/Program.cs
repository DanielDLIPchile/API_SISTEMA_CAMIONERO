using Camiones.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Obtiene la cadena de conexión del archivo de configuración
// Obtiene la cadena de conexión del archivo de configuración
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;


// Verifica si la cadena de conexión no es nula ni está vacía antes de usarla
if (!string.IsNullOrEmpty(connectionString))
{
    // Agrega los servicios al contenedor
    builder.Services.AddControllersWithViews();

    // Configura el contexto de la base de datos con la cadena de conexión
    builder.Services.AddDbContext<CamionesContext>(options =>
    {
        options.UseMySQL(connectionString);
    });
}
else
{
    // Maneja el caso en el que la cadena de conexión sea nula o esté vacía
    // Por ejemplo, puedes registrar un mensaje de advertencia o lanzar una excepción
    // dependiendo de la lógica de tu aplicación
    Console.WriteLine("Advertencia: La cadena de conexión es nula o está vacía.");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
