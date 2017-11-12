using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_store.Models
{
    public class Cliente
    {
        public string active;
        public string iduser;

        [Key]
        public int IDCliente { get; set; }
        [Required]
        [DisplayName("Cedula Identidad")]
        public string DNI { get; set; }
        [Required]
        [DisplayName("Nombre Completo")]
        public string NombreApellido { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }
        [Required]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaActualizado { get; set; }

        public string Active {
            get { return active; }
            set { active = value; }
        }

        public string IDUser {
            get { return iduser; }
            set { iduser = value; }
        }

        //public class ClienteViewModel {

        //}
    }
}