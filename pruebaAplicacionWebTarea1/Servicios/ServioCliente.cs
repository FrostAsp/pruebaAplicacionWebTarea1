using Clases_CRUD.CRUD_Modelos;
using Newtonsoft.Json;
using System.Text;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public class ServioCliente : ICliente
    {
        private string baseurl;

        public ServioCliente()
        {
            baseurl = "http://localhost:5285";
        }

        public async Task<Cliente> CrearUsuario(Cliente nuevoCliente)
        {
            Cliente existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoCliente), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"cliente/crear usuario", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);

                existe = resultado;
            }
            return existe;
        }
        public async Task<Cliente> BuscarUsuarioEditar(int id)
        {
            Cliente editar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"cliente/buscarusuario/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                editar = resultado;

            }
            return editar;
        }

        public async Task<Cliente> EditarUsuario(Cliente editarCliente)
        {
            Cliente clienteEditar = null;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(editarCliente), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"cliente/editarusuario", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                clienteEditar = resultado;

                return clienteEditar;
            }

            return clienteEditar;
        }
        public async Task<Cliente> BuscarUsuarioEliminar(int id)
        {
            Cliente clienteEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"cliente/buscarusuarioeliminar/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                clienteEliminar = resultado;

            }
            return clienteEliminar;

        }
        public async Task<Cliente> EliminarUsuario(int id)
        {
            Cliente eliminacion = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.DeleteAsync($"cliente/eliminarusuario/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                eliminacion = resultado;
                return eliminacion;

            }
            return eliminacion;
        }
        public async Task<Cliente> ValidarLogin(string cedula, string clave)
        {
            Cliente busquedaCliente = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"cliente/login/{cedula}/{clave}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                busquedaCliente = resultado;
                
            }
            return busquedaCliente;
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
    }
}
