using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using PoryectoSistemaTransporte.Shared;
using PoryectoSistemaTransporte.Shared.Request;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepositorio Repositorio;

        public VehiculoController(IVehiculoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        //Listar
        [HttpGet]
        public async Task<IActionResult> ListarVehiculo(string? Placa)
        {
            return Ok(await Repositorio.ListarAsync(Placa));
        }

        //Crear
        [HttpPost]
        public async Task<IActionResult> Insertar(VehiculoDTORequest request)
        {
            var vehiculo = new Vehiculo
            {
                Color = request.Color,
                NumeroDAsiento = request.NumeroDAsiento,
                Placa = request.Placa,
                TipoVehiculoId = request.TipoVehiculoId,
                MarcaId = request.MarcaId,
                ModeloId = request.ModeloId,
                Estado = request.Estado,
                UsuarioCreacion = request.UsuarioCreacion
            };
            var response = await Repositorio.InsertarAsync(vehiculo);
            return Ok(response);
        }

        //Buscar para el editar y eliminacion(buscara por el id)

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var vehiculo = await Repositorio.BuscarAsync(id);
            if (vehiculo is null)
            {
                return NotFound();
            }
            var response = new VehiculoDTORequest
            {
                Id = vehiculo.Id,
                Color = vehiculo.Color,
                NumeroDAsiento = vehiculo.NumeroDAsiento,
                Placa= vehiculo.Placa,
                Estado = vehiculo.Estado,
                MarcaId = vehiculo.MarcaId,
                ModeloId = vehiculo.ModeloId,
                TipoVehiculoId = vehiculo.TipoVehiculoId
                
            };

            return Ok(response);
        }

        //Editar

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Editar(int id, VehiculoDTORequest request)
        {
            var vehiculo = await Repositorio.BuscarAsync(id);
            if (vehiculo is null)
            {
                return NotFound();
            }
            vehiculo.Color = request.Color;
            vehiculo.NumeroDAsiento = request.NumeroDAsiento;
            vehiculo.Placa = request.Placa;
            vehiculo.Estado = request.Estado;
            vehiculo.MarcaId = request.MarcaId;
            vehiculo.ModeloId = request.ModeloId;
            vehiculo.TipoVehiculoId = request.TipoVehiculoId;
            vehiculo.UsuarioModificacion = request.UsuarioModificacion;
            vehiculo.FechaModificacion = request.FechaModificacion;

            var response =await Repositorio.ActualizarAsync();
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response =await Repositorio.EliminarAsync(id);

            return Ok(response);
        }

    }
}
