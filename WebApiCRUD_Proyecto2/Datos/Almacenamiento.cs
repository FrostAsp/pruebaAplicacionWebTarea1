
using Clases_CRUD.CRUD_Modelos;

namespace WebApiCRUD_Proyecto2.Datos
{
    public class Almacenamiento
    {
        public static string usuario;
        public static string clave;

        public static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente
            {
                Cedula = "1-1111-1111",
                NombreCompleto = "Administrador",
                FechaNacimiento = 1980,
                Telefono = 1345678678,
                Profecion = "Gerente",
                CorreoElectronico = "AdminG@gmail.com",
                DondeSeEnteroDeLaPagina = "SoyGerente",
                Contraseña = "123"
            }
        };

        //public static string[] usuario = new string[2];

        public static List<Tours> tours = new List<Tours> {
            new Tours
            {
                Id = 1,
                Descripcion = "Mirador Ujarrás",
                Dia = "Lunes",
                Imagen = "ccf5a8d7-b7cc-49b2-8a7a-8c22bd1608ac.png",
                Precio = 50000
            }
        };

        public static List<Producto> productos = new List<Producto>
        {
           new Producto
           {
               Id = 1,
               Descripcion = "Camisa de león",
               Año = 2020,
               precio = 12000,
               precioVenta = 10000,
               Utilidad = 5,
               //provedor = new Provedor{Cedula = "6-3223-2345", Descripcion = "Provedor mas confiable"}
           }
        };

        public static List<Provedor> proveedores = new List<Provedor> 
        {
            new Provedor
            {
                Cedula = "6-3223-2345",
                Descripcion = "Provedor mas confiable"
            }
        };

        public static List<Facturacion> facturacion = new List<Facturacion>();

        //public static List<listasFacturacion> listasProdutosyToursDisponibles = new List<listasFacturacion>();

        //public static listasFacturacion listasFacturacion = new listasFacturacion();

        //List<listasFacturacion> listasFacturacions = new List<listasFacturacion>
        //{


        //}

    }
}
