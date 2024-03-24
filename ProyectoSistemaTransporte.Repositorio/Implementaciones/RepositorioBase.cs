using Microsoft.EntityFrameworkCore;
using ProyectoSistemaTransporte.DataAccess.Data;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.RespuestaApi;
using ProyectoSistemaTransporte.Repositorio.Interfacces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Implementaciones
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntityBase
    {
        protected readonly SistemaTrasnporteDbContext Context;

        protected RepositorioBase(SistemaTrasnporteDbContext context)
        {
            Context = context;
        }

        public async Task<BaseResponse> ActualizarAsync()
        {
            var response = new BaseResponse();

            try
            {
                await Context.SaveChangesAsync();
                response.MensajeError = "Se actualizo Correctamente";
                response.Exito = true;
            }

            catch(Exception e)
            {
                response.MensajeError = "Error al actualizar ";
                response.Exito = false;

            }
        

            return response;
        }

        public async Task<T?> BuscarAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        

        public async Task<BaseResponse> EliminarAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                var registrar = await BuscarAsync(id);
                response.MensajeError = "Se elimino Correctamente";
                response.Exito = true;
                if (registrar is not null)
                {
                    registrar.Estado = false;
                    await ActualizarAsync();
                }
                
            }
            catch(Exception e)
            {
                response.MensajeError = "Error al eliminar";
                response.Exito = false;
            }
            

            return response;
        }

        public async Task<BaseResponse> InsertarAsync(T entidad)

        {
            var response = new BaseResponse();

            try
            {
                await Context.Set<T>().AddAsync(entidad);
                await Context.SaveChangesAsync();
                response.MensajeError = "Se Inserto Correctamente";
                response.Exito = true;

            }
            catch (Exception e)
            {
                response.MensajeError = "Error al Insertar";
                response.Exito = false;
            }
;
            
            return response;
        }

       
       

        public async Task<ICollection<T>> ListarAsync()
        {
            return await Context.Set<T>()

            .Where(p => p.Estado)
            .AsNoTracking()
            .ToListAsync();
        }

        public  async Task<ICollection<T>> ListarAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>()
               .Where(predicate)
               .AsNoTracking()
               .ToListAsync();
        }

       
    }
}
