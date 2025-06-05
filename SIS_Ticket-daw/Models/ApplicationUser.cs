using Microsoft.AspNetCore.Identity;

namespace SIS_Ticket_daw.Models
{
    // Clase que extiende IdentityUser para manejar usuarios en el sistema
    public class ApplicationUser : IdentityUser
    {
        // Puedes agregar propiedades adicionales si es necesario, como "nombre", "telefono", etc.
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
}
