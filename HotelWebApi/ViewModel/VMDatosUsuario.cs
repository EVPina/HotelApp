using HotelWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{
    public enum TipoRol
    {
        administrador,
        recepcionista,
        cliente
    }
    public class VMDatosUsuario
    {
        [EmailAddress]
        [MaxLength(50)]
        public string? Correo_Usuario { get; set; }

        [MaxLength(50)]
        [MinLength(6)]
        public string? Password_Usuario { get; set; }

        [Compare(nameof(Password_Usuario), ErrorMessage = "contraseña diferente")]
        public string? confirmpassword { get; set; }

        [EnumDataType(typeof(TipoRol))]
        public string Role_Usuario { get; set; }

        [Range(0, 99999999,ErrorMessage ="Se admite hasta 8 caracteres")]
        public int DNI_Empleado { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido_Empleado { get; set; }
        public string Cod_Usuario { get; set; }
        
    }
}
