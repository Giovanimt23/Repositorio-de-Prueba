using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Request
{
    public class TipoVehiculoDTORequest
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = default!;
    }
}
