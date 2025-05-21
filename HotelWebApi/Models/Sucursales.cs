using HotelWebApi.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.Models
{
    public class Sucursales : IGeneraId
    {
        [Key]
        [Required]
        [StringLength(5)]
        public string Codigo_Sucursal { get; set; }

        [Required]
        public string Nombre_Sucursal { get; set; }

        [Required]
        public int Pisos_Sucursal { get; set; }

        void IGeneraId.GenerarId()
        {
            Codigo_Sucursal = Guid.NewGuid().ToString("N")[..5];
        }
    }
}
