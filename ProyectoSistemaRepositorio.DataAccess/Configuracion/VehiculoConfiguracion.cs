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
    public class VehiculoConfiguracion : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.Property(v => v.Id)
             .HasColumnName("IdVehiculo");

            builder.Property(v => v.Color)
                .HasMaxLength(100);

            builder.Property(v => v.NumeroDAsiento)
                .HasMaxLength(100);

            builder.Property(v => v.Placa)
                .HasMaxLength(100);

        }
    }
}
