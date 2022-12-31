using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class DatosFacturacion
    {


        public static bool agregarFacturacion(EnvioFacturacion nuevaFacturacion)
        {
            bool existeFacturacion = false;


            List<Tours> tourslista = new List<Tours>();

            List<Producto> productoslista = new List<Producto>();

            //var facturacionCreada = Almacenamiento.facturacion.FirstOrDefault(o => o.cliente.Cedula == nuevaFacturacion.idCliente);

            //if (facturacionCreada != null)
            //{

            //    var tourfacturar = Almacenamiento.tours.FirstOrDefault(o => o.Id == nuevaFacturacion.idTours);


            //    if (tourfacturar != facturacionCreada.tour.FirstOrDefault(o => o.Id == nuevaFacturacion.idTours))
            //    {
            //        facturacionCreada.tour.Add(tourfacturar);
            //    }

            //    var productofacturar = Almacenamiento.productos.FirstOrDefault(o => o.Id_ == nuevaFacturacion.idProducto);

            //    if (productofacturar != facturacionCreada.producto.FirstOrDefault(o => o.Id_ == nuevaFacturacion.idProducto))
            //    {
            //        facturacionCreada.producto.Add(productofacturar);
            //    }

            //    existeFacturacion = true;

            //}
            //else
            //{
            //    var clienteFacturar = Almacenamiento.clientes.FirstOrDefault(o => o.Cedula == nuevaFacturacion.idCliente);

            //    var productofacturar = Almacenamiento.productos.FirstOrDefault(o => o.Id_ == nuevaFacturacion.idProducto);
            //    productoslista.Add(productofacturar);
            //    var tourfacturar = Almacenamiento.tours.FirstOrDefault(o => o.Id == nuevaFacturacion.idTours);
            //    tourslista.Add(tourfacturar);

            //    Facturacion itemFacturar = new Facturacion()
            //    {
            //        cliente = clienteFacturar,
            //        tour = tourslista,
            //        producto = productoslista
            //    };

            //    Almacenamiento.facturacion.Add(itemFacturar);

            //    return existeFacturacion;
            //}

            return existeFacturacion;
        }

        public static Facturacion EliminarFactura(string id)
        {
            //var factura = Almacenamiento.facturacion.Find(o => o.cliente.Cedula == id);

            //if (factura != null)
            //{
            //    Almacenamiento.facturacion.Remove(factura);
            //    return null;
            //}
            return null;
        }


        public static EditarFactura EditarItem(EditarFactura editarFactura)
        {
            //var facturacionCreada = Almacenamiento.facturacion.Find(o => o.cliente.Cedula == editarFactura.IdCliente);

            //if (facturacionCreada != null)
            //{
            //    if (facturacionCreada.tour != null)
            //    {
            //        if (editarFactura.tipoItem.Equals("Tour"))
            //        {
            //            var itemEliminar = facturacionCreada.tour.Find(o => o.Id == editarFactura.idItemFactura);

            //            if (itemEliminar != null)
            //            {
            //                facturacionCreada.tour.Remove(itemEliminar);
            //                return null;
            //            }
            //        }
            //    }
            //    if (facturacionCreada.producto != null)
            //    {

            //        var itemEliminar = facturacionCreada.producto.Find(o => o.Id_ == editarFactura.idItemFactura);

            //        if (itemEliminar != null)
            //        {
            //            facturacionCreada.producto.Remove(itemEliminar);
            //            return null;
            //        }
            //    }
            //}

            return null;
        }


    }
}
