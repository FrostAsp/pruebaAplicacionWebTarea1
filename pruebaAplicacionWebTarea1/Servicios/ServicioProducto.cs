using Clases_CRUD.CRUD_Modelos;
using Newtonsoft.Json;
using System.Text;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public class ServicioProducto : IProducto
    {
        private string baseurl;

        public ServicioProducto()
        {
            baseurl = "http://localhost:5285";
        }

        public async Task<Producto> CrearProducto(Producto nuevoProducto)
        {
            
            Producto existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoProducto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"producto/crearproducto", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);

                existe = resultado;
            }
            return existe;

        }

        public async Task<Producto> BuscarProductoEditar(int id)
        {
            Producto editar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"producto/buscaproducto/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                editar = resultado;

            }
            return editar;
        }

        public async Task<Producto> EditarProducto(int id, Producto nuevoProducto)
        {
            Producto productoEditar = null;

            nuevoProducto.Id = id;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoProducto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"producto/editarproducto/{id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                productoEditar = resultado;

                return productoEditar;
            }
            return productoEditar;
        }

        public async Task<Producto> BuscarProductoEliminar(int id)
        {
            Producto productoEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"producto/buscarproductoeliminar/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                productoEliminar = resultado;

            }
            return productoEliminar;
        }

        public async Task<Producto> EliminarProducto(int id)
        {
            Producto productoEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.DeleteAsync($"producto/eliminarproducto/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                productoEliminar = resultado;
                return productoEliminar;

            }
            return productoEliminar;
        }

        public async Task<List<Producto>> ListaProducto()
        {
            List<Producto> listaProductos = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"producto/listaproducto");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(json_respuesta);

                listaProductos = resultado;
            }
            return listaProductos;

        }

        public async Task<IEnumerable<Provedor>> ListaProvedores()
        {
            IEnumerable<Provedor> listaProductos = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"producto/listaprovedores");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<IEnumerable<Provedor>>(json_respuesta);

                listaProductos = resultado;
            }
            return listaProductos;

        }

        public async Task<IEnumerable<Producto>> FiltroProductoIndex(string id)
        {
            IEnumerable<Producto> filtroProducto = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"producto/filtroproducto/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(json_respuesta);

                filtroProducto = resultado;
            }
            return filtroProducto;
        }
    }
}
