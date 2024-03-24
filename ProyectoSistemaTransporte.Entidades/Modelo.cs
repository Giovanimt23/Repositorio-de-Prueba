using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Entidades
{
    public class Modelo : EntityBase
    {

        public string Descripcion { get; set; } = default!;
        public Marca Marca { get; set; } = default!;
        public int MarcaId { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; } = default!;

    }
}
