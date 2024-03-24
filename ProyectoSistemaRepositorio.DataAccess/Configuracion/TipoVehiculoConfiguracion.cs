using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoSistemaTransporte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemaTransporte.DataAccess.Configuracion
{
    public class TipoVehiculoConfiguracion : IEntityTypeConfiguration<TipoVehiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVehiculo> builder)
        {

            builder.Property(tp => tp.Id)
                .HasColumnName("IdTipoVehiculo");

            builder.Property(tp => tp.Descripcion)
                 .HasMaxLength(100);

            var lista = new List<TipoVehiculo>
            {
                new() {Id = 1, Descripcion = "Automovil",UsuarioCreacion ="administrador", UsuarioModificacion = "administrador"},
                new() {Id= 2, Descripcion = "MotoTaxi",UsuarioCreacion ="administrador", UsuarioModificacion = "administrador"}

            };

            builder.HasData(lista);
        }

       
    }
}
