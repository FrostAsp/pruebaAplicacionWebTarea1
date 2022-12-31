using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks.Dataflow;
using WebApiCRUD_Proyecto2.conexionBD;
using WebApiCRUD_Proyecto2.Datos;

namespace WebApiCRUD_Proyecto2.Controllers
{
    [ApiController]
    [Route("facturacion")]
    public class FacturacionController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FacturacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("nuevafacturar")]
        public async Task<Facturacion> guardarProducto(Facturacion nuevaFacturacion)
        {
            _context.Facturacion.Add(nuevaFacturacion);
            await _context.SaveChangesAsync();

            return nuevaFacturacion;
        }

        [HttpGet]
        [Route("listafacturacion")]
        public async Task<listasFacturacion> ListaFacturacion()
        {
            listasFacturacion listas = new listasFacturacion
            {
                cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.Cedula == UsuarioLogeado.usuario && m.Contraseña == UsuarioLogeado.clave),
                tour = await _context.Tours.ToListAsync(), 
                producto = await _context.Producto.ToListAsync(), 
 
            };

            return listas;
        }

        [HttpGet]
        [Route("usuariologeado")]
        ////GET: ClienteController/Edit/5
        public async Task<Cliente> UsuarioLogin()
        {

             var usuarioLogeado = await _context.Cliente
             .FirstOrDefaultAsync(m => m.Cedula == UsuarioLogeado.usuario && m.Contraseña == UsuarioLogeado.clave);

            if (usuarioLogeado == null)
            {
                return null;
            }

            return usuarioLogeado;
        }

        [HttpGet]
        [Route("facturacionescreadas")]
        public listasFacturacion FacturacionesCreadas()
        {
            
            List<int> idProductos = new List<int>();
            List<int> idTours = new List<int>();

            List<Producto> productosFacturados = new List<Producto>();
            List<Tours> tourFacturados = new List<Tours>();

            var usuarioLogeado = _context.Cliente
                                .FirstOrDefault(m => m.Cedula == UsuarioLogeado.usuario);


            var prueba4 = _context.Cliente.GroupJoin(_context.Facturacion, c => c.Id, s => s.idCliente,
                (c, s) => new { c, s }).FirstOrDefault(x => x.c.Id == usuarioLogeado.Id);

            Cliente cliente = null;
            //almacenado del objeto cliente que realizo la facturacion
            cliente = prueba4.c;

            //almenado de todos los id productos asociados a la factura del cliente.
            foreach (var item in prueba4.s)
            {
                if (item.idProducto != null)
                {
                    idProductos.Add((int)item.idProducto);
                }
            }
            //almenado de todos los id tours asociados a la factura del cliente.
            foreach (var item in prueba4.s)
            {
                if (item.idTour != null)
                {
                    idTours.Add((int)item.idTour);
                }
            }

            //se recorre cada id por medio de iterador i para traer todos los objetos productos
            foreach (var i in idProductos)
            {
                if(i != 0)
                {
                    Producto productoFactura = null;

                    productoFactura = _context.Producto.FirstOrDefault(x => x.Id == i);

                    if (productoFactura != null)
                    {
                        productosFacturados.Add(productoFactura);
                    }

                }
            }

            //se recorre cada id por medio de iterador i para traer todos los objetos tours
            foreach (var i in idTours)
            {
                if (i != 0)
                {
                    Tours tourFactura = null;

                    tourFactura = _context.Tours.FirstOrDefault(x => x.Id == i);

                    if (tourFactura != null)
                    {
                        tourFacturados.Add(tourFactura);
                    }

                }
            }

            //creacion del objeto factura con todos los objetos facturados por dicho cliente
            listasFacturacion itemFactura = new listasFacturacion()
            {
                cliente = cliente,
                producto = productosFacturados,
                tour = tourFacturados
            };


            return itemFactura;
        }


        [HttpDelete]
        [Route("eliminarfactura/{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            Facturacion facturacion = null;

            do
            {         
                var edicion = _context.Facturacion.ToList().FirstOrDefault(x => x.idCliente == id);

                if (edicion != null)
                {
                    facturacion = edicion;
                    _context.Facturacion.Remove(edicion);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    facturacion = null;
                }
                
            }
            while (facturacion != null);

            return Ok();
        }

        [HttpPut]
        [Route("editarfactura")]
        public async Task<EditarFactura> Editar(EditarFactura editarFactura)
        {

            if (editarFactura.tipoItem.Equals("Tour"))
            {
                var edicion = _context.Facturacion.ToList().FirstOrDefault(x => x.idTour == editarFactura.idItemFactura);
                edicion.idTour = null;
                _context.Facturacion.Update(edicion);
                await _context.SaveChangesAsync();
                return null;
            }
            else
            {
                var edicion = _context.Facturacion.ToList().FirstOrDefault(x => x.idProducto == editarFactura.idItemFactura);
                edicion.idProducto = null;
                _context.Facturacion.Update(edicion);
                await _context.SaveChangesAsync();
                return null;
            }

        }
    }
}

//var lista = Almacenamiento.facturacion.FirstOrDefault(o => o.cliente.Cedula == Almacenamiento.usuario);

//return Ok(lista);

//var facturacion =  _context.Facturacion.Join(_context.Producto, dir => dir.idProducto,
//    produc => produc.Id, (dir, produc) => new { dir, produc }).FirstOrDefault();

//var facturaConListas = _context.Cliente.GroupJoin(_context.Tours, tour => tour.Id,
//    tou => tou.Id, (tour, tou) => new { tour, tou }).FirstOrDefault(x => x.tou == )

//var facturaPorCliente = _context.Cliente.GroupJoin(_context.Producto, produc => produc.Id,
//    s => s.Id, (produc, s) => new { produc, s }).FirstOrDefault(x => x.produc.Id == 4);


//var prueba2 = _context.Cliente.GroupJoin(_context.Producto, clie => clie.Id,
//    d => d.Id, (clie, d) => new { clie, d }).FirstOrDefault(x => x.clie.Id == 4);

//var prueba3 = _context.Facturacion.ToList().FirstOrDefault(x => x.idCliente ==4);

//var clienteConItems = _context.Cliente.GroupJoin(_context.Producto, cli => cli.Id,
//    prod => prod.idprovedor, (cli, prod) => new { cli, prod }).First(x => x.cli.Id == 4);

//var itemsFactura = from Producto in _context.Producto join tor in _context.Tours equals tor.Id;


//var query = from f in _context.Facturacion
//            join p in _context.Producto on f.idProducto equals testc.
//            join t in _context.Tours on f.clave equals


//var query = from f in _context.Facturacion join p in _context.Producto on f.idProducto == 1;

//var query = from f in _context.Facturacion join p in _context.Producto on 

//SELECT a.Nombre FROM AfiliacionSede c INNER JOIN Sede a  ON c.IdCliente =


//var query = from f in _context.Facturacion
//            join p in _context.Producto on f.idProducto equals p.Id into jason join e in _context.Tours on f.idTour equals 
//            select new
//            {

//            }

//var q = from t in _context.Tours
//        from p in _context.Producto
//        from f in _context.Facturacion
//            on new {t.Id, f} equals new
//            {

//            }

//var query = from p in _context.Producto
//            join f in _context.Facturacion on p.Id equals f.Id
//            //join t in _context.Tours on p.Id equals t.Id
//            where f.idCliente == 4
//            select new EnvioFacturacion
//            {
//                idProducto = p.idprovedor,
//                idCliente = p.precio.ToString(),
//            };