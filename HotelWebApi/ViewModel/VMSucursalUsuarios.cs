using System.ComponentModel.DataAnnotations;

namespace HotelWebApi.ViewModel
{
    public class VMSucursalUsuarios
    {
        [Required]
        [StringLength(8)]
        public string Estado_Sucursales_Usuarios { get; set; }
    }
}
