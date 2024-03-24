using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using PoryectoSistemaTransporte.Server.Services;
using PoryectoSistemaTransporte.Shared;
using PoryectoSistemaTransporte.Shared.Request;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Repositorio.Interfacces;

namespace PoryectoSistemaTransporte.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio Repositorio;
        private readonly IFileUploader _fileUploader;

        public MarcaController(IMarcaRepositorio repositorio, IFileUploader fileUploader)
        {
            Repositorio = repositorio;
           _fileUploader = fileUploader;
        }
        //Listar
        [HttpGet]
        public async Task<IActionResult> ListarMarca(string? idtipovehiculo)
        {
            int id = Convert.ToInt32(idtipovehiculo);
            return Ok(await Repositorio.ListarAsync(id));
        }

        //Crear
        [HttpPost]
        public async Task<IActionResult> Insertar(MarcaDTORequest request)
        {
            var marca = new Marca
            {
                Descripcion = request.Descripcion,
                TipovehiculoId = request.TipovehiculoId,
                UsuarioCreacion = request.UsuarioCreacion,
    
                //UrlImagen = request.UrlImagen

                
            };
           marca.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
            var response = await Repositorio.InsertarAsync(marca);
            return Ok(response);
        }

        //Buscar para el editar y eliminacion(buscara por el id)

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var marca = await Repositorio.BuscarAsync(id);
            if (marca is null)
            {
                return NotFound();
            }
            var response = new MarcaDTORequest
            {
                Id = marca.Id,
                Descripcion = marca.Descripcion,
                TipovehiculoId = marca.TipovehiculoId,
                UrlImagen = marca.UrlImagen,
              
            };

            return Ok(response);
        }

        //Editar

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Editar(int id, MarcaDTORequest request)
        {
            var marca = await Repositorio.BuscarAsync(id);
            if (marca is null)
            {
                return NotFound();
            }
            marca.Descripcion = request.Descripcion;
            marca.TipovehiculoId = request.TipovehiculoId;
            marca.UsuarioModificacion = request.UsuarioModificacion;
            marca.FechaModificacion = request.FechaModificacion;
            //marca.UrlImagen = request.UrlImagen;

            if (!string.IsNullOrWhiteSpace(request.Base64Imagen))
            {
                marca.UrlImagen = await _fileUploader.UploadFileAsync(request.Base64Imagen, request.NombreArchivo);
            }
            var response = await Repositorio.ActualizarAsync();
            return Ok(response);
        }

        //Eliminar

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Repositorio.EliminarAsync(id);

            return Ok(response);
        }
    }
}
