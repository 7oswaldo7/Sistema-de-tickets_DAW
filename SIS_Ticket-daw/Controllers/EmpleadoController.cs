using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_Ticket_daw.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();  // Vista del Empleado
        }
    }

}
