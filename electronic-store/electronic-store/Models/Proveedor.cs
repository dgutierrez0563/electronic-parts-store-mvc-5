using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_store.Models
{
    public class Proveedor
    {

        [Key]
        public int IDProveedor { get; set; }

        [Required]
        [StringLength(40)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Representante")]
        public string Representante { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

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

        public ICollection<Producto> Productoes { get; set; }
    }
}