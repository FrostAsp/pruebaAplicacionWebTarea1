using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public interface IFacturacion
    {
        public Task<IEnumerable<listasFacturacion>> ListasFacturacion();

        public Task<Cliente> UsuarioLogeado();

        public Task<Facturacion> CrearFacturacion(Facturacion nuevaFacturacion);

        public Task<listasFacturacion> ListaFacturacionesCreadas();

        public Task<Facturacion> EliminarFacturacion(int id);

        public Task<EditarFactura> Editar(EditarFactura editarFactura);
    }
}
