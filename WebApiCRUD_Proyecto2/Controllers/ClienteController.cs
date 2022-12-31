using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApiCRUD_Proyecto2.conexionBD;
using WebApiCRUD_Proyecto2.Datos;


namespace WebApiCRUD_Proyecto2.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crear usuario")]
        public async Task<Cliente> guardarCliente(Cliente nuevoCliente)
        {

            if (ModelState.IsValid)
            {
                var existe = await _context.Cliente
                             .FirstOrDefaultAsync(m => m.Cedula == nuevoCliente.Cedula);

                if (existe == null)
                {
                    _context.Cliente.Add(nuevoCliente);
                    await _context.SaveChangesAsync();
                    return null;
                }

            }
            return nuevoCliente;

        }

        [HttpGet]
        [Route("lista de usuarios")]
        public IActionResult listausuarios()
        {
            return Ok(Almacenamiento.clientes);
        }

        [HttpGet]
        [Route("buscarusuario/{id}")]
        //////GET: ClienteController/Edit/5
        public async Task<Cliente> Editar(int id)
        {
            var cliente = await _context.Cliente
                            .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return cliente;
            }
            return cliente;
        }

        ////////// POST: ClienteController/Edit/5

        [HttpPut]
        [Route("editarusuario")]
        public async Task<Cliente> Editar(Cliente edicionCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Update(edicionCliente);
                await _context.SaveChangesAsync();
                return null;
            }

            return edicionCliente;
        }

        //////// GET: ClienteController/Delete/5
        [HttpGet]
        [Route("buscarusuarioeliminar/{id}")]
        public async Task<Cliente> Delete(int id)
        {

            var cliente = await _context.Cliente
               .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return null;
            }
            return cliente;
        }

        //////// POST: ClienteController/Delete/5
        [HttpDelete]
        [Route("eliminarusuario/{id}")]
        public async Task<Cliente> DeleteUsuario(int id)
        {
            var cliente = await _context.Cliente
                           .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();

                return null;
            }

            return cliente;


        }
        [HttpGet]
        [Route("login/{cedula}/{clave}")]
        ////GET: ClienteController/Edit/5
        public async Task<Cliente> ValidarUsuarioLogin(string cedula, string clave)
        {
            var existe = await _context.Cliente
                         .FirstOrDefaultAsync(m => m.Cedula == cedula && m.Contraseña == clave);
            
            if (existe == null)
            {
                return null;
            }
            UsuarioLogeado.usuario = cedula;
            UsuarioLogeado.clave = clave;
            return existe;
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

    }
}
