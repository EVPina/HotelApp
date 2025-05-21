using HotelWebApi.ViewModel;

namespace HotelWebApi.Interfaces
{
    public interface IUsuarios
    {
        public Task<string> Login(VMLogin vMUsuario);
        public Task<string> Registrar(VMRegistrar vMRegistrar);
    }
}
