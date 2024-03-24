using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Interfacces
{
    public interface IModeloRepositorio : IRepositorioBase<Modelo>
    {
        Task<ICollection<ModeloInfo>> ListarAsync(int idmarca);

        Task<ICollection<ModeloInfo>> ListarAsync(string descripcion);
    }
}
