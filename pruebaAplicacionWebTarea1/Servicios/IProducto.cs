using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public interface IProducto
    {
        public Task<Producto> CrearProducto(Producto nuevoProducto);

        public Task<List<Producto>> ListaProducto();

        public Task<IEnumerable<Provedor>> ListaProvedores();

        public Task<Producto> BuscarProductoEditar(int id);

        public Task<Producto> EditarProducto(int id, Producto nuevoProducto);

        public Task<Producto> BuscarProductoEliminar(int id);

        public Task<Producto> EliminarProducto(int id);

        public Task<IEnumerable<Producto>> FiltroProductoIndex(string id);

    }
}
