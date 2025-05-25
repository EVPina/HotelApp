using AutoMapper;
using HotelWebApi.Interfaces;
using HotelWebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _Service_user;

        public UsuariosController(IUsuarios Service_user) {
            _Service_user = Service_user;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] VMLogin vMUsuario)
        {

            var response = await _Service_user.Login(vMUsuario);

            if (response.Equals("No se encontro usuario"))
                return NotFound(response);
            else if (response.Equals("contraseña incorrecta"))
                return Unauthorized(response);
            else
                return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VMRegistrar vMRegistrar)
        {

            var response = await _Service_user.Registrar(vMRegistrar);
            if (response.Equals("correo ya registrado"))
                return BadRequest(response);
            else
                return (Ok(response));
        }

        [HttpPut("Saludo")]
        public async Task<IActionResult> ActualizarDatos([FromBody] VMDatosUsuario vMDatosUsuario)
        {
            if (ModelState.IsValid)
            {
                var respuesta = await _Service_user.ActualizarDatos(vMDatosUsuario);

                return Ok(respuesta);
            }
            return BadRequest();
        }
    }
}
