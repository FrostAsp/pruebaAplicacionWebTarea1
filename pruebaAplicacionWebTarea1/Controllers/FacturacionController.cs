using Microsoft.AspNetCore.Mvc;
using Clases_CRUD.CRUD_Modelos;
using JassonContreras_TAREA1asp.net.Servicios;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly IFacturacion servicioFacturacion;

        List<int> listidtours = new List<int>();
        List<int> listidproductos = new List<int>();
        
        int precioTotalsinIva = 0;
        int acumuladorIVa = 0;
        double IVA = 0.13;
        public FacturacionController(IFacturacion servicioFacturacion)
        {
            this.servicioFacturacion = servicioFacturacion;
        }
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var listaFacturacion = await servicioFacturacion.ListasFacturacion();

            return View(listaFacturacion);
        }
        [Authorize]
        public async Task<ActionResult> Crear()
        {
            var cedulaCliente = await servicioFacturacion.UsuarioLogeado();

            if (cedulaCliente == null)
            {

                return RedirectToAction("Validar", "Login");
            }

            var listasFacturacion = await servicioFacturacion.ListasFacturacion();


            /////

            foreach (var tours in listasFacturacion)
            {
                foreach (var idtours in tours.tour)
                {
                    listidtours.Add(idtours.Id);                   
                }
            }
            ViewBag.listaTours = listidtours;

            ////

            foreach (var productos in listasFacturacion)
            {
                foreach (var idProductos in productos.producto)
                {
                   
                   listidproductos.Add(idProductos.Id);
                    
                }
            }
            ViewBag.listaProductos = listidproductos;


            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Facturacion facturacion)
        {
            var cedulaCliente = await servicioFacturacion.UsuarioLogeado();

            if(cedulaCliente == null)
            {
                
                return RedirectToAction("Validar", "Login");
            }

            facturacion.idCliente = cedulaCliente.Id;

            //cedulaFacturacion = facturacion.idCliente;

            var clienteFacturacion = await servicioFacturacion.CrearFacturacion(facturacion);

            return RedirectToAction("Index", "Facturacion");
        }
        [Authorize]
        public async Task<ActionResult> FacturaFinal()
        {
            var cedulaCliente = await servicioFacturacion.UsuarioLogeado();

            if (cedulaCliente == null)
            {

                return RedirectToAction("Validar", "Login");
            }

            var facturacionCreada = await servicioFacturacion.ListaFacturacionesCreadas();

            if (facturacionCreada != null)
            {

                foreach (var facturacion in facturacionCreada.tour)
                {
                    if (facturacion != null)
                    {

                        if (facturacion.Precio != 0)
                        {
                            acumuladorIVa = (int)(acumuladorIVa + facturacion.Precio * IVA);

                            precioTotalsinIva = precioTotalsinIva + facturacion.Precio;
                        }
                    }
                }

                foreach (var facturacion in facturacionCreada.producto)
                {
                    if (facturacion != null)
                    {
                        if (facturacion.precioVenta != 0)
                        {
                            acumuladorIVa = (int)(acumuladorIVa + facturacion.precioVenta * IVA);

                            precioTotalsinIva = precioTotalsinIva + facturacion.precioVenta;
                        }
                    }



                }

                ViewBag.precioTotalsinIVA = precioTotalsinIva.ToString();

                ViewBag.precioTotalmasIVA = (precioTotalsinIva + acumuladorIVa).ToString();

                return View(facturacionCreada);

            }

            return View();
        }
        [Authorize]
        public async Task<ActionResult> Eliminar(int id)
        {
            var cedulaCliente = await servicioFacturacion.UsuarioLogeado();

            if (cedulaCliente == null)
            {

                return RedirectToAction("Validar", "Login");
            }

            var facturacion = await servicioFacturacion.EliminarFacturacion(id);

            if (facturacion == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Editar(int idItemFactura, string respuesta)
        {

            var cedulaCliente = await servicioFacturacion.UsuarioLogeado();

            if (cedulaCliente == null)
            {

                return RedirectToAction("Validar", "Login");
            }

            if(idItemFactura == 0)
            {
                return View();
            }
            
            EditarFactura editarFactura = new EditarFactura();

            editarFactura.IdCliente = cedulaCliente.Cedula;

            editarFactura.idItemFactura = idItemFactura;
            editarFactura.tipoItem = respuesta;

            var editado = await servicioFacturacion.Editar(editarFactura);

            return RedirectToAction(nameof(Index));
        }
    }
}
