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
    }
}
