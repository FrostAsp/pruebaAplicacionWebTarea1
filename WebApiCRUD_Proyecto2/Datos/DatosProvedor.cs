using Clases_CRUD.CRUD_Modelos;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class DatosProvedor
    {

        public static bool agregarProvedor(Provedor nuevoProvedor)
        {
            if (ValidarProvedor(nuevoProvedor.Cedula) != null)
            {
                return true;
            }
            else
            {

                Almacenamiento.proveedores.Add(nuevoProvedor);
                return false;
            }
        }

        public static Provedor ValidarProvedor(string id)
        {
            // se evalua por medio de la funcion firstorDefault si algun objeto interno contiene la misma cedula;
            var item = Almacenamiento.proveedores.FirstOrDefault(o => o.Cedula == id);

            if (item != null)
            {
                return item;
            }
            return item;
        }

        public static IEnumerable<Provedor> BusquedaProvedorIndex(string buscar)
        {
            var provedor = from Producto in Almacenamiento.proveedores select Producto;

            if (!String.IsNullOrEmpty(buscar))
            {
                provedor = provedor.Where(o => o.Descripcion!.Contains(buscar));
            }
            return provedor;
        }

        public static List<Provedor> ListaProvedores()
        {
            return Almacenamiento.proveedores;
        }

        public static Provedor BuscarProvedorEditar(string id)
        {
            var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == id);
            return provedor;
        }

        public static Provedor EditarProvedor(string Id, Provedor edicionProvedor)
        {
            var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == Id);
            var indice = Almacenamiento.proveedores.FindIndex(o => o.Cedula == Id);

            if (provedor != null)
            {
                Almacenamiento.proveedores.RemoveAt(indice);
                Almacenamiento.proveedores.Insert(indice, edicionProvedor);
                return edicionProvedor;
            }
            return provedor;
        }

        public static Provedor BuscarProvedorEliminar(string id)
        {
            var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == id.ToString());

            return provedor;
        }

        public static Provedor EliminarProvedor(string id)
        {
            var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == id);

            if (provedor != null)
            {
                Almacenamiento.proveedores.Remove(provedor);
                return null;
            }
            return provedor;
        }

    }
}
