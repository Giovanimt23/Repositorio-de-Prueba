using PoryectoSistemaTransporte.Shared.Request;
using PoryectoSistemaTransporte.Shared.Response;
using ProyectoSistemaTransporte.Entidades.RespuestaApi;

namespace PoryectoSistemaTransporte.Server.Services
{
    public interface IUserSerivce
    {
        Task<LoginDTOResponse> LoginAsync(LoginDTORequest request);

        Task<BaseResponseDTO> RegistroAsync(RegistroUsuarioDTO request);
    }
}
