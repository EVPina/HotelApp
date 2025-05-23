using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Sucursales_Usuarios
    {
        [Key]
        [Required]
        public int Id_Sucursales_Usuarios { get; set; }
        [Required]
        [StringLength(5)]
        public string Codigo_Sucursal { get; set; }
        [Required]
        [StringLength(8)]
        public string Cod_Usuario { get; set; }

        [ForeignKey(nameof(Codigo_Sucursal))]
        public Sucursales Sucursales { get; set; }
        [ForeignKey(nameof(Cod_Usuario))]
        public Usuarios Usuarios { get; set; }
    }
}
