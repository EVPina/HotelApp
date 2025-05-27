using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{
    public class VMSucursal
    {
        [Required]
        [StringLength(5)]
        public string Codigo_Sucursal { get; set; }
        public string? Nombre_Sucursal { get; set; }

        public string? Direccion_Sucursal { get; set; }

        [Phone]
        [StringLength(9)]
        public string? Telefono_Sucursal { get; set; }
    }
}
