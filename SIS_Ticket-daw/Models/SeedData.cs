using GestionTicketsDB.Models;

namespace SIS_Ticket_daw.Models
{
    public class SeedData
    {
        public static void Initialize(GestionTicketsDBContext context)
        {
            // Insertar roles si no existen
            if (!context.roles.Any())
            {
                context.roles.AddRange(
                    new roles { nombre_rol = "Administrador", descripcion_rol = "Rol con privilegios completos en el sistema" },
                    new roles { nombre_rol = "Empleado", descripcion_rol = "Rol con acceso para gestionar tickets asignados" },
                    new roles { nombre_rol = "Cliente", descripcion_rol = "Rol para crear tickets y ver el estado de los mismos" }
                );
                context.SaveChanges();
            }

            // Insertar usuarios si no existen
            if (!context.usuarios.Any())
            {
                var admin = new usuarios
                {
                    nombre = "Darwin Aguirre",
                    genero = "Masculino",
                    telefono = "77777777",
                    correo_electronico = "darwin@gmail.com",
                    contrasena = "1234"  // Contraseña en texto plano
                };
                var empleado = new usuarios
                {
                    nombre = "Juan Pérez",
                    genero = "Masculino",
                    telefono = "1234567890",
                    correo_electronico = "juan.perez@gmail.com",
                    contrasena = "1234"  // Contraseña en texto plano
                };
                var cliente = new usuarios
                {
                    nombre = "Ana García",
                    genero = "Femenino",
                    telefono = "0987654321",
                    correo_electronico = "ana.garcia@gmail.com",
                    contrasena = "1234"  // Contraseña en texto plano
                };

                context.usuarios.AddRange(admin, empleado, cliente);
                context.SaveChanges();

                // Relacionar los usuarios con los roles
                context.empleados.AddRange(
                    new empleados { id_usuario = admin.id_usuario, id_rol = 1 }, // Administrador
                    new empleados { id_usuario = empleado.id_usuario, id_rol = 2 }, // Empleado
                    new empleados { id_usuario = cliente.id_usuario, id_rol = 3 }  // Cliente
                );
                context.SaveChanges();
            }
        }
    }
}
