using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using JassonContreras_TAREA1asp.net.Servicios;
using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    
    public class ClienteController : Controller
    {
        private readonly ICliente servicioCliente;

        public ClienteController(ICliente servicioCliente)
        {
            this.servicioCliente = servicioCliente;        
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var cedulaCliente = await servicioCliente.UsuarioLogeado();

            if (cedulaCliente == null)
            {
                return RedirectToAction("Validar", "Login");
            }

            var cliente = await servicioCliente.UsuarioLogeado();

            if (cliente != null && cliente.Cedula != "1-1111-1111")
            { 
                return View(cliente);
            }
            return View(cliente);
        }
        [Authorize]
        public async Task<ActionResult> Eliminar(int Id)
        {
            if (Id == 0)
            {
                return View();
            }

            var cliente = await servicioCliente.BuscarUsuarioEliminar(Id);

            if (cliente == null)
            {
                return View();
            }
            return View(cliente);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int Id,Cliente clienteEliminar)
        {
            var cliente = await servicioCliente.EliminarUsuario(Id);

            if (cliente==null)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Eliminar", "Cliente");
        }
        [Authorize]
        public async Task<ActionResult> Editar(int Id)
        {
            if(Id == 0)
            {
                return View();
            }

            var cliente = await servicioCliente.BuscarUsuarioEditar(Id);

            if(cliente == null)
            {
                return View();
            }

            return View(cliente);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Cliente edicionCliente)
        {
            var cliente = await servicioCliente.EditarUsuario(edicionCliente);

            if (cliente == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

        }

    }
}
