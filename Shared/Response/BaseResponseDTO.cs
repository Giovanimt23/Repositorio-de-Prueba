using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Response
{
    public class BaseResponseDTO
    {
        public string? MensajeError { get; set; }
        public bool Exito { get; set; }
    }
}
