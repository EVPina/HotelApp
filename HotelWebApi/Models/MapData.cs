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
            CreateMap<VMDatosUsuario, Persona>();
            CreateMap<Persona, VMDatosUsuario>();
        }
    }
}
