using AutoMapper;
using HotelWebApi.Interfaces;
using HotelWebApi.Models;
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

        [HttpPut("ActualizarDatos")]
        public async Task<IActionResult> ActualizarDatos([FromBody] VMDatosUsuario vMDatosUsuario)
        {
            if (ModelState.IsValid)
            {
                var respuesta = await _Service_user.ActualizarDatos(vMDatosUsuario);

                return Ok(respuesta);
            }
            return BadRequest();
        }

        [HttpGet("ListarSucursales/{id_usuario}")]
        public async Task<IActionResult> ListarSucursales(string id_usuario)
        {
            List<VMSucursal> sucursales = await _Service_user.ListarSucursales(id_usuario);

            if (sucursales.Count == 0 | sucursales == null) 
                return NotFound("No hay sucursales asociadas al usuario");
            else
                return Ok(sucursales);
        }

        [AllowAnonymous]
        [HttpGet("ListarPisos/{id_sucursal}")]
        public async Task<IActionResult> ListarPisos(string id_sucursal)
        {
            List<VMPiso> sucursales = await _Service_user.ListarPisos(id_sucursal);

            if (sucursales.Count == 0 | sucursales == null) 
                return NotFound("No hay sucursales asociadas al usuario");
            else
                return Ok(sucursales);
        }
       
        [HttpGet("ListarHabitaciones/{id_sucursal}")]
        public async Task<IActionResult> ListarHabitaciones(string id_sucursal)
        {
            List<VMSucursal> sucursales = await _Service_user.ListarSucursales(id_usuario);

            if (sucursales.Count == 0 | sucursales == null) 
                return NotFound("No hay sucursales asociadas al usuario");
            else
                return Ok(sucursales);
        }
    }
}
