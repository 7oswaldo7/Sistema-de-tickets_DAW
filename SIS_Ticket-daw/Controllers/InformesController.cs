using GestionTicketsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SIS_Ticket_daw.Controllers
{
    public class InformesController : Controller
    {
        private readonly GestionTicketsDBContext _context;

        public InformesController(GestionTicketsDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Datos para el dashboard (resumen rápido)
            var totalTickets = await _context.tickets.CountAsync();
            var ticketsAbiertos = await _context.tickets.Where(t => t.id_estado_ticket == 1).CountAsync(); // Asumiendo 1 = Abierto
            var ticketsCerrados = await _context.tickets.Where(t => t.id_estado_ticket == 2).CountAsync(); // Asumiendo 2 = Cerrado
            var ticketsAsignados = await _context.asignacion_tickets.CountAsync();

            // Datos para informe: Tickets por estado
            var ticketsPorEstado = await _context.estado_tickets
                .Select(e => new
                {
                    Estado = e.estado,
                    Conteo = _context.tickets.Count(t => t.id_estado_ticket == e.id_estado_ticket)
                }).ToListAsync();

            // Datos para informe: Tickets por prioridad
            var ticketsPorPrioridad = await _context.prioridades_tickets
                .Select(p => new
                {
                    Prioridad = p.nivel_prioridad,
                    Conteo = _context.tickets.Count(t => t.id_prioridad == p.id_prioridad)
                }).ToListAsync();

            // Pasar datos a la vista mediante ViewBag o ViewModel
            ViewBag.TotalTickets = totalTickets;
            ViewBag.TicketsAbiertos = ticketsAbiertos;
            ViewBag.TicketsCerrados = ticketsCerrados;
            ViewBag.TicketsAsignados = ticketsAsignados;
            ViewBag.TicketsPorEstado = ticketsPorEstado;
            ViewBag.TicketsPorPrioridad = ticketsPorPrioridad;

            return View();
        }
    }
}
