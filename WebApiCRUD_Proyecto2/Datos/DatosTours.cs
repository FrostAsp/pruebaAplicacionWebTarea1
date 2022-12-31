using Clases_CRUD.CRUD_Modelos;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class DatosTours
    {
        public static bool agregarTours(Tours nuevoTours)
        {
            if (ValidarTours(nuevoTours.Id) != null)
            {
                return true;
            }
            else
            {
                Almacenamiento.tours.Add(nuevoTours);
                return false;
            }
        }

        public static Tours ValidarTours(int id)
        {
            // se evalua por medio de la funcion firstorDefault si algun objeto interno contiene la misma cedula;
            var item = Almacenamiento.tours.FirstOrDefault(o => o.Id == id);

            if (item != null)
            {
                return item;
            }
            return item;
        }

        public static List<Tours> ListaTours()
        {
            return Almacenamiento.tours;
        }

        public static Tours BuscarToursEditar(int id)
        {
            var tours = Almacenamiento.tours.Find(o => o.Id == id);
            return tours;
        }

        public static Tours EditarTours(int Id, Tours edicionTours)
        {
            var tours = Almacenamiento.tours.Find(o => o.Id == Id);
            var indice = Almacenamiento.tours.FindIndex(o => o.Id == Id);

            if (tours != null)
            {
                Almacenamiento.tours.RemoveAt(indice);
                Almacenamiento.tours.Insert(indice, edicionTours);
                return edicionTours;
            }
            return tours;
        }

        public static Tours BuscarToursEliminar(int id)
        {
            var tours = Almacenamiento.tours.Find(o => o.Id == id);

            return tours;
        }

        public static Tours EliminarTours(int id)
        {
            var tours = Almacenamiento.tours.Find(o => o.Id == id);

            if (tours != null)
            {
                Almacenamiento.tours.Remove(tours);
                return null;
            }
            return tours;
        }

        public static IEnumerable<Tours> BusquedaToursIndex(string buscar)
        {
            var tours = from Producto in Almacenamiento.tours select Producto;

            if (!String.IsNullOrEmpty(buscar))
            {
                tours = tours.Where(o => o.Descripcion!.Contains(buscar));
            }
            return tours;
        }

    }
}
