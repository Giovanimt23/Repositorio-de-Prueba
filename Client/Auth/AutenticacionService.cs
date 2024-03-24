using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;
using PoryectoSistemaTransporte.Shared.Response;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace PoryectoSistemaTransporte.Client.Auth
{
    public class AutenticacionService : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly ClaimsPrincipal usuarioanonimo = new ClaimsPrincipal(new ClaimsIdentity());
        public AutenticacionService(HttpClient httpClient, ISessionStorageService sessionStorageService)
        {
            _httpClient = httpClient;
            _sessionStorageService = sessionStorageService;
        }

        public async Task Autenticar(LoginDTOResponse? response)
        {
            ClaimsPrincipal UsuarioPrincipal;

            if (response is not null)
            {
                //establecemos el objeto Httpcliente token y header
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.token);

                //se recupera los claims
                var jwt = ParseToken(response);

                UsuarioPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, authenticationType:"JWT"));

                //guardamos la session
                await _sessionStorageService.SetItemAsync("SessionUsuario", response);
            }
            else
            {
                UsuarioPrincipal = usuarioanonimo;
                await _sessionStorageService.RemoveItemAsync("SessionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(UsuarioPrincipal)));
        }

        private JwtSecurityToken ParseToken(LoginDTOResponse response)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(response.token);
            return token;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sessionUsuario = await _sessionStorageService.GetItemAsync<LoginDTOResponse>("SessionUsuario");

            if (sessionUsuario is null)
                return await Task.FromResult(new AuthenticationState(usuarioanonimo));

            var UsuarioPrincipal = new ClaimsPrincipal(new ClaimsIdentity(ParseToken(sessionUsuario).Claims, authenticationType: "JWT"));

            return await Task.FromResult(new AuthenticationState(UsuarioPrincipal));
                
            
        }
    }
}
