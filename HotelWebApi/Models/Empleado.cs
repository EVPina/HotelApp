using HotelWebApi.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Empleado 
    {
        [Key]
        [StringLength(8)]
        [Required]
        public string Cod_Empleado { get; set; }

        [Range(0, 99999999)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? DNI_Empleado { get; set; }

        [Required]
        public string? Nombre_Empleado { get; set; }
        [Required]
        public string? Apellido_Empleado { get; set; }

        [Required]
        public string Cod_Usuario { get; set; }

        [ForeignKey(nameof(Cod_Usuario))]
        public Usuarios Usuarios { get; set; }
        public void GenerarId()
        {
            Cod_Empleado = Guid.NewGuid().ToString("N")[..8];
        }

    }
}
