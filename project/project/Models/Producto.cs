using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Producto
    {

        [Key]
        public int IDProducto { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]        
        [DisplayName("Precio/U")]
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int IDCategoria { get; set; }
        [ForeignKey("IDCategoria")]
        public virtual Categoria Categorias { get; set; }

        [Required]
        [DisplayName("Proveedor")]
        public int IDProveedor { get; set; }
        [ForeignKey("IDProveedor")]
        public virtual Proveedor Proveedors { get; set; }

        [Required]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }


        public ICollection<Atributo> Atributos { get; set; }
    }
}