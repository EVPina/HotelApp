using HotelWebApi.Interfaces;
using HotelWebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class AdminController : ControllerBase
    {
        private readonly ISAdministrador _sAdministrador;

        public AdminController(ISAdministrador sAdministrador) {
            _sAdministrador = sAdministrador;
                }

        [HttpPut("ActualizarSucursal")]
        public async Task<IActionResult> ActualizarSucursal([FromBody] VMSucursal vMSucursal)
        {
            if(ModelState.IsValid)
            {
                // Aquí se llamaría al servicio para agregar la sucursal
                string response = await _sAdministrador.ActualizarSucursal(vMSucursal);
                switch (response)
                {
                    case "Error en la actualizacion":
                        return BadRequest(response);
                    case "Sucursal no encontrada.":
                        return NotFound(response);
                    default:
                        return Ok(response);
                }
                 
            }
            return BadRequest(ModelState);
        }
    }
}
