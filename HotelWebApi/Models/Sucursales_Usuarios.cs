using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class Sucursales_Usuarios
    {
        [Key]
        [Required]
        public int Id_Sucursales_Usuarios { get; set; }
        [Required]
        [StringLength(5)]
        public int Codigo_Sucursal { get; set; }
        [Required]
        [StringLength(8)]
        public string Cod_Usuario { get; set; }

        public Sucursales Sucursales { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
