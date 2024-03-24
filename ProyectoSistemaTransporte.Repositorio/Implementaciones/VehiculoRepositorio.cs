using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Implementaciones
{
    public class VehiculoRepositorio : RepositorioBase<Vehiculo>, IVehiculoRepositorio
    {
        public VehiculoRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

       public async Task<ICollection<VehiculoInfo>> ListarAsync(string? Placa)
        {
            var vehiculo = Context.Set<Vehiculo>()
                 .Where(p => p.Estado);

                 if (!string.IsNullOrEmpty(Placa))
                    {
                          vehiculo = vehiculo.Where(p => p.Placa == Placa);
                    }


                 return await vehiculo
                .Select(x => new VehiculoInfo
                {
                    Id = x.Id,
                    Color = x.Color,
                    NumeroDAsiento = x.NumeroDAsiento,
                    Placa = x.Placa,
                    Marca = x.Marca.Descripcion,
                    Modelo = x.Modelo.Descripcion,
                    TipoVehiculo = x.TipoVehiculo.Descripcion
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
