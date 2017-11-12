using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_store.Models
{
    public class Atributo
    {

        [Key]
        public int IDAtributo { get; set; }

        //public int IDAtributoProducto { get; set; }

        [Required]
        [DisplayName("Producto")]
        public int IDProducto { get; set; }
        [ForeignKey("IDProducto")]
        public virtual Producto Productos { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Detalle")]
        public string Detalle { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }
    }
}