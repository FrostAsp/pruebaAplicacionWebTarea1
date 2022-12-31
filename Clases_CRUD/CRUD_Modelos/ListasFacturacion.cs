using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_CRUD.CRUD_Modelos
{
    public class listasFacturacion
    {
        public Cliente cliente { get; set; }
        public List<Tours> tour { get; set; }

        public  List<Producto> producto { get; set; }

    }
}
