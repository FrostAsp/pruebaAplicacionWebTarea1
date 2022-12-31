using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public interface ITours
    {
        public Task<Tours> CrearTours(Tours nuevoTours);

        public Task<List<Tours>> ListaTours();

        public Task<Tours> BuscarToursEditar(int id);

        public Task<Tours> EditarTours(Tours nuevoTours);

        public Task<Tours> BuscarToursEliminar(int id);

        public Task<Tours> EliminarTours(int id);

        public Task<IEnumerable<Tours>> FiltroToursIndex(string id);

    }
}
