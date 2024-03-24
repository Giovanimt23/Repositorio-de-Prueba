using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Response
{
    public class LoginDTOResponse : BaseResponseDTO
    {
        public string token { get; set; } = default!;
        public string NombreCompleto { get; set; } = default!;

        public List<string> Roles { get; set; } = default!;

        
    }
    
}
