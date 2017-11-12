using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_store.Models
{
    public class DetalleFactura
    {
        [Key]
        public int IDDetalle { get; set; }

        public int FacturaID { get; set; }

        public int ProductoID { get; set; }

        public int Cantidad { get; set; }

        public double PrecioProducto { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }
    }
}