using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Login
    {
        [Required(ErrorMessage = "La Cedula es Obligatoria")]
        [RegularExpression(@"^[1-9]-\d{4}-\d{4}$", ErrorMessage = "La Cedula debe Digitarse en el formato [#-####-####] y debe contener 9 caracteres")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Su Contraseña es Requerida")]
        public string Contraseña { get; set; }
    }
}
