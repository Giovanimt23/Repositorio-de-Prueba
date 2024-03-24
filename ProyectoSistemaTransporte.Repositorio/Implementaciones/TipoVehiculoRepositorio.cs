using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System.Globalization;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProyectoSistemaTransporte.Repositorio.Implementaciones
{
    public class TipoVehiculoRepositorio : RepositorioBase<TipoVehiculo>, ITipoVehiculoRepositorio
    {
        public TipoVehiculoRepositorio(SistemaTrasnporteDbContext context) : base(context)
        {
        }

        public async Task<ICollection<TipoVehiculoInfo>> ListarAsync(string? Descripcion)
        {
            string? ParamteroDescripcion;

            if (Descripcion == null)
            {
                ParamteroDescripcion = string.Empty;
            }
            else
            {
                ParamteroDescripcion = Descripcion;
            }
          
            await using var simplequery = await Context.Database.GetDbConnection()
                .QueryMultipleAsync(
                  sql: "sp_listartipovehiculo",
                    
                  commandType: CommandType.StoredProcedure,
                  param: new
                  {
                      ParamteroDescripcion

                  });
         
                var listatipovehiculo = simplequery.Read<TipoVehiculoInfo>().ToList();

                return listatipovehiculo;
          
        }
    }
}
