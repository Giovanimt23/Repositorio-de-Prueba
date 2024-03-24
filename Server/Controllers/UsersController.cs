using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoryectoSistemaTransporte.Server.Services;
using PoryectoSistemaTransporte.Shared.Request;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserSerivce _serviceusuario;
       
        public UsersController(IUserSerivce service)
        {
            _serviceusuario = service;
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDTORequest request)
        {
            var response = await _serviceusuario.LoginAsync(request);

            return Ok(response);
        }


        [HttpPost("Registro")]
        public async Task<IActionResult> Register([FromBody] RegistroUsuarioDTO request)
        {
            var response = await _serviceusuario.RegistroAsync(request);

            return Ok(response);
        }
    }
}
