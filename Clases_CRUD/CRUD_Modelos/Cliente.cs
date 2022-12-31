using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La Cedula es Obligatoria")]
        [RegularExpression(@"^[1-9]-\d{4}-\d{4}$", ErrorMessage = "La Cedula debe Digitarse en el formato [#-####-####] y debe contener 9 caracteres")]
        public string Cedula { get; set; }

        [Display(Name = "Nombre Completo")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "El Nombre es Obligatorio")]
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string? NombreCompleto { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La Fecha de Nacimiento es Obligatoria")]
        [Range(1900, 2020)]
        public int? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Telefono es Obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El Numero de Telefono debe Contener el Formato ## #### ##")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Debe Digitar una Profecion")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Su Profecion debe Tener Minimo 10 Caracteres")]
        public string? Profecion { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El Correo es Obligatorio")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "El Correo no Tiene los Suficientes Caracteres")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Su Correo debe Contener @ y gmail.com")]
        public string? CorreoElectronico { get; set; }

        public string? DondeSeEnteroDeLaPagina { get; set; }

        [RegularExpression("^(?=(?:.*[@$?¡\\-_]){1})\\S{8,16}$", ErrorMessage = "Rango Minimo 8 Caracteres Ademas Contener (Caracter Especial[@$?¡])")]
        [Required(ErrorMessage = "Debe Digitar una Contraseña")]
        public string? Contraseña { get; set; }

        //public bool Administrador = true;

    }
}
