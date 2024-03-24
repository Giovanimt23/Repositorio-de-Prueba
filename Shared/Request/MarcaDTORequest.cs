using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoryectoSistemaTransporte.Shared.Request
{
    public class MarcaDTORequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el Nombre")]
        public string Descripcion { get; set; } = default!;

        public string? UrlImagen { get; set; }
        public string? Base64Imagen { get; set; }
        public string? NombreArchivo { get; set; }
        [Range(1, 9999, ErrorMessage = "Seleccionar Tipo Vehiculo")]
        public int TipovehiculoId { get; set; }

        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
