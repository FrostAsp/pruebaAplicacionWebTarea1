using Clases_CRUD.CRUD_Modelos;
using Microsoft.EntityFrameworkCore;

namespace WebApiCRUD_Proyecto2.conexionBD
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
        public DbSet<Provedor> Provedor { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Tours> Tours { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Facturacion> Facturacion { get; set; }
    }
}
