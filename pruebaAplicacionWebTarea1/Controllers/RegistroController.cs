using Microsoft.AspNetCore.Mvc;
using JassonContreras_TAREA1asp.net.Servicios;
using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ICliente servicioCliente;

        public RegistroController(ICliente servicioCliente)
        {
            this.servicioCliente = servicioCliente;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NuevoRegistro()
        {       
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NuevoRegistro(Cliente nuevoCliente)//se ingresa el objeto cargado de la vista nuevo registro
        {
            if (nuevoCliente.Cedula == null || nuevoCliente.Telefono == 0 || nuevoCliente.CorreoElectronico == null || nuevoCliente.Contraseña == null || nuevoCliente.Profecion == null || nuevoCliente.FechaNacimiento == 0)
            {
                return View();
            }

            var existe = await servicioCliente.CrearUsuario(nuevoCliente);

            if (existe == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.result = "Ya Existe un Usuario con Esta Cedula.";
                return View();
            }

            
        }

    }
}

