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

                Empleado map_empleado = _mapper.Map<Empleado>(vMDatos);

                var result_usuarios = await _context.Usuarios.FirstOrDefaultAsync(x => x.Cod_Usuario == map_empleado.Cod_Usuario);


                var result_persona = await _context.Empleado.FirstOrDefaultAsync(x => x.DNI_Empleado == vMDatos.DNI_Empleado);

                //Si no hy datos personales del usuario, lo agregamos
                if (result_persona == (null))
                {
                    _logger.LogInformation("Se estan agregando datos personales");
                    map_empleado.GenerarId();
                    _context.Empleado.Add(map_empleado);
                    await _context.SaveChangesAsync();
                }

                //Actualizamos los datos del usuario
                if (result_usuarios != null)
                {
                    _logger.LogInformation("Se estan actualizando los datos del usuario");

                    if (vMDatos.Correo_Usuario != null)
                    {
                        result_usuarios.Correo_Usuario = vMDatos.Correo_Usuario;
                    }

                    if (vMDatos.Password_Usuario != null)
                    {
                        string nueva_contrasena = BCrypt.Net.BCrypt.HashPassword(vMDatos.Password_Usuario);
                        result_usuarios.Password_Usuario = nueva_contrasena;
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());

                response = ex.Message;
            }

            return response;
        }

        public async Task<List<VMSucursal>> ListarSucursales(string id_usuario)
        {
            List<VMSucursal> map_sucursal = null;

            List <Sucursales> lista_sucursales = await _context.Sucursales.Include(c=>c.Sucursales_Usuarios).Where(c=>c.Sucursales_Usuarios.Any(r=>r.Cod_Usuario==id_usuario & r.Estado_Sucursales_Usuarios == "activo")).ToListAsync();

            if (lista_sucursales != null || lista_sucursales.Count != 0)
                 map_sucursal= _mapper.Map<List<VMSucursal>>(lista_sucursales);
            
            return map_sucursal;
        }
    }
}
