using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class Sucursales
    {
        [Key]
        [Required]
        [StringLength(5)]
        public string Codigo_Sucursal { get; set; }

        [Required]
        public string Nombre_Sucursal { get; set; }

        [Required]
        public int Pisos_Sucursal { get; set; }
    }
}
