using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class TipoHabitacion
    {
        [Required]
        [Key]
        public int ID_TipoHabitacion { get; set; }

        [Required]
        public string Nombre_TipoHabitacion { get; set; }

        [Required]
        public double Precio_TipoHabitacion { get; set; }

        [Required]
        public int Codigo_Piso { get; set; }

        [ForeignKey(nameof(Codigo_Piso))]
        public Piso piso { get; set; }

    }
}
