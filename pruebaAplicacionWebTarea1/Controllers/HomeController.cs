using Microsoft.AspNetCore.Mvc;
using JassonContreras_TAREA1asp.net.Models;
using System.Diagnostics;


using Microsoft.AspNetCore.Authorization;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
                                                                                                                                                                                                                                                }
        [Authorize()]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Proveedores()
        {
            return View();
        }
        public IActionResult ListaClientes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}