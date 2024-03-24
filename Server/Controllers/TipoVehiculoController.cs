using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ITipoVehiculoRepositorio Repositorio;

        public TipoVehiculoController(ITipoVehiculoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }
        //Listar
        [HttpGet]
        public async Task<IActionResult> ListarTipoVehiculo(string? Descripcion)
        {
            return Ok(await Repositorio.ListarAsync(Descripcion));
        }

       /*[HttpGet]
        public  async Task<IActionResult> ListarTipoVehiculoDescripcion(string? Descripcion)
        {
            return Ok(await Repositorio.ListarAsync(Descripcion));
        }*/
    }
}
