using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCRUD_Proyecto2.conexionBD;
using WebApiCRUD_Proyecto2.Datos;

namespace WebApiCRUD_Proyecto2.Controllers
{
    [ApiController]
    [Route("producto")]
    public class ProductoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crearproducto")]
        public async Task<Producto> guardarProducto(Producto nuevoProducto)
        {
            _context.Producto.Add(nuevoProducto);
            await _context.SaveChangesAsync();
            return nuevoProducto;

        }

        [HttpGet]
        [Route("listaproducto")]
        public async Task<List<Producto>> listaProductos()
        {
            List<Producto> productos = await _context.Producto.ToListAsync();

            return productos;
        }

        [HttpGet]
        [Route("listaprovedores")]
        public async Task<List<Provedor>> listaProvedores()
        {
            List<Provedor> provedores = await _context.Provedor.ToListAsync();

            return provedores;
        }

        [HttpGet]
        [Route("buscaproducto/{id}")]
        //////GET: ClienteController/Edit/5
        public async Task<Producto> Editar(int id)
        {
            var producto = await _context.Producto
                            .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return producto;
            }
            return producto;
        }

        ////////// POST: ClienteController/Edit/5

        [HttpPut]
        [Route("editarproducto/{id}")]
        public async Task<Producto> Editar(int id, Producto edicionProducto)
        {
            _context.Producto.Update(edicionProducto);
            await _context.SaveChangesAsync();
            return null;
        }

        [HttpGet]
        [Route("buscarproductoeliminar/{id}")]
        public async Task<Producto> Delete(int id)
        {
            var producto = await _context.Producto
                           .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return producto;
            }
            return producto;
        }

        //////// POST: ClienteController/Delete/5
        [HttpDelete]
        [Route("eliminarproducto/{id}")]
        public async Task<Producto> DeleteUsuario(int id)
        {
            var producto = await _context.Producto
                           .FirstOrDefaultAsync(m => m.Id == id);

            if (producto != null)
            {
                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync();
                return null;
            }

            return producto;
        }

        [HttpGet]
        [Route("filtroproducto/{id}")]
        public async Task<List<Producto>> FiltroProductoIndex(string id)
        {
            List<Producto> productos = await _context.Producto.ToListAsync();

            foreach (var item in productos)
            {
                if (item.Descripcion.Equals(id))
                {
                    List<Producto> productosFiltro = new List<Producto>();
                    productosFiltro.Add(item);
                    return productosFiltro;
                }
            }
            return productos;
        }

    }
}
