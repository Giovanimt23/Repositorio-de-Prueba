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
    public class MarcaRepositorio : RepositorioBase<Marca>, IMarcaRepositorio
    {
        public MarcaRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

        public async Task<ICollection<MarcaInfo>> ListarAsync(int idtipovehiculo)
        {
            var marcas = Context.Set<Marca>()
                 .Where(p => p.Estado)
                .AsQueryable();

            if(idtipovehiculo != 0)
            {
                marcas = marcas.Where(p => p.TipovehiculoId == idtipovehiculo);
            }
                var list =marcas.Select(m => new MarcaInfo
                {
                    Id = m.Id,
                    Descripcion = m.Descripcion,
                    TipoVehiculo = m.TipoVehiculo.Descripcion,
                    UrlImagen = m.UrlImagen
                    
                })
                .AsNoTracking()
                .ToListAsync();

            return await list;
           /*return await Context.Set<Marca>()
                 .Where(p => p.Id)
                .AsNoTracking()
                .ToListAsync();*/
        }
    }
}
