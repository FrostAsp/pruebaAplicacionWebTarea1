using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public interface ICliente
    {
        public Task<Cliente> CrearUsuario(Cliente nuevoCliente);

        public Task<Cliente> BuscarUsuarioEditar(int id);

        public Task<Cliente> EditarUsuario(Cliente nuevoCliente);

        public Task<Cliente> BuscarUsuarioEliminar(int id);

        public Task<Cliente> EliminarUsuario(int id);

        public Task<Cliente> ValidarLogin(string cedula, string clave);

        public Task<Cliente> UsuarioLogeado();
      
    }
}
