﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Wishlist
    {

        [Key]
        public int IDWishlist { get; set; }
        //[Required]
        //[StringLength(30)]
        //[DisplayName("Nombre")]
        //public string NombreLista { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        [Required]
        public int IDProducto { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }

    }
}