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
    public class ModeloConfiguracion : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.Property(mo => mo.Id)
                .HasColumnName("IdModelo");

            builder.Property(mo => mo.Descripcion)
                .HasMaxLength(100);

            var lista = new List<Modelo>
            {
                new() { Id = 1,Descripcion = "Corrola",UsuarioCreacion ="administrador", UsuarioModificacion = "administrador",MarcaId=1},
                new() { Id = 2,Descripcion = "Sportage",UsuarioCreacion ="administrador", UsuarioModificacion = "administrador",MarcaId=1},
                new() { Id = 3,Descripcion = "Santa Fe",UsuarioCreacion ="administrador", UsuarioModificacion = "administrador", MarcaId=1},
            };
            builder.HasData(lista);
        }
    }
}
