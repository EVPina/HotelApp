using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class Persona
    {

        [Key]
        [Required]
        [StringLength(8)]
        public int DNI_Persona { get; set; }

        [Required]
        public string Nombre_Persona { get; set; }
        [Required]
        public string Apellido_Persona { get; set; }
        [Required]
        public int Id_Usuario { get; set; }

        public Usuarios Usuarios { get; set; }

    }
}
