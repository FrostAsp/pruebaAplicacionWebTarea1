using Microsoft.AspNetCore.Mvc;

using Clases_CRUD.CRUD_Modelos;
using JassonContreras_TAREA1asp.net.Servicios;
using JassonContreras_TAREA1asp.net.Models;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class ProveedoresController : Controller
    {

        private readonly IProvedor servicioProvedor;

        public ProveedoresController(IProvedor servicioProvedor)
        {
            this.servicioProvedor = servicioProvedor;
        }

        public async Task<ActionResult> Index()
        {
            var provedor = await servicioProvedor.ListaProvedor();

            if (provedor != null)
            {
                return View(provedor);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string buscar)
        {

            var filtroProvedor = await servicioProvedor.FiltroProvedorIndex(buscar);

            if (filtroProvedor != null)
            {
                return View(filtroProvedor);
            }
            else
            {
                var cliente = await servicioProvedor.ListaProvedor();

                return View(cliente);
            }

        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Provedor provedor)
        {

            var productoExiste = await servicioProvedor.CrearProvedor(provedor);

            if (productoExiste == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.result = "Ya Existe un Usuario con Esta Cedula.";
                return View();
            }

        }
        public async Task<ActionResult> Editar(int Id)
        {
            if (Id == 0)
            {
                return View();
            }

            var provedor = await servicioProvedor.BuscarProvedorEditar(Id);

            if (provedor == null)
            {
                return View();
            }

            return View(provedor);
        }
        [HttpPost]
        public async Task<ActionResult> Editar(Provedor proveedores)
        {
            if (proveedores == null)
            {
                return View();
            }

            var provedorEditado = await servicioProvedor.EditarProvedor(proveedores);

            if (provedorEditado == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.result = "Ya Existe un Usuario con Esta Cedula.";
                return View();
            }

        }

        public async Task<ActionResult> Eliminar(int Id)
        {

            if (Id == 0)
            {
                return View();
            }

            var provedor = await servicioProvedor.BuscarProvedorEliminar(Id);

            if (provedor == null)
            {
                return View();
            }
            return View(provedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int Id, Provedor proveedores)
        {
            var provedorBorrar = await servicioProvedor.EliminarProvedor(Id);

            if (provedorBorrar == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();
        }



    }
}
