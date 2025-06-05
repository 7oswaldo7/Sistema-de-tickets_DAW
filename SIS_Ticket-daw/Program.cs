using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models; // Aseg�rate de tener el using correcto

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del DbContext
builder.Services.AddDbContext<GestionTicketsDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestionTicketsDB")));

// Configuraci�n de servicios de sesiones
builder.Services.AddDistributedMemoryCache();  // Se requiere para almacenar los datos de la sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo m�ximo de la sesi�n
    options.Cookie.HttpOnly = true;  // Seguridad de las cookies
});

// Agregar servicios MVC (Controladores y Vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Usar archivos est�ticos como CSS, JS, etc.
app.UseStaticFiles();

// Habilitar el middleware de sesiones
app.UseSession();  // Debe estar aqu� para habilitar el uso de sesiones

// Usar rutas y autorizaci�n
app.UseRouting();
app.UseAuthorization();

// Configurar las rutas para las vistas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
