
using Clases_CRUD.CRUD_Modelos;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class DatosCliente
    {  
        public static bool agregarUsuario(Cliente nuevoCliente)
        {
            if (ValidarUsuario(nuevoCliente.Cedula) != null)
            {
                return true;
            }
            else
            {
                Almacenamiento.clientes.Add(nuevoCliente);
                return false;
            }        
        }

        public static Cliente ValidarUsuario(string cedula)
        {
            // se evalua por medio de la funcion firstorDefault si algun objeto interno contiene la misma cedula;
            var item = Almacenamiento.clientes.FirstOrDefault(o => o.Cedula == cedula);

            if (item != null)
            {
                return item;
            }
            return item;
        }

        //metodo que realiza la validacion respectiva del usuario y cliente
        public static Cliente ValidarUsuario(string cedula, string clave)
        {
            return Almacenamiento.clientes.Where(item => item.Cedula == cedula && item.Contraseña == clave).FirstOrDefault();
        }

        public static Cliente UsuarioLogeado(string cedula, string clave)
        {
            return Almacenamiento.clientes.Where(item => item.Cedula == cedula && item.Contraseña == clave).FirstOrDefault();
        }

        public static Cliente BuscarUsuarioEditar(string id)
        {
            var cliente = Almacenamiento.clientes.Find(o => o.Cedula == id);
            return cliente;
        }

        public static Cliente EditarUsuario(string Id, Cliente edicionCliente)
        {
            var cliente = Almacenamiento.clientes.Find(o => o.Cedula == Id.ToString());
            var indice = Almacenamiento.clientes.FindIndex(o => o.Cedula == Id.ToString());

            if (cliente != null)
            {               
                Almacenamiento.clientes.RemoveAt(indice);
                Almacenamiento.clientes.Insert(indice, edicionCliente);
                return edicionCliente;
            }
            return cliente;
        }


        public static Cliente BuscarUsuarioEliminar(string id)
        {
            var cliente = Almacenamiento.clientes.Find(o => o.Cedula == id.ToString());

            return cliente;
        }

        public static Cliente EliminarUsuario(string id)
        {
            var cliente = Almacenamiento.clientes.Find(o => o.Cedula == id);

            if (cliente != null)
            {
                Almacenamiento.clientes.Remove(cliente);
                return null;
            }
            return cliente;
        }

    }
}
