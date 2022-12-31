using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_CRUD.CRUD_Modelos
{
    public class ItemFactura
    {

        //public List<Producto> Producto { get; set; }

        public List<Tours> Tours { get; set; }

        //public Facturacion Facturacion { get; set; }

        public IEnumerable<Producto> Producto { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
