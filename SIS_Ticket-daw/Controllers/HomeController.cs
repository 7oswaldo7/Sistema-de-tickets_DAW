using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIS_Ticket_daw.Models;

namespace SIS_Ticket_daw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción Index
        public IActionResult Index()
        {
            // Verificar si el usuario está autenticado
            if (!User.Identity.IsAuthenticated)
            {
                // Redirigir al login si no está autenticado
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // Acción Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }

}
