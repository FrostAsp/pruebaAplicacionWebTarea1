using Clases_CRUD.CRUD_Modelos;
using System.Security.Cryptography;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class DatosProducto
    {
        //public static bool agregarProducto(Producto nuevoProducto)
        //{
        //    if (ValidarProducto(nuevoProducto.Id_) != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == nuevoProducto.provedor.Cedula);

        //        nuevoProducto.provedor = provedor;

        //        Almacenamiento.productos.Add(nuevoProducto);
        //        return false;
        //    }
        //}

        //public static Producto ValidarProducto(int id)
        //{
        //    // se evalua por medio de la funcion firstorDefault si algun objeto interno contiene la misma cedula;
        //    var item = Almacenamiento.productos.FirstOrDefault(o => o.Id_ == id);

        //    if (item != null)
        //    {
        //        return item;
        //    }
        //    return item;
        //}

        //public static List<Producto> ListaProducto()
        //{
        //    return Almacenamiento.productos;
        //}

        //public static Producto BuscarProductoEditar(int id)
        //{
        //    var producto = Almacenamiento.productos.Find(o => o.Id_ == id);
        //    return producto;
        //}

        //public static Producto EditarProducto(int Id, Producto edicionProducto)
        //{
        //    var producto = Almacenamiento.productos.Find(o => o.Id_ == Id);
        //    var indice = Almacenamiento.productos.FindIndex(o => o.Id_ == Id);

        //    if (producto != null)
        //    {
        //        var provedor = Almacenamiento.proveedores.Find(o => o.Cedula == edicionProducto.provedor.Cedula);

        //        edicionProducto.provedor = provedor;

        //        Almacenamiento.productos.RemoveAt(indice);
        //        Almacenamiento.productos.Insert(indice, edicionProducto);
        //        return edicionProducto;
        //    }
        //    return producto;
        //}

        //public static Producto BuscarProductoEliminar(int id)
        //{
        //    var producto = Almacenamiento.productos.Find(o => o.Id_ == id);

        //    return producto;
        //}

        //public static Producto EliminarUsuario(int id)
        //{
        //    //var producto = Almacenamiento.productos.Find(o => o.Id_ == id);

        //    //if (producto != null)
        //    //{
        //    //    Almacenamiento.productos.Remove(producto);
        //    //    return null;
        //    //}
        //    return producto;
        //}

        //public static IEnumerable<Producto> BusquedaProductoIndex(string buscar)
        //{
        //    var productos = from Producto in Almacenamiento.productos select Producto;

        //    if (!String.IsNullOrEmpty(buscar))
        //    {
        //        productos = productos.Where(o => o.Descripcion!.Contains(buscar));
        //    }
        //    return productos;
        //}

        //public static IEnumerable<Provedor> listaProvedores()
        //{
        //    return Almacenamiento.proveedores;
        //}

    }
}
