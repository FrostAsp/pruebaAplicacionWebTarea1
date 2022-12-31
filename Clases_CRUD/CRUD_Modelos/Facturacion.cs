using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Facturacion
    {
        public int Id { get; set; }

        public int idCliente { get; set; }

        public int? idProducto { get; set; }

        public int? idTour { get; set; }

    }
}
