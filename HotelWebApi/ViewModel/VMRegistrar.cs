using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{

    public enum RoleUsuario
    {
        Administrador,
        Empleado,
        Cliente
    }
    public class VMRegistrar
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Correo_Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password_Usuario { get; set; }

        [Required]
        [Compare(nameof(Password_Usuario), ErrorMessage = "contraseña diferente")]
        public string confirmpassword { get; set; }

        [EnumDataType(typeof(RoleUsuario), ErrorMessage = "Rol no válido.")]
        [Required]
        public string Role_Usuario { get; set; }
    }
}
