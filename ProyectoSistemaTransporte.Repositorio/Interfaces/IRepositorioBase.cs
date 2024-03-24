using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.RespuestaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Interfacces
{
    public interface IRepositorioBase<T> where T : EntityBase
    {
        Task<ICollection<T>> ListarAsync();
        Task<ICollection<T>> ListarAsync(Expression<Func<T, bool>> predicate);
        Task<T?> BuscarAsync(int id);
        Task<BaseResponse> InsertarAsync(T entidad);
        Task<BaseResponse> ActualizarAsync();
        Task<BaseResponse> EliminarAsync(int id);
    }
}
