using Microsoft.AspNetCore.Mvc;
using SIS_Ticket_daw.Models;

public class AccountController : Controller
{
    private readonly GestionTicketsDBContext _context;

    public AccountController(GestionTicketsDBContext context)
    {
        _context = context;
    }

    // Acción GET para mostrar el formulario de login
    public IActionResult Login()
    {
        return View();
    }

    // Acción POST para autenticar al usuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string password)
    {
        var user = _context.usuarios.SingleOrDefault(u => u.correo_electronico == email);

        if (user != null && user.contrasena == password)
        {
            // Autenticación exitosa: establecer la sesión
            HttpContext.Session.SetString("UserId", user.id_usuario.ToString());

            // Consultar el rol del usuario desde la tabla 'empleados'
            var empleado = _context.empleados.SingleOrDefault(e => e.id_usuario == user.id_usuario);
            var rol = _context.roles.SingleOrDefault(r => r.id_rol == empleado.id_rol);

            if (rol != null)
            {
                if (rol.nombre_rol == "Administrador")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (rol.nombre_rol == "Empleado")
                {
                    return RedirectToAction("Index", "Empleado");
                }
                else if (rol.nombre_rol == "Cliente")
                {
                    return RedirectToAction("Index", "Cliente");
                }
            }
        }

        ModelState.AddModelError(string.Empty, "Credenciales incorrectas.");
        return View();
    }

    // Acción para logout (cerrar sesión)
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();  // Limpiar la sesión del usuario
        return RedirectToAction("Login", "Account");  // Redirigir al login
    }
}
