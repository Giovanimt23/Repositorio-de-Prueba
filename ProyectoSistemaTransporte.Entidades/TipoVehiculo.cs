using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class TipoVehiculo : EntityBase
    {

        public string Descripcion { get; set; } = default!;
        public ICollection<Marca> Marcas { get; set; } = default!;
        public ICollection<Vehiculo> Vehiculos { get; set; } = default!;
    }
}
