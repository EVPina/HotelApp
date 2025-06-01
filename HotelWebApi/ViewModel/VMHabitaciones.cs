using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{
    public class VMHabitaciones
    {
        [Required]
        [Key]
        public int ID_TipoHabitacion { get; set; }

        [Required]
        public string Nombre_TipoHabitacion { get; set; }

        [Required]
        public double Precio_TipoHabitacion { get; set; }
    }
}
