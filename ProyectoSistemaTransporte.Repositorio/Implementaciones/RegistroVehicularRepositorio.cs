using Microsoft.EntityFrameworkCore;
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
    public class RegistroVehicularRepositorio : RepositorioBase<RegistroVehicular>, IRegistroVehicularRepositorio
    {
        public RegistroVehicularRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

        public async Task<ICollection<RegistroVehicularInfo>> ListarAsync(string? Placa, string? Dni)
        {
            var registrovehicular = Context.Set<RegistroVehicular>()
              .Where(p => p.Estado)
              .AsQueryable();

                    if (!string.IsNullOrEmpty(Dni))
                    {
                        registrovehicular = registrovehicular.Where(p => p.Conductor.Dni == Dni);
                    }

                    if (!string.IsNullOrEmpty(Placa))
                     {
                        registrovehicular = registrovehicular.Where(p => p.Vehiculo.Placa == Placa);
                     }

                  

                    return await registrovehicular
                    .Select(x => new RegistroVehicularInfo
                    {
                    Id = x.Id,
                    Conductor = x.Conductor.Nombre,
                    ConductorApellido = x.Conductor.Apellido,
                    ConductorDni = x.Conductor.Dni,
                    VehiculiPlaca = x.Vehiculo.Placa,
                    TipoVehiculiNombre = x.Vehiculo.TipoVehiculo.Descripcion,
                    MarcaNombre = x.Vehiculo.Marca.Descripcion,
                    ModeloNombre = x.Vehiculo.Modelo.Descripcion,
                    UrlPdf = x.UrlPdf,
                    FechaRegistro = x.FechaRegistro,
                    FechaCaducidad = x.FechaCaducidad


                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
