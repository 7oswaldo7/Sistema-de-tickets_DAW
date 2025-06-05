using GestionTicketsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIS_Ticket_daw.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SIS_Ticket_daw.Controllers
{
    public class SeguimientoController : Controller
    {
        private readonly GestionTicketsDBContext _context;

        public SeguimientoController(GestionTicketsDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.tickets
                .Include(t => t.usuarios)
                .Include(t => t.estado_tickets)
                .Include(t => t.asignacion_tickets)
                    .ThenInclude(a => a.empleados)
                        .ThenInclude(e => e.usuarios)
                .Include(t => t.comentarios)
                .ToListAsync();

            return View(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> AsignarEmpleado(int ticketId, int empleadoId)
        {
            var asignacion = new asignacion_tickets
            {
                id_ticket = ticketId,
                id_empleado = empleadoId,
                fecha_asignacion = DateTime.Now
            };

            _context.asignacion_tickets.Add(asignacion);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AgregarComentario(int ticketId, string comentarioTexto)
        {
            var comentario = new comentarios
            {
                id_ticket = ticketId,
                comentario_texto = comentarioTexto,
                estado = "Abierto",
                fecha_asignacion = DateTime.Now
            };

            _context.comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
