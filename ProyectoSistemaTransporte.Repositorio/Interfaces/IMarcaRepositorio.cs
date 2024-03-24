using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Interfacces
{
    public interface IMarcaRepositorio : IRepositorioBase<Marca>
    {

       Task<ICollection<MarcaInfo>> ListarAsync(int idtipovehiculo);
    }
}
