using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{
    public class VMLogin
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Correo_Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password_Usuario { get; set; }
    }
}
