using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Categoria
    {

        [Key]
        public int IDCategoria { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Detalle")]
        public string Detalle { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}