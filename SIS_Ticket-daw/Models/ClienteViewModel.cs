using GestionTicketsDB.Models;

namespace SIS_Ticket_daw.Models
{
    public class ClienteViewModel
    {
        public List<tickets> Tickets { get; set; }  // Lista de tickets creados por el cliente
        public List<Categorias_tickets> Categorias { get; set; }  // Categorías de tickets disponibles
        public List<prioridades_tickets> Prioridades { get; set; }  // Prioridades disponibles
    }
}
