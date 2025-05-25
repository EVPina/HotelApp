using HotelWebApi.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Clientes : IGeneraId
    {
        [Key]
        [StringLength(8)]
        [Required]
        public string Cod_Clientes{ get; set; }

        [Range(0, 99999999)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? DNI_Cliente { get; set; }

        [Required]
        public string? Nombre_Cliente { get; set; }
        [Required]
        public string? Apellido_Cliente { get; set; }

        void IGeneraId.GenerarId()
        {
          Cod_Clientes= Guid.NewGuid().ToString("N")[..8];
        }
    }
}
