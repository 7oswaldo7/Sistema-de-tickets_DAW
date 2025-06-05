using GestionTicketsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models;

public class ClienteController : Controller
{
    private readonly GestionTicketsDBContext _context;
    private readonly IConfiguration _configuration;

    public ClienteController(GestionTicketsDBContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // Acción para mostrar el formulario de crear ticket y los tickets del cliente
    public IActionResult Index()
    {
        var usuarioId = HttpContext.Session.GetString("UserId");

        if (usuarioId == null)
        {
            return RedirectToAction("Login", "Account");  // Si el usuario no está logueado, redirigir al login
        }

        var usuario = _context.usuarios.Find(int.Parse(usuarioId));

        // Cargar los tickets creados por el cliente
        var tickets = _context.tickets
            .Include(t => t.estado_tickets)  // Incluir estado_tickets
            .Include(t => t.prioridades_tickets)  // Incluir prioridades_tickets
            .Include(t => t.Categorias_tickets)  // Incluir Categorias_tickets
            .Where(t => t.id_usuario == usuario.id_usuario)
            .ToList();

        // Cargar las categorías de tickets y prioridades desde la base de datos para el formulario de creación de ticket
        var categorias = _context.Categorias_tickets.ToList(); // Correcta carga de categorías
        var prioridades = _context.prioridades_tickets.ToList();

        // Crear el ViewModel con los tickets y las opciones de categorías y prioridades
        var model = new ClienteViewModel
        {
            Tickets = tickets,
            Categorias = categorias, // Asignar las categorías de tickets al ViewModel
            Prioridades = prioridades
        };

        // Pasar los datos al ViewModel para que se usen en la vista
        return View(model);
    }

    // Acción POST para crear un ticket
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CrearTicket(string titulo, string descripcion, int categoria, int prioridad)
    {
        var usuarioId = HttpContext.Session.GetString("UserId");

        if (usuarioId == null)
        {
            return RedirectToAction("Login", "Account");  // Si el usuario no está logueado, redirigir al login
        }

        var usuario = await _context.usuarios.FindAsync(int.Parse(usuarioId));

        if (usuario == null)
        {
            return RedirectToAction("Login", "Account");  // Si no encontramos el usuario, redirigir al login
        }

        // Crear el ticket
        var ticket = new tickets
        {
            titulo = titulo,
            descripcion = descripcion,
            fecha_creacion = DateTime.Now,
            id_usuario = usuario.id_usuario,
            id_categoria_ticket = categoria,  // Asignar la categoría seleccionada
            id_estado_ticket = 1,  // Ticket está en "Abierto"
            id_prioridad = prioridad,  // Asignar la prioridad seleccionada
            id_servicio = 1  // Puedes asignar un servicio de acuerdo a tu lógica (ejemplo: soporte técnico)
        };

        _context.tickets.Add(ticket);
        await _context.SaveChangesAsync();

        // Redirigir al cliente para ver los tickets creados
        return RedirectToAction("Index");
    }
}
