using AutoMapper;
using HotelWebApi.ViewModel;

namespace HotelWebApi.Models
{
    public class MapData : Profile
    {
        public MapData() {
            CreateMap<VMLogin, Usuarios>();
            CreateMap<Usuarios, VMLogin>();
            CreateMap<VMRegistrar, Usuarios>();
            CreateMap<Usuarios, VMRegistrar>();
            CreateMap<VMDatosUsuario, Empleado>();
            CreateMap<Empleado, VMDatosUsuario>();
            CreateMap<Sucursales, VMSucursal>().ForMember(c=>c.SucursalUsuarios,opt=>opt.MapFrom(src=>src.Sucursales_Usuarios));
            CreateMap<Sucursales_Usuarios, VMSucursalUsuarios>();
            CreateMap<Piso, VMPiso>();
            CreateMap<TipoHabitacion, VMHabitaciones>();
        }
    }
}
