using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepositorio Repositorio;

        public ModeloController(IModeloRepositorio repositorio)
        {
            Repositorio = repositorio;
        }
        //Listar
        [HttpGet("simple")]
        public async Task<IActionResult> ListarModelo(int idmarca)
        {
            return Ok(await Repositorio.ListarAsync(idmarca));
        }

        [HttpGet("simpleSP")]
        public async Task<IActionResult> ListarModelo(string? Descripcion)
        {

            return Ok(await Repositorio.ListarAsync(Descripcion));
        }
    }
}
