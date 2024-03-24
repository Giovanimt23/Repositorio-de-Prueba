using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class Conductor : EntityBase
    {
  
        public string Nombre { get; set; } = default!;
        public string Apellido { get; set; } = default!;
        public string Dni { get; set; } = default!;
        public string Edad { get; set; } = default!;
        public string Telefono { get; set; } = default!;
        public string Direccion { get; set; } = default!;

        public ICollection<RegistroVehicular> RegistroVehiculars { get; set; } = default!;

    }
}
