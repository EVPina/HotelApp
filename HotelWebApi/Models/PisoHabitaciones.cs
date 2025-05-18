using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class PisoHabitaciones
    {
        [Key]
        [Required]
        [StringLength(5)]
        public int Id_PisoHabitacion { get; set; }

        [Required]
        [StringLength(5)]
        public string Nombre_PisoHabitacion { get; set; }
        
        [Required]
        public int ID_TipoHabitacion { get; set; }
        
        [Required]
        public string Estado_TipoHabitacion { get; set; }

        [Required]
        public int Codigo_Sucursal { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
        public Sucursales Sucursales { get; set; }
    }
}
