using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades.Infos
{
    public class MarcaInfo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;

        public string? UrlImagen { get; set; }

        public string TipoVehiculo { get; set; } = default!;
    }
}
