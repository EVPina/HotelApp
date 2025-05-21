using HotelWebApi.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Persona 
    {

        [Key]
        [StringLength(8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DNI_Persona { get; set; }

        [Required]
        public string Nombre_Persona { get; set; }
        [Required]
        public string Apellido_Persona { get; set; }
        [Required]
        public string Cod_Usuario { get; set; }

        public Usuarios Usuarios { get; set; }

    }
}
