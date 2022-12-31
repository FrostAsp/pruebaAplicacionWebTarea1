using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public interface IProvedor
    {
        public Task<Provedor> CrearProvedor(Provedor nuevoProvedor);

        public Task<List<Provedor>> ListaProvedor();

        public Task<Provedor> BuscarProvedorEditar(int id);

        public Task<Provedor> EditarProvedor(Provedor nuevoProvedor);

        public Task<Provedor> BuscarProvedorEliminar(int id);

        public Task<Provedor> EliminarProvedor(int id);

        public Task<IEnumerable<Provedor>> FiltroProvedorIndex(string id);

    }
}
