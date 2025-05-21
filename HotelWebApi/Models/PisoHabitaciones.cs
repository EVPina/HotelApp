using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class PisoHabitaciones
    {
        [Key]
        [Required]
        [StringLength(5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Cod_PisoHabitacion { get; set; }

        [Required]
        [StringLength(5)]
        public string Nombre_PisoHabitacion { get; set; }
        
        [Required]
        public int ID_TipoHabitacion { get; set; }
        
        [Required]
        public string Estado_TipoHabitacion { get; set; }

        [Required]
        public string Codigo_Sucursal { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
        public Sucursales Sucursales { get; set; }
    }
}
