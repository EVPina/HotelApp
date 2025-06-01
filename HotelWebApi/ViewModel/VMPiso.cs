using HotelWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.ViewModel
{
    public class VMPiso
    {
        [Key]
        [Required]
        public int Codigo_Piso { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre_Piso { get; set; }
    }
}
