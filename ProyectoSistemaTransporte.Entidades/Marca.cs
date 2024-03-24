using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class Marca : EntityBase
    {
    
        public string Descripcion { get; set; } = default!;
        
        public string? UrlImagen { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; } = default!;
        public int TipovehiculoId { get; set; }
        public ICollection<Modelo> Modelos { get; set; } = default!;
        public ICollection<Vehiculo> Vehiculos { get; set; } = default!;
    }
}
