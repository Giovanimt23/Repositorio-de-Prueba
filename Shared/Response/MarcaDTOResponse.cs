using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Response
{
    public class MarcaDTOResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;

        public string? UrlImagen { get; set; }

        public string TipoVehiculo { get; set; } = default!;


    }
}
