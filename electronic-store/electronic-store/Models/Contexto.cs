using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace electronic_store.Models
{
    public class Contexto:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Producto> Productoes { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        //public DbSet<ShopCar> ShopCars { get; set; }
    }
}