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

        // Acci�n Index
        public IActionResult Index()
        {
            // Verificar si el usuario est� autenticado
            if (!User.Identity.IsAuthenticated)
            {
                // Redirigir al login si no est� autenticado
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // Acci�n Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }

}
