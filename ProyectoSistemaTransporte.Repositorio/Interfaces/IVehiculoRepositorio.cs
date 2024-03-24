using Microsoft.EntityFrameworkCore.Infrastructure;
using ProyectoSistemaTransporte.Entidades;
using ProyectoSistemaTransporte.Entidades.Infos;
using ProyectoSistemaTransporte.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.Repositorio.Interfacces
{
    public interface IVehiculoRepositorio : IRepositorioBase<Vehiculo>
    {
        Task<ICollection<VehiculoInfo>> ListarAsync(string? Placa);
    }
}
