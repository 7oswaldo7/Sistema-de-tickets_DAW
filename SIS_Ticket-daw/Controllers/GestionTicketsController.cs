using GestionTicketsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIS_Ticket_daw.Controllers
{
    public class GestionTicketsController : Controller
    {
        private readonly GestionTicketsDBContext _context;

        public GestionTicketsController(GestionTicketsDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? empleadoId)
        {
            if (!empleadoId.HasValue)
            {
                return BadRequest("El parámetro empleadoId es requerido.");
            }

            // Verificar si existe el empleado en la base de datos
            var existeEmpleado = await _context.empleados.AnyAsync(e => e.id_empleado == empleadoId.Value);

            if (!existeEmpleado)
            {
                // Retornar 404 o mostrar una vista personalizada con mensaje
                return NotFound($"No se encontró un empleado con id {empleadoId.Value}.");
            }


            var ticketsAsignados = await _context.asignacion_tickets
                .Where(a => a.id_empleado == empleadoId)
                .Include(a => a.tickets)
                    .ThenInclude(t => t.estado_tickets)
                .Include(a => a.tickets.usuarios)
                .ToListAsync();

            var ticketsUnicos = ticketsAsignados
                .GroupBy(a => a.id_ticket)
                .Select(g => g.First())
                .ToList();

            return View(ticketsUnicos);
        }


        // GET: para editar ticket
        public async Task<IActionResult> Editar(int id)
        {
            var ticket = await _context.tickets
                .Include(t => t.estado_tickets)
                .FirstOrDefaultAsync(t => t.id_ticket == id);

            if (ticket == null)
            {
                return NotFound();
            }

            ViewBag.Estados = await _context.estado_tickets.ToListAsync();
            return View(ticket);
        }

        // POST: para guardar cambios
        [HttpPost]
        public async Task<IActionResult> Editar(int id, int id_estado_ticket, string descripcion)
        {
            var ticket = await _context.tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            ticket.id_estado_ticket = id_estado_ticket;
            ticket.descripcion = descripcion;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
