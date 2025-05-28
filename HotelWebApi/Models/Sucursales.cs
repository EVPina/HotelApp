using HotelWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApi.Models
{
    public class Sucursales : IGeneraId
    {
        [Key, Required, StringLength(5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Codigo_Sucursal { get; set; }

        [Required]
        public string Nombre_Sucursal { get; set; }
  
        [Required]
        public string Direccion_Sucursal { get; set; }

        [Required, Phone]
        [StringLength(9)]
        public string Telefono_Sucursal { get; set; }

        public ICollection<Sucursales_Usuarios> Sucursales_Usuarios { get; set; }
        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<Piso> Pisos { get; set; }

        public void GenerarId()
        {
            Codigo_Sucursal = Guid.NewGuid().ToString("N")[..5];
        }
    }
}
