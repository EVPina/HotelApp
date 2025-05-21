using AutoMapper;
using HotelWebApi.Interfaces;
using HotelWebApi.Models;
using HotelWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Services
{
    public class SUsuarios: IUsuarios
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly SJWToken _swtoken;
        public SUsuarios(AppDBContext dbContext, IMapper mapper, SJWToken swtoken) { _context = dbContext;
            _mapper =mapper;
            _swtoken=swtoken;
        }

        public async Task<string> Login(VMLogin vMUsuario)
        {
            string response = "";

            Usuarios map_user = _mapper.Map<Usuarios>(vMUsuario);
            var usuario = await FindUser(map_user);

            if (usuario != null)
            {
                response = CheckPassword(usuario.Password_Usuario, vMUsuario.Password_Usuario);

                if (response == "verificado") 
                    response = _swtoken.generateToken(usuario.Correo_Usuario, usuario.Cod_Usuario, usuario.Role_Usuario);
            }

            else
                response = "No se encontro usuario";
            return response;
        }

        public async Task<string> Registrar(VMRegistrar vMRegistrar)
        {
            string response = "se logro registrar";

            Usuarios map_usuarios = _mapper.Map<Usuarios>(vMRegistrar);

            map_usuarios.GenerarId();

            Usuarios usuarios = await FindUser(map_usuarios);

            if (usuarios == null)
            {
                string nueva_contrasena = BCrypt.Net.BCrypt.HashPassword(map_usuarios.Password_Usuario);

                map_usuarios.Password_Usuario = nueva_contrasena;


                _context.Usuarios.Add(map_usuarios);
                await _context.SaveChangesAsync();
            }
            else
                response = "correo ya registrado";
            return response;
        }


        //Buscar si existe usuario 
        private async Task<Usuarios> FindUser(Usuarios usuarios)
        {
            string correo_usuario = usuarios.Correo_Usuario;

            var result_usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Correo_Usuario == correo_usuario);

            return result_usuario;
        }

        private string CheckPassword(string dbpassword, string contrasena)
        {
            string response = "verificado";
            //Comparamos las contraseñas con la base de datos
            if (!BCrypt.Net.BCrypt.Verify(contrasena, dbpassword))
                response = "contraseña incorrecta";
            return response;
        }
    }
}
