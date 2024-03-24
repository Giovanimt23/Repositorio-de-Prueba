using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoryectoSistemaTransporte.Shared.Request;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVehicularController : ControllerBase
    {
        private readonly IRegistroVehicularRepositorio Repositorio;

        public RegistroVehicularController(IRegistroVehicularRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ListarRegistroVehicular(string? Placa, string? Dni)
        {
            return Ok(await Repositorio.ListarAsync(Placa, Dni));
        }


        //Crear
        [HttpPost]
        public async Task<IActionResult> Insertar(RegistroVehicularDTORequest request)
        {
            var registrovehiculo = new RegistroVehicular
            {
                FechaCaducidad = request.FechaCaducidad,
                FechaRegistro = request.FechaRegistro,
                ConductorId = request.ConductorId,
                VehiculoId = request.VehiculoId,
                UsuarioCreacion = request.UsuarioCreacion

            };
           var response = await Repositorio.InsertarAsync(registrovehiculo);
            return Ok(response);
        }




        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Repositorio.EliminarAsync(id);

            return Ok(response);
        }
    }
}
