using Camiones.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Obtiene la cadena de conexi�n del archivo de configuraci�n
// Obtiene la cadena de conexi�n del archivo de configuraci�n
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;


// Verifica si la cadena de conexi�n no es nula ni est� vac�a antes de usarla
if (!string.IsNullOrEmpty(connectionString))
{
    // Agrega los servicios al contenedor
    builder.Services.AddControllersWithViews();

    // Configura el contexto de la base de datos con la cadena de conexi�n
    builder.Services.AddDbContext<CamionesContext>(options =>
    {
        options.UseMySQL(connectionString);
    });
}
else
{
    // Maneja el caso en el que la cadena de conexi�n sea nula o est� vac�a
    // Por ejemplo, puedes registrar un mensaje de advertencia o lanzar una excepci�n
    // dependiendo de la l�gica de tu aplicaci�n
    Console.WriteLine("Advertencia: La cadena de conexi�n es nula o est� vac�a.");
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
