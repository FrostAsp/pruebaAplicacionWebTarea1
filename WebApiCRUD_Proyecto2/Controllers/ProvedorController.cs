using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApiCRUD_Proyecto2.conexionBD;
using WebApiCRUD_Proyecto2.Datos;

namespace WebApiCRUD_Proyecto2.Controllers
{
    [ApiController]
    [Route("provedor")]
    public class ProvedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crearprovedor")]
        public async Task<Provedor> guardarProvedor(Provedor nuevoProvedor)
        {

            if (ModelState.IsValid)
            {
                var existe = await _context.Provedor
                             .FirstOrDefaultAsync(m => m.Cedula == nuevoProvedor.Cedula);

                if(existe == null)
                {
                    _context.Provedor.Add(nuevoProvedor);
                    await _context.SaveChangesAsync();
                    return null;
                }

            }
            return nuevoProvedor;
        }

        [HttpGet]
        [Route("listaprovedor")]
        public async Task<List<Provedor>> listaProvedores()
        {
            List<Provedor> provedores = await _context.Provedor.ToListAsync();

            return provedores;
        }

        [HttpGet]
        [Route("buscaprovedor/{id}")]
        //////GET: ClienteController/Edit/5
        public async Task<Provedor> Editar(int id)
        {
            var provedor = await _context.Provedor
                            .FirstOrDefaultAsync(m => m.Id == id);

            if (provedor == null)
            {
                return provedor;
            }
            return provedor;

        }

        ////////// POST: ClienteController/Edit/5

        [HttpPut]
        [Route("editarprovedor")]
        public async Task<Provedor> Editar(Provedor edicionProducto)
        {

            if (ModelState.IsValid)
            {
                var existe = await _context.Provedor
                             .FirstOrDefaultAsync(m => m.Cedula == edicionProducto.Cedula);

                if(existe == null)
                {
                    _context.Provedor.Update(edicionProducto);
                    await _context.SaveChangesAsync();
                    return null;

                }

            }

            return edicionProducto;
        }

        [HttpGet]
        [Route("buscarprovedoreliminar/{id}")]
        public async Task<Provedor> Delete(int id)
        {
            var provedor = await _context.Provedor
                           .FirstOrDefaultAsync(m => m.Id == id);

            if (provedor == null)
            {
                return provedor;
            }
            return provedor;

        }

        //////// POST: ClienteController/Delete/5
        [HttpDelete]
        [Route("eliminarprovedor/{id}")]
        public async Task<Provedor> DeleteUsuario(int id)
        {
            var provedor = await _context.Provedor
               .FirstOrDefaultAsync(m => m.Id == id);

            if(provedor != null)
            {
                _context.Provedor.Remove(provedor);
                await _context.SaveChangesAsync();

                return null;
            }

            return provedor;
        }

        [HttpGet]
        [Route("filtroprovedores/{id}")]
        public async Task<List<Provedor>> FiltroProvedoresIndex(string id)
        {
            List<Provedor> provedores = await _context.Provedor.ToListAsync();

            foreach (var item in provedores)
            {
                if (item.Descripcion.Equals(id))
                {
                    List<Provedor> provedors = new List<Provedor>();
                    provedors.Add(item);
                    return provedors;
                }
            }
            return provedores;
        }
    }
}
