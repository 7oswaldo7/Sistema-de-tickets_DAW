using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestionTicketsDB.Models;  // Tu espacio de nombres con las entidades

namespace SIS_Ticket_daw.Models
{
    public class GestionTicketsDBContext : DbContext
    {
        public GestionTicketsDBContext(DbContextOptions<GestionTicketsDBContext> options)
            : base(options)
        {
        }

        // DbSets para las demás entidades de tu aplicación
        public DbSet<roles> roles { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<empleados> empleados { get; set; }
        public DbSet<servicio_cliente> servicio_cliente { get; set; }
        public DbSet<categorias_servicios> categorias_servicios { get; set; }
        public DbSet<estado_servicios> estado_servicios { get; set; }
        public DbSet<servicios> servicios { get; set; }
        public DbSet<prioridades_tickets> prioridades_tickets { get; set; }
        public DbSet<estado_tickets> estado_tickets { get; set; }
        public DbSet<Categorias_tickets> Categorias_tickets { get; set; }
        public DbSet<tickets> tickets { get; set; }
        public DbSet<asignacion_tickets> asignacion_tickets { get; set; }
        public DbSet<comentarios> comentarios { get; set; }
        public DbSet<archivos_comentarios> archivos_comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Asegúrate de llamar al método base

            // Configurar relaciones con eliminación restrictiva (evitar eliminación en cascada)
            modelBuilder.Entity<asignacion_tickets>()
                .HasOne(a => a.tickets)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);  // Evita la eliminación en cascada

            modelBuilder.Entity<asignacion_tickets>()
                .HasOne(a => a.empleados)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);  // Evita la eliminación en cascada


        }
    }
}


