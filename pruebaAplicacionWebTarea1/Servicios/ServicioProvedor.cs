using Clases_CRUD.CRUD_Modelos;
using Newtonsoft.Json;
using System.Text;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public class ServicioProvedor : IProvedor
    {

        private string baseurl;

        public ServicioProvedor()
        {
            baseurl = "http://localhost:5285";
        }

        public async Task<Provedor> CrearProvedor(Provedor nuevoProvedor)
        {
            Provedor existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoProvedor), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"provedor/crearprovedor", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Provedor>(json_respuesta);

                existe = resultado;
            }
            return existe;
        }

        public async Task<Provedor> BuscarProvedorEditar(int id)
        {
            Provedor editar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"provedor/buscaprovedor/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Provedor>(json_respuesta);
                editar = resultado;

            }
            return editar;
        }
        public async Task<Provedor> EditarProvedor(Provedor nuevoProvedor)
        {
            Provedor provedorEditar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoProvedor), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"provedor/editarprovedor/", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Provedor>(json_respuesta);
                provedorEditar = resultado;

                return provedorEditar;
            }
            return provedorEditar;
        }
        public async Task<Provedor> BuscarProvedorEliminar(int id)
        {
            Provedor provedorEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"provedor/buscarprovedoreliminar/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Provedor>(json_respuesta);
                provedorEliminar = resultado;

            }
            return provedorEliminar;
        }
        public async Task<Provedor> EliminarProvedor(int id)
        {
            Provedor provedorEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.DeleteAsync($"provedor/eliminarprovedor/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Provedor>(json_respuesta);
                provedorEliminar = resultado;
                return provedorEliminar;

            }
            return provedorEliminar;

        }

        public async Task<List<Provedor>> ListaProvedor()
        {
            List<Provedor> listaProvedor = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"provedor/listaprovedor");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Provedor>>(json_respuesta);

                listaProvedor = resultado;
            }
            return listaProvedor;
        }

        public async Task<IEnumerable<Provedor>> FiltroProvedorIndex(string id)
        {
            IEnumerable<Provedor> filtroProvedor = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"provedor/filtroprovedores/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Provedor>>(json_respuesta);

                filtroProvedor = resultado;
            }
            return filtroProvedor;
        }
    }
}
