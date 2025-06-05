using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models; // Asegúrate de tener el using correcto

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext
builder.Services.AddDbContext<GestionTicketsDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestionTicketsDB")));

// Configuración de servicios de sesiones
builder.Services.AddDistributedMemoryCache();  // Se requiere para almacenar los datos de la sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo máximo de la sesión
    options.Cookie.HttpOnly = true;  // Seguridad de las cookies
});

// Agregar servicios MVC (Controladores y Vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Usar archivos estáticos como CSS, JS, etc.
app.UseStaticFiles();

// Habilitar el middleware de sesiones
app.UseSession();  // Debe estar aquí para habilitar el uso de sesiones

// Usar rutas y autorización
app.UseRouting();
app.UseAuthorization();

// Configurar las rutas para las vistas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
