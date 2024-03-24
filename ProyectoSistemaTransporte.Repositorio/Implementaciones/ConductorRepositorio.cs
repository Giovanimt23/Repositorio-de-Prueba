using Microsoft.EntityFrameworkCore;
using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Implementaciones
{
    public class ConductorRepositorio : RepositorioBase<Conductor>, IConductorRepositorio
    {
        public ConductorRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

        public async Task<ICollection<ConductorInfo>> ListarAsync(string? Apellido, string? Dni)
        {
            var conductor = Context.Set<Conductor>()
              .Where(p => p.Estado)
              .AsQueryable();

            if (!string.IsNullOrEmpty(Apellido))
            {
                conductor = conductor.Where(p => p.Apellido == Apellido);
            }

            if (!string.IsNullOrEmpty(Dni))
            {
                conductor = conductor.Where(p => p.Dni == Dni);
            }



            return await conductor
            .Select(x => new ConductorInfo
            {
               Id = x.Id,
               Nombre = x.Nombre,
               Apellido = x.Apellido,
               Dni = x.Dni,
               Edad = x.Edad,
               Direccion = x.Direccion,
               Telefono = x.Telefono,



            })
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
