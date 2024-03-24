using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class Vehiculo : EntityBase
    {
    
        public string Color { get; set; } = default!;
        public string NumeroDAsiento { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public Modelo Modelo { get; set; } = default!;
        public int ModeloId { get; set; }
        public Marca Marca { get; set; } = default!;
        public int MarcaId {get; set; }
        public TipoVehiculo TipoVehiculo { get; set; } = default!;
        public int TipoVehiculoId { get; set; }

 

    }
}
