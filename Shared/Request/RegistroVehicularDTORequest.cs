using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Request
{
    public class RegistroVehicularDTORequest
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now!;

   
        public DateTime FechaCaducidad { get; set; } = DateTime.Now!;

        [Range(1, 9999, ErrorMessage = "Ingrese el Nombre")]
        public int ConductorId { get; set; }

        [Range(1, 9999, ErrorMessage = "Ingrese la Placa")]
        public int VehiculoId { get; set; }
        public string? UrlPdf { get; set; }
        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
