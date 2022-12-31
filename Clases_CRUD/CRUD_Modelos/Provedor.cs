using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Provedor
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Ingresar una Cedula")]
        [RegularExpression(@"^[1-9]-\d{4}-\d{4}$", ErrorMessage = "La Cedula se Digita en Formato #-####-####")]
        public string Cedula { get; set; }

        [Display(Name = "Descripcion del Proveedor")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Debe dar una Descripcion")]
        [Required(ErrorMessage = "Debe de DIgitar")]
        public string Descripcion { get; set; }
    }
}
