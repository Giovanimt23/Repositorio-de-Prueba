using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades.Infos
{
    public class VehiculoInfo
    {
        public int Id { get; set; }
        public string Color { get; set; } = default!;
        public string NumeroDAsiento { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public bool Estado { get; set; }
        public string Modelo { get; set; } = default!;
        public string Marca { get; set; } = default!;
        public string TipoVehiculo { get; set; } = default!;


        public string ForName => $"switch_{Id}";
    }
}
