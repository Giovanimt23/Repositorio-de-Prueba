using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PoryectoSistemaTransporte.Shared;
using PoryectoSistemaTransporte.Shared.Request;
using PoryectoSistemaTransporte.Shared.Response;
using ProyectoSistemaTransporte.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;


namespace PoryectoSistemaTransporte.Server.Services
{
    public class UserService : IUserSerivce
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUsuarioTransporte> _userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(IConfiguration configuration,UserManager<IdentityUsuarioTransporte> userManager, ILogger<UserService> logger)
        {
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;

     
        }
        public async Task<LoginDTOResponse> LoginAsync(LoginDTORequest request)
        {

            var response = new LoginDTOResponse();

            //Validamos el usuario y clave

            try
            {
                var identity = await _userManager.FindByNameAsync(request.Usuario);

                if(identity is null)
                    throw new SecurityException("Usuario no existe");
               
                if(! await _userManager.CheckPasswordAsync(identity, request.Password))
                {
                    throw new SecurityException("Usuario o clave incorrecta");
                }

                var roles = await _userManager.GetRolesAsync(identity);
                var fechaExpiracion = DateTime.Now.AddHours(1);


                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, identity.NombreCompleto),
                        new Claim(ClaimTypes.Expiration, fechaExpiracion.ToString("yyyy-MM-dd HH:mm:ss"))
                      
                    };

                claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

                response.Roles = roles.ToList();

                    var llaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWt:SecretKey"]!));
                    var credenciales = new SigningCredentials(llaveSimetrica, SecurityAlgorithms.HmacSha256);

                    var header = new JwtHeader(credenciales);

                    var payload = new JwtPayload(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        DateTime.Now,
                        fechaExpiracion
                        );

                    var jwtToken = new JwtSecurityToken(header, payload);

                response.token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                response.NombreCompleto = identity.NombreCompleto;
                response.Exito = true;

                _logger.LogInformation("Se creo el JWT de forma satisfactoria");

                   
            }
            catch(SecurityException ex)
            {
                response.MensajeError = ex.Message;
                _logger.LogError(ex, "Error de seguridad {Message}", ex.Message);
            }    
            catch(Exception ex)
            {
                response.MensajeError = "Error inesperado";
                _logger.LogError(ex, "Error al auntenticar {Message}", ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseDTO> RegistroAsync(RegistroUsuarioDTO request)
        {
            var response = new BaseResponseDTO();

            try
            {
                var identity = new IdentityUsuarioTransporte
                {
                    NombreCompleto = request.NombreCompleto,
                    FechaNacimiento = request.FechaNacimiento,
                    Direccion = request.Direccion,
                    UserName = request.NombreUsuario,
                    Email = request.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(identity, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identity, Constantes.RolRegistrador);


                }
                else
                {
                    var sb = new StringBuilder();
                    foreach (var identityError in result.Errors)
                    {
                        sb.AppendFormat("{0} ", identityError.Description);
                    }

                    response.MensajeError = sb.ToString();
                    sb.Clear();
                }

                response.Exito = result.Succeeded;
            }
            catch (Exception ex)
            {
                response.MensajeError = "Error al registrar";
                _logger.LogWarning(ex, "{MensajeError} {Message}", response.MensajeError, ex.Message);
            }

            return response;
        }

       
    }
}
