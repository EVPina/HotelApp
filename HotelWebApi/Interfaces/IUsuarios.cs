using HotelWebApi.Models;
using HotelWebApi.ViewModel;

namespace HotelWebApi.Interfaces
{
    public interface IUsuarios
    {
        public Task<string> Login(VMLogin vMUsuario);
        public Task<string> Registrar(VMRegistrar vMRegistrar);
        public Task<string> ActualizarDatos(VMDatosUsuario vMDatos);
        public Task<List<VMSucursal>> ListarSucursales(string id_usuario);
        public Task<List<VMSucursal>> ListarHabitacions(string id_sucursales);
        public Task<List<VMPiso>> ListarPisos(string id_sucursal);
    }
}
