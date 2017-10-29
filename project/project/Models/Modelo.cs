using System.Data.Entity;

namespace project.Models
{
    public class Modelo:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        //public DbSet<Factura> Facturas { get; set; }
    }
}