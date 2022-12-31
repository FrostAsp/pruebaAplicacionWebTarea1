using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clases_CRUD.CRUD_Modelos
{
    public class Producto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 10, ErrorMessage = "Debe dar una Descripcion")]
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Año en que se Ingreso al Inventario")]
        [Required(ErrorMessage = "Debe Digitar el Año en que se Ingreso")]
        [Range(1900, 2022, ErrorMessage = "El Año Debe Estar Entre (1900-2022)")]
        public int Año { get; set; }

        [Display(Name = "Precio de Compra")]
        [Range(0, 1000000)]
        [Required(ErrorMessage = "Debe Digitar un Precio")]
        public int precio { get; set; }

        [Display(Name = "Precio de Venta")]
        [Range(0, 1000000)]
        [Required(ErrorMessage = "Debe Digitar un Precio")]
        public int precioVenta { get; set; }

        [Display(Name = "Utilidad (%)")]
        [Range(1, int.MaxValue, ErrorMessage = "La Utilidad debe ser mayor a 0")]
        [Required(ErrorMessage = "Debe Digitar Una Utilidad")]
        public int Utilidad { get; set; }

        public int idprovedor { get; set; }

        //public virtual Provedor provedor { get; set; }

    }
}
