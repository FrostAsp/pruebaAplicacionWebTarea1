using Clases_CRUD.CRUD_Modelos;
using Newtonsoft.Json;
using System.Text;

namespace JassonContreras_TAREA1asp.net.Servicios
{
    public class ServicioTours : ITours
    {

        private string baseurl;

        public ServicioTours()
        {
            baseurl = "http://localhost:5285";
        }

        public async Task<Tours> CrearTours(Tours nuevoTours)
        {
            Tours existe = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoTours), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync($"tours/creartours", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);

                existe = resultado;
            }
            return existe;
        }

        public async Task<Tours> BuscarToursEditar(int id)
        {
            Tours editar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"tours/buscartours/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);
                editar = resultado;

            }
            return editar;
        }

        public async Task<Tours> EditarTours(Tours nuevoTours)
        {
            Tours toursEditar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(nuevoTours), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"tours/editartours/", contenido);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);
                toursEditar = resultado;

                return toursEditar;
            }
            return toursEditar;
        }

        public async Task<Tours> BuscarToursEliminar(int id)
        {
            Tours toursEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"tours/buscartourseliminar/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);
                toursEliminar = resultado;

            }
            return toursEliminar;
        }

        public async Task<Tours> EliminarTours(int id)
        {
            Tours toursEliminar = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.DeleteAsync($"tours/eliminartours/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tours>(json_respuesta);
                toursEliminar = resultado;
                return toursEliminar;

            }
            return toursEliminar;
        }

        public async Task<List<Tours>> ListaTours()
        {
            List<Tours> listaTours = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"tours/listatours");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tours>>(json_respuesta);
                listaTours = resultado;
            }
            return listaTours;
        }

        public async Task<IEnumerable<Tours>> FiltroToursIndex(string id)
        {
            IEnumerable<Tours> filtroTours = null;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(baseurl);

            var respuesta = await cliente.GetAsync($"tours/filtrotours/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Tours>>(json_respuesta);

                filtroTours = resultado;
            }
            return filtroTours;
        }
    }
}
