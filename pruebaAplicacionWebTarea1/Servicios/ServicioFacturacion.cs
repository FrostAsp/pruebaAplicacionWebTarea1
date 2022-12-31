using Clases_CRUD.CRUD_Modelos;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public class ServicioFacturacion : IFacturacion
    {

        private string baseurl;
        
        public ServicioFacturacion()
        {
            baseurl = "http://localhost:5285";
        }

        public async Task<IEnumerable<listasFacturacion>> ListasFacturacion() 
        {
            listasFacturacion listasFacturacion = null;
            List<listasFacturacion> listasDisponibles = new List<listasFacturacion>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"facturacion/listafacturacion");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<listasFacturacion>(json_respuesta);

                listasFacturacion = resultado;
            }
            listasDisponibles.Add(listasFacturacion);

            return listasDisponibles;

        }

        public async Task<Cliente> UsuarioLogeado()
        {
            Cliente busquedaCliente = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"cliente/usuariologeado");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                busquedaCliente = resultado;
            }
            return busquedaCliente;
        }

        public async Task<Facturacion> CrearFacturacion(Facturacion nuevaFacturacion)
        {
            Facturacion existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevaFacturacion), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"facturacion/nuevafacturar", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Facturacion>(json_respuesta);

                existe = resultado;
            }
            return existe;
        }

        public async Task<listasFacturacion> ListaFacturacionesCreadas()
        {
            listasFacturacion facturacionCreadas = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"facturacion/facturacionescreadas");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<listasFacturacion>(json_respuesta);

                facturacionCreadas = resultado;
            }
            return facturacionCreadas;
            

        }

        public async Task<Facturacion> EliminarFacturacion(int id)
        {
            Facturacion Eliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);
            
            var respuesta = await cliente.DeleteAsync($"facturacion/eliminarfactura/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Facturacion>(json_respuesta);
                Eliminar = resultado;

            }
            return Eliminar;
        }

        public async Task<EditarFactura> Editar(EditarFactura editarFactura)
        {
            EditarFactura existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(editarFactura), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"facturacion/editarfactura", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<EditarFactura>(json_respuesta);

                existe = resultado;
            }
            return existe;
        }
    }
}
