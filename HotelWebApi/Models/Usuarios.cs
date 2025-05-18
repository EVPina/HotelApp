using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class Usuarios
    {
        [Required]
        [Key]
        [StringLength(8)]
        public string Cod_Usuario { get; set; }
        
        [Required]
        [EmailAddress]
        public string Correo_Usuario { get; set; }

        [Required]
        [MinLength(8)]
        public string Password_Usuario { get; set; }

        [Required]
        public string Role_Usuario { get; set; }
    }
}
