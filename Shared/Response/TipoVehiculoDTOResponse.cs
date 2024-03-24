using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Response
{
    public class TipoVehiculoDTOResponse
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = default!;
    }
}
