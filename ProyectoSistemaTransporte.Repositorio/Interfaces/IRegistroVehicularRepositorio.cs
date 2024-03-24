using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Interfacces
{
    public interface IRegistroVehicularRepositorio : IRepositorioBase<RegistroVehicular>
    {
        Task<ICollection<RegistroVehicularInfo>> ListarAsync(string? Placa, string? Dni);
    }
}
