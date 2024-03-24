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
    internal class RegistroVehicularConfiguracion : IEntityTypeConfiguration<RegistroVehicular>
    {
        public void Configure(EntityTypeBuilder<RegistroVehicular> builder)
        {
            builder.Property(rg => rg.Id)
             .HasColumnName("IdRegistroVehicular");

            builder.Property(rg => rg.FechaRegistro)
                .HasColumnType("DATE");

            builder.Property(rg => rg.FechaCaducidad)
                .HasColumnType("DATE");
           
        }
    }
}
