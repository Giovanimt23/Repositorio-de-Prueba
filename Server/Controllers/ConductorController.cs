using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoryectoSistemaTransporte.Shared.Request;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorRepositorio Repositorio;

        public ConductorController(IConductorRepositorio repositorio)
        {
            Repositorio = repositorio;
        }
        //Listar
        [HttpGet]
        public async Task<IActionResult> ListarConductor(string? Apellido, string? Dni)
        {
            return Ok(await Repositorio.ListarAsync(Apellido,Dni));
        }

        //Crear
        [HttpPost]
        public async Task<IActionResult> Insertar(ConductorDTORequest request)
        {
            var conductor = new Conductor
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Dni = request.Dni,
                Edad = request.Edad,
                Telefono = request.Telefono,
                Direccion = request.Direccion,
                Estado = request.Estado,
                UsuarioCreacion = request.UsuarioCreacion
            };
            var response = await Repositorio.InsertarAsync(conductor);
            return Ok(response);
        }

        //Buscar para el editar y eliminacion(buscara por el id)

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var conductor = await Repositorio.BuscarAsync(id);
            if(conductor is null)
            {
                return NotFound();
            }
            return Ok(conductor);
        }

        //Editar

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Editar(int id, ConductorDTORequest request)
        {
            var conductor = await Repositorio.BuscarAsync(id);
            if(conductor is null)
            {
                return NotFound();
            }
            conductor.Nombre = request.Nombre;
            conductor.Apellido = request.Apellido;
            conductor.Dni = request.Dni;
            conductor.Edad = request.Edad;
            conductor.Telefono = request.Telefono;
            conductor.Direccion = request.Direccion;
            conductor.Estado = request.Estado;

            var response = await Repositorio.ActualizarAsync();
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
