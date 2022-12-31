using Clases_CRUD.CRUD_Modelos;
using JassonContreras_TAREA1asp.net.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class ProductoController : Controller
    {
        
        List<int> idProvedores = new List<int>();

        private readonly IProducto servicioProducto;

        public ProductoController(IProducto servicioProducto)
        {
            this.servicioProducto = servicioProducto;
        }

        public async Task<ActionResult> Index()
        {
            var cliente = await servicioProducto.ListaProducto();

            if (cliente != null)
            {
                return View(cliente);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string buscar)
        {
            var filtroProducto = await servicioProducto.FiltroProductoIndex(buscar);

            if (filtroProducto != null)
            {
                return View(filtroProducto);
            }
            else
            {
                var cliente = await servicioProducto.ListaProducto();

                return View(cliente);
            }
          
        }
        public async Task<ActionResult> Crear()
        {
            foreach (var id in await servicioProducto.ListaProvedores())
            {
                idProvedores.Add(id.Id);
            }

            ViewBag.listaProvedor = idProvedores;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(int? Id, Producto producto)
        {
            var productoExiste = await servicioProducto.CrearProducto(producto);

            if (productoExiste == null)
            {
                foreach (var id in await servicioProducto.ListaProvedores())
                {
                    idProvedores.Add(id.Id);
                }
                ViewBag.listaProvedor = idProvedores;
                return View();

            }
            return RedirectToAction("Index", "Producto");
        }

        public async Task<ActionResult> Editar(int Id)
        {
            var producto = await servicioProducto.BuscarProductoEditar(Id);

            if (producto == null)
            {
                return View();
            }
            
            foreach (var id in await servicioProducto.ListaProvedores())
            {
                idProvedores.Add(id.Id);
            }
            ViewBag.listaProvedor = idProvedores;
    
            return View(producto);
        }
        [HttpPost]
        public async Task<ActionResult> Editar(int Id, Producto producto)
        {

            //producto.provedor.Descripcion = "Esperando llenado de descripcion...";

            var productoEditado = await servicioProducto.EditarProducto(Id, producto);

            if (productoEditado == null)
            {
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Eliminar(int Id)
        {
            var producto = await servicioProducto.BuscarProductoEliminar(Id);

            if (producto == null)
            {
                return View();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int Id, Producto producto)
        {
            var productoBorrar = await servicioProducto.EliminarProducto(Id);

            if (productoBorrar == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

    }
}
