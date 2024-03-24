using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Request
{
    public class LoginDTORequest
    {
        public string Usuario { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}