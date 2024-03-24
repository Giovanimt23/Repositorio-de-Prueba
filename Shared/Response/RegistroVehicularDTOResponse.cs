using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Response
{
    public class RegistroVehicularDTOResponse
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; } = default!;
        public DateTime FechaCaducidad { get; set; } = default!;

        public string Conductor { get; set; } = default!;
        public string Vehiculo { get; set; } = default!;

        public string? UrlPdf { get; set; }

        public string ConductorApellido { get; set; } = default!;
        public string ConductorDni { get; set; } = default!;
        public string VehiculiPlaca { get; set; } = default!;

        public string TipoVehiculiNombre { get; set; } = default!;
        public string MarcaNombre { get; set; } = default!;
        public string ModeloNombre { get; set; } = default!;

    }
}
