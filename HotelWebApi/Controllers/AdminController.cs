using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "administrador")]
    public class AdminController : ControllerBase
    {

        public AdminController() {}

        [HttpGet("prueba")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
