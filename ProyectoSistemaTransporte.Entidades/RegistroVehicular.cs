using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class RegistroVehicular : EntityBase
    {

       
        public DateTime FechaRegistro { get; set; } = default!;

        public DateTime FechaCaducidad { get; set; } = default!;

        public Conductor Conductor { get; set; } = default!;
        public int ConductorId {  get; set; }

        public Vehiculo Vehiculo { get; set; } = default!;
        public int VehiculoId { get; set; }

        public string? UrlPdf { get; set; }
    }
}
