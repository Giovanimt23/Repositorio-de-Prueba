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
    public class ConductorConfiguracion : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {

            builder.Property(C => C.Id)
                .HasColumnName("IdConductor");

            builder.Property(c => c.Nombre)
                .HasMaxLength(100);

            builder.Property(c => c.Apellido)
               .HasMaxLength(100);

            builder.Property(c => c.Dni)
               .HasMaxLength(100);

            builder.Property(c => c.Edad)
               .HasMaxLength(100);

            builder.Property(c => c.Telefono)
               .HasMaxLength(100);

            builder.Property(c => c.Direccion)
               .HasMaxLength(100);

        }

        
    }
}
