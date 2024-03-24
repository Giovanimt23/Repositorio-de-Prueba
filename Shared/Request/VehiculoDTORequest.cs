using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Request
{
    public class VehiculoDTORequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el Color")]
        public string Color { get; set; } = default!;
        [Required(ErrorMessage ="Ingrese el Numero de Asiento")]
        public string NumeroDAsiento { get; set; } = default!;
        [Required(ErrorMessage ="Ingrese la Placa ssss")]
        public string Placa { get; set; } = default!;
        [Range(1,9999, ErrorMessage ="Selecione el Estado")]
        public bool Estado { get; set; }
        [Range(1, 9999, ErrorMessage = "Seleccionar Modelo")]
        public int ModeloId { get; set; }
        [Range(1, 9999, ErrorMessage = "Seleccionar Marca")]
        public int MarcaId { get; set; }
        [Range(1, 9999, ErrorMessage = "Seleccionar Tipo Vehiculo")]
        public int TipoVehiculoId { get; set; }
        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
