using AutoMapper;
using HotelWebApi.Interfaces;
using HotelWebApi.Models;
using HotelWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelWebApi.Services
{
    public class SUsuarios : IUsuarios
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SUsuarios> _logger;
        private readonly SJWToken _swtoken;
        public SUsuarios(AppDBContext dbContext, IMapper mapper, SJWToken swtoken, ILogger<SUsuarios> logger)
        {
            _context = dbContext;
            _mapper = mapper;
            _swtoken = swtoken;
            _logger = logger;
        }

        public async Task<string> Login(VMLogin vMUsuario)
        {
            string response = "";

            _logger.LogInformation("Iniciando el proceso de iniciar para el usuario: {Correo_Usuario}", vMUsuario.Correo_Usuario);

            Usuarios map_user = _mapper.Map<Usuarios>(vMUsuario);
            var usuario = await FindUser(map_user.Correo_Usuario);

            if (usuario != null)
            {
                response = CheckPassword(usuario.Password_Usuario, vMUsuario.Password_Usuario);

                if (response == "verificado")
                {
                    response = _swtoken.generateToken(usuario.Correo_Usuario, usuario.Cod_Usuario, usuario.Role_Usuario);
                    _logger.LogInformation("Se logro iniciar sesion");
                }
            }

            else
            {
                _logger.LogWarning("El Correo {Correo_Usuario} no se encuentra registrado", vMUsuario.Correo_Usuario);
                response = "No se encontro usuario";
            }
            return response;
        }

        public async Task<string> Registrar(VMRegistrar vMRegistrar)
        {
            string response = "se logro registrar";

            _logger.LogInformation("Iniciando el proceso de registrar para el usuario: {Correo_Usuario}", vMRegistrar.Correo_Usuario);

            Usuarios map_usuarios = _mapper.Map<Usuarios>(vMRegistrar);

            Usuarios check_usuarios = await FindUser(vMRegistrar.Correo_Usuario);

            if (check_usuarios == null)
            {
                string nueva_contrasena = BCrypt.Net.BCrypt.HashPassword(map_usuarios.Password_Usuario);

                map_usuarios.Password_Usuario = nueva_contrasena;
                map_usuarios.GenerarId();

                _context.Usuarios.Add(map_usuarios);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Se logro registrar el usuario");

            }
            else
            {
                response = "correo ya registrado";

                _logger.LogWarning("El Correo {Correo_Usuario} ya se encuentra registrado", map_usuarios.Correo_Usuario);

            }
            return response;
        }


        //Buscar si existe usuario 
        private async Task<Usuarios> FindUser(string correo_usuario)
        {
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

        public async Task<string> ActualizarDatos(VMDatosUsuario vMDatos)
        {
            string response = "se logro actualizar";
            try
            {
                _logger.LogInformation("Iniciando el proceso de actualizar para el usuario: {Correo_Usuario}", vMDatos.Correo_Usuario);

                Persona persona = _mapper.Map<Persona>(vMDatos);

                var result_usuario = await _context.Personas.FirstOrDefaultAsync(x => x.Cod_Usuario == persona.Cod_Usuario);

                if (result_usuario == (null))
                {
                    _context.Personas.Add(persona);
                    await _context.SaveChangesAsync();
                }
                else
                {
                   var a = await _context.Personas.Include(c=>c.Usuarios).ToListAsync();
                    response = a.FirstOrDefault().Usuarios.Correo_Usuario;
                }
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
         

            return response;
        }
    }
}
