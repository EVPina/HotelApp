using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Piso
    {
        [Key]
        [Required]
        public int Codigo_Piso{ get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre_Piso{ get; set; }

        [Required]
        public string Codigo_Sucursal { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado_Habitacion { get; set; }
  
        [ForeignKey(nameof(Codigo_Sucursal))]
        public Sucursales Sucursales { get; set; }

        public ICollection<TipoHabitacion> TipoHabitaciones { get; set; }

    }
}
