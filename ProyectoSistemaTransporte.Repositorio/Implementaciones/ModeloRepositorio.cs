using Dapper;
using Microsoft.EntityFrameworkCore;
using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Implementaciones
{
    public class ModeloRepositorio : RepositorioBase<Modelo>, IModeloRepositorio
    {
        public ModeloRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

        public async Task<ICollection<ModeloInfo>> ListarAsync(int idmarca)
        {
            var marcas = Context.Set<Modelo>()
                 .Where(p => p.Estado)
                .AsQueryable();

            if (idmarca != 0)
            {
                marcas = marcas.Where(p => p.MarcaId == idmarca);
            }
            var list = marcas.Select(m => new ModeloInfo
            {
                Id = m.Id,
                Descripcion = m.Descripcion,
            })
            .AsNoTracking()
            .ToListAsync();

            return await list;
            /*return await Context.Set<Marca>()
                  .Where(p => p.Id)
                 .AsNoTracking()
                 .ToListAsync();*/
        }

        public async Task<ICollection<ModeloInfo>> ListarAsync(string descripcion)
        {
            string? Parametromodelo;
            try
            {
                if (descripcion == null)
                {
                    Parametromodelo = string.Empty;
                }
                else
                {
                    Parametromodelo = descripcion;
                }

               await using var querySP = await Context.Database.GetDbConnection()
               .QueryMultipleAsync(
               sql: "sp_listarmodelo",
               commandType: CommandType.StoredProcedure,
               param: new
               {
                   Parametromodelo
               });

                var listaModelos = querySP.Read<ModeloInfo>().ToList();

                return listaModelos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
