using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Tours
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 10, ErrorMessage = "Debe dar una Descripcion")]
        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public string Dia { get; set; }

        public int Precio { get; set; } 

    }
}
