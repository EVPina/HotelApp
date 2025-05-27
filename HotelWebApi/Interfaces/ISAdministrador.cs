using HotelWebApi.ViewModel;

namespace HotelWebApi.Interfaces
{
    public interface ISAdministrador
    {
        public Task<string> ActualizarSucursal(VMSucursal vMSucursal);
    }
}
