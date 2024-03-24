using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.DataAccess
{
    public class IdentityUsuarioTransporte : IdentityUser
    {
        [StringLength(200)]
        public string NombreCompleto { get; set; } = default!;

        [Column(TypeName = "DATE")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(250)]
        public string? Direccion { get; set; }

        [StringLength(30)]
        public string? Telefono { get; set; }

        [StringLength(250)]
        public string? PreguntaSecreta { get; set; }

        [StringLength(250)]
        public string? RespuestaSecreta { get; set; }
    }
}
