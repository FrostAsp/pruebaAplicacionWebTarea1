using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clases_CRUD.CRUD_Modelos
{
    public class EditarFactura
    {
        public string IdCliente { get; set; }

        [Display(Name = "Id del item a Eliminar")]
        [Required(ErrorMessage = "Debe digitar un id del item de su facturacion que desea eliminar")]
        public int idItemFactura { get; set; }

        public string tipoItem { get; set; }
    }
}
