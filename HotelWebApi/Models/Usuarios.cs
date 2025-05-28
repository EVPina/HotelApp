using HotelWebApi.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public enum Role{
        administrador,
        usuario
    }
    public class Usuarios : IGeneraId
    {
        [Required]
        [Key]
        [StringLength(8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cod_Usuario { get; set; }
        
        [Required]
        [EmailAddress]
        public string Correo_Usuario { get; set; }

        [Required]
        [MinLength(8)]
        public string Password_Usuario { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role_Usuario { get; set; }

        public ICollection<Sucursales_Usuarios> Sucursales_Usuarios { get; set; }
        public ICollection<Empleado> Empleados { get; set; }

        public void GenerarId()
        {
            Cod_Usuario =  Guid.NewGuid().ToString("N")[..8];
        }
    }
}
